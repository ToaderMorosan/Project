using SkillMatrix1.Data;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;

namespace SkillMatrix1.Repository
{
    public class StudyRepository : IStudyRepository
    {
        private DataContext _context;
        public StudyRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateStudy(Study study)
        {
            _context.Add(study);
            return Save();
        }

        public bool DeleteStudy(Study study)
        {
            _context.Remove(study);
            return Save();
        }

        public ICollection<Study> GetStudies()
        {
            return _context.Studies.ToList();
        }

        public ICollection<Study> GetStudiesOfAnEmployee(int employeeId)
        {
            return _context.Studies.Where(r => r.Employee.Id == employeeId).ToList();
        }

        public Study GetStudy(int studyId)
        {
            return _context.Studies.Where(r => r.Id == studyId).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool StudyExists(int studyId)
        {
            return _context.Studies.Any(r => r.Id == studyId);
        }

        public bool UpdateStudy(Study study)
        {
            _context.Update(study);
            return Save();
        }

        public IEnumerable<Study> GetStudiesForEmployee(int employeeId)
        {
            if (employeeId == null)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            return _context.Studies
                        .Where(c => c.Employee.Id == employeeId)
                        .ToList();
        }


        public void AddStudyForEmployee(int employeeId, Study study)
        {
            if (employeeId == null)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            if (study == null)
            {
                throw new ArgumentNullException(nameof(study));
            }
            study.Employee =  _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            _context.Studies.Add(study);
        }

    }
}
