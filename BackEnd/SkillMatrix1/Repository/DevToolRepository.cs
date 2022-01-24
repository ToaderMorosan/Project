using SkillMatrix1.Data;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;

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
    }
}
