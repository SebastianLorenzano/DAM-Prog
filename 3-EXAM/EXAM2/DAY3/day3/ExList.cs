using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace day3
{

    public class ExList<T>
    {
        public delegate void VisitDelegate(T value);
        public delegate bool SortDelegate(T value1, T value2);
        public delegate bool FilterDelegate(T value);

        private T[] _items = Array.Empty<T>();
        public int Count => _items.Length;
        public T First => _items.Length > 0 ? _items[0] : throw new IndexOutOfRangeException();

        public T Last => _items.Length > 0 ? _items[_items.Length - 1] : throw new IndexOutOfRangeException();

        public ExList<T> Reversed => Reverse();

        public ExList()
        {

        }

        public ExList(T[] items)
        {
            _items = ToArray(items);
        }

        public T? GetElementAt(int index)
        {
            if (index < 0 || index >= _items.Length)
                return default(T);
            return _items[index];
        }

        public void SetElementAt(int index, T value)
        {
            if (index < 0 || index >= _items.Length)
                return;
            _items[index] = value;
        }

        public void Add(T value)
        {
            int count = _items.Length;
            var result = new T[count + 1];
            for (int i = 0; i < count; i++)
            {
                result[i] = _items[i];
            }
            result[count] = value;
            _items = result;
        }

        public void RemoveAt(int index)
        {
            int count = _items.Length;
            if (index < 0 || index >= count)
                return;
            var result = new T[count - 1];
            for (int i = 0; i < index; i++)
                result[i] = _items[i];
            for (int i = index; i < result.Length; i++)
                result[i] = _items[i + 1];
            _items = result;
        }

        public void Clear()
        {
            _items = new T[0];
        }

        public void Insert(int index, T value)
        {
            int count = _items.Length;
            if (index < 0 || index >= count)
                return;

            var result = new T[count + 1];
            for (int i = 0; i < index; i++)
            {
                result[i] = _items[i];
            }
            result[index] = value;
            for (int i = index + 1; i < count; i++)
            {
                result[i] = _items[i - 1];
            }
            _items = result;
        }

        private int IndexOf(T value)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(value))
                    return i;
            }
            return -1;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) >= 0;
        }


        public void Visit(VisitDelegate del)
        {
            if (del == null)
                return;
            for (int i = 0; i < _items.Length; i++)
                del(_items[i]);
        }


        public void Sort(SortDelegate del)
        {
            if (del == null)
                return;
            for (int i = 0; i < _items.Length - 1;i++)
            {
                for (int j = i + 1; j < _items.Length; j++)
                {
                    if (!del(_items[i], _items[j]))
                    {
                        var aux = _items[i];
                        _items[i] = _items[j];
                        _items[j] = aux;
                    }
                }
            }
        }

        public T[] Filter(FilterDelegate del)
        {
            if (del == null || _items.Length == 0)
                return new T[0];
            var result = new List<T>();
            for (int i = 0; i < _items.Length; i++)
            {
                if (del(_items[i]))
                    result.Add(_items[i]);
            }
            return result.ToArray();
        }

        private ExList<T> Reverse()
        {
            int count = _items.Length;
            if (count == 0)
                return new ExList<T>();
            var result = new T[count];
            int j = count - 1;
            for (int i = 0; i <= j; i++)
            {
                j = count - 1 - i;
                result[i] = _items[j];
                result[j] = _items[i];
            }
            return new ExList<T>(result);
        }

        public ExList<T> Clone()
        {
            return new ExList<T>(_items);
        }

        public T[] ToArray()
        {
            return ToArray(_items);
        }

        public static T[] ToArray(T[] array)
        {
            if (array == null)
                return new T[0];
            var result = new T[array.Length];
            for (int i = 0; i <  array.Length; i++)
                result[i] = array[i];
            return result;
        }
    }
}
