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
                _count++;
                _set[_count] = value;
            }
        }

        public void Remove(T value)
        {

        }

        public bool Contains(T value)
        {
            return true;
        }
    }
}
