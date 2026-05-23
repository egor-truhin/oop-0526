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

            Worker perA = new Engineer { Name = "A", Age = 30, Salary = 1000 };
            Worker perB = new Worker { Name = "B", Age = 25, Salary = 2000 };
            Worker perC = new Administration { Name = "C", Age = 40, Salary = 3000 };
            Worker perD = new Worker { Name = "D", Age = 22, Salary = 1000 };
            Worker perE = new Engineer { Name = "E", Age = 35, Salary = 4000 };
            Worker perF = new Administration { Name = "F", Age = 45, Salary = 5000 };
            Worker perG = new Engineer { Name = "G", Age = 37, Salary = 6000 };
            Worker perH = new Worker { Name = "H", Age = 67, Salary = 7000 };

            c.Departments["IT"].Push(perA);
            c.Departments["IT"].Push(perB);
            c.Departments["IT"].Push(perC);
            c.Departments["IT"].Push(perD);

            c.Departments["HR"].Push(perC);
            c.Departments["HR"].Push(perD);
            c.Departments["HR"].Push(perE);
            c.Departments["HR"].Push(perF);

            c.Departments["Finance"].Push(perE);
            c.Departments["Finance"].Push(perF);
            c.Departments["Finance"].Push(perB);
            c.Departments["Finance"].Push(perD);

            c.Departments["Other"].Push(perG);
            c.Departments["Other"].Push(perH);

            return c;
        }
    }
}
