using SkillMatrix1.Models;

namespace SkillMatrix1.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int id);
        Employee GetEmployee(string name);
        bool EmployeeExists(int employeeId);
        bool CreateEmployee(int skillId, int InterestId, int DevToolId, Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
    }
}
