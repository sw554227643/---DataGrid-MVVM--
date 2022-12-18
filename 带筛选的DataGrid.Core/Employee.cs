using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 带筛选的DataGrid.Core
{
    public class Employee
    {
        public int Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public int Salay { get; set; }

        public static Employee FakeOne() => employeeFaker.Generate();

        public static IEnumerable< Employee> FakeMany(int count ) => employeeFaker.Generate(count);


        private static readonly Faker<Employee> employeeFaker = new Faker<Employee>()
            .RuleFor(x => x.Id, x => x.IndexFaker)
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.Birthday, x => DateOnly.FromDateTime(x.Person.DateOfBirth))
            .RuleFor(x => x.Salay, x => x.Random.Int(6, 30) * 1000);
    }
}
