using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix1.Dto;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;

namespace SkillMatrix1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetEmployees()
        {
            var employees = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetEmployee(int employeeId)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
                return NotFound();
            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(employeeId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employee);
        }

/*        [HttpGet("{employeeName} ")]
        public IActionResult GetEmployee(string employeeName)
        {
            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(employeeName));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(employee);
        }
*/

        [HttpPost("CreateEmployeeWithSkillInterestDevTooleEmployee")]
        public IActionResult CreatCreateEmployeeWithSkillInterestDevTooleEmployee([FromQuery] int skillId, [FromQuery] int interestId, [FromQuery] int devToolId, [FromBody] EmployeeDto employeeCreate)
        {
            if (employeeCreate == null)
                return BadRequest(ModelState);

            var employees = _employeeRepository.GetEmployees()
                .Where(c => c.Name.Trim().ToUpper() == employeeCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (employees != null)
            {
                ModelState.AddModelError("", "Employee already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeMap = _mapper.Map<Employee>(employeeCreate);


            if (!_employeeRepository.CreateEmployeeWithSkillInterestDevTool(skillId, interestId, devToolId, employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPost]
        public IActionResult CreateEmployee( [FromBody] EmployeeDto employeeCreate)
        {
            if (employeeCreate == null)
                return BadRequest(ModelState);

            var employees = _employeeRepository.GetEmployees()
                .Where(c => c.Name.Trim().ToUpper() == employeeCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (employees != null)
            {
                ModelState.AddModelError("", "Employee already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeMap = _mapper.Map<Employee>(employeeCreate);


            if (!_employeeRepository.CreateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{employeeId}")]
        [EnableCors]
        public IActionResult UpdateEmployee(int employeeId, [FromBody] EmployeeDto updatedEmployee)
        {
            if (updatedEmployee == null)
                return BadRequest(ModelState);
            if (employeeId != updatedEmployee.Id)
                return BadRequest(ModelState);

            if (!_employeeRepository.EmployeeExists(employeeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var employeeMap = _mapper.Map<Employee>(updatedEmployee);

            if (!_employeeRepository.UpdateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employeeToDelete = _employeeRepository.GetEmployee(employeeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_employeeRepository.DeleteEmployee(employeeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }

        [HttpGet("Interest/{employeeId}")]
        public IActionResult GetInterestByEmployeeId(int employeeId)
        {
            var interests = _mapper.Map<List<Interest>>(_employeeRepository.GetInterestByEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(interests);
        }
        [HttpGet("Skill/{employeeId}")]
        public IActionResult GetSkillByEmployeeId(int employeeId)
        {
            var skills = _mapper.Map<List<Skill>>(_employeeRepository.GetSkillByEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(skills);
        }
        [HttpGet("DevTool/{employeeId}")]
        public IActionResult GetDevToolByEmployeeId(int employeeId)
        {
            var devTools = _mapper.Map<List<DevTool>>(_employeeRepository.GetDevToolByEmployee(employeeId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(devTools);
        }


    }
}
