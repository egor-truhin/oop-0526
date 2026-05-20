using System;
using WorkersLib.Models;

namespace QueryLib
{
    public class Company
    {
        public Dictionary<string, Stack<Worker>> Departments { get; set; }
            = new();
    }

    public class LetNewType
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Level { get; set; }
    }

    public class JoinNewType
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    public static class CompanyFactory
    {
        public static Company Create()
        {
            var c = new Company();

            c.Departments["IT"] = new Stack<Worker>();
            c.Departments["HR"] = new Stack<Worker>();
            c.Departments["Finance"] = new Stack<Worker>();
            c.Departments["Other"] = new Stack<Worker>();

            c.Departments["IT"].Push(new Engineer { Name = "A", Age = 30, Salary = 1000 });
            c.Departments["IT"].Push(new Worker { Name = "B", Age = 25, Salary = 2000 });

            c.Departments["HR"].Push(new Administration { Name = "C", Age = 40, Salary = 3000 });
            c.Departments["HR"].Push(new Worker { Name = "D", Age = 22, Salary = 1000 });

            c.Departments["Finance"].Push(new Engineer { Name = "E", Age = 35, Salary = 4000 });
            c.Departments["Finance"].Push(new Administration { Name = "F", Age = 45, Salary = 5000 });

            c.Departments["Other"].Push(new Engineer { Name = "G", Age = 37, Salary = 6000 });
            c.Departments["Other"].Push(new Worker { Name = "H", Age = 67, Salary = 7000 });

            return c;
        }
    }
}
