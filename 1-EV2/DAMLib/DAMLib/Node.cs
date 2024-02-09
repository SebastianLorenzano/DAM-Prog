
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DAMLib
{
    public delegate bool CheckDelegate<T>(Node<T> node);
    public class Node<T>
    {
        public T? _item;
        List<Node<T>> _children;
        WeakReference<Node<T>?> _parent;        //TODO: Make _parent work at the beggining as null and for it to create when needed

        public Node<T>? Parent
        {
            get
            {
                if (_parent == null)
                    return null;
                Node<T>? parent;
                _parent.TryGetTarget(out parent);
                return parent;
            }

            set => SetParent(value!);           //El signo de exclamacion lo que hace aqui es sacar la advertencia de null, 
        }                                           //es equivalente a poner una instruccion #nullable disable
        public bool IsRoot => Parent == null;
        public bool IsLeaf => _children == null || _children.Count == 0;
        public int ChildrenCount
        {
            get
            {
                if (_children == null)
                    return 0;
                return _children.Count;
            }
        }
        public int Level => GetLevel();
        public Node<T> Root => GetRoot();


        public Node()
        {

        }

        public Node(T? item) : this()
        {
            _item = item;
        }

        public int GetLevel()
        { 
            int level = 0;
            var parent = Parent;
            while (parent != null)
            {
                level++;
                parent = parent.Parent;
            }
            return level;
        }

        public Node<T> GetRoot()
        {
            var parent = Parent;
            if (parent == null)
                return this;
            return parent.GetRoot();
        }

        public bool Contains(Node<T> node) 
        {
            if (node == null)
                return false;
            return IndexOf(node) >= 0;
        }

        private int IndexOf(Node<T> node)
        {
            for(int i = 0;  i < _children.Count; i++) 
            {
                if (_children[i] == node)
                    return i;
            }
            return -1;
        }

        public Node<T>? GetChildAt(int index)
        {
            return (index < 0 || index >= ChildrenCount) ? null : _children[index];
        }

        public void Unlink()
        {
            var parent = Parent;
            if (parent == null)
                return;
            int index = parent.IndexOf(this);
            if (index >= 0)
                parent._children.RemoveAt(index);       //Preguntar a Javi si hace falta usar SetTarget o al modificar
            _parent.SetTarget(null);                      // la variable strong se modifica el Target             
        }                                               
        public void AddChild(Node<T> node)
        {
            if (node == null)
                return;
            if (_children == null)
                _children = new();
            node.Unlink();
            node._parent.SetTarget(this);
            if (_children == null)
                _children = new();
            _children.Add(node);
        }

        public void SetParent(Node<T>? node)
        {
            if (node == null)
            {
                if (_parent != null)
                    Unlink(); 
                return;
            }
            if (_parent == null)
                _parent = new WeakReference<Node<T>?>(null);
            if (_children != null && Contains(node))
                throw new ArgumentException("Tried Adding its own child as a Parent.");
            node.AddChild(this);
        }

        public bool ContainsAscestor(Node<T> node)
        {
            if (node == null || Parent == null && this != node)
                return false;
            if (this == node)
                return true;
            return Parent!.ContainsAscestor(node);
        }

        public bool ContainsDescendant(Node<T> node)
        {
            if (node == null) 
                return false;
            if (this == node) 
                return true;
            int n = ChildrenCount;
            for (int i = 0; i < n; i++)
            {
                var c = _children[i];
                if (c == node || c.ContainsDescendant(node)) 
                    return true;
            }
            return false;
        }

        public bool IsSibling(Node<T> node)
        {
            if (node == null || Parent == null)
                return false;
            if (this == node)                                   
                return false;
            return Parent.Contains(node);
        }

        public Node<T>? FindNode(CheckDelegate<T> checker)
        {
            if (checker == null)
                return null;
            if (checker(this))
                return this;
            int n = ChildrenCount;
            for (int i = 0; i < n; i++)
            {
                var result = _children[i].FindNode(checker);
                if (result != null)
                    return result;
            }
            return null;
        }

        public List<Node<T>> FindNodes(CheckDelegate<T> checker)
        {
            var list = new List<Node<T>>();
            if (checker == null)
                return list;
            FindNodes(checker, list);
            return list;
        }

        public void FindNodes(CheckDelegate<T> checker, List<Node<T>> result)
        {
            if (checker(this))
                result.Add(this);
            int n = ChildrenCount;
            for (int i = 0; i < n; i++)
                _children[i].FindNodes(checker, result);
        }
        
        public List<Node<T>> Filter(CheckDelegate<T> checker)
        {
            return FindNodes(checker);
        }
    }
}

