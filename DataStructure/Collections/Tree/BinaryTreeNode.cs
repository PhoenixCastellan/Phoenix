using System;
using System.Collections.Generic;
using DataStructure.Collections.Generic;

namespace DataStructure.Collections.Tree
{
    public class BinaryTreeNode<T> where T:IComparable
    {
        private T _data;
        private BinaryTreeNode<T> _parent;
        public int NumOfChild;
        private BinaryTreeNode<T> _lChild;
        private BinaryTreeNode<T> _rChild;
        private BinaryTree<T> _tree;

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public BinaryTreeNode<T> LeftChild
        {
            get { return _lChild; }
            set { _lChild = value; }
        }

        public BinaryTreeNode<T> RightChild
        {
            get { return _rChild; }
            set { _rChild = value; }
        }

        public BinaryTreeNode<T> Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public BinaryTree<T> Tree
        {
            get { return _tree; }
            set { _tree = value; }
        }

        public BinaryTreeNode()
        {
            _data = default(T);
            _parent = null;
            _lChild = null;
            _rChild = null;
            _tree = null;
        }

        public BinaryTreeNode(T data)
        {
            _data = data;
            _parent = null;
            _lChild = null;
            _rChild = null;
            _tree = null;
        }
        public BinaryTreeNode(T data,BinaryTree<T> tree)
        {
            _data = data;
            _parent = null;
            _lChild = null;
            _rChild = null;
            _tree = tree;
        }
    }
}
