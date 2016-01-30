using System;

namespace CollectionsForDummies.Collections.Enumerators
{
    internal class BinarySearchTreePostOrderEnumerator<T> : BinarySearchTreeEnumerator<T>
        where T : IComparable<T>
    {
        public BinarySearchTreePostOrderEnumerator(BinarySearchTree<T> tree)
            : base(tree)
        {
        }

        protected override void VisitNode(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                this.VisitNode(node.LeftChild);
                this.VisitNode(node.RightChild);
                this.TraverseQueue.Enqueue(node);
            }
        }
    }
}
