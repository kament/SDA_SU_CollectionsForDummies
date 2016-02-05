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
        public BinaryTreeNode<T> Root { get; protected set; }

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(BinaryTreeNode<T> rootNode)
        {
            this.Root = rootNode;
            this.Count++;
        }

        public BinarySearchTree(BinaryTreeNode<T> rootNode, TreeWalk walk)
            : this(rootNode)
        {
            this.TreeWalk = walk;
        }
        
        public virtual TreeWalk TreeWalk { get; set; }

        public virtual int Count { get; private set; }

        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual void Add(BinaryTreeNode<T> item)
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
                        if (!currentRootNode.HasLeftChild)
                        {
                            currentRootNode.LeftChild = item;
                            item.Parent = currentRootNode;
                            this.Count++;
                            break;
                        }

                        currentRootNode = currentRootNode.LeftChild;
                    }
                    else if (item.Value.CompareTo(currentRootNode.Value) > 0)
                    {
                        //add the value in the right node if its null
                        if (!currentRootNode.HasRightChild)
                        {
                            currentRootNode.RightChild = item;
                            item.Parent = currentRootNode;
                            this.Count++;
                            break;
                        }

                        currentRootNode = currentRootNode.RightChild;
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
            return this.Find(item) != null;
        }

        public virtual bool Remove(BinaryTreeNode<T> item)
        {
            var nodeInTheTree = this.Find(item);

            return this.RemoveTreeNode(nodeInTheTree);
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

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter node
        /// </summary>
        public virtual int GetHeight(BinaryTreeNode<T> startNode)
        {
            if (startNode != null)
            {
                return 1 + Math.Max(this.GetHeight(startNode.LeftChild), this.GetHeight(startNode.RightChild));
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Remove node from current tree
        /// </summary>
        protected bool RemoveTreeNode(BinaryTreeNode<T> nodeInTheTree)
        {
            if (nodeInTheTree == null)
            {
                //maybe its a good idea to return false
                //throw new ArgumentException("Node does not exist! " + item.Value);

                //return false is beter idea, i think
                return false;
            }

            var parentNode = nodeInTheTree.Parent;

            if (nodeInTheTree.IsLeaf && !nodeInTheTree.IsRoot)
            {
                if (nodeInTheTree.IsLeftChild)
                {
                    parentNode.LeftChild = null;
                }
                else if (nodeInTheTree.IsRightChild)
                {
                    parentNode.RightChild = null;
                }
            }
            else if (nodeInTheTree.HasLeftChild && !nodeInTheTree.HasRightChild)
            {
                if (nodeInTheTree.IsLeftChild)
                {
                    parentNode.LeftChild = nodeInTheTree.LeftChild;
                }
                else if (nodeInTheTree.IsRightChild)
                {
                    parentNode.RightChild = nodeInTheTree.LeftChild;
                }
            }
            else if (!nodeInTheTree.HasLeftChild && nodeInTheTree.HasRightChild)
            {
                if (nodeInTheTree.IsLeftChild)
                {
                    parentNode.LeftChild = nodeInTheTree.RightChild;
                }
                else if (nodeInTheTree.IsRightChild)
                {
                    parentNode.RightChild = nodeInTheTree.RightChild;
                }
            }
            else if (nodeInTheTree.HasRightChild)
            {
                var minElement = this.GetMininalElement(nodeInTheTree.RightChild);

                nodeInTheTree.Value = minElement.Value;

                if (minElement.IsLeftChild)
                {
                    minElement.Parent.LeftChild = null;
                }
                else
                {
                    minElement.Parent.RightChild = null;
                }
            }
            else
            {
                //in this last case this will be the root tag, which has no child
                this.Root = null;
            }

            this.Count--;

            return true;
        }

        /// <summary>
        /// Search for node in the current tree
        /// </summary>
        /// <param name="treeNode">Node which should be found</param>
        /// <returns>Node which value equals to "treeNode" value. If treed node does not exist return null</returns>
        protected BinaryTreeNode<T> Find(BinaryTreeNode<T> treeNode)
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
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }

            return foundNode;
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

                    nodesToTravers.Enqueue(currentNode.LeftChild);
                    nodesToTravers.Enqueue(currentNode.RightChild);
                }
            }

            return minElement;
        }
    }
}
