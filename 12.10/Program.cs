using System;
using System.IO;

namespace BinaryTreeApplication
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public TreeNode Root;

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            Root = InsertRec(Root, value);
        }

        private TreeNode InsertRec(TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }

            if (value < root.Value)
            {
                root.Left = InsertRec(root.Left, value);
            }
            else if (value > root.Value)
            {
                root.Right = InsertRec(root.Right, value);
            }

            return root;
        }

        public void RemoveNodesInRange(int min, int max)
        {
            Root = RemoveNodesInRangeRec(Root, min, max);
        }

        private TreeNode RemoveNodesInRangeRec(TreeNode root, int min, int max)
        {
            if (root == null)
            {
                return null;
            }

            root.Left = RemoveNodesInRangeRec(root.Left, min, max);
            root.Right = RemoveNodesInRangeRec(root.Right, min, max);

            if (root.Value >= min && root.Value <= max)
            {
                root = RemoveNode(root);
            }

            return root;
        }

        private TreeNode RemoveNode(TreeNode node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            else
            {
                node.Value = FindMin(node.Right).Value;
                node.Right = RemoveMin(node.Right);
                return node;
            }
        }

        private TreeNode FindMin(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        private TreeNode RemoveMin(TreeNode node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            node.Left = RemoveMin(node.Left);
            return node;
        }

        public void PrintTree(TreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " ");
                PrintTree(node.Left);
                PrintTree(node.Right);
            }
        }

        public void PrintTreeBeforeAndAfterRemoval()
        {
            Console.WriteLine("Tree before removing nodes:");
            PrintTree(Root);
            Console.WriteLine();

            int sum = 0, count = 0;
            CalculateSumAndCount(Root, ref sum, ref count);
            int average = sum / count;

            RemoveNodesInRange(int.MinValue, average);

            Console.WriteLine("\nTree after removing nodes:");
            PrintTree(Root);
            Console.WriteLine();
        }

        private void CalculateSumAndCount(TreeNode node, ref int sum, ref int count)
        {
            if (node != null)
            {
                sum += node.Value;
                count++;
                CalculateSumAndCount(node.Left, ref sum, ref count);
                CalculateSumAndCount(node.Right, ref sum, ref count);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int value = int.Parse(line);
                    tree.Insert(value);
                }
            }

            tree.PrintTreeBeforeAndAfterRemoval();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
