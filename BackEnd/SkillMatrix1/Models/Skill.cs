using System.ComponentModel.DataAnnotations;

namespace SkillMatrix1.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Proficiency { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
 