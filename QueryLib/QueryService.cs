using System;
using System.Collections.Generic;
using System.Text;
using WorkersLib.Models;

namespace QueryLib
{
    public class QueryService
    {
        private readonly Company _company;

        public QueryService(Company company)
        {
            _company = company;
        }

        private IEnumerable<Worker> All()
            => _company.Departments.SelectMany(d => d.Value);

        // query syntax
        public IEnumerable<Worker> Where_Query_Administation()
        {
            return from d in _company.Departments
                   from p in d.Value
                   where p is Administration
                   select p;
        }

        // method syntax
        public IEnumerable<Worker> Where_Method_Administation()
        {
            return All().Where(p => p is Administration);
        }

        public IEnumerable<Worker> Union_Example()
        {
            return _company.Departments["IT"]
                .Union(_company.Departments["HR"]);
        }

        public IEnumerable<Worker> Except_Example()
        {
            return _company.Departments["IT"]
                .Except(_company.Departments["HR"]);
        }

        public IEnumerable<Worker> Intersect_Example()
        {
            return _company.Departments["IT"]
                .Intersect(_company.Departments["Finance"]);
        }

        public int SumAges()
        {
            return All().Sum(p => p.Age);
        }

        public int MaxAge()
        {
            return All().Max(p => p.Age);
        }

        public int MinAge()
        {
            return All().Min(p => p.Age);
        }

        public double AverageAge()
        {
            return All().Average(p => p.Age);
        }

        // query syntax
        public IEnumerable<IGrouping<string, Worker>> GroupBy_Query()
        {
            return from p in All()
                   group p by p.GetType().Name;
        }

        // method syntax
        public IEnumerable<IGrouping<string, Worker>> GroupBy_Method()
        {
            return All().GroupBy(p => p.GetType().Name);
        }

        public IEnumerable<LetNewType> Let_Query()
        {
            var query =
                from p in All()
                let level = p.Age > 30 ? "Senior" : "Junior"
                select new LetNewType
                {
                    Name = p.Name,
                    Age = p.Age,
                    Level = level
                };

            return query;
        }

        public IEnumerable<JoinNewType> Join_Example()
        {
            var query =
                from dept in _company.Departments
                from person in dept.Value
                select new JoinNewType
                {
                    Department = dept.Key,
                    Name = person.Name,
                    Salary = person.Salary
                };

            return query;
        }
    }
}
