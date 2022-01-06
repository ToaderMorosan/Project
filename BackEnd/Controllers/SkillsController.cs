using Microsoft.AspNetCore.Mvc;
using SkillsSet.Data;
using SKillsSet.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace SkillsSet.Controllers
{   

    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillRepo _repository;
        public SkillsController(ISkillRepo repository)
        {
            _repository = repository;    
        }
        //GET api/skills
        [HttpGet]
        public ActionResult <IEnumerable<Skill>> GetAllSkills()
        {
            var skillItems = _repository.GetAllSkills();

            return Ok(skillItems);
        }
        
        //GET api/skills/{id}
        [HttpGet("{id}")]
        public ActionResult <Skill> GetSkillById(int id)
        {
            var skillItem = _repository.GetSkillById(id);
            return Ok(skillItem);
        }
    }


}