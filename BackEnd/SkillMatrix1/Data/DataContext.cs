using Microsoft.EntityFrameworkCore;
using SkillMatrix1.Models;

namespace SkillMatrix1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<DevTool> DevTools { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<EmployeeDevTool> EmployeeDevTools { get; set; }
        public DbSet<EmployeeInterest> EmployeeInterests { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInterest>()
                .HasKey(ei => new { ei.EmployeeId, ei.InterestId });
            modelBuilder.Entity<EmployeeInterest>()
                .HasOne(e => e.Employee)
                .WithMany(ei => ei.EmployeeInterests)
                .HasForeignKey(i => i.EmployeeId);
            modelBuilder.Entity<EmployeeInterest>()
                .HasOne(e => e.Interest)
                .WithMany(ei => ei.EmployeeInterests)
                .HasForeignKey(i => i.InterestId);
            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(ei => new { ei.EmployeeId, ei.SkillId });
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(e => e.Employee)
                .WithMany(ei => ei.EmployeeSkills)
                .HasForeignKey(i => i.EmployeeId);
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(e => e.Skill)
                .WithMany(ei => ei.EmployeeSkills)
                .HasForeignKey(i => i.SkillId);
            modelBuilder.Entity<EmployeeDevTool>()
                .HasKey(ei => new { ei.EmployeeId, ei.DevToolId });
            modelBuilder.Entity<EmployeeDevTool>()
                .HasOne(e => e.Employee)
                .WithMany(ei => ei.EmployeeDevTools)
                .HasForeignKey(i => i.EmployeeId);
            modelBuilder.Entity<EmployeeDevTool>()
                .HasOne(e => e.DevTool)
                .WithMany(ei => ei.EmployeeDevTool)
                .HasForeignKey(i => i.DevToolId);
        }
    }
}
