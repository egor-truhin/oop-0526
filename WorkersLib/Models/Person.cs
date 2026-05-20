using System;
using System.Collections.Generic;
using System.Text;
using WorkersLib.Interfaces;

namespace WorkersLib.Models
{
    public abstract class Person : IInit, IComparable<Person>, ICloneable
    {
        protected string name;
        protected int age;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым");
                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentException("Недопустимый возраст");
                age = value;
            }
        }

        protected Person()
        {
            Name = "Без имени";
            Age = 0;
        }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        protected Person(Person other)
        {
            Name = other.Name;
            Age = other.Age;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Person: {Name}, Age: {Age}");
        }

        public virtual void Init()
        {
            Console.Write("Имя: ");
            Name = Console.ReadLine();
            Console.Write("Возраст: ");
            Age = int.Parse(Console.ReadLine());
        }

        public virtual void RandomInit(Random rnd)
        {
            Name = $"Person_{rnd.Next(100)}";
            Age = rnd.Next(18, 80);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person p)
                return Name == p.Name && Age == p.Age;
            return false;
        }

        public virtual int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        public abstract object Clone();

        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone();
        }

        // Привести к строке с информацией
        public override string ToString()
        {
            return Name;
        }
    }
}
