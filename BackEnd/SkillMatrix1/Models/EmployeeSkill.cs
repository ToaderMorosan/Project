namespace SkillMatrix1.Models
{
    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
    }
}
