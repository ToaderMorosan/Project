using Microsoft.EntityFrameworkCore;
using SkillMatrix1.Data;
using SkillMatrix1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
//[assembly: CollectionBehavior(MaxParallelThreads = 1)]

namespace SkillMatrix.Tests
{
    //[CollectionDefinition(DisableParallelization = true)]
    public class SeedDataFixture2 : IDisposable
    {
        public DataContext DataContext { get; private set; }

        public SeedDataFixture2()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .EnableSensitiveDataLogging(true)
                .UseInMemoryDatabase($"SkillDataBase2")
                .Options;
            DataContext = new DataContext(options);
            DataContext.Interests.Add(new Interest { Id = 1, Name = "Interest 1" });
            DataContext.Interests.Add(new Interest { Id = 2, Name = "Interest 2" });
            DataContext.Interests.Add(new Interest { Id = 3, Name = "Interest 3" });
            DataContext.DevTools.Add(new DevTool { Id = 1, Name = "DevTool 1", Proficiency = 67 });
            DataContext.Skills.Add(new Skill { Id = 1, Name = "Skill 1", Proficiency = 67 });
            DataContext.Employees.Add(new Employee { Id = 1, Name = "Employee 1", address = "address1", Description = "description1", email = "email1", Ocupation = "ocupation1", github = "github1", instagram = "instagram1", PhoneNumber = "phone1" });
            DataContext.Employees.Add(new Employee { Id = 2, Name = "Employee 2", address = "address2", Description = "description2", email = "email2", Ocupation = "ocupation2", github = "github2", instagram = "instagram2", PhoneNumber = "phone2" });
            DataContext.Employees.Add(new Employee { Id = 3, Name = "Employee 3", address = "address3", Description = "description3", email = "email3", Ocupation = "ocupation3", github = "github3", instagram = "instagram3", PhoneNumber = "phone3" });
            DataContext.SaveChanges();
            foreach (var entity in DataContext.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
