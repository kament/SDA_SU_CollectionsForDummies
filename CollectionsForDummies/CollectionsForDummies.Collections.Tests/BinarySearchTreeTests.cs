using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionsForDummies.Collections.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private const string ShouldReturnTrueFormat = "Should return true when remove {0} !";
        private const string RemovedValueShouldBeNullOrReplacedByChild = "{0} should be reset to Null, or replaced by one of its child nodes!";

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
        public void ShouldCreateBinarySearchTreeWithGivenRootAndUpdateTheCounter()
        {
            var rootNode = new BinaryTreeNode<int>(null);

            var binarySearchTree = new BinarySearchTree<int>(rootNode);

            Assert.AreEqual(1, binarySearchTree.Count);
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
            this.ShouldUpdateTheCounterWhenAddNewItems(new[] { 10, -100, 144, 27, 88, 56, 22, 9, -6, 14, 666666, 10000, 111 }, 13);
        }

        [TestMethod]
        public void ShouldUpdateCounterWhenRemoveItem()
        {
            var binaryTree = this.CreateTree(new[] { 2, 5, 8, -10 });

            binaryTree.Remove(new BinaryTreeNode<int>(null, 8));

            Assert.AreEqual(3, binaryTree.Count);
        }

        [TestMethod]
        public void ShouldUpdateCounterWhenRemoveItemWhenTreeIsBigger()
        {
            var binaryTree = this.CreateTree(new[] { 10, -100, 144, 27, 88, 56, 22, 9, -6, 14, 666666, 10000, 111 });

            binaryTree.Remove(new BinaryTreeNode<int>(null, 666666));

            Assert.AreEqual(12, binaryTree.Count);
        }

        [TestMethod]
        public void ShouldNotUpdateCounterWhenRemoveUnexistingItem()
        {
            var binaryTree = this.CreateTree(new[] { 2, 5, 8, -10 });

            binaryTree.Remove(new BinaryTreeNode<int>(null, 666666));

            Assert.AreEqual(4, binaryTree.Count);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemExistInTheTreeAndItIsTheRoot()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            Assert.IsTrue(binaryTree.Contains(new BinaryTreeNode<int>(null, 20)));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemExistInTheLeftSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.LeftChild = new BinaryTreeNode<int>(binaryTree.Root, 15);

            Assert.IsTrue(binaryTree.Contains(new BinaryTreeNode<int>(null, 15)));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemExistInTheRightSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.RightChild = new BinaryTreeNode<int>(binaryTree.Root, 25);

            Assert.IsTrue(binaryTree.Contains(new BinaryTreeNode<int>(null, 25)));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemExistInLeftSubtreeAndThanInItsRightSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.LeftChild = new BinaryTreeNode<int>(binaryTree.Root, 15);
            binaryTree.Root.LeftChild.RightChild = new BinaryTreeNode<int>(binaryTree.Root.LeftChild, 18);

            Assert.IsTrue(binaryTree.Contains(new BinaryTreeNode<int>(null, 18)));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemExistInLeftSubtreeAndThanInItsLeftSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.LeftChild = new BinaryTreeNode<int>(binaryTree.Root, 15);
            binaryTree.Root.LeftChild.LeftChild = new BinaryTreeNode<int>(binaryTree.Root.LeftChild, 10);

            Assert.IsTrue(binaryTree.Contains(new BinaryTreeNode<int>(null, 10)));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemExistInRightSubtreeAndThanInItsRightSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.RightChild = new BinaryTreeNode<int>(binaryTree.Root, 25);
            binaryTree.Root.RightChild.RightChild = new BinaryTreeNode<int>(binaryTree.Root.LeftChild, 28);

            Assert.IsTrue(binaryTree.Contains(new BinaryTreeNode<int>(null, 28)));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenItemExistInRightSubtreeAndThanInItsLeftSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.RightChild = new BinaryTreeNode<int>(binaryTree.Root, 25);
            binaryTree.Root.RightChild.LeftChild = new BinaryTreeNode<int>(binaryTree.Root.LeftChild, 22);

            Assert.IsTrue(binaryTree.Contains(new BinaryTreeNode<int>(null, 22)));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenItemDoesNotExistAndTheTreeIsEmpty()
        {
            Assert.IsFalse(new BinarySearchTree<int>().Contains(new BinaryTreeNode<int>(null, 10)));
        }

        [TestMethod]
        public void ShouldRetrnFalseWhenItemDoesNotExistInTree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            Assert.IsFalse(binaryTree.Contains(new BinaryTreeNode<int>(null, 21)));
        }

        [TestMethod]
        public void ShouldRetrnFalseWhenItemDoesNotExistInTreeAndItsIntDefaulthValue()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            Assert.IsFalse(binaryTree.Contains(new BinaryTreeNode<int>(null, 0)));
        }

        [TestMethod]
        public void ShouldRetrnFalseWhenItemDoesNotExistInTreeAndItsIntDefaulthValueAndTheTreeIsEmpty()
        {
            var binaryTree = new BinarySearchTree<int>();

            Assert.IsFalse(binaryTree.Contains(new BinaryTreeNode<int>(null, 0)));
        }

        [TestMethod]
        public void ShouldRemoveCorrectlyRootInTreeWithNoChildNodes()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            Assert.IsTrue(binaryTree.Remove(new BinaryTreeNode<int>(null, 20)), string.Format(ShouldReturnTrueFormat, 20));
            Assert.AreEqual(null, binaryTree.Root, string.Format(RemovedValueShouldBeNullOrReplacedByChild, "Root tag"));
        }

        [TestMethod]
        public void ShouldRemoveCorrectlyTagWhichExistInTheLeftSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.LeftChild = new BinaryTreeNode<int>(binaryTree.Root, 10);

            Assert.IsTrue(binaryTree.Remove(new BinaryTreeNode<int>(null, 10)), string.Format(ShouldReturnTrueFormat, 10));
            Assert.AreEqual(null, binaryTree.Root.LeftChild, string.Format(RemovedValueShouldBeNullOrReplacedByChild, "Left Child"));
        }

        [TestMethod]
        public void ShouldRemoveCorrectlyTagWhichExistInTheRightSubtree()
        {
            var binaryTree = new BinarySearchTree<int>(new BinaryTreeNode<int>(null, 20));

            binaryTree.Root.RightChild = new BinaryTreeNode<int>(binaryTree.Root, 22);

            Assert.IsTrue(binaryTree.Remove(new BinaryTreeNode<int>(null, 22)), string.Format(ShouldReturnTrueFormat, 22));
            Assert.AreEqual(null, binaryTree.Root.RightChild, string.Format(RemovedValueShouldBeNullOrReplacedByChild, "Right Child"));
        }

        [TestMethod]
        public void ShouldRomoveRootElementAndReplaceItWithMinElementInRightSubtree()
        {
            var numbers = new[] { 21, 17, 28, 13, 19, 22, 40 };

            var binaryTree = this.CreateTree(numbers);

            binaryTree.Remove(new BinaryTreeNode<int>(null, 21));

            Assert.AreEqual(22, binaryTree.Root.Value);
            Assert.AreEqual(17, binaryTree.Root.LeftChild.Value);
            Assert.AreEqual(19, binaryTree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(13, binaryTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(28, binaryTree.Root.RightChild.Value);
            Assert.AreEqual(40, binaryTree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldChangeNewNodeRelationsWhenRemoveNodeWhichHasRightChildrensAndDoesNotHaveLeftInTheRightSubtree()
        {
            var tree = this.CreateTree(new[] { 20, 15, 28, 35, 30, 38 });

            tree.Remove(new BinaryTreeNode<int>(null, 28));

            Assert.AreEqual(20, tree.Root.Value);

            Assert.AreEqual(35, tree.Root.RightChild.Value);
            Assert.AreEqual(20, tree.Root.RightChild.Parent.Value);

            Assert.AreEqual(30, tree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(35, tree.Root.RightChild.LeftChild.Parent.Value);

            Assert.AreEqual(38, tree.Root.RightChild.RightChild.Value);
            Assert.AreEqual(35, tree.Root.RightChild.RightChild.Parent.Value);
        }

        [TestMethod]
        public void ShouldChangeNewNodeRelationsWhenRemoveNodeWhichHasLeftChildrensAndDoesNotHaveRightInTheRightSubtree()
        {
            var tree = this.CreateTree(new[] { 20, 15, 48, 35, 30, 38 });

            tree.Remove(new BinaryTreeNode<int>(null, 48));

            Assert.AreEqual(20, tree.Root.Value);

            Assert.AreEqual(35, tree.Root.RightChild.Value);
            Assert.AreEqual(20, tree.Root.RightChild.Parent.Value);

            Assert.AreEqual(30, tree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(35, tree.Root.RightChild.LeftChild.Parent.Value);

            Assert.AreEqual(38, tree.Root.RightChild.RightChild.Value);
            Assert.AreEqual(35, tree.Root.RightChild.RightChild.Parent.Value);
        }

        [TestMethod]
        public void ShouldChangeNewNodeRelationsWhenRemoveNodeWhichHasRightChildrensAndDoesNotHaveLeftInTheLeftSubtree()
        {
            var tree = this.CreateTree(new[] { 30, 40, 15, 25, 28, 20 });

            tree.Remove(new BinaryTreeNode<int>(null, 15));

            Assert.AreEqual(30, tree.Root.Value);

            Assert.AreEqual(25, tree.Root.LeftChild.Value);
            Assert.AreEqual(30, tree.Root.LeftChild.Parent.Value);

            Assert.AreEqual(20, tree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(25, tree.Root.LeftChild.LeftChild.Parent.Value);

            Assert.AreEqual(28, tree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(25, tree.Root.LeftChild.RightChild.Parent.Value);
        }

        [TestMethod]
        public void ShouldChangeNewNodeRelationsWhenRemoveNodeWhichHasLeftChildrensAndDoesNotHaveRightInTheLeftSubtree()
        {
            var tree = this.CreateTree(new[] { 35, 40, 30, 25, 28, 20 });

            tree.Remove(new BinaryTreeNode<int>(null, 30));

            Assert.AreEqual(35, tree.Root.Value);

            Assert.AreEqual(25, tree.Root.LeftChild.Value);
            Assert.AreEqual(35, tree.Root.LeftChild.Parent.Value);

            Assert.AreEqual(20, tree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(25, tree.Root.LeftChild.LeftChild.Parent.Value);

            Assert.AreEqual(28, tree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(25, tree.Root.LeftChild.RightChild.Parent.Value);
        }

        [TestMethod]
        public void ShouldMakeRightChildRootWhenRemoveTheRootAndItHasNoLeftValues()
        {
            var tree = CreateTree(new[] { 10, 20 });

            tree.Remove(new BinaryTreeNode<int>(null, 10));

            Assert.AreEqual(20, tree.Root.Value);
            Assert.AreEqual(null, tree.Root.Parent);
        }

        [TestMethod]
        public void ShouldMakeLeftChildRootWhenRemoveTheRootAndItHasNoRightValues()
        {
            var tree = CreateTree(new[] { 30, 4 });

            tree.Remove(new BinaryTreeNode<int>(null, 30));

            Assert.AreEqual(4, tree.Root.Value);
            Assert.AreEqual(null, tree.Root.Parent);
        }

        [TestMethod]
        public void ShouldRemoveRootLeftChild()
        {
            var numbers = new[] { 21, 17, 28, 13, 19, 22, 40 };

            var binaryTree = this.CreateTree(numbers);

            binaryTree.Remove(new BinaryTreeNode<int>(null, 17));

            Assert.AreEqual(21, binaryTree.Root.Value);
            Assert.AreEqual(19, binaryTree.Root.LeftChild.Value);
            Assert.AreEqual(13, binaryTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(28, binaryTree.Root.RightChild.Value);
            Assert.AreEqual(22, binaryTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(40, binaryTree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void ShouldRemoveRootRightChild()
        {
            var numbers = new[] { 21, 17, 28, 13, 19, 22, 40 };

            var binaryTree = this.CreateTree(numbers);

            binaryTree.Remove(new BinaryTreeNode<int>(null, 28));

            Assert.AreEqual(21, binaryTree.Root.Value);
            Assert.AreEqual(17, binaryTree.Root.LeftChild.Value);
            Assert.AreEqual(13, binaryTree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(19, binaryTree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(40, binaryTree.Root.RightChild.Value);
            Assert.AreEqual(22, binaryTree.Root.RightChild.LeftChild.Value);
        }

        [TestMethod]
        public void ShouldRemoveNodeWhichHasLeftChildAndDoesNotHaveRightInTheLeftSubtree()
        {
            var numbers = new[] { 21, 17, 28, 13, 22, 40 };

            var binaryTree = this.CreateTree(numbers);

            binaryTree.Remove(new BinaryTreeNode<int>(null, 17));
            
            Assert.AreEqual(13, binaryTree.Root.LeftChild.Value);
        }

        [TestMethod]
        public void ShouldRemoveNodeWhichHasRightChildAndDoesNotHaveLeftInTheLeftSubtree()
        {
            var numbers = new[] { 21, 17, 28, 19, 22, 40 };

            var binaryTree = this.CreateTree(numbers);

            binaryTree.Remove(new BinaryTreeNode<int>(null, 17));

            Assert.AreEqual(19, binaryTree.Root.LeftChild.Value);
        }

        [TestMethod]
        public void ShouldRemoveNodeWhichHasRightChildAndDoesNotHaveLeftInTheRightSubtree()
        {
            var numbers = new[] { 21, 17, 28, 13, 19, 40 };

            var binaryTree = this.CreateTree(numbers);

            binaryTree.Remove(new BinaryTreeNode<int>(null, 28));

            Assert.AreEqual(40, binaryTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void ShouldRemoveNodeWhichHasLeftChildAndDoesNotHaveRightInTheRightSubtree()
        {
            var numbers = new[] { 21, 17, 28, 13, 19, 22 };

            var binaryTree = this.CreateTree(numbers);

            binaryTree.Remove(new BinaryTreeNode<int>(null, 28));

            Assert.AreEqual(22, binaryTree.Root.RightChild.Value);
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
