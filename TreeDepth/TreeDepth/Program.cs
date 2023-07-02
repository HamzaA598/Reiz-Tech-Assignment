using System;

namespace MyApp
{
    // should the branch class be outside the Program class?
    // should the inner branches list be public or returned using a getter?

    internal class Program
    {
        public class Branch
        {
            public List<Branch> branches;
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
        static void Main(string[] args)
        {
            Branch tree = new Branch();
            tree.branches = new List<Branch>();
            tree.branches.Add(new Branch());
            tree.branches.Add(new Branch());
            tree.branches.Add(new Branch());
            tree.branches.Add(new Branch());
            tree.branches[0].branches = new List<Branch>();
            tree.branches[0].branches.Add(new Branch());
            Console.WriteLine(TreeDepth(tree));
        }
    }
}