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

            Assert.AreEqual(null, root.ParentNode);
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

            Assert.IsFalse(root.HasLeftNode);
            Assert.IsFalse(root.HasRightNode);
        }

        [TestMethod]
        public void ShoulCorrectlyAddLeftNode()
        {
            var root = new BinaryTreeNode<int>(null);

            var leftChild = new BinaryTreeNode<int>(root);
            root.LeftNode = leftChild;

            Assert.AreEqual(leftChild.ParentNode, root);
            Assert.AreEqual(root.LeftNode, leftChild);
            Assert.IsTrue(leftChild.IsLeftChild);
        }

        [TestMethod]
        public void ShouldCorrectlyAddRightNode()
        {
            var root = new BinaryTreeNode<int>(null);

            var rightChild = new BinaryTreeNode<int>(root);
            root.RightNode = rightChild;

            Assert.AreEqual(rightChild.ParentNode, root);
            Assert.AreEqual(root.RightNode, rightChild);
            Assert.IsTrue(rightChild.IsRightChild);
        }
    }
}
