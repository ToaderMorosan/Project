using SkillMatrix1.Models;
using System.ComponentModel.DataAnnotations;

namespace SkillMatrix1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
/*        public string Password { get; set; }*/

        public string Ocupation { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        public string address { get; set; }

        public string email { get; set; }
        public string github { get; set; }
        public string instagram { get; set; }

        public ICollection<Study> Studies { get; set; }

        public ICollection<EmployeeInterest> EmployeeInterests { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<EmployeeDevTool > EmployeeDevTools { get; set; }

    }
}
