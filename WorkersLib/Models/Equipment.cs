using System;
using System.Collections.Generic;
using System.Text;
using WorkersLib.Interfaces;

namespace WorkersLib.Models
{
    public class Equipment : IInit
    {
        public string Name { get; set; }

        public void Init()
        {
            Console.Write("Оборудование: ");
            Name = Console.ReadLine();
        }

        public void RandomInit(Random rnd)
        {
            Name = $"Device_{rnd.Next(100)}";
        }

        public override string ToString()
        {
            return $"Equipment: {Name}";
        }
    }
}
