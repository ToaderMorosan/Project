using SkillMatrix1.Models;

namespace SkillMatrix1.Interfaces
{
    public interface IDevToolRepository 
    {
        ICollection<DevTool> GetDevTools();
        DevTool GetDevTool(int Id);
        ICollection<Employee> GetEmployeeByDevTool(int devToolId);
        bool DevToolExists(int id);
        bool UpdateDevTool(DevTool decTool);
        bool CreateDevTool(DevTool devTool);
        bool DeleteDevTool(DevTool devTool);
        bool Save();
    }
}
