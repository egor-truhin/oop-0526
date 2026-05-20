using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WorkersLib.Models
{
    public class TestCollections
    {
        private List<Worker> list1 = new();
        private List<string> list2 = new();

        private Dictionary<Person, Worker> dict1 = new();
        private Dictionary<string, Worker> dict2 = new();

        private int count;

        public TestCollections(int n = 1000)
        {
            count = n;

            Random rnd = new();

            for (int i = 0; i < n; i++)
            {
                Worker worker = new Worker();
                worker.RandomInit(rnd);

                // 1) List<Worker>
                list1.Add(worker);

                // 2) List<string>
                list2.Add(worker.ToString());

                // 3) Dictionary<Person, Worker>
                dict1.Add(worker.BasePerson, worker);

                // 4) Dictionary<string, Worker>
                dict2.Add(worker.ToString(), worker);
            }
        }

        public void Add(Worker worker)
        {
            list1.Add(worker);
            list2.Add(worker.ToString());
            dict1.Add(worker.BasePerson, worker);
            dict2.Add(worker.ToString(), worker);
        }

        public void Remove(Worker worker)
        {
            list1.Remove(worker);
            list2.Remove(worker.ToString());
            dict1.Remove(worker.BasePerson);
            dict2.Remove(worker.ToString());
        }

        private long Measure(Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.ElapsedTicks;
        }

        public void SearchTests()
        {
            var firstWorker = list1[0];
            var middleWorker = list1[list1.Count / 2];
            var lastWorker = list1[list1.Count - 1];

            Worker notExists = new Worker();
            notExists.RandomInit(new Random());

            Console.WriteLine("\n");
            Console.WriteLine("List<Worker> Contains:");

            Console.WriteLine("First: " + Measure(() => list1.Contains(firstWorker)));
            Console.WriteLine("Middle: " + Measure(() => list1.Contains(middleWorker)));
            Console.WriteLine("Last: " + Measure(() => list1.Contains(lastWorker)));
            Console.WriteLine("Not exists: " + Measure(() => list1.Contains(notExists)));

            Console.WriteLine("\n");
            Console.WriteLine("List<string> Contains:");

            Console.WriteLine("First: " + Measure(() => list2.Contains(firstWorker.ToString())));
            Console.WriteLine("Middle: " + Measure(() => list2.Contains(middleWorker.ToString())));
            Console.WriteLine("Last: " + Measure(() => list2.Contains(lastWorker.ToString())));
            Console.WriteLine("Not exists: " + Measure(() => list2.Contains(notExists.ToString())));

            Console.WriteLine("\n");
            Console.WriteLine("Dictionary<Person, Worker> ContainsKey:");

            Console.WriteLine("First: " + Measure(() => dict1.ContainsKey(firstWorker.BasePerson)));
            Console.WriteLine("Middle: " + Measure(() => dict1.ContainsKey(middleWorker.BasePerson)));
            Console.WriteLine("Last: " + Measure(() => dict1.ContainsKey(lastWorker.BasePerson)));
            Console.WriteLine("Not exists: " + Measure(() => dict1.ContainsKey(notExists.BasePerson)));

            Console.WriteLine("\n");
            Console.WriteLine("Dictionary<string, Worker> ContainsKey:");

            Console.WriteLine("First: " + Measure(() => dict2.ContainsKey(firstWorker.ToString())));
            Console.WriteLine("Middle: " + Measure(() => dict2.ContainsKey(middleWorker.ToString())));
            Console.WriteLine("Last: " + Measure(() => dict2.ContainsKey(lastWorker.ToString())));
            Console.WriteLine("Not exists: " + Measure(() => dict2.ContainsKey(notExists.ToString())));

            Console.WriteLine("\n");
            Console.WriteLine("Dictionary<Person, Worker> ContainsValue:");

            Console.WriteLine("First: " + Measure(() => dict1.ContainsValue(firstWorker)));
            Console.WriteLine("Middle: " + Measure(() => dict1.ContainsValue(middleWorker)));
            Console.WriteLine("Last: " + Measure(() => dict1.ContainsValue(lastWorker)));
            Console.WriteLine("Not exists: " + Measure(() => dict1.ContainsValue(notExists)));

            Console.WriteLine("\n");
            Console.WriteLine("Итог: Поиск по List - O(n), по Dictionary - O(1), так как использует хэш-таблицу");
            Console.WriteLine("ContainsValue в Dictionary - O(n), так как идет перебор каждого значения");
        }
    }
}
