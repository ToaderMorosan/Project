using System.ComponentModel.DataAnnotations;

namespace SkillMatrix1.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeInterest> EmployeeInterests { get; set; }
    }
}
