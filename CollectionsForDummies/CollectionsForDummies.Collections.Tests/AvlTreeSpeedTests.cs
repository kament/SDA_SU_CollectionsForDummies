using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CollectionsForDummies.Collections.Tests
{
    [TestClass]
    public class AvlTreeSpeedTests
    {
        [TestMethod]
        public void CompareAddTime()
        {
            var itemsCount = 10000;

            var startTime = DateTime.Now;

            var list = new List<int>();
            for (int i = 0; i < itemsCount; i++)
            {
                list.Add(i);
            }

            var listAddingTime = DateTime.Now - startTime;

            startTime = DateTime.Now;
            var avlTree = new AvlTree<int>();

            for (int i = 0; i < itemsCount; i++)
            {
                avlTree.Add(i);
            }

            var avlAddTree = DateTime.Now - startTime;
        }

        [TestMethod]
        public void CompareSearchTime()
        {
            var itemsCount = 10000;
            
            var list = new List<int>();
            for (int i = 0; i < itemsCount; i++)
            {
                list.Add(i);
            }

            var startTime = DateTime.Now;

            list.Contains(5000);

            var listContainsTime = DateTime.Now - startTime;

            var avlTree = new AvlTree<int>();

            for (int i = 0; i < itemsCount; i++)
            {
                avlTree.Add(i);
            }

            startTime = DateTime.Now;

            avlTree.Contains(5000);

            var avlContainsTime = DateTime.Now - startTime;
        }

        [TestMethod]
        public void CompareRemoveTime()
        {
            var itemsCount = 10000;

            var list = new List<int>();
            for (int i = 0; i < itemsCount; i++)
            {
                list.Add(i);
            }

            var startTime = DateTime.Now;

            list.Remove(5000);

            var listRemoveTime = DateTime.Now - startTime;

            var avlTree = new AvlTree<int>();

            for (int i = 0; i < itemsCount; i++)
            {
                avlTree.Add(i);
            }

            startTime = DateTime.Now;

            avlTree.Remove(5000);

            var avlRemoveTime = DateTime.Now - startTime;
        }
    }
}
