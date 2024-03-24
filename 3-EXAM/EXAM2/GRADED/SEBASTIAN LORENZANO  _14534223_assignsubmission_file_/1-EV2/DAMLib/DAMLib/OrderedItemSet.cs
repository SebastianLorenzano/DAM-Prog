using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAMLib
{
    public class OrderedItemSet<T> : ISet<T>
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

        public void Add(T element)
        {
            if (element == null)
                return;
            int indexContains = -1;
            int indexDestined = 0;
            int hash = element.GetHashCode();
            IndexOf(element, hash, out indexContains, out indexDestined);     // TODO: TENGO QUE HACER QUE ESTA FUNCION RECIBA CON OUT 2 INTS, UNO LA POSICION DEL OBJETO (-1 SI NO ESTA) Y OTRO LA POSICION
                                            // QUE TENDRIA QUE TENER EL OBJETO SI ESTUVIESE
            if (indexContains < 0)
            {
                // Javi: Te acercas bastante, pero esto no es correcto. Si se mete en el if
                // se fastidia todo
                if (_items.Length > _count)
                {
                    _items[_count].element = element;
                    _items[_count].hash = element.GetHashCode();
                    _count++;
                }
                else
                {
                    _count++;
                    Item[] newItems;
                    newItems = new Item[_count];

                    for (int i = 0; i < indexDestined; i++)
                        newItems[i] = _items[i];
                    newItems[indexDestined] = new (element, element.GetHashCode());
                        for (int i = indexDestined + 1; i < _count; i++)
                            newItems[i] = _items[i - 1];
                    _items = newItems;
                }
            }
        }
        // Javi: guia de estilo
public void Remove(T element)
        {
            int indexContains = -1;
            int indexDestined = -1;
            int hash = element.GetHashCode();
            IndexOf(element, hash, out indexContains, out indexDestined);
            if (indexContains >= 0)
            {
                if (_items.Length > 1)
                    RearrangeAfterRemove(indexContains);
                _items[_count - 1].element = default(T);
                _items[_count-- - 1].hash = 0;
            }
        }


        public bool Contains(T value)
        {
            if (value == null)
                return false;
            int indexContains = -1;
            int indexDestined = 0;
            int hash = value.GetHashCode();
            IndexOf(value, hash, out indexContains, out indexDestined);
            return indexContains >= 0;
        }

        // Javi: Está perfecto, pero yo hubiese hecho que al menos devolviera un bool
        public void IndexOf(T element, int hash, out int indexContains, out int indexDestined)
        {
            indexContains = -1;
            indexDestined = 0;
            if (element == null || _items.Length == 0) 
                return;
            int min = 0;
            int max = _count - 1;
            if (_items[min].hash > hash || hash > _items[max].hash)
                return;
            while (min < max)
            {
                indexContains = min;
                int mid = (max + min) >> 1;     
                int midHash = _items[mid].hash;
                if (midHash == hash)
                    EqualHash(mid, element, hash, out indexContains, out indexDestined);
                else if (midHash < hash)
                    min = mid + 1;
                else if (midHash > hash)
                    max = mid - 1;
            }
        }

        public T GetElementAt(int i)
        {
            // Javi: una linea
            if ((i >= 0) || (i < _count))
                return _items[i].element;
            return default(T);
        }

        public void RearrangerBeforeAdd(int index)
        {
            for (int i = _count - 1; i > index; i++)
            {

            }
        }

        public void RearrangeAfterRemove(int index)
        {
            for (int i = index; i < _count - 1; i++)
            {

                _items[i] = _items[i + 1];
            }
        }

        // Javi: Public no!!!!!!!!!!!!!!!!!!!
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

        private void EqualHash(int index, T element, int hash, out int indexContains, out int indexDestined)
        {
            indexContains = -1;
            indexDestined = -1;
            // Javi: Fos fors que hacen lo mismo
            for (int i = index + 1; index < _count - 1; i++)
            {
                if (_items[i].hash != hash)
                    break;
                if (_items[i].element.Equals(element))
                {
                    indexContains = i;
                    return;
                }
                else
                    indexDestined = i;
            }

            for (int i = index - 1; index >= 0; i--)
            {
                if (_items[i].hash != hash)
                    break;
                if (_items[i].element.Equals(element))
                {
                    indexContains = i;
                    return;
                }
                else
                    indexDestined = i;
            }
            return;
        }
    }

}

