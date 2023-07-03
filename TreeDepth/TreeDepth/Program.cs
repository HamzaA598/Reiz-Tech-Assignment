using System;

namespace MyApp
{
    internal class Program
    {
        public class Branch
        {
            public List<Branch> branches;
        }


        // generates a random prufer list of n-2 elements
        static List<int> GeneratePruferSequence(int n)
        {
            Random rand = new Random();
            int m = n - 2;
            List<int> prufer = new List<int>();

            // Loop to Generate Random list
            for (int i = 0; i < m; i++)
                prufer.Add(rand.Next(m + 1) + 1);

            return prufer;
        }

        static void AddEdge(ref List<List<int>> adj, int u, int v)
        {
            adj[u].Add(v);
            adj[v].Add(u);
        }

        // given a prufer sequence, constructs the adjacency list of the tree
        static List<List<int>> ConstructAdjacencyList(ref List<int> prufer)
        {
            int m = prufer.Count;
            int n = m + 2;
            List<List<int>> adj = new List<List<int>>();
            for(int i = 0; i < n+2; i++)
                adj.Add(new List<int>());

            // Declare and initialize the list of vertices
            List<int> vertexSet = new List<int>();
            for (int i = 0; i < n; i++)
                vertexSet.Add(0);

            // Number of occurrences of vertex in code
            for (int i = 0; i < n - 2; i++)
                vertexSet[prufer[i] - 1] += 1;

            Console.WriteLine("The random-generated tree edges are: ");

            int j, u = -1, v = -1;

            // Find the smallest label not present in prufer list.
            for (int i = 0; i < n - 2; i++)
            {
                for (j = 0; j < n; j++)
                {

                    // If j + 1 is not present in prufer set
                    if (vertexSet[j] == 0)
                    {

                        // Remove from Prufer set and print pair.
                        vertexSet[j] = -1;
                        u = j + 1;
                        v = prufer[i];
                        Console.WriteLine(u + " " + v);

                        // add the edge to the adjacency list
                        AddEdge(ref adj, u, v);

                        vertexSet[prufer[i] - 1]--;

                        break;
                    }
                }
            }

            j = 0;
            // For the last element
            for (int i = 0; i < n; i++)
            {
                if (vertexSet[i] == 0 && j == 0)
                {
                    Console.Write((i + 1) + " ");
                    u = i + 1;
                    j++;
                }
                else if (vertexSet[i] == 0 && j == 1)
                {
                    Console.WriteLine((i + 1));
                    v = i + 1;
                }
            }

            AddEdge(ref adj, u, v);

            return adj;
        }

        // convert the adjacency list to the branch class
        static Branch BuildTree(ref List<List<int>> adj, int current, int parent)
        {
            Branch subtree = new Branch();
            foreach(int child in adj[current])
            {
                if (child != parent)
                {
                    if (subtree.branches == null)
                        subtree.branches = new List<Branch>();
                    subtree.branches.Add(BuildTree(ref adj, child, current));
                }
            }
            return subtree;
        }

        static Branch GenerateRandomTree(int n)
        {
            List<int> prufer = GeneratePruferSequence(n);
            List<List<int>> adj = ConstructAdjacencyList(ref prufer);
            Branch tree = BuildTree(ref adj, 1, -1);
            return tree;
        }
        
        // given a tree, calculates its depth
        public static int TreeDepth(Branch current)
        {
            if (current.branches == null)
                return 1;

            int depth = 0;

            foreach (Branch branch in current.branches)
                depth = Math.Max(depth, TreeDepth(branch));

            return 1 + depth;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the number of vertices of the tree: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Branch tree = GenerateRandomTree(n);
            int depth = TreeDepth(tree);
            Console.WriteLine("The depth of the random-generated tree is: " + depth);
        }
    }
}