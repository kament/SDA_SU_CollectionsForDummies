using System;
using System.Collections;
using System.Collections.Generic;

using CollectionsForDummies.Collections.Enumerators;

namespace CollectionsForDummies.Collections
{
    /// <summary>
    /// Data Structure that represent binary search treee
    /// </summary>
    /// <typeparam name="T">Object which is IComparable of "T"/></typeparam>
    internal class BinarySearchTree<T> : ICollection<BinaryTreeNode<T>>
        where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinarySearchTree(BinaryTreeNode<T> rootNode)
        {
            this.Root = rootNode;
        }

        public BinarySearchTree(BinaryTreeNode<T> rootNode, TreeWalk walk)
            : this(rootNode)
        {
            this.TreeWalk = walk;
        }

        public BinarySearchTree()
            : this(null)
        {
        }

        public TreeWalk TreeWalk { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(BinaryTreeNode<T> item)
        {
            if (this.Root == null)
            {
                this.Root = item;
                this.Count++;
            }
            else
            {
                var currentRootNode = this.Root;

                while (currentRootNode != null)
                {
                    if (item.Value.CompareTo(currentRootNode.Value) < 0)
                    {
                        //add the velue in the left node if its null
                        if (!currentRootNode.HasLeftNode)
                        {
                            currentRootNode.LeftNode = item;
                            item.ParentNode = currentRootNode;
                            this.Count++;
                            break;
                        }

                        currentRootNode = currentRootNode.LeftNode;
                    }
                    else if (item.Value.CompareTo(currentRootNode.Value) > 0)
                    {
                        //add the value in the right node if its null
                        if (!currentRootNode.HasRightNode)
                        {
                            currentRootNode.RightNode = item;
                            item.ParentNode = currentRootNode;
                            this.Count++;
                            break;
                        }

                        currentRootNode = currentRootNode.RightNode;
                    }
                    else
                    {
                        //the item already exist, so stop the the operation
                        break;
                    }
                }
            }
        }
        
        public bool Contains(BinaryTreeNode<T> item)
        {
            return this.Search(item) != null;
        }
        
        public bool Remove(BinaryTreeNode<T> item)
        {
            var nodeInTheTree = this.Search(item);

            if (nodeInTheTree == null)
            {
                //maybe its a good idea to return false
                throw new ArgumentException("Node does not exist! " + item.Value);
            }

            var isLeftNodeNull = nodeInTheTree.LeftNode == null;
            var isRightNodeNull = nodeInTheTree.RightNode == null;

            var parentNode = nodeInTheTree.ParentNode;

            if (nodeInTheTree.IsLeaf)
            {
                if (nodeInTheTree.IsLeftChild)
                {
                    parentNode.LeftNode = null;
                }
                else if (nodeInTheTree.IsRightChild)
                {
                    parentNode.RightNode = null;
                }
            }
            else if (nodeInTheTree.HasLeftNode && !nodeInTheTree.HasRightNode)
            {
                if (nodeInTheTree.IsLeftChild)
                {
                    parentNode.LeftNode = nodeInTheTree.LeftNode;
                }
                else if (nodeInTheTree.IsRightChild)
                {
                    parentNode.RightNode = nodeInTheTree.LeftNode;
                }
            }
            else if (!nodeInTheTree.HasLeftNode && nodeInTheTree.HasRightNode)
            {
                if (nodeInTheTree.IsLeftChild)
                {
                    parentNode.LeftNode = nodeInTheTree.RightNode;
                }
                else if (nodeInTheTree.IsRightChild)
                {
                    parentNode.RightNode = nodeInTheTree.RightNode;
                }
            }
            else
            {
                var minElement = this.GetMininalElement(nodeInTheTree.RightNode);

                //TODO: should be unitested very carefully
                nodeInTheTree.Value = minElement.Value;

                if (minElement.IsLeftChild)
                {
                    minElement.ParentNode.LeftNode = null;
                }
                else
                {
                    minElement.ParentNode.RightNode = null;
                }
            }

            this.Count--;

            return true;
        }

        public void CopyTo(BinaryTreeNode<T>[] array, int arrayIndex)
        {
            var enumerator = this.GetEnumerator();

            for (int i = arrayIndex; i < array.Length; i++)
            {
                if (enumerator.MoveNext())
                {
                    array[i] = enumerator.Current;
                }
                else
                {
                    break;
                }
            }
        }

        public void Clear()
        {
            var enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                this.Remove(enumerator.Current);
            }

            enumerator.Dispose();
        }

        public IEnumerator<BinaryTreeNode<T>> GetEnumerator()
        {
            switch (this.TreeWalk)
            {
                case TreeWalk.InOrder:
                    return new BinarySearchTreeInOrderEnumerator<T>(this);
                case TreeWalk.PostOrder:
                    return new BinarySearchTreePostOrderEnumerator<T>(this);
                case TreeWalk.PreOrder:
                    return new BinarySearchTreePreOrderEnumerator<T>(this);
                default:
                    throw new ArgumentException("There is not enumerator for: " + this.TreeWalk);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Return the min element in a tree
        private BinaryTreeNode<T> GetMininalElement(BinaryTreeNode<T> tree)
        {
            var minElement = tree;
            var nodesToTravers = new Queue<BinaryTreeNode<T>>();
            nodesToTravers.Enqueue(tree);

            while (nodesToTravers.Count != 0)
            {
                var currentNode = nodesToTravers.Dequeue();

                if (currentNode != null)
                {
                    if (minElement.Value.CompareTo(currentNode.Value) > 0)
                    {
                        minElement = currentNode;
                    }

                    nodesToTravers.Enqueue(currentNode.LeftNode);
                    nodesToTravers.Enqueue(currentNode.RightNode);
                }
            }

            return minElement;
        }

        /// <summary>
        /// Search for node in the current tree
        /// </summary>
        /// <param name="treeNode">Node which should be found</param>
        /// <returns>Node which value equals to "treeNode" value. If treed node does not exist return null</returns>
        private BinaryTreeNode<T> Search(BinaryTreeNode<T> treeNode)
        {
            var currentNode = this.Root;
            BinaryTreeNode<T> foundNode = null;

            while (currentNode != null)
            {
                if (treeNode.Value.CompareTo(currentNode.Value) == 0)
                {
                    foundNode = currentNode;
                    break;
                }
                else if (treeNode.Value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                }
            }

            return foundNode;
        }
    }
}
