namespace SkillMatrix1.Models
{
    public class EmployeeDevTool
    {
        public int EmployeeId { get; set; }
        public int DevToolId { get; set; }
        public Employee Employee { get; set; }
        public DevTool DevTool { get; set; }
    }
}
