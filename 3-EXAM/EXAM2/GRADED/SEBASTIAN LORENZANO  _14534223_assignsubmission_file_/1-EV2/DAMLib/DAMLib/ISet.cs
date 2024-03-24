using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMLib
{
    public interface ISet<T>
    {
        bool Empty { get; }
        int Count { get; }
        void Add(T item);
        void Remove(T item);
        bool Contains(T item);
    }
}
