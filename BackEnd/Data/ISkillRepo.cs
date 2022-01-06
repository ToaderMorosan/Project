using SKillsSet.Models;

namespace SkillsSet.Data
{
    public interface ISkillRepo{
        IEnumerable<Skill> GetAllSkills(); 
        Skill GetSkillById(int id);
    }
}