using SKillsSet.Models;

namespace SkillsSet.Data
{
    public interface ISkillRepo{
        IEnumerable<Skill> GetAppSkills(); 
        Skill GetSkillById(int id);
    }
}