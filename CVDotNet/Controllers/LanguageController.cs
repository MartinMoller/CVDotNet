using System.Collections.Generic;
using CVDotNet.Models;
using CVDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CVDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepo _repo;

        public LanguageController(ILanguageRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Language> GetAll()
        {
            return _repo.GetALl();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var language = _repo.GetById(id);
            if (language != null)
            {
                return Ok(language);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {
            _repo.Create(language);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Language language)
        {
            _repo.Update(language);
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