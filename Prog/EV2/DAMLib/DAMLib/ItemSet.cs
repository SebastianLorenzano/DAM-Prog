using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMLib
{
    public class ItemSet<T>
    {
        /* 
         Hacer un Binary Search a traves del cual se comparen los Hash para encontrar mas rapido el objeto.
         Para hacer eso, organizar la lista.
        Cuando este todo hecho, intentar hacer que el Add funcione mas rapido. para hacer eso, cuando busca usando el Binary Search y no lo encuentra, recuerda la posicion donde termino, mueve la lista
            Una para adelante y pone el nuevo item de la lista en la posicion que debe.
         */
        private class Item
        {
            public T element; 
            public int hash;

            internal Item(T element, int hash)
            {
                this.element = element;
                this.hash = hash;
            }
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
                        newItems[i] = _items[i];      

                    newItems[_count] = new(value, value.GetHashCode());
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
                    RearrangeAfterRemove(index);
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
                {
                    if (hash == _items[i].hash && _items[i].element.Equals(value))
                        return i;
                }

            return -1;
        }

        public T GetElementAt(int i)
        {
            if ((i >= 0) || (i < _count))
                return _items[i].element;
            return default(T);
        }

        public void RearrangeAfterRemove(int index)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
        }



        public void OrderByHash()
        {
            Item aux;
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = i + 1; j < _count; j++)
                {
                    if (_items[i].hash > _items[j].hash)
                    {
                        aux = _items[i];
                        _items[i] = _items[j];
                        _items[j] = aux;
                    }
                }
            }
        }

        private int BinarySearch(T element)
        {
            int hash = element.GetHashCode();
            int min = _items[0].hash;
            int max = _items[_count - 1].hash;
            if (min < hash || hash > max)
                return -1;
            while (min < max)
            {
                int mid = (max + min) / 2;
                if (hash == _items[mid].hash)
                    return EqualHash(mid, element);
                else if (_items[mid].hash < hash)
                    min = mid + 1;
                else if (_items[mid].hash > hash)
                    max = mid - 1;
            }
            return -1;
        }

        private int EqualHash(int index, T element)
        {
            int hash = _items[index].hash;
            for (int i = index + 1;; i++)
            {
                if (_items[i].hash != hash)
                    break;
                if (_items[i].element.Equals(element))
                    return i;
            }
            for (int i = index - 1; ; i--)
            {
                if (_items[i].hash != hash)
                    break;
                if (_items[i].element.Equals(element))
                    return i;
            }
            
            /*                  
             *      
            for (int i = index + 1; _items[i].hash == _items[index].hash; i++)
            {
                if (element.Equals(_items[i].element))
                    return i;
            }
            for (int i = index - 1; _items[i].hash == _items[index].hash; i--)
            {
                if (element.Equals(_items[i].element))
                    return i;
            }
            */

            return -1;
        }
    }

}

