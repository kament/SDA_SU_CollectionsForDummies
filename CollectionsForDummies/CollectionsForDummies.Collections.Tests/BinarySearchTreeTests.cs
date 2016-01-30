using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsForDummies.Collections.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void ShouldCreateBinarySearchTreeWhithoutGivingRootNode()
        {
            var binarySearchTree = new BinarySearchTree<int>();

            Assert.AreEqual(null, binarySearchTree.Root);
        }

        [TestMethod]
        public void ShouldCreateBinarySearchTreeWithGivenRoot()
        {
            var rootNode = new BinaryTreeNode<int>(null);

            var binarySearchTree = new BinarySearchTree<int>(rootNode);

            Assert.AreEqual(rootNode, binarySearchTree.Root);
        }

        [TestMethod]
        public void ShouldCreateBinarySearchTreeWithGivenRootAndTreeWalk()
        {
            var binarySearchTree = new BinarySearchTree<int>(null, TreeWalk.PreOrder);

            Assert.AreEqual(TreeWalk.PreOrder, binarySearchTree.TreeWalk);
        }

        [TestMethod]
        public void ShouldAddTreeNodeAsRootWhenTreeIsCreatedWithoutRootNode()
        {
            var node = new BinaryTreeNode<int>(null, 15);

            var binaryTree = new BinarySearchTree<int>();

            binaryTree.Add(node);

            Assert.AreEqual(node, binaryTree.Root);
        }

        [TestMethod]
        public void ShouldAddAfterTheRootNodeAsLeftNode()
        {
            var root = new BinaryTreeNode<int>(null, 15);

            var binaryTree = new BinarySearchTree<int>(root);

            var nodeToAdd = new BinaryTreeNode<int>(null, 10);
            binaryTree.Add(nodeToAdd);

            Assert.AreEqual(nodeToAdd, root.LeftChild, "Should be added as left node!");
            Assert.AreEqual(root, nodeToAdd.Parent, "Parent node should be the root node, after adding!");
        }

        [TestMethod]
        public void ShouldAddAfterTheRootNodeAsRightNode()
        {
            var root = new BinaryTreeNode<int>(null, 15);

            var binaryTree = new BinarySearchTree<int>(root);

            var nodeToAdd = new BinaryTreeNode<int>(null, 17);
            binaryTree.Add(nodeToAdd);

            Assert.AreEqual(nodeToAdd, root.RightChild, "Should be added as right node!");
            Assert.AreEqual(root, nodeToAdd.Parent, "Parent node should be the root node, after adding!");
        }

        [TestMethod]
        public void ShouldCorrectlyAddItemsInCorrectOrder1()
        {
            var binaryTree = new BinarySearchTree<int>();

            for (int i = 0; i < 15; i++)
            {
                binaryTree.Add(new BinaryTreeNode<int>(null, i));
            }

            var nodeToCheck = binaryTree.Root;
            var counter = 0;

            while (nodeToCheck != null)
            {
                Assert.AreEqual(counter++, nodeToCheck.Value);

                nodeToCheck = nodeToCheck.RightChild;
            }

            Assert.AreEqual(15, counter, "The tree should have 15 elements, and its height must be 15. All items should be right.");
        }

        [TestMethod]
        public void ShouldCorrectlyAddItemsInCorrectOrder2()
        {
            var binaryTree = new BinarySearchTree<int>();

            for (int i = 14; i >= 0; i--)
            {
                binaryTree.Add(new BinaryTreeNode<int>(null, i));
            }

            var nodeToCheck = binaryTree.Root;
            var counter = 14;

            while (nodeToCheck != null)
            {
                Assert.AreEqual(counter--, nodeToCheck.Value);

                nodeToCheck = nodeToCheck.LeftChild;
            }

            Assert.AreEqual(-1, counter, "The tree should have 14 elements, and its height must be 14. All items should be left.");
        }

        [TestMethod]
        public void ShouldCorrectlyAddItemsInCorrectOrder3()
        {
            var binaryTree = new BinarySearchTree<int>();

            binaryTree.Add(new BinaryTreeNode<int>(null, 27));
            binaryTree.Add(new BinaryTreeNode<int>(null, 10));
            binaryTree.Add(new BinaryTreeNode<int>(null, 40));
            binaryTree.Add(new BinaryTreeNode<int>(null, 30));
            binaryTree.Add(new BinaryTreeNode<int>(null, 10));
            binaryTree.Add(new BinaryTreeNode<int>(null, 15));
            binaryTree.Add(new BinaryTreeNode<int>(null, 55));
            binaryTree.Add(new BinaryTreeNode<int>(null, 8));
            binaryTree.Add(new BinaryTreeNode<int>(null, 9));
            binaryTree.Add(new BinaryTreeNode<int>(null, 3));
            binaryTree.Add(new BinaryTreeNode<int>(null, -21));
            binaryTree.Add(new BinaryTreeNode<int>(null, 100));
            binaryTree.Add(new BinaryTreeNode<int>(null, 7));

            Assert.AreEqual(27, binaryTree.Root.Value);
            Assert.AreEqual(40, binaryTree.Root.RightChild.Value);
            Assert.AreEqual(55, binaryTree.Root.RightChild.RightChild.Value);
            Assert.AreEqual(30, binaryTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(100, binaryTree.Root.RightChild.RightChild.RightChild.Value);
            Assert.AreEqual(10, binaryTree.Root.LeftChild.Value);
            Assert.AreEqual(15, binaryTree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(8, binaryTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(9, binaryTree.Root.LeftChild.LeftChild.RightChild.Value);
            Assert.AreEqual(3, binaryTree.Root.LeftChild.LeftChild.LeftChild.Value);
            Assert.AreEqual(-21, binaryTree.Root.LeftChild.LeftChild.LeftChild.LeftChild.Value);
            Assert.AreEqual(7, binaryTree.Root.LeftChild.LeftChild.LeftChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldCorrectlyAddItemsInCorrectOrder4()
        {
            var binaryTree = new BinarySearchTree<int>();

            binaryTree.Add(new BinaryTreeNode<int>(null, 20));
            binaryTree.Add(new BinaryTreeNode<int>(null, 5));
            binaryTree.Add(new BinaryTreeNode<int>(null, 6));
            binaryTree.Add(new BinaryTreeNode<int>(null, 30));
            binaryTree.Add(new BinaryTreeNode<int>(null, 28));
            binaryTree.Add(new BinaryTreeNode<int>(null, 21));
            binaryTree.Add(new BinaryTreeNode<int>(null, 50));
            binaryTree.Add(new BinaryTreeNode<int>(null, 29));

            Assert.AreEqual(20, binaryTree.Root.Value);
            Assert.AreEqual(5, binaryTree.Root.LeftChild.Value);
            Assert.AreEqual(6, binaryTree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(30, binaryTree.Root.RightChild.Value);
            Assert.AreEqual(28, binaryTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(21, binaryTree.Root.RightChild.LeftChild.LeftChild.Value);
            Assert.AreEqual(50, binaryTree.Root.RightChild.RightChild.Value);
            Assert.AreEqual(29, binaryTree.Root.RightChild.LeftChild.RightChild.Value);

            Assert.AreEqual(8, binaryTree.Count, "Items count is should be 8");
        }
        
        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems7()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(7);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems10()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(10);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems40()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(40);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems100()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(100);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems500()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(500);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems1000()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(1000);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems10000()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(10000);
        }

        private void ShouldUpdateTheCounterWhenAddNewItems(int itemsCount)
        {
            var binaryTree = new BinarySearchTree<int>();

            var addedNumbers = new HashSet<int>();
            var random = new Random();

            for (int i = 0; i < itemsCount; i++)
            {
                var numberToAdd = random.Next();

                while (addedNumbers.Contains(numberToAdd))
                {
                    numberToAdd = random.Next();
                }

                binaryTree.Add(new BinaryTreeNode<int>(null, numberToAdd));

                addedNumbers.Add(numberToAdd);
            }

            Assert.AreEqual(itemsCount, binaryTree.Count);
        }
    }
}
