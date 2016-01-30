﻿using System;
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
        public void ShouldUpdateTheCounterWhenAddForFirstTime()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new[] { 2 }, 1);
        }

        [TestMethod]
        public void CountShouldBeZeroWheAddNoItems()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new int[] { }, 0);
        }

        [TestMethod]
        public void ShouldNotUpdateCounterWhenAddAlwreadyExistingItem()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new int[] { 5, 2, 9, 5, 5, 5 }, 3);
        }

        [TestMethod]
        public void ShouldUpdateCounterWhenRemoveItem()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new int[] { 5, 2, 9 }, 3);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItems500()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new[] { 2 }, 500);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddInTheLeftSubtree()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new[] { 2, -10 }, 2);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddInTheRightSubtree()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new[] { 2, 15 }, 2);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItemsWith12Items()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new[] { 15, 6, 7, 2, 4, 18, -56, 22, 55, -37, 12, 16 }, 12);
        }

        [TestMethod]
        public void ShouldUpdateTheCounterWhenAddItemsWith13Items()
        {
            this.ShouldUpdateTheCounterWhenAddNewItems(new[] { 10, -100, 144, 27, 88, 56, 22, 9, -6, 14, 66666666, 10000000, 111 }, 13);
        }

        private void ShouldUpdateTheCounterWhenAddNewItems(int[] items, int itemsCount)
        {
            Assert.AreEqual(itemsCount, this.CreateTree(items).Count);
        }

        private BinarySearchTree<int> CreateTree(int[] items)
        {
            var binaryTree = new BinarySearchTree<int>();

            for (int i = 0; i < items.Length; i++)
            {
                binaryTree.Add(new BinaryTreeNode<int>(null, items[i]));
            }

            return binaryTree;
        }
    }
}
