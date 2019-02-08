using System.Collections.Generic;
using CVDotNet.Models;
using CVDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CVDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepo _repo;

        public EducationController(IEducationRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Education> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var education = _repo.GetById(id);
            if (education != null)
            {
                return Ok(education);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Education educationParam)
        {
            var education = _repo.Create(educationParam);
            return Ok(education);
        }

        [HttpPut]
        public IActionResult Update(Education education)
        {
            _repo.Update(education);
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