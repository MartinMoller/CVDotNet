using System.Collections.Generic;
using CVDotNet.Models;
using CVDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CVDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly IWorkRepo _repo;

        public WorkController(IWorkRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Work> getAll()
        {
            return _repo.GetAllWork();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var work = _repo.GetById(id);
            if (work != null)
            {
                return Ok(work);
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Work work)
        {
            _repo.Update(work);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Work work)
        {
            _repo.Create(work);
            return Ok();
        }
        
        
    }
}