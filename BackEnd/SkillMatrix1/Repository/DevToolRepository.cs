using SkillMatrix1.Data;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;
using System.Linq;

namespace SkillMatrix1.Repository
{
    public class DevToolRepository : IDevToolRepository
    {
        private DataContext _context;
        public DevToolRepository(DataContext context)
        {
            _context = context;
        }
        public bool DevToolExists(int id)
        {
            return _context.DevTools.Any(i => i.Id == id);
        }

        public ICollection<DevTool> GetDevTools()
        {
            return _context.DevTools.ToList();
        }

        public ICollection<Employee> GetEmployeeByDevTool(int devToolId)
        {
            return _context.EmployeeDevTools.Where(i => i.DevToolId == devToolId).Select(e => e.Employee).ToList();
        }

        public DevTool GetDevTool(int Id)
        {
            return _context.DevTools.Where(i => i.Id == Id).FirstOrDefault();
        }

        public bool CreateDevTool(DevTool devTool)
        {
            _context.Add(devTool);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDevTool(DevTool devTool)
        {
            _context.Update(devTool);
            return Save();
        }

        public bool DeleteDevTool(DevTool devTool)
        {
            _context.Remove(devTool);
            return Save();
        }

        public void AddDevToolForEmployee(int employeeId, DevTool devTool)
        {
            var EmployeeDevToolEntity = _context.Employees.Where(a => a.Id == employeeId).FirstOrDefault();
            var employeeDevTool = new EmployeeDevTool()
            {
                DevTool = devTool,
                Employee = EmployeeDevToolEntity,
            };
            _context.Add(employeeDevTool);
            if (employeeId == null)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            if (devTool == null)
            {
                throw new ArgumentNullException(nameof(devTool));
            }

            _context.DevTools.Add(devTool);
        }


        public IEnumerable<DevTool> GetDevToolsForEmployee(int employeeId)
        {
            if (employeeId == null)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var employees = _context.EmployeeDevTools
                        .Where(c => c.EmployeeId == employeeId)
                        .ToList();
            var listOfId = employees.Select(r => r.EmployeeId);

            return _context.DevTools.Where(c => listOfId.Contains(c.Id)).ToList();

        }

    }
}
