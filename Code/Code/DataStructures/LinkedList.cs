using System.Linq;
using cg = System.Collections.Generic;

namespace Niipazzo.DataStructures
{
    public class LinkedList<T>
    {
        private cg.List<LinkedListNode<T>> Nodes { get; }

        public LinkedList()
        {
            Nodes = new cg.List<LinkedListNode<T>>();
        }

        public LinkedListNode<T> First
        {
            get
            {
                return Nodes.FirstOrDefault();
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                return Nodes.LastOrDefault();
            }
        }

        public void Add(LinkedListNode<T> node)
        {
            node.Next = null; //sanity check
            if (Last != null)
            {
                Last.Next = node;
            }
            Nodes.Add(node);
        }
    }

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }
}
