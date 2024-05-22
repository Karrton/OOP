using LabLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    [Serializable]
    public class Tree<T> : IEnumerable<T>, ICollection<T> where T : IComparable<T>
    {
        private Node<T> root;
        private int count;
        [NonSerialized]
        private static Random rnd = new Random();

        public Node<T> GetRoot()
        {
            return root;
        }
        public int Count => count;
        public bool IsReadOnly => false;

        public Tree()
        {
            root = null;
        }

        public Tree(Tree<T> tree)
        {
            if (tree.root != null)
            {
                this.root = Clone(tree.root);
            }
        }

        public Tree(int capacity)
        {
            root = CreateEmptyTreeWithCapacityRecursive(capacity);
        }

        public static Challenge GetChallenge()
        {
            Challenge temp = null;
            int num = rnd.Next(1, 4);
            switch (num)
            {
                case 0: temp = new Challenge(); break;
                case 1: temp = new Exam(); break;
                case 2: temp = new FinalExam(); break;
                case 3: temp = new Test(); break;
                default: throw new Exception("Число должно быть в пределах от 0, до 4");
            }

            temp.RandomInit();
            return temp;
        }

        private Node<T> CreateEmptyTreeWithCapacityRecursive(int capacity)
        {
            if (capacity <= 0)
            {
                return null;
            }

            int mid = capacity / 2;
            Node<T> newNode = new Node<T>();
            newNode.SetLeft(CreateEmptyTreeWithCapacityRecursive(mid));
            newNode.SetRight(CreateEmptyTreeWithCapacityRecursive(capacity - mid - 1));
            count++;
            return newNode;
        }

        public void AddNode(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (root == null)
            {
                root = newNode;
                count++;
                return;
            }

            Node<T> current = root;
            Node<T> parent = null;

            while (current != null)
            {
                parent = current;
                if (Comparer<T>.Default.Compare(data, current.GetData()) < 0)
                {
                    current = current.GetLeft();
                }
                else if (Comparer<T>.Default.Compare(data, current.GetData()) > 0)
                {
                    current = current.GetRight();
                }
                else
                {
                    return;
                }
            }

            if (Comparer<T>.Default.Compare(data, parent.GetData()) < 0)
            {
                parent.SetLeft(newNode);
            }
            else
            {
                parent.SetRight(newNode);
            }
            count++;
        }

        public void RemoveNode(T data)
        {
            if (root == null) return;

            Node<T> current = root;
            Node<T> parent = null;

            while (current != null)
            {
                int comparison = Comparer<T>.Default.Compare(data, current.GetData());
                if (comparison == 0)
                {
                    break;
                }
                parent = current;
                if (comparison < 0)
                {
                    current = current.GetLeft();
                }
                else
                {
                    current = current.GetRight();
                }
            }

            if (current == null) return;

            if (current.GetRight() == null && current.GetLeft() == null)
            {
                if (parent != null)
                {
                    if (parent.GetLeft() == current)
                    {
                        parent.SetLeft(null);
                    }
                    else
                    {
                        parent.SetRight(null);
                    }
                }
                else
                {
                    root = null;
                }
            }
            else if (current.GetRight() != null && current.GetLeft() == null)
            {
                if (parent != null)
                {
                    if (parent.GetLeft() == current)
                    {
                        parent.SetLeft(current.GetRight());
                    }
                    else
                    {
                        parent.SetRight(current.GetRight());
                    }
                }
                else
                {
                    root = current.GetRight(); 
                }
                current.SetRight(null); 
            }
            else if (current.GetRight() == null && current.GetLeft() != null)
            {
                if (parent != null)
                {
                    if (parent.GetLeft() == current)
                    {
                        parent.SetLeft(current.GetLeft());
                    }
                    else
                    {
                        parent.SetRight(current.GetLeft());
                    }
                }
                else
                {
                    root = current.GetLeft(); 
                }
                current.SetLeft(null); 
            }
            else
            {
                // Узел имеет обоих потомков
                Node<T> successor = FindSuccessor(current);
                T successorData = successor.GetData();
                RemoveNode(successorData); 
                current.SetData(successorData); 
            }

            count--;
        }

        private Node<T> FindSuccessor(Node<T> node)
        {
            Node<T> current = node.GetRight();
            while (current.GetLeft() != null)
            {
                current = current.GetLeft();
            }
            return current;
        }

        public void PrintTree()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пустое");
                return;
            }

            PrintTree(root, 0);
        }

        private void PrintTree(Node<T> node, int depth)
        {
            if (node == null)
            {
                return;
            }

            PrintTree(node.GetRight(), depth + 1);

            Console.WriteLine($"{new string(' ', depth * 2)}{node.GetData()}");

            PrintTree(node.GetLeft(), depth + 1);
        }

        public void BuildBalancedTree(List<T> sortedList)
        {
            root = BuildBalancedTreeRecursive(sortedList, 0, sortedList.Count - 1);
        }

        private Node<T> BuildBalancedTreeRecursive(List<T> sortedList, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            Node<T> newNode = new Node<T>(sortedList[mid]);

            newNode.SetLeft(BuildBalancedTreeRecursive(sortedList, start, mid - 1));
            newNode.SetRight(BuildBalancedTreeRecursive(sortedList, mid + 1, end));

            return newNode;
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = Height(node.GetLeft());
            int rightHeight = Height(node.GetRight());

            // Высота дерева равна максимальной из высот поддеревьев плюс один (за счет текущего узла)
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        private Node<T> Clone(Node<T> node)
        {
            if (node == null)
                return null;

            Node<T> newNode = new Node<T>(node.GetData());
            newNode.SetLeft(Clone(node.GetLeft()));
            newNode.SetRight(Clone(node.GetRight()));

            return newNode;
        }

        public Tree<T> ShallowCopy()
        {
            Tree<T> newTree = new Tree<T>();
            newTree.root = root;
            return newTree;
        }

        public void DeleteTree()
        {
            Clear(root);
            root = null;
            count = 0;
        }

        private void Clear(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            Clear(node.GetLeft());
            Clear(node.GetRight());

            node.SetLeft(null);
            node.SetRight(null);
        }

        public Node<T> Search(T data)
        {
            Node<T> current = root;
            while (current != null)
            {
                int comparison = Comparer<T>.Default.Compare(data, current.GetData());
                if (comparison == 0)
                {
                    return current;
                }
                else if (comparison < 0)
                {
                    current = current.GetLeft();
                }
                else
                {
                    current = current.GetRight();
                }
            }
            return null;
        }

        public bool Equals(Tree<T> otherTree)
        {
            if (otherTree == null)
            {
                return false;
            }

            return AreTreesEqual(root, otherTree.root);
        }

        private bool AreTreesEqual(Node<T> node1, Node<T> node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }
            else if (node1 == null || node2 == null)
            {
                return false;
            }
            else
            {
                if (!node1.GetData().Equals(node2.GetData()))
                {
                    return false;
                }

                return AreTreesEqual(node1.GetLeft(), node2.GetLeft()) && AreTreesEqual(node1.GetRight(), node2.GetRight());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(root);
        }

        private IEnumerable<T> InOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                foreach (var data in InOrderTraversal(node.GetLeft()))
                    yield return data;

                yield return node.GetData();

                foreach (var data in InOrderTraversal(node.GetRight()))
                    yield return data;
            }
        }

        public void Add(T item)
        {
            AddNode(item);
        }

        public void Clear()
        {
            DeleteTree();
        }

        public bool Contains(T item)
        {
            return Search(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                RemoveNode(item);
                return true;
            }
            return false;
        }
    }
}
