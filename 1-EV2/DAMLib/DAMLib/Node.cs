
namespace DAMLib
{
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
            Node<T>? node = this;
            while (node != null)
            {
                level++;
                node = node._parent;
            }
            return level;
        }

        public Node<T> GetRoot()
        {
            if (_parent == null)
                return this;
            return _parent.GetRoot();
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
            _parent._children.Remove(this);         //Antes de que critiques el uso de Remove(), lei la documentación
            _parent = null;                             // y vi el proceso que hace. Simplemente llama a un IndexOf() 
        }                                               // y hace un RemoveAt() de esa posición si es >= 0, asi que es 
                                                        // completamente legal. 
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

        public bool ContainsAscendant(Node<T> node)
        {
            if (node == null || _parent == null && this != node)
                return false;
            if (this == node)
                return true;
            return _parent.ContainsAscendant(node);
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




    }
}
