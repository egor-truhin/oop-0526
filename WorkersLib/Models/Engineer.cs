using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersLib.Models
{
    public class Engineer : Worker
    {
        public string Level { get; set; }

        public Engineer() : base()
        {
            Level = "Junior";
        }
        public Engineer(string name, int age, double salary, string level)
            : base(name, age, salary)
        {
            Level = level;
        }

        public Engineer(Engineer other) : base(other)
        {
            Level = other.Level;
        }

        public override void Show()
        {
            Console.WriteLine($"Engineer: {Name}, Age: {Age}, Salary: {Salary}, Level: {Level}");
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            string[] levels = { "Junior", "Middle", "Senior" };
            Level = levels[rnd.Next(levels.Length)];
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Уровень: ");
            Level = Console.ReadLine();
        }

        public override Engineer Clone()
        {
            return new Engineer(this);
        }
    }
}
