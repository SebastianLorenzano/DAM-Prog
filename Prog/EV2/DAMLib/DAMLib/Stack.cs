
namespace DAMLib
{
    public class Stack<T>
    {
        public class DAMLib
        {
            private T[] _stack = Array.Empty<T>();


            public void Push(T newElement)
            {
                var result = new T[_stack.Length + 1];
                for (int i = 0; i < _stack.Length; i++)
                {
                    result[i] = _stack[i];
                }
                result[_stack.Length] = newElement;
                _stack = result;
            }

            public T Pop()
            {
                if (IsEmpty())
                    return default(T);
                T result = _stack[_stack.Length - 1];
                var newStack = new T[_stack.Length - 1];
                for (int i = 0; i < newStack.Length; i++)
                {
                    newStack[i] = _stack[i];
                }
                _stack = newStack;
                return result;
            }


            public T GetTop()
            {
                if (IsEmpty())
                    return default(T);
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
