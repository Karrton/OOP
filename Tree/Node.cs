using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    [Serializable]
    public class Node<T> where T : IComparable<T>
    {
        private T data;
        private Node<T> left;
        private Node<T> right;

        public Node()
        {
            data = default(T);
            left = null;
            right = null;
        }

        public object GetObject()
        {
            return data;
        }

        public Node(T data)
        {
            this.data = data;
            left = null;
            right = null;
        }

        public T GetData()
        {
            return data;
        }

        public void SetData(T data)
        {
            this.data = data;
        }

        public Node<T> GetLeft()
        {
            return left;
        }

        public void SetLeft(Node<T> left)
        {
            this.left = left;
        }

        public Node<T> GetRight()
        {
            return right;
        }

        public void SetRight(Node<T> right)
        {
            this.right = right;
        }
    }
}
