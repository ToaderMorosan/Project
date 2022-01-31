using SkillMatrix1.Models;
using SkillMatrix1.Repository;
using System.Linq;
using Xunit;

namespace SkillMatrix.Tests
{
    public class EmployeeTests : IClassFixture<SeedDataFixture>
    {
        SeedDataFixture fixture;
        public EmployeeTests(SeedDataFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void GetEmployees()
        {
            var sut = new EmployeeRepository(fixture.DataContext);
            //Act
            var interests = sut.GetEmployees();

            //Assert
            Xunit.Assert.Equal(3, interests.Count());
        }

        [Fact]
        public void CreateEmployee()
        {
            var sut = new EmployeeRepository(fixture.DataContext);
            var newEmployee = new Employee
            {
                Id = 24,
                Name = "NewEmployee",
                Ocupation = "NewEmployee",
                PhoneNumber = "NewEmployee",
                email = "NewEmployee",
                Description = "NewEmployee",
                github = "NewEmployee",
                instagram = "NewEmployee",
                address = "address"
            };
            //Act
            sut.CreateEmployee(1, 1, 1, newEmployee);
            var employees = sut.GetEmployees();

            //Assert
            Xunit.Assert.Equal(3, employees.Count());
        }
        [Fact]
        public void DeleteEmployee()
        {
            var sut = new EmployeeRepository(fixture.DataContext);
            //Act
            var employee = sut.GetEmployee(1);
            sut.DeleteEmployee(employee);
            var employees = sut.GetEmployees();

            //Assert
            Xunit.Assert.Equal(2, employees.Count());
        }

        [Fact]
        public void UpdateEmployee()
        {
            var sut = new EmployeeRepository(fixture.DataContext);
            var newEmployee = new Employee
            {
                Id = 2,
                Name = "UpdatedEmployee",
                Ocupation = "NewEmployee",
                PhoneNumber = "NewEmployee",
                email = "NewEmployee",
                Description = "NewEmployee",
                github = "NewEmployee",
                instagram = "NewEmployee",
                address = "address"
            };
            //Act
            sut.UpdateEmployee(newEmployee);
            var employee = sut.GetEmployee(2);
            //Assert
            Xunit.Assert.Equal(employee.Name, newEmployee.Name);
        }

    }
}
