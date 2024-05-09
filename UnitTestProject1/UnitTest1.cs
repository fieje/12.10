using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeApplication;
using System;
using System.IO;

namespace BinaryTreeUnitTest
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TestInsert()
        {
            BinaryTree tree = new BinaryTree();
            int[] values = { 5, 3, 8, 1, 4, 6, 9 };

            foreach (int value in values)
            {
                tree.Insert(value);
            }

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(5, tree.Root.Value);
            Assert.AreEqual(3, tree.Root.Left.Value);
            Assert.AreEqual(8, tree.Root.Right.Value);
            Assert.AreEqual(1, tree.Root.Left.Left.Value);
            Assert.AreEqual(4, tree.Root.Left.Right.Value);
            Assert.AreEqual(6, tree.Root.Right.Left.Value);
            Assert.AreEqual(9, tree.Root.Right.Right.Value);
        }

        [TestMethod]
        public void TestRemoveNodesInRange()
        {
            BinaryTree tree = new BinaryTree();
            int[] values = { 5, 3, 8, 1, 4, 6, 9 };

            foreach (int value in values)
            {
                tree.Insert(value);
            }

            tree.RemoveNodesInRange(2, 7);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(8, tree.Root.Value);
            Assert.AreEqual(1, tree.Root.Left.Value);
            Assert.AreEqual(9, tree.Root.Right.Value);
            Assert.IsNull(tree.Root.Left.Left);
            Assert.IsNull(tree.Root.Left.Right);
            Assert.IsNull(tree.Root.Right.Left);
            Assert.IsNull(tree.Root.Right.Right);
        }

        [TestMethod]
        public void TestPrintTree()
        {
            BinaryTree tree = new BinaryTree();
            int[] values = { 5, 3, 8, 1, 4, 6, 9 };
            string expectedOutput = "5 3 1 4 8 6 9 ";

            foreach (int value in values)
            {
                tree.Insert(value);
            }

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                tree.PrintTree(tree.Root);

                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
