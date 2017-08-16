using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Collections.Generic
{
    public class Queue<T>
    {
        private T[] _array;

        private int _head;
        private int _tail;

        public Queue()
        {
            _array = new T[10];
            _head = -1;
            _tail = -1;
        }

        public T Dequeue()
        {
            if (_head == -1 && _tail == -1)
            {
                throw new ArgumentOutOfRangeException();
            }

            T item = _array[_head];
            _head += 1;
            return item;
        }

        public void Enqueue(T item)
        {
            
        }
    }
    
}
