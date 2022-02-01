using SkillMatrix1.Models;
using SkillMatrix1.Repository;
using System.Linq;
using Xunit;
namespace SkillMatrix.Tests
{
    public class InterestsTests : IClassFixture<SeedDataFixture>
    {
        SeedDataFixture fixture;
        public InterestsTests(SeedDataFixture fixture)
        {
            this.fixture = fixture;
        }
 
        [Fact]
        public void GetInterests()
        {
            // Use a clean instance of the context to run the test
            var sut = new InterestRepository(fixture.DataContext);
            //Act
            var interests = sut.GetInterests();

            //Assert
            Xunit.Assert.Equal(3, interests.Count());
        }

        [Fact]
        public void CreateInterest()
        {
            var sut = new InterestRepository(fixture.DataContext);
            var newInterest = new Interest
            {
                Id = 23,
                Name = "Soccer"
            };
            //Act
            var interest = sut.CreateInterest(newInterest);
            var interests = sut.GetInterests();

            //Assert
            Xunit.Assert.Equal(4, interests.Count());
        }
        [Fact]
        public void DeleteInterest()
        {

            // Use a clean instance of the context to run the test
            var sut = new InterestRepository(fixture.DataContext);
            //Act
            var interest = sut.GetInterest(1);
            sut.DeleteInterest(interest);
            var interests = sut.GetInterests();

            //Assert
            Xunit.Assert.Equal(3, interests.Count());
            
        }
        [Fact]
        public void UpdateInterest()
        {
            var sut = new InterestRepository(fixture.DataContext);
            var newInterest = new Interest
            {
                Id = 2,
                Name = "UpdatedInterest",
            };
            //Act
            sut.UpdateInterest(newInterest);
            var employee = sut.GetInterest(2);
            //Assert
            Xunit.Assert.Equal(employee.Name, newInterest.Name);

        }
    }
}