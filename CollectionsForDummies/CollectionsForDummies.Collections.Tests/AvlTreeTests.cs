﻿using System.Collections.Generic;

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
        public void ShouldGenerateAvlTreeWithEmptyConstructor()
        {
            var avlTree = new AvlTree<int>();

            Assert.AreEqual(null, avlTree.Root);
        }

        [TestMethod]
        public void ShouldGenerateAvlTreeFromEnumerableConstructor()
        {
            var avlTree = new AvlTree<int>(new int[] { 40, 15, 25, 14, 17, 22, 44, 88 });

            Assert.AreEqual(17, avlTree.Root.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(14, avlTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(25, avlTree.Root.RightChild.Value);
            Assert.AreEqual(22, avlTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(44, avlTree.Root.RightChild.RightChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.RightChild.LeftChild.Value);
            Assert.AreEqual(88, avlTree.Root.RightChild.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftRightOverweight()
        {
            var avlTree = new AvlTree<int>(40);

            avlTree.Add(15);
            avlTree.Add(25);

            Assert.AreEqual(25, avlTree.Root.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftRightOverweighWithEmptyConstructor()
        {
            var avlTree = new AvlTree<int>(new int[] { 40, 15, 25 });

            Assert.AreEqual(25, avlTree.Root.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftLeftOverweight()
        {
            var avlTree = new AvlTree<int>(new int[] { 40, 20, 10 });

            Assert.AreEqual(20, avlTree.Root.Value);
            Assert.AreEqual(10, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsRightRightOverweight()
        {
            var avlTree = new AvlTree<int>(new int[] { 20, 30, 40 });

            Assert.AreEqual(30, avlTree.Root.Value);
            Assert.AreEqual(20, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsRightLeftOverweight()
        {
            var avlTree = new AvlTree<int>(new[] { 20, 30, 25 });

            Assert.AreEqual(25, avlTree.Root.Value);
            Assert.AreEqual(20, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(30, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftLeftOverweightInTheLeftSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 25, 40, 17, 15, 22 });

            avlTree.Add(14);

            Assert.AreEqual(17, avlTree.Root.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(14, avlTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(25, avlTree.Root.RightChild.Value);
            Assert.AreEqual(22, avlTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftRightOverweightInTheLeftSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 25, 40, 17, 15, 22 });

            avlTree.Add(16);

            Assert.AreEqual(17, avlTree.Root.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(16, avlTree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(25, avlTree.Root.RightChild.Value);
            Assert.AreEqual(22, avlTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsRightRightOverweightInTheLeftSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 25, 40, 15, 17 });

            avlTree.Add(22);

            Assert.AreEqual(25, avlTree.Root.Value);
            Assert.AreEqual(17, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(22, avlTree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsRightLeftOverweightInTheLeftSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 25, 40, 15, 17 });

            avlTree.Add(16);

            Assert.AreEqual(25, avlTree.Root.Value);
            Assert.AreEqual(16, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(17, avlTree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(15, avlTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsRightRightOverweightInTheRightSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 18, 14, 24, 22, 30, 13, 38 });

            avlTree.Add(40);

            Assert.AreEqual(18, avlTree.Root.Value);
            Assert.AreEqual(14, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(13, avlTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(24, avlTree.Root.RightChild.Value);
            Assert.AreEqual(22, avlTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(38, avlTree.Root.RightChild.RightChild.Value);
            Assert.AreEqual(30, avlTree.Root.RightChild.RightChild.LeftChild.Value);
            Assert.AreEqual(40, avlTree.Root.RightChild.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsRightLeftOverweightInTheRightSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 18, 14, 24, 22, 30, 13, 38 });

            avlTree.Add(36);

            Assert.AreEqual(18, avlTree.Root.Value);
            Assert.AreEqual(14, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(13, avlTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(24, avlTree.Root.RightChild.Value);
            Assert.AreEqual(22, avlTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(36, avlTree.Root.RightChild.RightChild.Value);
            Assert.AreEqual(30, avlTree.Root.RightChild.RightChild.LeftChild.Value);
            Assert.AreEqual(38, avlTree.Root.RightChild.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftLeftOverweightInTheRightSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 18, 14, 30, 25 });

            avlTree.Add(22);

            Assert.AreEqual(18, avlTree.Root.Value);
            Assert.AreEqual(14, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(25, avlTree.Root.RightChild.Value);
            Assert.AreEqual(22, avlTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(30, avlTree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldBalanceTreeWhenItIsLeftRightOverweightInTheRightSubtree()
        {
            var avlTree = new AvlTree<int>(new int[] { 18, 14, 30, 25 });

            avlTree.Add(27);

            Assert.AreEqual(18, avlTree.Root.Value);
            Assert.AreEqual(14, avlTree.Root.LeftChild.Value);
            Assert.AreEqual(27, avlTree.Root.RightChild.Value);
            Assert.AreEqual(25, avlTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(30, avlTree.Root.RightChild.RightChild.Value);
        }

        private AvlTree<int> GetAvlTree(IEnumerable<int> numbers)
        {
            var avlTree = new AvlTree<int>();

            foreach (var number in numbers)
            {
                avlTree.Add(number);
            }

            return avlTree;
        }
    }
}
