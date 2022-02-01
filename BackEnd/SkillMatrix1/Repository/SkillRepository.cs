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
        public class Item
        {
            public string Name { get; set; }
            public int Occurence { get; set; }
        }

        public void AddSkillForEmployee(int employeeId, Skill skill)
        {
            var EmployeeSkillEntity = _context.Employees.Where(a => a.Id == employeeId).FirstOrDefault();
            var employeeSkill = new EmployeeSkill()
            {
                Skill = skill,
                Employee = EmployeeSkillEntity,
            };
            _context.Add(employeeSkill);
            if (employeeId == null)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            if (skill == null)
            {
                throw new ArgumentNullException(nameof(employeeSkill));
            }

            _context.Skills.Add(skill);
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

        public List<Item> GetSkills()
        {
            List<Skill> list = _context.Skills.ToList();
/*            List<string> listOfSkills = new List<string>();
            var skills =_context.Skills.ToList();
            foreach (var skill in list)
            {
                listOfSkills.Add(skill.Name);
            }
            List<string> distinctSkills = (List<string>)listOfSkills.Distinct()
                .ToList();*/
            List<Item> skilsOccurences = new List<Item>();
            /*            var k = 0;
                        foreach (var skill in listOfSkills)
                        {
                            if (distinctSkills.Contains(skill))
                            {
                                k++;
                            }
                        }*/

            foreach (var line in list.GroupBy(info => info.Name)
                                    .Select(group => new {
                                        Name = group.Key,
                                        Count = group.Count()
                                    })
                                    .OrderBy(x => x.Name))
            {
                Console.WriteLine("{0} {1}", line.Name, line.Count);
                Item item = new Item();
                item.Name = line.Name;
                item.Occurence = line.Count;
                skilsOccurences.Add(item);
            }

            return skilsOccurences;
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
