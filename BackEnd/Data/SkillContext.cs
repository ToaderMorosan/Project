using Microsoft.EntityFrameworkCore;
using SKillsSet.Models;

namespace SkillsSet.Data 
{
    public class SkillContext : DbContext
    {
        public SkillContext(DbContextOptions<SkillContext> opt) : base(opt)
        {
            
        }

        public DbSet<Skill> Skills { get; set; } 

         
    }
}