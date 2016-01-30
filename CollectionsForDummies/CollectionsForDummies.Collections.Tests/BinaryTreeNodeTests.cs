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
        public void ShoulCorrectlyAddLeftNode()
        {
            var root = new BinaryTreeNode<int>(null);

            var leftChild = new BinaryTreeNode<int>(root);
            root.LeftChild = leftChild;

            Assert.AreEqual(leftChild.Parent, root);
            Assert.AreEqual(root.LeftChild, leftChild);
            Assert.IsTrue(leftChild.IsLeftChild);
        }

        [TestMethod]
        public void ShouldCorrectlyAddRightNode()
        {
            var root = new BinaryTreeNode<int>(null);

            var rightChild = new BinaryTreeNode<int>(root);
            root.RightChild = rightChild;

            Assert.AreEqual(rightChild.Parent, root);
            Assert.AreEqual(root.RightChild, rightChild);
            Assert.IsTrue(rightChild.IsRightChild);
        }
    }
}
