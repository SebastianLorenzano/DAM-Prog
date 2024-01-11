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
                newSet[_count] = value;
                _set = newSet;
                _count++;
            }
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                if (_set.Length > 1)
                 _set[index] = _set[_count - 1];
                _set[_count - 1] = default(T);
                _count--;
            }
        }
        

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < _count; i++)
                if (_set[i].Equals(value))
                    return i;
            return -1;
        }
    }
}
