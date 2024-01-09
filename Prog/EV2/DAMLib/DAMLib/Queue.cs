using System;
using System.Reflection.Metadata.Ecma335;

namespace DAMLib
{
    public class Queue <T>
    {
        private T[] _queue = new T[0];
        private int _count = 0;

        public int Count 
        {
            get => _count;
        }

        public T First => _count > 0 ? _queue[0] : default(T);

        public T Last => _count > 0 ? _queue[_count - 1] : default(T);

        public bool Empty
        {
            get => _queue.Length == 0;
        }

        public void InQueue(T value)
        {
            int aux = Count;
            T[] newQueue;
            if (_queue.Length > aux)
            {
                _queue[aux] = value;
                _count += 1;
            }

            else
            {
                newQueue = new T[aux + 1];
                for (int i = 0; i < Count - 1; i++)
                    newQueue[i] = _queue[i];
                newQueue[Count] = value;
                _queue = newQueue;
            }
        }

        public T DeQueue()
        {
            T var1;
            return var1;
        }

    }
}
