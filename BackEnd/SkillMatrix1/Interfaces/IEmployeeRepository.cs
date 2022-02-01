using SkillMatrix1.Dto;
using SkillMatrix1.Models;

namespace SkillMatrix1.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int id);
/*        Employee GetEmployee(string name);*/
        bool EmployeeExists(int employeeId);
        bool CreateEmployeeWithSkillInterestDevTool(int skillId, int InterestId, int DevToolId, Employee employee);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        ICollection<Interest> GetInterestByEmployee(int employeeId);
        ICollection<Skill> GetSkillByEmployee(int employeeId);
        ICollection<DevTool> GetDevToolByEmployee(int employeeId);
/*        public Employee GetAuth(UserLogin userLogin);*/
        bool Save();
    }
}
