using WorkersLib;
using WorkersLib.Comparers;
using WorkersLib.Models;
using Xunit;

public class PersonTests
{
    [Fact]
    public void Age_ShouldThrow_WhenNegative()
    {
        Person p = new Worker();
        Assert.Throws<ArgumentException>(() => p.Age = -5);
    }

    [Fact]
    public void Equals_ReturnsTrue_ForSameData()
    {
        Worker w1 = new Worker("Alex", 30, 50000);
        Worker w2 = new Worker("Alex", 30, 50000);

        Assert.True(w1.Equals(w2));
    }

    [Fact]
    public void Sort_ByName_WorksCorrectly()
    {
        Person[] arr =
        {
            new Worker { Name = "Petr" },
            new Worker { Name = "Ivan" },
            new Worker { Name = "Egor" }
        };

        Array.Sort(arr);

        Assert.Equal("Egor", arr[0].Name);
        Assert.Equal("Petr", arr[2].Name);
    }

    [Fact]
    public void SalaryComparer_SortsCorrectly()
    {
        Person[] arr =
        {
            new Worker { Salary = 50000 },
            new Worker { Salary = 30000 }
        };

        Array.Sort(arr, new SalaryComparer());

        Assert.Equal(30000, ((Worker)arr[0]).Salary);
    }

    [Fact]
    public void Clone_CreatesIndependentCopy()
    {
        Engineer e1 = new Engineer();
        e1.Level = "Junior";

        Engineer e2 = (Engineer)e1.Clone();
        e1.Level = "Senior";

        Assert.Equal("Junior", e2.Level);
    }

}