using SkillMatrix1.Models;

namespace SkillMatrix1.Models
{
    public class Study
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Interval { get; set; }
        public Employee Employee { get; set; }
    }
}
