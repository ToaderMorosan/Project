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
    public class DevToolController : Controller
    {
        private readonly IDevToolRepository _devToolRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public DevToolController(IDevToolRepository devToolRepository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _devToolRepository = devToolRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DevTool>))]
        public IActionResult GetDevTools()
        {
            var devTools = _mapper.Map<List<DevToolDto>>(_devToolRepository.GetDevTools());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(devTools);
        }
        [HttpGet("{devToolId}")]
        public IActionResult GetDevTool(int devToolId)
        {
            if (!_devToolRepository.DevToolExists(devToolId))
                return NotFound();
            var devTool = _mapper.Map<DevToolDto>(_devToolRepository.GetDevTool(devToolId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(devTool);
        }
        [HttpGet("employee/{devToolId}")]
        public IActionResult GetEmployeeByDevToolId(int devToolId)
        {
            var devTools = _mapper.Map<List<EmployeeDto>>(_devToolRepository.GetEmployeeByDevTool(devToolId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(devTools);
        }
        [HttpPost]
        public IActionResult CreateSkill([FromBody] DevToolDto devToolCreate)
        {
            if (devToolCreate == null)
                return BadRequest(ModelState);

            var devTools = _devToolRepository.GetDevTools()
                .Where(c => c.Name.Trim().ToUpper() == devToolCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
            if (devTools != null)
            {
                ModelState.AddModelError("", "Skill already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var devToolMap = _mapper.Map<DevTool>(devToolCreate);

            if (!_devToolRepository.CreateDevTool(devToolMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpPut("{devToolId}")]
        public IActionResult UpdateDevTool(int devToolId, [FromBody] DevToolDto updatedDevTool)
        {
            if (updatedDevTool == null)
                return BadRequest(ModelState);
            if (devToolId != updatedDevTool.Id)
                return BadRequest(ModelState);
            if (!_devToolRepository.DevToolExists(devToolId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            var devToolMap = _mapper.Map<DevTool>(updatedDevTool);
            if (!_devToolRepository.UpdateDevTool(devToolMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{devToolId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDevTool(int devToolId)
        {
            if (!_devToolRepository.DevToolExists(devToolId))
            {
                return NotFound();
            }
            var devToolToDelete = _devToolRepository.GetDevTool(devToolId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_devToolRepository.DeleteDevTool(devToolToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }
            return NoContent();
        }

        [HttpPost("{employeeId}")]
        public ActionResult<DevToolDto> CreateDevToolForEmployee(int employeeId, DevToolDto devTool)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }
            var devToolMap = _mapper.Map<DevTool>(devTool);
            _devToolRepository.AddDevToolForEmployee(employeeId, devToolMap);
            _devToolRepository.Save();
            return Ok();
        }

        [HttpPost("GetDevToolsByEmployees/{employeeId}")]
        public IActionResult GetDevToolsByEmployees(int employeeId)
        {
            var devTools = _mapper.Map<List<DevToolDto>>(_devToolRepository.GetDevToolsForEmployee(employeeId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(devTools);
        }

    }
}
