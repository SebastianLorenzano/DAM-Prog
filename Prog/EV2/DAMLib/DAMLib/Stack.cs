
namespace DAMLib
{
    public class Stack<T>
    {
        public class DAMLib
        {
            private T[] _stack = new T[0];


            public void Push(T newElement)
            {
                var result = new T[_stack.Length + 1];
                for (int i = 0; i < _stack.Length; i++)
                {
                    result[i] = _stack[i];
                }
                result[_stack.Length] = newElement;
            }

            public T Pop()
            {
                return _stack[_stack.Length - 1];
            }


            public T GetTop()
            {

                return _stack[_stack.Length - 1];

            }

            public bool IsEmpty()
            {
                return _stack.Length == 0;
            }

            public int GetCount()
            {
                return _stack.Length;
            }




        }
    }
}
