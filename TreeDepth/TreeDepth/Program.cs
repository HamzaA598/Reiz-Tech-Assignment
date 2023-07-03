using System;

namespace MyApp
{
    // should the branch class be outside the Program class?
    // should the inner branches list be public or returned using a getter?
    // where should the TreeDepth function be? inside the branch class or inside the program class?
    // better design of the adjacency list construction in construct adjacency list function

    internal class Program
    {
        public class Branch
        {
            public List<Branch> branches;
        }

        public static Branch CreateTree()
        {
            Branch branch = new Branch();

            return new Branch();
        }

        public static int TreeDepth(Branch current)
        {
            if (current.branches == null)
                return 1;

            int depth = 0;

            foreach (Branch branch in current.branches)
                depth = Math.Max(depth, TreeDepth(branch));

            return 1 + depth;
        }

        static List<int> GeneratePruferSequence(int n)
        {
            Random rand = new Random();
            int m = n - 2;
            List<int> prufer = new List<int>();

            // Loop to Generate Random Array
            for (int i = 0; i < m; i++)
                prufer.Add(rand.Next(m + 1) + 1);

            return prufer;
        }

        static List<List<int>> ConstructAdjacencyList(List<int> prufer)
        {
            int m = prufer.Count;
            int n = m + 2;
            List<List<int>> adj = new List<List<int>>();
            for(int i = 0; i < n+2; i++)
                adj.Add(new List<int>());

            List<int> vertex_set = new List<int>();


            // Initialize the array of vertices
            for (int i = 0; i < n; i++)
                vertex_set.Add(0);

            // Number of occurrences of vertex in code
            for (int i = 0; i < n - 2; i++)
                vertex_set[prufer[i] - 1] += 1;

            Console.WriteLine("The random-generated tree edges are: ");

            int j = 0;

            // Find the smallest label not present in
            // prufer[].
            for (int i = 0; i < n - 2; i++)
            {
                for (j = 0; j < n; j++)
                {

                    // If j + 1 is not present in prufer set
                    if (vertex_set[j] == 0)
                    {

                        // Remove from Prufer set and print
                        // pair.
                        vertex_set[j] = -1;
                        Console.WriteLine((j + 1) + " " + prufer[i]);
                        adj[j + 1].Add(prufer[i]);
                        adj[prufer[i]].Add(j + 1);

                        vertex_set[prufer[i] - 1]--;

                        break;
                    }
                }
            }

            j = 0;

            int u = -1, v = -1;
            // For the last element
            for (int i = 0; i < n; i++)
            {
                if (vertex_set[i] == 0 && j == 0)
                {
                    Console.Write((i + 1) + " ");
                    u = i + 1;
                    j++;
                }
                else if (vertex_set[i] == 0 && j == 1)
                {
                    Console.WriteLine((i + 1));
                    v = i + 1;
                }
            }

            adj[u].Add(v);
            adj[v].Add(u);

            return adj;
        }

        // convert the adjacency list to the branch class
        static Branch BuildTree(List<List<int>> adj, int current, int parent)
        {
            Branch subtree = new Branch();
            foreach(int child in adj[current])
            {
                if (child != parent)
                {
                    if (subtree.branches == null)
                        subtree.branches = new List<Branch>();
                    subtree.branches.Add(BuildTree(adj, child, current));
                }
            }
            return subtree;
        }

        static Branch GenerateRandomTree(int n)
        {
            List<int> prufer = GeneratePruferSequence(n);
            List<List<int>> adj = ConstructAdjacencyList(prufer);
            Branch tree = BuildTree(adj, 1, -1);
            return tree;
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