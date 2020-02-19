using System;

namespace Niipazzo.DataStructures
{
    public class List<T>
    {
        int capacity = 4;
        T[] data = null;
        bool hasHole = false;
        private static object _lock = new object();

        public List()
        {
            data = new T[capacity];
        }

        public void Add(T item)
        {
            lock (_lock)
            {
                //double list capacity
                if (data.Length == capacity)
                {
                    capacity *= 2;
                    var temp = new T[capacity];
                    Array.Copy(data, 0, temp, 0, data.Length);
                    data = temp;
                }

                data[data.Length] = item;
            }
        }

        public void Remove(T value)
        {
            lock (_lock)
            {
                //find element
                //remove element
                //update hasHole
            }
        }

        private int IndexOf(T item)
        {

        }
    }
}
