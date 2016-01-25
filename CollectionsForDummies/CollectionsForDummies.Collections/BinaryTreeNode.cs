namespace CollectionsForDummies.Collections
{
    internal class BinaryTreeNode<T>
    {
        public BinaryTreeNode(BinaryTreeNode<T> parentNode)
        {
            this.ParentNode = parentNode;
        }

        public BinaryTreeNode(BinaryTreeNode<T> parentNode, T value)
            :this(parentNode)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public BinaryTreeNode<T> ParentNode { get; set; }

        public BinaryTreeNode<T> LeftNode { get; set; }

        public BinaryTreeNode<T> RightNode { get; set; }

        public bool HasLeftNode
        {
            get
            {
                return this.LeftNode != null;
            }
        }

        public bool HasRightNode
        {
            get
            {
                return this.RightNode != null;
            }
        }

        public bool IsLeaf
        {
            get
            {
                return (!this.HasLeftNode) && (!this.HasRightNode);
            }
        }

        public bool IsRoot
        {
            get
            {
                return this.ParentNode == null;
            }
        }

        public bool IsLeftChild
        {
            get
            {
                if (this.ParentNode != null)
                {
                    return this.ParentNode.LeftNode.Equals(this);
                }

                return false;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.ParentNode != null)
                {
                    return this.ParentNode.RightNode.Equals(this);
                }

                return false;
            }
        }
    }
}
