using SkillMatrix1.Models;

namespace SkillMatrix1.Interfaces
{
    public interface IInterestRepository
    {
        ICollection<Interest> GetInterests();
        Interest GetInterest(int Id);
        ICollection<Employee> GetEmployeeByInterest(int interestId);
        bool InterestExists(int id);
        bool CreateInterest(Interest interest);

        bool UpdateInterest(Interest interest);
        bool DeleteInterest(Interest interest);
        bool Save();
    }
}
