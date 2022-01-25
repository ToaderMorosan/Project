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
    public class InterestController : Controller
    {
        private readonly IInterestRepository _interestRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public InterestController(IInterestRepository interestRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
           _interestRepository = interestRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Interest>))]
        public IActionResult GetInterests()
        {
            var interests = _mapper.Map<List<InterestDto>>(_interestRepository.GetInterests());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(interests);
        }


        [HttpGet("{interestId} ")]
        public IActionResult GetInterest(int interestId)
        {
            if (!_interestRepository.InterestExists(interestId))
                return NotFound();
            var interest = _mapper.Map<InterestDto>(_interestRepository.GetInterest(interestId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(interest); 
        }

        [HttpGet("employee/{interestId}")]
        public IActionResult GetEmployeeByInterestId(int interestId)
        {
            var employees = _mapper.Map<List<EmployeeDto>>(_interestRepository.GetEmployeeByInterest(interestId));

            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(employees);
        }



        [HttpPost]
        public IActionResult CreateInterest([FromBody] InterestDto interestCreate)
        {
            if (interestCreate == null)
                return BadRequest(ModelState);

            var skills = _interestRepository.GetInterests()
                .Where(c => c.Name.Trim().ToUpper() == interestCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (skills != null)
            {
                ModelState.AddModelError("", "Interest already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var skillMap = _mapper.Map<Interest>(interestCreate);
            if (!_interestRepository.CreateInterest(skillMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{interestId}")]
        public IActionResult UpdateInterest(int interestId, [FromBody] InterestDto updatedInterest)
        {
            if (updatedInterest == null)
                return BadRequest(ModelState);

            if (interestId != updatedInterest.Id)
                return BadRequest(ModelState);

            if (!_interestRepository.InterestExists(interestId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var interestMap = _mapper.Map<Interest>(updatedInterest);

            if (!_interestRepository.UpdateInterest(interestMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



        [HttpDelete("{interestId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDevTool(int interestId)
        {
            if (!_interestRepository.InterestExists(interestId))
            {
                return NotFound();
            }

            var interestToDelete = _interestRepository.GetInterest(interestId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_interestRepository.DeleteInterest(interestToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }


        [HttpPost("{employeeId}")]
        public ActionResult<InterestDto> CreateInterestForEmployee(int employeeId, InterestDto interest)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }
            var interestMap = _mapper.Map<Interest>(interest);
            _interestRepository.AddInterestForEmployee(employeeId, interestMap);
            _interestRepository.Save();
            return Ok();
        }

    }
}
