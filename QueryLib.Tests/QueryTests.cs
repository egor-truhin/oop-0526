using WorkersLib.Models;

namespace QueryLib.Tests
{
    public class QueryTests
    {
        private readonly QueryService _service;

        public QueryTests()
        {
            var company = CompanyFactory.Create();
            _service = new QueryService(company);
        }

        [Fact]
        public void Where_Engineers_ShouldReturnOnlyEngineers()
        {
            var result = _service.Where_Method_Administation();

            Assert.All(result, p => Assert.IsType<Administration>(p));
        }

        [Fact]
        public void Where_Query_And_Method_ShouldMatch()
        {
            var q = _service.Where_Query_Administation().Count();
            var m = _service.Where_Method_Administation().Count();

            Assert.Equal(q, m);
        }

        [Fact]
        public void Union_ShouldNotBeEmpty()
        {
            var result = _service.Union_Example();

            Assert.NotEmpty(result);
        }

        [Fact]
        public void Except_ShouldReturnSubset()
        {
            var result = _service.Except_Example();

            Assert.All(result, p =>
            {
                Assert.Contains(p, CompanyFactory.Create().Departments["IT"]);
            });
        }

        [Fact]
        public void Intersect_ShouldBeValid()
        {
            var result = _service.Intersect_Example();

            Assert.NotNull(result);
        }

        [Fact]
        public void Sum_ShouldBeGreaterThanZero()
        {
            var sum = _service.SumAges();

            Assert.True(sum > 0);
        }

        [Fact]
        public void MaxMin_ShouldBeValidRange()
        {
            var max = _service.MaxAge();
            var min = _service.MinAge();

            Assert.True(max >= min);
        }

        [Fact]
        public void Average_ShouldBeInRange()
        {
            var avg = _service.AverageAge();

            Assert.InRange(avg, 0, 120);
        }

        [Fact]
        public void GroupBy_ShouldContainGroups()
        {
            var groups = _service.GroupBy_Method();

            Assert.NotEmpty(groups);
        }

        [Fact]
        public void GroupBy_ShouldGroupByType()
        {
            var groups = _service.GroupBy_Method();

            Assert.All(groups, g =>
            {
                Assert.NotNull(g.Key);
                Assert.NotEmpty(g);
            });
        }

        [Fact]
        public void Let_ShouldReturnProjectedData()
        {
            var result = _service.Let_Query();

            Assert.All(result, x =>
            {
                Assert.False(string.IsNullOrEmpty(x.Name));
                Assert.True(x.Age > 0);
            });
        }

        [Fact]
        public void Join_ShouldContainDepartmentData()
        {
            var result = _service.Join_Example();

            Assert.All(result, x =>
            {
                Assert.False(string.IsNullOrEmpty(x.Department));
                Assert.False(string.IsNullOrEmpty(x.Name));
                Assert.True(double.IsRealNumber(x.Salary));
            });
        }

        [Fact]
        public void Where_Linq_ShouldMatch_ManualLoop()
        {
            var linq = _service.Where_Method_Administation().Count();

            var company = CompanyFactory.Create();
            int loopCount = 0;

            foreach (var dept in company.Departments)
            {
                foreach (var person in dept.Value)
                {
                    if (person is Administration)
                        loopCount++;
                }
            }

            Assert.Equal(linq, loopCount);
        }
    }
}
