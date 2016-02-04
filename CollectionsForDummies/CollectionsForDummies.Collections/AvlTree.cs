using System;
using System.Collections.Generic;

namespace CollectionsForDummies.Collections
{
    internal class AvlTree<T> : BinarySearchTree<T>, ICollection<BinaryTreeNode<T>> where T : IComparable<T>
    {
        public AvlTree()
            : base()
        {
        }

        public AvlTree(T rootValue)
            :base(new BinaryTreeNode<T>(null, rootValue))
        {
        }

        public AvlTree(T rootValue, TreeWalk treeWalk)
            :base(new BinaryTreeNode<T>(null, rootValue), treeWalk)
        {
        }

        public void Add(T value)
        {
            this.Add(new BinaryTreeNode<T>(null, value));
        }

        public override void Add(BinaryTreeNode<T> item)
        {
            base.Add(item);

            this.Balance(item);
        }

        public bool Remove(T value)
        {
            return this.Remove(new BinaryTreeNode<T>(null, value));
        }
        
        public override bool Remove(BinaryTreeNode<T> item)
        {
            var removed = base.Remove(item);

            this.Balance(item);

            return removed;
        }

        protected void Balance(BinaryTreeNode<T> startNode)
        {
            var nodeToBalance = startNode;

            while (nodeToBalance != null)
            {
                var balance = this.GetBalance(nodeToBalance);

                if (Math.Abs(balance) > 1)
                {
                    //its unbalanced
                    this.Balance(nodeToBalance, balance);
                }

                nodeToBalance = nodeToBalance.Parent;
            }
        }

        protected void Balance(BinaryTreeNode<T> nodeToBalance, int balance)
        {
            if (balance > 1)
            {
                //its left overweight
                var leftChildBalance = this.GetBalance(nodeToBalance.LeftChild);

                if(leftChildBalance < 0)
                {
                    //its right overweight, so should became left overweight
                    this.RotateLeft(nodeToBalance.LeftChild);
                }

                this.RotateRight(nodeToBalance);
            }
            else if(balance < -1)
            {
                //its left overweight
                var rightChildBalance = this.GetBalance(nodeToBalance.RightChild);

                if(rightChildBalance > 0)
                {
                    //its left overweight, so should became right overweight
                    this.RotateRight(nodeToBalance.RightChild);
                }

                this.RotateLeft(nodeToBalance);
            }
        }

        protected void RotateRight(BinaryTreeNode<T> root)
        {
            var newRoot = root.LeftChild;
            newRoot.Parent = root.Parent;
            
            if (root.IsLeftChild)
            {
                root.Parent.LeftChild = newRoot;
            }
            else if(root.IsRightChild)
            {
                root.Parent.RightChild = newRoot;
            }
            else
            {
                //root is the real Avl tree root
                this.Root = newRoot;
            }

            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;
            root.Parent = newRoot;
        }

        protected void RotateLeft(BinaryTreeNode<T> root)
        {
            var newRoot = root.RightChild;
            newRoot.Parent = root.Parent;

            if (root.IsRightChild)
            {
                root.Parent.RightChild = newRoot;
            }
            else if (root.IsLeftChild)
            {
                root.Parent.LeftChild = newRoot;
            }

            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;
            root.Parent = newRoot;
        }

        protected int GetBalance(BinaryTreeNode<T> root)
        {
            return this.GetHeight(root.LeftChild) - this.GetHeight(root.RightChild);
        }
    }
}
