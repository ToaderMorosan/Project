using SkillMatrix1.Models;

namespace SkillMatrix1.Interfaces
{
    public interface IStudyRepository
    {
        ICollection<Study> GetStudies();
        Study GetStudy(int studyId);
        ICollection<Study> GetStudiesOfAnEmployee(int employeeId);
        bool StudyExists(int studyId);
        
        bool CreateStudy(Study study);
        bool UpdateStudy(Study study);
        bool DeleteStudy(Study study);
        IEnumerable<Study> GetStudiesForEmployee(int employeeId);
        bool Save();
    }
}
