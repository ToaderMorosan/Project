using SkillMatrix1.Models;

namespace SkillMatrix1.Interfaces
{
    public interface ISkillRepository
    {
        List<Repository.SkillRepository.Item> GetSkills();
        Skill GetSkill(int Id);
        ICollection<Employee> GetEmployeeBySkill(int skillId);
        bool SkillExists(int id);

        bool UpdateSkill(Skill skill);
        bool CreateSkill(Skill skill);
        bool DeleteSkill(Skill skill);
        void AddSkillForEmployee(int employeeId, Skill skill);
        bool Save();
    }
}
