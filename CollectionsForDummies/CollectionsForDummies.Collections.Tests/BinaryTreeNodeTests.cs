using System;
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
    }
}
