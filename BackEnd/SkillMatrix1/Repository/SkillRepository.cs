using SkillMatrix1.Data;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;

namespace SkillMatrix1.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private DataContext _context;
        public SkillRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSkill(Skill skill)
        {
            _context.Add(skill);
            return Save();
        }

        public bool DeleteSkill(Skill skill)
        {
            _context.Remove(skill);
            return Save();
        }

        public ICollection<Employee> GetEmployeeBySkill(int skillId)
        {
            return _context.EmployeeSkills.Where(i => i.SkillId == skillId).Select(e => e.Employee).ToList();
        }

        public Skill GetSkill(int Id)
        {
            return _context.Skills.Where(i => i.Id == Id).FirstOrDefault();
        }

        public ICollection<Skill> GetSkills()
        {
            return _context.Skills.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SkillExists(int id)
        {
            return _context.Skills.Any(i => i.Id == id);
        }

        public bool UpdateSkill(Skill skill)
        {
            _context.Update(skill);
            return Save();
        }
    }
}
