using System;


namespace DAMLib
{
    public class SetWithHash<T> : ISet<T>
    {
        T[] _set = Array.Empty<T>();
        int[] _hash = Array.Empty<int>();
        int _count = 0;

        public bool Empty => _count == 0;

        public int Count => _count;

        public void Add(T value)
        {
            if (!Contains(value) && value != null)
            {
                if (_set.Length > _count)
                {
                    _set[_count] = value;
                    _hash[_count] = value.GetHashCode();
                    _count++;
                }
                else
                {
                    T[] newSet;
                    int[] newHash;
                    newSet = new T[_count + 1];
                    newHash = new int[_count + 1];
                    for (int i = 0; i < _count; i++)
                    {
                        newSet[i] = _set[i];
                        newHash[i] = _hash[i];

                    }
                    newSet[_count] = value;
                    _hash[_count] = value.GetHashCode();
                    _set = newSet;
                    _count++;
                }
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
                _hash[_count - 1] = 0;
                _count--;
            }
        }


        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        private int IndexOf(T value)
        {
            int hash = value.GetHashCode();
            if (value != null)
                for (int i = 0; i < _count; i++)
                    if (hash == _hash[i] && _set[i].Equals(value))
                        return i;
            return -1;
        }

        public T GetElementAt(int i)
        {
            if ((i >= 0) || (i < _count))
                return _set[i];
            return default(T);
        }
    }
}

