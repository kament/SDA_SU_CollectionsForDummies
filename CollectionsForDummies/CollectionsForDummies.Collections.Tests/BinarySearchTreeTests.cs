using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ShouldUpdateTheCounterWhenAddNewItems()
        {
            var binaryTree = new BinarySearchTree<int>();

            binaryTree.Add(new BinaryTreeNode<int>(null, 1));
            binaryTree.Add(new BinaryTreeNode<int>(null, 2));
            binaryTree.Add(new BinaryTreeNode<int>(null, 3));
            binaryTree.Add(new BinaryTreeNode<int>(null, 4));
            binaryTree.Add(new BinaryTreeNode<int>(null, 5));
            binaryTree.Add(new BinaryTreeNode<int>(null, 6));
            binaryTree.Add(new BinaryTreeNode<int>(null, 7));

            Assert.AreEqual(7, binaryTree.Count);
        }

        [TestMethod]
        public void ShouldCorrectlyAddItemsInCorrectOrder()
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

            Assert.AreEqual(8, binaryTree.Count);
        }
    }
}
