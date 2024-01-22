using System;


namespace DAMLib
{

    delegate bool DictionaryFilterDelegate<K, V>(K key, V value);


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

        }

        public void Add(K key, V value)
        {

        }

        public void AddOrReplace(K key, V value)
        {

        }

        public bool Contains(K key)
        {
            return false;
        }

        int IndexOf()
        {
            return 0;
        }


        public void Remove(K key)
        {

        }

        public V GetValueWithKey(K key)
        {

        }

        public bool TryGetValue(K key, out V value)
        {

        }

        public Dictionary<K, V> Filter(DictionaryFilterDelegate<K, V> where)
        {
            for (int i = 0; i < _count; i++)
            {
                Item item = _items[i];
                bool addToNewDictionary = where(item.key, item.value);
            }
        }



    }
}
