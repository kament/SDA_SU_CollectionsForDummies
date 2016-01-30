using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsForDummies.Collections.Tests
{
    [TestClass]
    public class BinaryTreeNodeTests
    {
        [TestMethod]
        public void ShouldCorrectlyCreateNode()
        {
            var root = new BinaryTreeNode<int>(null);

            root.Value = 10;

            Assert.AreEqual(10, root.Value);
        }

        [TestMethod]
        public void ShouldCorrectlyCreateRootNode()
        {
            var root = new BinaryTreeNode<int>(null);

            Assert.AreEqual(null, root.Parent);
            Assert.IsTrue(root.IsRoot);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenGetIsLeftChildOnRootNode()
        {
            var root = new BinaryTreeNode<int>(null);

            Assert.IsFalse(root.IsLeftChild);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenGetIsRightChildOnRootNode()
        {
            var root = new BinaryTreeNode<int>(null);

            Assert.IsFalse(root.IsRightChild);
        }

        [TestMethod]
        public void ShouldNotHaveChildNodesInitialy()
        {
            var root = new BinaryTreeNode<int>(null);

            Assert.IsFalse(root.HasLeftChild);
            Assert.IsFalse(root.HasRightChild);
        }

        [TestMethod]
        public void ShoulCorrectlyAddLeftChild()
        {
            var root = new BinaryTreeNode<int>(null);

            var leftChild = new BinaryTreeNode<int>(root);
            root.LeftChild = leftChild;

            Assert.AreEqual(leftChild.Parent, root);
            Assert.AreEqual(root.LeftChild, leftChild);
            Assert.IsTrue(leftChild.IsLeftChild);
        }

        [TestMethod]
        public void ShouldCorrectlyAddRightChild()
        {
            var root = new BinaryTreeNode<int>(null);

            var rightChild = new BinaryTreeNode<int>(root);
            root.RightChild = rightChild;

            Assert.AreEqual(rightChild.Parent, root);
            Assert.AreEqual(root.RightChild, rightChild);
            Assert.IsTrue(rightChild.IsRightChild);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemIsLeftChild()
        {
            var root = new BinaryTreeNode<int>(null, 10);

            var leftChild = new BinaryTreeNode<int>(root, 14);

            root.LeftChild = leftChild;

            Assert.IsTrue(leftChild.IsLeftChild);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenItemIsNotLeftChild()
        {
            var root = new BinaryTreeNode<int>(null, 10);

            var rightChild = new BinaryTreeNode<int>(root, 1);

            root.RightChild = rightChild;

            Assert.IsFalse(rightChild.IsLeftChild);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemIsRightChild()
        {
            var root = new BinaryTreeNode<int>(null, 10);

            var rightChild = new BinaryTreeNode<int>(root, 14);

            root.RightChild = rightChild;

            Assert.IsTrue(rightChild.IsRightChild);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenItemIsNotRightChild()
        {
            var root = new BinaryTreeNode<int>(null, 10);

            var leftChild = new BinaryTreeNode<int>(root, 1);

            root.LeftChild = leftChild;

            Assert.IsFalse(leftChild.IsRightChild);
        }
    }
}
