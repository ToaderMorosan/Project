using SkillMatrix1.Data;
using SkillMatrix1.Dto;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;

namespace SkillMatrix1.Repository
{
    public class EmployeeRepository : IEmployeeRepository 
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateEmployee(Employee employee)
        {
            _context.Add(employee);

            return Save();
        }
        public bool CreateEmployeeWithSkillInterestDevTool(int SkillId, int InterestId, int DevToolId, Employee employee)
        {
            var EmployeeSkillEntity = _context.Skills.Where(a => a.Id == SkillId).FirstOrDefault();
            var EmployeeInterestEntity = _context.Interests.Where(a => a.Id == InterestId).FirstOrDefault();
            var DevToolInterestEntity = _context.DevTools.Where(a => a.Id == DevToolId).FirstOrDefault();
            var employeeSkill = new EmployeeSkill()
            {
                Skill = EmployeeSkillEntity,
                Employee = employee,
            };
            _context.Add(employeeSkill);
            var employeeInterest = new EmployeeInterest()
            {
                Interest = EmployeeInterestEntity,
                Employee = employee,
            };
            _context.Add(employeeInterest);
            var employeeDevTool = new EmployeeDevTool()
            {
                DevTool = DevToolInterestEntity,
                Employee = employee,
            };
            _context.Add(employeeDevTool);

            _context.Add(employee);

            return Save();
        }

        public bool DeleteEmployee(Employee employee)
        {
            _context.Remove(employee);
            return Save();
        }

        public bool EmployeeExists(int employeeId)
        {
            return _context.Employees.Any(e=> e.Id == employeeId);
        }

        public Employee GetEmployee(int id) 
        {
            return _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return _context.Employees.Where (e => e.Name == name).FirstOrDefault();
        }

        public ICollection<Employee> GetEmployees()
        {
            return _context.Employees.OrderBy(e => e.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _context.Update(employee);
            return Save();
        }

        public ICollection<Interest> GetInterestByEmployee(int employeeId)
        {
            return _context.EmployeeInterests.Where(i => i.EmployeeId == employeeId).Select(e => e.Interest).ToList();
        }

        public ICollection<Skill> GetSkillByEmployee(int employeeId)
        {
            return _context.EmployeeSkills.Where(i => i.EmployeeId == employeeId).Select(e => e.Skill).ToList();
        }
        public ICollection<DevTool> GetDevToolByEmployee(int employeeId)
        {
            return _context.EmployeeDevTools.Where(i => i.EmployeeId == employeeId).Select(e => e.DevTool).ToList();
        }

    }
}
