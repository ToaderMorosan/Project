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
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public SkillController(ISkillRepository skillRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Skill>))]
        public IActionResult GetSkills()
        {
            var skills = _mapper.Map<List<SkillDto>>(_skillRepository.GetSkills());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(skills);
        }


        [HttpGet("{skillId} ")]
        public IActionResult GetSkill(int skillId)
        {
            if (!_skillRepository.SkillExists(skillId))
                return NotFound();
            var skill = _mapper.Map<SkillDto>(_skillRepository.GetSkill(skillId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(skill);
        }

        [HttpGet("employee/{skillId}")]
        public IActionResult GetEmployeeBySkillId(int skillId)
        {
            var employees = _mapper.Map<List<EmployeeDto>>(_skillRepository.GetEmployeeBySkill(skillId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateSkill( [FromBody] SkillDto skillCreate)
        {
            if (skillCreate == null)
                return BadRequest(ModelState);

            var skills = _skillRepository.GetSkills()
                .Where(c => c.Name.Trim().ToUpper() == skillCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (skills != null)
            {
                ModelState.AddModelError("", "Skill already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var skillMap = _mapper.Map<Skill>(skillCreate);


            if (!_skillRepository.CreateSkill(skillMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }


        [HttpPut("{skillId}")]
        public IActionResult UpdateSkill(int skillId, [FromBody] SkillDto updatedSkill)
        {
            if (updatedSkill == null)
                return BadRequest(ModelState);

            if (skillId != updatedSkill.Id)
                return BadRequest(ModelState);

            if (_skillRepository.SkillExists(skillId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var skillMap = _mapper.Map<Skill>(updatedSkill);

            if (!_skillRepository.UpdateSkill(skillMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



        [HttpDelete("{skillId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSkill(int skillId)
        {
            if (!_skillRepository.SkillExists(skillId))
            {
                return NotFound();
            }

            var skillToDelete = _skillRepository.GetSkill(skillId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_skillRepository.DeleteSkill(skillToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }


        [HttpPost("{employeeId}")]
        public ActionResult<SkillDto> CreateSkillForEmployee(int employeeId, SkillDto skill)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }
            var skillMap = _mapper.Map<Skill>(skill);
            _skillRepository.AddSkillForEmployee(employeeId, skillMap);
            _skillRepository.Save();
            return Ok();
        }

    }
}
