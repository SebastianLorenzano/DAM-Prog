﻿
using System.Collections.Generic;

namespace DAMLib
{
    public delegate bool CheckDelegate<T>(Node<T> node);
    public class Node<T>
    {
        public T _item;
        List<Node<T>> _children = new();
        Node<T>? _parent;

        public Node<T>? Parent 
        { 
            get => _parent;
            set => SetParent(value!);           //El signo de exclamacion lo que hace aqui es sacar la advertencia de null, 
        }                                           //es equivalente a poner una instruccion #nullable disable #nullable enable 
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
                if (node == _children[i])
                    return i;
            }
            return -1;
        }

        public Node<T>? GetChildAt(int index)
        {
            return (index < 0 || index >= _children.Count) ? null : _children[index];
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
            {
                _parent = null;
                return;
            }
            if (Contains(node))
                throw new ArgumentException("Tried Adding its own child as a Parent.");
            node.AddChild(this);
        }

        public bool ContainsAscestor(Node<T> node)
        {
            if (node == null || _parent == null && this != node)
                return false;
            if (this == node)
                return true;
            return _parent!.ContainsAscestor(node);
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

        public bool IsSibling(Node<T> node)
        {
            if (node == null || _parent == null)
                return false;
            if (this == node)                                   
                return false;
            return _parent.Contains(node);
        }

        public Node<T>? FindNode(CheckDelegate<T> checker)
        {
            if (checker == null)
                return null;
            if (checker(this))
                return this;
            for (int i = 0; i < _children.Count; i++)
            {
                var child = _children[i];
                var result = child.FindNode(checker);
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

            for (int i = 0; i < _children.Count; i++)
                _children[i].FindNodes(checker, result);
        }
        
        public List<Node<T>> Filter(CheckDelegate<T> checker)
        {
            return FindNodes(checker);
        }
    }
}

