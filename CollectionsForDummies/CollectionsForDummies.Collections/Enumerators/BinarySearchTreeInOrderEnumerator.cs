using System;

namespace CollectionsForDummies.Collections.Enumerators
{
    internal class BinarySearchTreeInOrderEnumerator<T> : BinarySearchTreeEnumerator<T>
        where T : IComparable<T>
    {
        public BinarySearchTreeInOrderEnumerator(BinarySearchTree<T> tree)
            : base(tree)
        {
        }

        protected override void VisitNode(BinaryTreeNode<T> node)
        {
            if(node != null)
            {
                this.VisitNode(node.LeftNode);
                this.TraverseQueue.Enqueue(node);
                this.VisitNode(node.RightNode);
            }
        }
    }
}
