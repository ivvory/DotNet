using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace Generics
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
        }

        private Node<T> _root;
        private IComparer<T> _comparer;

        public BinaryTree(IComparer<T> comparer)
        {
            this._comparer = comparer;
        }

        private int Compare(T fst, T snd)
        {
            if (this._comparer == null)
            {
                return (fst as IComparable<T>).CompareTo(snd);
            }
            else
            {
                return this._comparer.Compare(fst, snd);
            }
        }

        private Node<T> Insert(T v, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>();
                node.Value = v;
            }
            else if (Compare(v, node.Value) < 0)
            {
                node.Left = Insert(v, node.Left);
            }
            else
            {
                node.Right = Insert(v, node.Right);
            }

            return node;
        }

        private static IEnumerable<T> NodePreorder(Node<T> root)
        {
            if (root != null)
            {
                yield return root.Value;
                
                foreach (var v in NodePreorder(root.Left))
                {
                    yield return v;
                }
                foreach (var v in NodePreorder(root.Right))
                {
                    yield return v;
                }
            }
        }

        private static IEnumerable<T> NodeInorder(Node<T> root)
        {
            if (root != null)
            {
                foreach (var v in NodeInorder(root.Left))
                {
                    yield return v;
                }
                
                yield return root.Value;
                
                foreach (var v in NodeInorder(root.Right))
                {
                    yield return v;
                }
            }
        }

        private IEnumerable<T> NodePostorder(Node<T> root)
        {
            if (root != null)
            {
                foreach (var v in NodePostorder(root.Left))
                {
                    yield return v;
                }
                foreach (var v in NodePostorder(root.Right))
                {
                    yield return v;
                }
                yield return root.Value;
            }
        }
        
        public BinaryTree()
        {
            this._root = null;
        }

        public void Insert(T v)
        {
            if (this._root == null)
            {
                this._root = new Node<T>();
                this._root.Value = v;
            }
            else
            {
                Insert(v, this._root);
            }
        }

        public IEnumerable<T> Preorder()
        {
            foreach (var v in NodePreorder(this._root))
            {
                yield return v;
            }
        }
        public IEnumerable<T> Inorder()
        {
            foreach (var v in NodeInorder(this._root))
            {
                yield return v;
            }
        }
        public IEnumerable<T> Postorder()
        {
            foreach (var v in NodePostorder(this._root))
            {
                yield return v;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var v in Inorder())
            {
                yield return v;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()  
        {  
            return GetEnumerator();  
        }  
    }
}