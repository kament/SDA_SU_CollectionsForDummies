using System;

namespace CollectionsForDummies.Collections.Enumerators
{
    internal class BinarySearchTreePreOrderEnumerator<T> : BinarySearchTreeEnumerator<T>
        where T : IComparable<T>
    {
        public BinarySearchTreePreOrderEnumerator(BinarySearchTree<T> tree)
            : base(tree)
        {
        }

        protected override void VisitNode(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                this.TraverseQueue.Enqueue(node);
                this.VisitNode(node.LeftChild);
                this.VisitNode(node.RightChild);
            }
        }
    }
}
