using System;
using System.Reflection.Metadata.Ecma335;

namespace DAMLib
{
    public class Queue <T>
    {
        private T[] _queue = Array.Empty<T>();
        private int _count = 0;

        public int Count 
        {
            get => _count;
        }
#nullable disable
        public T First => _count > 0 ? _queue[0] : default(T);

        public T Last => _count > 0 ? _queue[_count - 1] : default(T);
#nullable enable
        public bool Empty
        {
            get => _queue.Length == 0;
        }

        public void InQueue(T value)
        {
            T[] newQueue;
            if (_queue.Length > Count)
            {
                _queue[_count] = value;
                _count++;
            }

            else
            {
                newQueue = new T[_count + 1];
                for (int i = 0; i < _count; i++)
                    newQueue[i] = _queue[i];
                newQueue[_count] = value;
                _count++;
                _queue = newQueue;
            }
        }

        public T DeQueue()
        {
            if (_count == 0)
                return default(T);
            T result = _queue[0];
            T[] newQueue;
            newQueue = new T[_count + 1];
            for (int i = 0 ; i < _count - 1 ; i++)
                newQueue[i] = _queue[i + 1];
            _queue = newQueue;
            return result;
        }
    }
}
