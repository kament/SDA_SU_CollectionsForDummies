using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsForDummies.Collections.Tests
{
    [TestClass]
    public class BinarySearchTreeEnumeratorTests
    {
        [TestMethod]
        public void ShouldEnumerateCorrectlyEnumeratePreOrderTreeWalk()
        {
            var avlTree = new AvlTree<int>(new int[] { 30, 15, 14, 18, 34, 44, 33 });

            avlTree.TreeWalk = TreeWalk.PreOrder;

            var resultFromTravers = string.Empty;

            foreach (var item in avlTree)
            {
                resultFromTravers += " " + item.Value.ToString();
            }

            var expectedTravers = "30 15 14 18 34 33 44";

            Assert.AreEqual(expectedTravers, resultFromTravers.Trim());
        }

        [TestMethod]
        public void ShouldEnumerateCorrectlyEnumerateInOrderTreeWalk()
        {
            var avlTree = new AvlTree<int>(new int[] { 30, 15, 14, 18, 34, 44, 33 });

            avlTree.TreeWalk = TreeWalk.InOrder;

            var resultFromTravers = string.Empty;

            foreach (var item in avlTree)
            {
                resultFromTravers += " " + item.Value.ToString();
            }

            var expectedTravers = "14 15 18 30 33 34 44";

            Assert.AreEqual(expectedTravers, resultFromTravers.Trim());
        }

        [TestMethod]
        public void ShouldEnumerateCorrectlyEnumeratePostOrderTreeWalk()
        {
            var avlTree = new AvlTree<int>(new int[] { 30, 15, 14, 18, 34, 44, 33 });

            avlTree.TreeWalk = TreeWalk.PostOrder;

            var resultFromTravers = string.Empty;

            foreach (var item in avlTree)
            {
                resultFromTravers += " " + item.Value.ToString();
            }

            var expectedTravers = "14 18 15 33 44 34 30";

            Assert.AreEqual(expectedTravers, resultFromTravers.Trim());
        }
    }
}
