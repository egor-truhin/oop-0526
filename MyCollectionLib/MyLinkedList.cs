using System;
using System.Collections;
using System.Collections.Generic;
using WorkersLib.Models;

namespace MyCollectionLib
{
    public class MyLinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        protected Node<T> head;
        protected int count;
        public int Count => count;
        public bool IsReadOnly => false;

        public MyLinkedList() {}

        public MyLinkedList(int capacity)
        {
            count = 0;
        }

        public MyLinkedList(MyLinkedList<T> c)
        {
            foreach (var item in c)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = node;
            }

            count++;
        }

        public void AddRange(params T[] items)
        {
            foreach (var item in items)
                Add(item);
        }

        public bool Remove(T item)
        {
            Node<T> current = head;
            Node<T> prev = null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (prev == null)
                        head = current.Next;
                    else
                        prev.Next = current.Next;

                    count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T item)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public MyLinkedList<T> DeepCopy()
        {
            MyLinkedList<T> copy = new MyLinkedList<T>();

            Node<T> current = head;

            while (current != null)
            {
                copy.Add(current.Data);
                current = current.Next;
            }

            return copy;
        }

        public MyLinkedList<T> ShallowCopy()
        {
            MyLinkedList<T> copy = new MyLinkedList<T>();

            copy.head = this.head;
            copy.count = this.count;

            return copy;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length - arrayIndex < count)
                throw new ArgumentException("Недостаточно места в массиве");

            Node<T> current = head;

            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }
    }
}
