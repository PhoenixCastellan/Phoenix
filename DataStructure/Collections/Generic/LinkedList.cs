using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Collections.Generic
{
    public class LinkedList<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        private int _size;

        public int Count => _size;
        public LinkedListNode<T> Head => _head;
        public LinkedListNode<T> Tail => _tail;

        public LinkedList()
        {
            _size = 0;
        }

        public LinkedListNode<T> AddFirst(T item)
        {
            if (_size == 0)
            {
                var node = new LinkedListNode<T>(item);
                node.PreNode = null;
                node.NextNode = null;
                node.LinkedList = this;
                _tail = _head = node;
                _size += 1;
            }
            else
            {
                var node =new LinkedListNode<T>(item);
                _head.PreNode = node;
                node.NextNode = _head;
                node.PreNode = null;
                node.LinkedList = this;

                _head = node;
                _size += 1;
            }
            return _head;
        }

        public LinkedListNode<T> AddLast(T item)
        {
            var newNode = new LinkedListNode<T>(item);
            if (_size == 0)
            {
                newNode.PreNode = null;
                newNode.NextNode = null;
                newNode.LinkedList = this;
                _tail = _head = newNode;
                _size += 1;
            }
            else
            {
                _tail.NextNode = newNode;
                newNode.PreNode = _tail;
                newNode.NextNode = null;
                newNode.LinkedList = this;

                _tail = newNode;
                _size += 1;
            }
            return _tail;
        }

        public LinkedListNode<T> InsertBefore(LinkedListNode<T> positionNode, T item)
        {
            if (positionNode.PreNode == null)
            {
                if (positionNode != _head)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    this.AddFirst(item);
                    return _head;
                }
            }
            else
            {
                var preNode = positionNode.PreNode;
                var newNode = new LinkedListNode<T>(item);

                newNode.LinkedList = this;

                LinkTwoNode(preNode,newNode);
                LinkTwoNode(newNode,positionNode);

                _size += 1;
                return newNode;
            }
        }
        
        public LinkedListNode<T> InsertAfter(LinkedListNode<T> positionNode, T item)
        {
            if (positionNode.NextNode == null)
            {
                if (positionNode != _tail)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    this.AddLast(item);
                    return _tail;
                }
            }
            else
            {
                var nextNode = positionNode.NextNode;
                var newNode = new LinkedListNode<T>(item);

                newNode.LinkedList = this;

                LinkTwoNode(positionNode,newNode);
                LinkTwoNode(newNode,nextNode);

                _size += 1;

                return newNode;
            }
        }


        public void Clear()
        {
            if (_head == null && _tail == null)
            {
                _size = 0;
            }
            else if (_head == null && _tail != null)
            {
                while (_tail != null)
                {
                    var node = _tail.PreNode;
                    _tail = null;
                    _tail = node;
                }
            }
            else
            {
                while (_head != null)
                {
                    var node = _head.NextNode;
                    _head.Dispose();
                    _head = node;
                }
            }
            _tail = null;
            _size = 0;
        }

        private void LinkTwoNode(LinkedListNode<T> node, LinkedListNode<T> nextNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            if (nextNode == null)
            {
                throw new ArgumentNullException(nameof(nextNode));
            }

            node.NextNode = nextNode;
            nextNode.PreNode = node;
        }
    }
}
