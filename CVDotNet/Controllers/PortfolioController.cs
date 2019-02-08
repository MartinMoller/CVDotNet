using System.Collections.Generic;
using CVDotNet.Models;
using CVDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CVDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepo _repo;

        public PortfolioController(IPortfolioRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Portfolio> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var portfolio = _repo.GetById(id);
            if (portfolio != null)
            {
                return Ok(portfolio);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {
            _repo.Create(portfolio);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Portfolio portfolio)
        {
            _repo.Update(portfolio);
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