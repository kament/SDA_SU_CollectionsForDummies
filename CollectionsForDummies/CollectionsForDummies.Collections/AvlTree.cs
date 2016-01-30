using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsForDummies.Collections
{
    internal class AvlTree<T> : BinarySearchTree<T>, ICollection<BinaryTreeNode<T>> where T : IComparable<T>
    {
        public AvlTree()
            :base()
        {
        }
        
        public override void Add(BinaryTreeNode<T> item)
        {
            base.Add(item);

            this.Balance(item);
        }
        
        public override bool Contains(BinaryTreeNode<T> item)
        {
            return base.Contains(item);
        }
        
        public override bool Remove(BinaryTreeNode<T> item)
        {
            var removed = base.Remove(item);

            this.Balance(item);

            return removed;
        }

        public override void CopyTo(BinaryTreeNode<T>[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }

        IEnumerator<BinaryTreeNode<T>> IEnumerable<BinaryTreeNode<T>>.GetEnumerator()
        {
            return base.GetEnumerator();
        }

        private void Balance(BinaryTreeNode<T> startNode)
        {
            throw new NotImplementedException();
        }
    }
}
