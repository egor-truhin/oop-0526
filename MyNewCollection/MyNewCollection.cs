using MyNewCollection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MyCollectionLib;
using WorkersLib.Models;

namespace MyNewCollectionLib
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class MyNewCollection<T> : MyDoublyLinkedList<T> where T : Person
    {
        public string Name { get; set; } = "";

        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public MyNewCollection() : base() { }

        public MyNewCollection(int capacity) : base(capacity) { }

        protected void OnCountChanged(string type, T item)
        {
            CollectionCountChanged?.Invoke(
                this,
                new CollectionHandlerEventArgs("MyLinkedList", type, item.ToString())
            );
        }

        protected void OnReferenceChanged(T item)
        {
            CollectionReferenceChanged?.Invoke(
                this,
                new CollectionHandlerEventArgs("MyLinkedList", "Reference changed", item.ToString())
            );
        }

        public T this[int index]
        {
            get => GetByIndex(index);
            set
            {
                SetByIndex(index, value);
                OnReferenceChanged(value);
            }
        }

        protected T GetByIndex(int index)
        {
            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Data;
        }

        protected void SetByIndex(int index, T value)
        {
            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            current.Data = value;
        }

        public void AddDefaults(int n, Func<T> generator)
        {
            for (int i = 0; i < n; i++)
            {
                T item = generator();
                Add(item);
                OnCountChanged("Added", item);
            }
        }

        public void Add(T item)
        {
            base.Add(item);
            OnCountChanged("Added", item);
        }

        public bool Remove(int index)
        {
            T item = this[index];

            bool result = base.Remove(item);

            if (result)
                OnCountChanged("Removed", item);

            return result;
        }
    }
}
