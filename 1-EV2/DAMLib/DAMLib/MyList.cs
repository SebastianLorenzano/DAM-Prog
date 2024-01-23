
using System;
using System.Runtime.CompilerServices;

namespace DAMLib
{
    public class MyList<T>
    {
        /*
         
        0   This get set                                                             
        0   MyList()
        0   MyList(int)
        0   public void Add(T element)
        0   public void RemoveAt(int index)
        0   public void Clear()
        0   public bool Contains(T element)
        0   public T GetLast()
        0   public T GetFirst()
        0   public MyList<T> Clone()
        0   public int IndexOf(T element)
        0   public int[] IndexesOf(T element)
        0   public static MyList<T> operator +(T element, MyList<T> list)
        0   public static bool operator ==(MyList<T> list1, MyList<T> list2)
        0   public static bool operator !=(MyList<T> list1, MyList<T> list2)

        */
        private T[] _array = Array.Empty<T>();
        private int _count = 0;

        public int Capacity => _array.Length;
        public int Count => _count;
        public bool Empty => _array.Length == 0;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();
                _array[index] = value;
            }
        }

        public MyList()
        {

        }

        public MyList(int index)
        {
            _array = new T[index];
            _count = index;
        }

        public void Add(T element)
        {
            //TODO
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            //TODO
            throw new NotImplementedException();
        }
        public void Clear()
        {
            //TODO
            throw new NotImplementedException();
        }
        public bool Contains(T element)
        {
            //TODO
            throw new NotImplementedException();
        }
        public T GetLast()
        {
            //TODO
            throw new NotImplementedException();
        }
        public T GetFirst()
        {
            //TODO
            throw new NotImplementedException();
        }
        public MyList<T> Clone()
        {
            //TODO
            throw new NotImplementedException();
        }
        public int IndexOf(T element)
        {
            //TODO
            throw new NotImplementedException();
        }
        public int[] IndexesOf(T element)
        {
            //TODO
            throw new NotImplementedException();
        }
        public static MyList<T> operator +(T element, MyList<T> list)
        {
            //TODO
            throw new NotImplementedException();
        }
        public static bool operator == (MyList<T> list1, MyList<T> list2)
        {
            //TODO
            throw new NotImplementedException();
        }
        public static bool operator != (MyList<T> list1, MyList<T> list2)
        {
            //TODO
            throw new NotImplementedException();
        }


    }
}
