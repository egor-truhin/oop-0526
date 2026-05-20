using System;
using System.Collections.Generic;
using System.Text;
using WorkersLib.Models;

namespace WorkersLib.Comparers
{
    public class SalaryComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x is Worker wx && y is Worker wy)
                return wx.Salary.CompareTo(wy.Salary);

            return 0;
        }
    }
}
