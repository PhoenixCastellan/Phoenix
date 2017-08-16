using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Collections.Generic
{
    public class LinkedListNode<T>:IDisposable
    {
        public T Value;
        public LinkedListNode<T> NextNode;
        public LinkedListNode<T> PreNode;
        public LinkedList<T> LinkedList;
        

        public LinkedListNode(T item)
        {
            Value = item;
            NextNode = null;
            PreNode = null;
            LinkedList = null;
        }

        //public LinkedListNode(T item, LinkedList<T> list)
        //{
        //    var node = new LinkedListNode<T>(item);
        //    node.LinkedList=
        //}

        public void Dispose()
        {
            this.Value = default(T);
            this.NextNode = null;
            this.PreNode = null;
            this.LinkedList = null;
        }
    }
}
