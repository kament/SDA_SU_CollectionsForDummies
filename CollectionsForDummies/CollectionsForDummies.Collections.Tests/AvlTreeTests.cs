using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsForDummies.Collections.Tests
{
    [TestClass]
    public class AvlTreeTests
    {
        [TestMethod]
        public void ShouldCreateCorrectlyAvlTreeWithConstructorWithValue()
        {
            var avlTree = new AvlTree<int>(40);

            Assert.AreEqual(40, avlTree.Root.Value);
            
            //check not to add some child nodes
            Assert.IsFalse(avlTree.Root.HasLeftChild);
            Assert.IsFalse(avlTree.Root.HasRightChild);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftOverweight()
        {
            var avlTree = new AvlTree<int>(40);

            avlTree.Add(15);
            avlTree.Add(25);

            Assert.AreEqual(25, avlTree.Root.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftOverweightAndCreatedWithEmptyConstructor()
        {
            var avlTree = new AvlTree<int>();

            avlTree.Add(40);
            avlTree.Add(15);
            avlTree.Add(25);

            Assert.AreEqual(25, avlTree.Root.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }
        
    }
}
