using System.Collections.Generic;
using CVDotNet.Models;
using CVDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CVDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepo _repo;

        public SkillController(ISkillRepo repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IEnumerable<Skill> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var skill = _repo.GetById(id);
            if (skill != null)
            {
                return Ok(skill);
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult Update(Skill skill)
        {
            _repo.Update(skill);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            _repo.Create(skill);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}