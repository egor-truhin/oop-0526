using System;
using System.Collections;
using System.Collections.Generic;
using WorkersLib.Models;

namespace MyCollectionLib
{
    public class MyDoublyLinkedList<T>: IEnumerable<T>, ICollection<T> where T : Person
    {
        protected Node<T> head;
        protected Node<T> tail;
        protected int count;

        public int Count => count;
        public bool IsReadOnly => false;

        public MyDoublyLinkedList() { }

        public MyDoublyLinkedList(int capacity)
        {
            count = 0;
        }

        public MyDoublyLinkedList(MyDoublyLinkedList<T> c)
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
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
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

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        tail = current.Prev;

                    count--;
                    return true;
                }

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

        public MyDoublyLinkedList<T> DeepCopy()
        {
            MyDoublyLinkedList<T> copy = new MyDoublyLinkedList<T>();

            Node<T> current = head;

            while (current != null)
            {
                copy.Add((T)current.Data.Clone());
                current = current.Next;
            }

            return copy;
        }

        public MyDoublyLinkedList<T> ShallowCopy()
        {
            MyDoublyLinkedList<T> copy = new MyDoublyLinkedList<T>();

            copy.head = this.head;
            copy.tail = this.tail;
            copy.count = this.count;

            return copy;
        }

        public void Clear()
        {
            head = null;
            tail = null;
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

        public T Find(string name)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Name.Contains(name))
                    return current.Data;

                current = current.Next;
            }

            return null;
        }
    }
}
