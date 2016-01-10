using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsForDummies.Collections.Enumerators
{
    internal abstract class BinarySearchTreeEnumerator<T> : IEnumerator<BinaryTreeNode<T>>
        where T : IComparable<T>
    {
        protected BinaryTreeNode<T> current;
        protected BinarySearchTree<T> tree;
        
        public BinarySearchTreeEnumerator(BinarySearchTree<T> tree)
        {
            this.tree = tree;
            this.current = tree.Root;
            this.TraverseQueue = new Queue<BinaryTreeNode<T>>();

            this.VisitNode(current);
        }

        protected Queue<BinaryTreeNode<T>> TraverseQueue { get; private set; }

        protected abstract void VisitNode(BinaryTreeNode<T> node);

        public BinaryTreeNode<T> Current
        {
            get
            {
                return this.current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {
            this.TraverseQueue = null;
            this.tree = null;
            this.current = null;
        }

        public bool MoveNext()
        {
            if(this.TraverseQueue.Count > 0)
            {
                this.current = this.TraverseQueue.Dequeue();
            }
            else
            {
                this.current = null;
            }

            return current != null;
        }

        public void Reset()
        {
            this.current = tree.Root;
            this.TraverseQueue.Clear();
        }
    }
}
