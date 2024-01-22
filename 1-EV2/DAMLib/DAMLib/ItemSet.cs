using System;


namespace DAMLib
{
    public class ItemSet<T> : ISet<T>
    {
        private class Item
        {
            public T element; 
            public int hash;

        }

        Item[] _items = Array.Empty<Item>();
        int _count = 0;

        public bool Empty => _count == 0;

        public int Count => _count;

        public void Add(T value)
        {
            if (!Contains(value) && value != null)
            {
                if (_items.Length > _count)
                {
                    _items[_count].element = value;
                    _items[_count].hash = value.GetHashCode();
                    _count++;
                }
                else
                {
                    Item[] newItems;
                    newItems = new Item[_count + 1];

                    for (int i = 0; i < _count; i++)
                    {
                        newItems[i].element = _items[i].element;
                        newItems[i] = _items[i];

                    }
                    newItems[_count].element = value;
                    newItems[_count].hash = value.GetHashCode();
                    _items = newItems;
                    _count++;
                }
            }
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                if (_items.Length > 1)
                    _items[index] = _items[_count - 1];
                _count--;
            }
        }


        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(T value)
        {
            int hash = value.GetHashCode();
            if (value != null)
                for (int i = 0; i < _count; i++)
                    if (hash == _items[i].hash && _items[i].element.Equals(value))
                        return i;
            return -1;
        }

        public T GetElementAt(int i)
        {
            if ((i >= 0) || (i < _count))
                return _items[i].element;
            return default(T);
        }
    }

}

