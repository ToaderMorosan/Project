using SkillMatrix1.Data;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;

namespace SkillMatrix1.Repository
{
    public class InterestRepository : IInterestRepository
    {
        private DataContext _context;
        public InterestRepository(DataContext context)
        {
            _context = context;
        }

        public void AddInterestForEmployee(int employeeId, Interest interest)
        {
            var EmployeeInterestEntity = _context.Employees.Where(a => a.Id == employeeId).FirstOrDefault();
            var employeeInterest = new EmployeeInterest()
            {
                Interest = interest,
                Employee = EmployeeInterestEntity,
            };
            _context.Add(employeeInterest);
            if (employeeId == null)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            if (interest == null)
            {
                throw new ArgumentNullException(nameof(interest));
            }

            _context.Interests.Add(interest);
        }

        public bool CreateInterest(Interest interest)
        {
            _context.Add(interest);
            return Save();
        }

        public bool DeleteInterest(Interest interest)
        {
            _context.Remove(interest);
            return Save();
        }

        public ICollection<Employee> GetEmployeeByInterest(int interestId)
        {
            return _context.EmployeeInterests.Where(i => i.InterestId == interestId).Select(e => e.Employee).ToList();
        }

        public Interest GetInterest(int Id)
        {
            return _context.Interests.Where(i => i.Id == Id).FirstOrDefault();
        }

        public ICollection<Interest> GetInterests()
        {
            return _context.Interests.ToList();
        }

        public bool InterestExists(int id)
        {
            return _context.Interests.Any(i => i.Id == id); 
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateInterest(Interest interest)
        {
            _context.Update(interest);
            return Save();
        }
    }
}
