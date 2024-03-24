using System;


namespace DAMLib
{

    public delegate bool DictionaryFilterDelegate<K, V>(K key, V value);


    public class Dictionary<K, V>
    {
        private int _count = 0;
        private class Item
        {
            public K key;
            public V value;
        }

        private Item[] _items = Array.Empty<Item>();

        public int Count => 0;

        public bool IsEmpty => _count == 0;

        public void Clear()
        {
            _count = 0;
        }

        public void Add(K key, V value)
        {
            if (key != null && value != null && !Contains(key))
            {
                if (_items.Length > _count)
                {
                    _items[_count].key = key;
                    _items[_count].value = value;
                    _count++;
                }
                else
                {
                    Item[] newItems;
                    newItems = new Item[_count + 1];

                    for (int i = 0; i < _count; i++)
                    {
                        newItems[i] = _items[i];

                    }
                    Item newItem = new()
                    {
                        key = key,
                        value = value
                    };
                    newItems[_count] = newItem;
                    _items = newItems;
                    _count++;
                }
            }
        }


        public void AddOrReplace(K key, V value)
        {
            if (key == null)
                return;
            int index = IndexOf(key);
            if (index < 0)
                Add(key, value);
            else
            {
                _items[index].key = key;
                _items[index].value = value;
            }

        }

        public bool Contains(K key)
        {
            return IndexOf(key) >= 0;
        }

        int IndexOf(K key)
        {
            if (key == null)
                return -1;
            for (int i = 0; i < _count; i++)
                if (_items[i].key.Equals(key))
                    return i;
            return -1;
        }


        public void Remove(K key)
        {
            if (key == null)
                return;
            for (int i = 0; i < _count; i++)
                if (_items[i].key.Equals(key))
                {
                    _items[i] = _items[_count - 1];
                    _count--;
                    return;
                }           
        }

        public V GetValueWithKey(K key)
        {
            int index = IndexOf(key);
            if (index < 0)
                new ArgumentException("Key was not found.");
            return _items[index].value;
        }

        public bool TryGetValue(K key, out V value)
        {
            value = default(V);
            int index = IndexOf(key);
            if (index < 0)
                return false;
            value = _items[index].value;
            return true;
        }

        public Dictionary<K, V> Filter(DictionaryFilterDelegate<K, V> where)
        {
            if (where == null)
                throw new Exception();
            Dictionary<K, V> result = new();
            for (int i = 0; i < _count; i++)
            {
                Item item = _items[i];
                bool addToNewDictionary = where(item.key, item.value);
                if (addToNewDictionary)
                    result.Add(item.key, item.value);
            }
            return result;
        } 

        public Dictionary<K, V> Remove(DictionaryFilterDelegate<K, V> where)
        {
            if (where == null)
                throw new Exception();
            Dictionary<K, V> result = new();        //TODO: Se clona la lista y despues se le saca las cosas, sin tocar la lista original
            for (int i = 0; i < _count; i++)
            {
                Item item = _items[i];
                bool removeFromNewDictionary = where(item.key, item.value);
                if (removeFromNewDictionary)
                    Remove(item.key);
            }
            return this;
        }




    }
}
