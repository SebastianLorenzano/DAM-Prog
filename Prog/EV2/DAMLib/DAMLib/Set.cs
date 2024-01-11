using System;
using System.Linq.Expressions;

namespace DAMLib
{
    public class Set<T>
    {
        T[] _set = Array.Empty<T>();
        int _count = 0;
        
        public bool Empty => _count == 0;

        public int Count => _count;

        public void Add(T value)
        {
            if (!Contains(value))
            if (_set.Length > _count)
            {
                _set[_count] = value;
                _count++;
            }
            else
            {
                T[] newSet;
                newSet = new T[_count + 1];
                for (int i = 0; i < _count; i++)
                    newSet[i] = _set[i];
                _set[_count] = value;
                _count++;
            }
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index != -1)
            {
                T[] newSet;
                int aux = 0;
                newSet = new T[_count - 1];
                for (int i = 0; i < _count - 1; i++)
                {
                    if (i != index)
                    {
                        newSet[aux] = _set[i];
                        aux++;
                    }
                }
            }
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < _set.Length; i++)
                if (_set[i].Equals(value))
                    return i;
            return -1;
        }
    }
}
