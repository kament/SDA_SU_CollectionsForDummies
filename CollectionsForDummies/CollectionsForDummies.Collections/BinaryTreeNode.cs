namespace CollectionsForDummies.Collections
{
    internal class BinaryTreeNode<T>
    {
        public BinaryTreeNode(BinaryTreeNode<T> parentNode)
        {
            this.Parent = parentNode;
        }

        public BinaryTreeNode(BinaryTreeNode<T> parentNode, T value)
            :this(parentNode)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public bool HasLeftChild
        {
            get
            {
                return this.LeftChild != null;
            }
        }

        public bool HasRightChild
        {
            get
            {
                return this.RightChild != null;
            }
        }

        public bool IsLeaf
        {
            get
            {
                return (!this.HasLeftChild) && (!this.HasRightChild);
            }
        }

        public bool IsRoot
        {
            get
            {
                return this.Parent == null;
            }
        }

        public bool IsLeftChild
        {
            get
            {
                if (this.Parent != null && this.Parent.LeftChild != null)
                {
                    return this.Parent.LeftChild.Equals(this);
                }

                return false;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent != null && this.Parent.RightChild != null)
                {
                    return this.Parent.RightChild.Equals(this);
                }

                return false;
            }
        }
    }
}
