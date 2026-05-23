using System;
using System.Linq;
using Xunit;
using MyCollectionLib;
using WorkersLib.Models;

namespace MyCollections.Tests
{
    public class MyDoublyLinkedListTests
    {
        private MyDoublyLinkedList<Person> list;

        public MyDoublyLinkedListTests()
        {
            list = new MyDoublyLinkedList<Person>();
        }

        [Fact]
        public void Add_ShouldIncreaseCount()
        {
            list.Add(new Worker());
            list.Add(new Engineer());

            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenElementExists()
        {
            var worker = new Worker();

            list.Add(worker);

            Assert.True(list.Contains(worker));
        }

        [Fact]
        public void Remove_ShouldDecreaseCount()
        {
            var worker = new Worker();
            var engineer = new Engineer();

            list.Add(worker);
            list.Add(engineer);

            bool result = list.Remove(worker);

            Assert.True(result);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Foreach_ShouldIterateAllElements()
        {
            var w1 = new Worker();
            var w2 = new Worker();

            list.Add(w1);
            list.Add(w2);

            var result = list.ToList();

            Assert.Equal(2, result.Count);
            Assert.Contains(w1, result);
            Assert.Contains(w2, result);
        }

        [Fact]
        public void Clear_ShouldEmptyList()
        {
            list.Add(new Worker());
            list.Add(new Engineer());

            list.Clear();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void CopyTo_ShouldCopyElements()
        {
            var w1 = new Worker();
            var w2 = new Worker();

            list.Add(w1);
            list.Add(w2);

            Person[] arr = new Person[5];

            list.CopyTo(arr, 1);

            Assert.Equal(w1, arr[1]);
            Assert.Equal(w2, arr[2]);
        }
    }
}
