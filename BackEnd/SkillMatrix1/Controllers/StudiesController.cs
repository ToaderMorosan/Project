using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix1.Dto;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;

namespace SkillMatrix1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiesController : Controller
    {
        private readonly IStudyRepository _studyRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public StudiesController(IStudyRepository studyRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _studyRepository = studyRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetStudies()
        {
            var studies = _mapper.Map<List<StudyDto>>(_studyRepository.GetStudies());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studies);
        }

        [HttpGet("{reviewId}")]
        public IActionResult GetEmployee(int studyId)
        {
            if (!_studyRepository.StudyExists(studyId))
                return NotFound();

            var study = _mapper.Map<StudyDto>(_studyRepository.GetStudy(studyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(study);
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetStudiesForAnEmployee(int employeeId)
        {
            var studies = _mapper.Map<List<StudyDto>>(_studyRepository.GetStudiesOfAnEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(studies);
        }


        [HttpPost]
        public IActionResult CreateStudy([FromQuery] int employeeId, [FromBody] StudyDto studyCreate)
        {
            if (studyCreate == null)
                return BadRequest(ModelState);

            var studies = _studyRepository.GetStudies()
                .Where(c => c.Name.Trim().ToUpper() == studyCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (studies != null)
            {
                ModelState.AddModelError("", "Study already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studyMap = _mapper.Map<Study>(studyCreate);

            studyMap.Employee = _employeeRepository.GetEmployee(employeeId);


            if (!_studyRepository.CreateStudy(studyMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }


        [HttpPut("{studyId}")]
        public IActionResult UpdateStudy(int studyId, [FromBody] StudyDto updatedStudy)
        {
            if (updatedStudy == null)
                return BadRequest(ModelState);

            if (studyId != updatedStudy.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var studyMap = _mapper.Map<Study>(updatedStudy);

            if (!_studyRepository.UpdateStudy(studyMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{studyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStydt(int studyId)
        {
            if (!_studyRepository.StudyExists(studyId))
            {
                return NotFound();
            }

            var devToolToDelete = _studyRepository.GetStudy(studyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_studyRepository.DeleteStudy(devToolToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }


        [HttpGet("getStudyByEmployee/{employeeId}", Name = "GetStudyByEmployee")]
        public ActionResult<IEnumerable<StudyDto>> GetStudyForEmployee(int employeeId)
        {
            var studiesForEmployeeFromRepo = _studyRepository.GetStudiesForEmployee(employeeId);
            return Ok(_mapper.Map<IEnumerable<StudyDto>>(studiesForEmployeeFromRepo));

        }
    }
}
