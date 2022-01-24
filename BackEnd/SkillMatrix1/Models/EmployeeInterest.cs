

namespace SkillMatrix1.Models
{
    public class EmployeeInterest
    {
        public int EmployeeId { get; set; }
        public int InterestId { get; set; }
        public Employee Employee { get; set; }
        public Interest Interest { get; set; }
    }
}
