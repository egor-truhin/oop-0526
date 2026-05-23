using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersLib.Models
{
    public class Administration : Engineer
    {
        public string Department { get; set; }

        public Administration()
        {
            Department = "General";
        }

        public Administration(string name, int age, double salary, string level, string dept)
            : base(name, age, salary, level)
        {
            Department = dept;
        }

        public Administration(Administration other) : base(other)
        {
            Department = other.Department;
        }

        public override void Show()
        {
            Console.WriteLine(
                $"Admin: {Name}, Age: {Age}, Salary: {Salary}, Level: {Level}, Dept: {Department}"
            );
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            string[] deps = { "HR", "IT", "Finance" };
            Department = deps[rnd.Next(deps.Length)];
        }

        public override bool Equals(object obj)
        {
            return obj is Administration a && base.Equals(a) && Department == a.Department;
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Отдел: ");
            Department = Console.ReadLine();
        }

        public override Administration Clone()
        {
            return new Administration(this);
        }
    }
}
