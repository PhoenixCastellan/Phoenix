using System;
using System.Collections.Generic;

namespace DataStructure.Collections.Tree
{
    public class BinaryTree<T>:IBinaryTree<T> where T:IComparable
    {
        private BinaryTreeNode<T> _root;


        public BinaryTreeNode<T> GetRoot()
        {
            return _root;
        }

        public BinaryTreeNode<T> Add(T data)
        {
            var newNode = new BinaryTreeNode<T>(data,this);

            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                if (_root.Data.CompareTo(data) < 0)
                {
                    if (_root.LeftChild == null)
                    {
                        _root.LeftChild = newNode;
                        newNode.Parent = _root;
                    }
                    else if (_root.RightChild == null)
                    {
                        _root.RightChild = newNode;
                        newNode.Parent = _root;
                    }
                    else
                    {
                        if (_root.LeftChild.NumOfChild > _root.RightChild.NumOfChild)
                        {

                        }
                        else
                        {
                            
                        }
                    }
                }
                
            }

            return newNode;
        }

        private void AddNode(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            if (node.Data.CompareTo(newNode.Data) > 0)
            {
                node.Parent?.
            }
            else
            {
                
            }
        }

        public bool Remove(BinaryTreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        public IList<T> PreorderTraversal()
        {
            throw new NotImplementedException();
        }

        public IList<T> InorderTraversal()
        {
            throw new NotImplementedException();
        }

        public IList<T> PostorderTraversal()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
