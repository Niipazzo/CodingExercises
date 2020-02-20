using System;
using System.Linq;

namespace Niipazzo.DataStructures
{
    /// <summary>
    /// Simple example of LinkedList (single-linked)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        private int capacity = 4;

        private LinkedListNode<T>[] Nodes { get; }

        public LinkedList()
        {
            Nodes = new LinkedListNode<T>[capacity];
        }

        public int Count { get; private set; } = 0;

        public LinkedListNode<T> First
        {
            get
            {
                return Count > 0 ? Nodes[0] : null;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                return Count > 0 ? Nodes[Count - 1] : null;
            }
        }

        public void Add(T value)
        {
            Add(new LinkedListNode<T>(value));
        }

        private void Add(LinkedListNode<T> node)
        {
            if (node.Next != null) throw new ArgumentException("New node has to have Next=null"); //sanity check

            if (Last != null) // If last not null then update next
            {
                Last.Next = node;
            }

            Nodes[Count++] = node;
        }
    }

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
        }
    }
}
