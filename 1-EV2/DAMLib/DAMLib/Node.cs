
namespace DAMLib
{
    delegate void VisistDelegate<T>(Node<T> node);
    public class Node<T>
    {
        public T _item;
        List<Node<T>> _children = new();
        Node<T>? _parent;

        public Node<T>? Parent 
        { 
            get => _parent; 
            set => _parent = value; 
        }
        public List<Node<T>> Children => _children;

        public bool IsRoot => _parent == null;
        public bool IsLeaf => _children.Count == 0;
        public int ChildrenCount => _children.Count;
        public int Level => GetLevel();
        public Node<T> Root => GetRoot();

        public int GetLevel()
        { 
            int level = 0;
            var parent = _parent;
            while (parent != null)
            {
                level++;
                parent = parent._parent;
            }
            return level;
        }

        public Node<T> GetRoot()
        {
            if (_parent == null)
                return this;
            return _parent.GetRoot();
        }

        public bool Contains(Node<T> node) 
        {
            if (node == null)
                return false;
            return (IndexOf(node) >= 0);
        }

        private int IndexOf(Node<T> node)
        {
            for(int i = 0;  i < _children.Count; i++) 
            {
                var c = _children[i];
                if (node == c)
                    return i;
            }
            return -1;
        }

        public Node<T>? GetChildAt(int index)
        {
            if (index < 0 || index >= _children.Count)
                return null;
            return _children[index];
        }

        public void Unlink()
        {
            if (_parent == null)
                return;
            int index = _parent.IndexOf(this);
            if (index >= 0)
                _parent._children.RemoveAt(index);
            _parent = null;                             
        }                                               
        public void AddChild(Node<T> node)
        {
            if (node == null)
                return;
            node.Unlink();
            _children.Add(node);
        }

        public void SetParent(Node<T> node)
        {
            if (node == null)
                _parent = null;
            else
                node.AddChild(this);
        }

        public bool ContainsAscestor(Node<T> node)
        {
            if (node == null || _parent == null && this != node)
                return false;
            if (this == node)
                return true;
            return _parent.ContainsAscestor(node);
        }

        public bool ContainsDescendant(Node<T> node)
        {
            if (node == null) 
                return false;
            if (this == node) 
                return true;
            for (int i = 0; i< _children.Count; i++)
            {
                var c = _children[i];
                if (c == node || c.ContainsDescendant(node)) 
                    return true;
            }
            return false;
        }

        bool IsSibling(Node<T> node)
        {
            if (node == null || _parent == null)
                return false;
            if (this == node)                                   
                return false;
            return _parent.Contains(node);
        }

        public 

    }
}
