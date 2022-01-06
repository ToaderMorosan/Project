using SKillsSet.Models;

namespace SkillsSet.Data
{
    public class MockSkillRepo : ISkillRepo
    {
        public IEnumerable<Skill> GetAllSkills()
        {
            var skills = new List<Skill>
            {
                new Skill{Id=0, Name ="Html"},
                new Skill{Id=1, Name ="CSS"},
                new Skill{Id=2, Name ="C#"}
            };
            return skills;
        }

        public Skill GetSkillById(int id)
        {
            return new Skill{Id=0, Name ="Html"};
        }
    }
}