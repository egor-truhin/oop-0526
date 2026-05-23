using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersLib.Models
{
    public class Worker : Person
    {
        protected double salary;
        protected int experience;

        // Свойство для получения ссылки на объект базового класса
        public Person BasePerson
        {
            get => this;
        }

        public double Salary
        {
            get => salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Зарплата < 0");
                salary = value;
            }
        }

        public int Experience
        {
            get => experience;
            set
            {
                if (value < 0 || value > 60)
                    throw new ArgumentException("Недопустимый стаж");
                experience = value;
            }
        }

        public Worker() : base()
        {
            Salary = 0;
        }

        public Worker(string name, int age, double salary)
            : base(name, age)
        {
            Salary = salary;
        }

        public Worker(Worker other) : base(other)
        {
            Salary = other.Salary;
            Experience = other.Experience;
        }

        public override void Show()
        {
            Console.WriteLine($"Worker: {Name}, Age: {Age}, Salary: {Salary}, Exp: {Experience}");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Зарплата: ");
            Salary = double.Parse(Console.ReadLine());
            Console.Write("Стаж: ");
            Experience = int.Parse(Console.ReadLine());
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Salary = rnd.Next(30000, 100000);
            Experience = rnd.Next(0, 40);
        }

        public override bool Equals(object obj)
        {
            return obj is Worker w && base.Equals(w) && Salary == w.Salary;
        }

        public override Worker Clone()
        {
            return new Worker(this);
        }

        // Привести к строке с информацией
        public override string ToString()
        {
            return $"{base.ToString()}, Salary: {salary}, Experience: {experience}";
        }
    }
}
