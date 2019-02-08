using System.Collections.Generic;
using CVDotNet.Models;

namespace CVDotNet.Repositories
{
    public interface IPortfolioRepo
    {
        IEnumerable<Portfolio> GetAll();
        Portfolio GetById(int id);
        Portfolio Create(Portfolio portfolio);
        void Update(Portfolio portfolio);
        void Delete(int id);
    }


    public class PortfolioRepo : IPortfolioRepo
    {
        private readonly cvDBContext _context;

        public PortfolioRepo(cvDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Portfolio> GetAll()
        {
            return _context.Portfolio;
        }

        public Portfolio GetById(int id)
        {
            return _context.Portfolio.Find(id);
        }

        public Portfolio Create(Portfolio portfolio)
        {
            _context.Portfolio.Add(portfolio);
            _context.SaveChanges();
            return portfolio;
        }

        public void Update(Portfolio portfolio)
        {
            var toBeUpdated = _context.Portfolio.Find(portfolio.Id);
            if (toBeUpdated != null)
            {
                _context.Entry(toBeUpdated).CurrentValues.SetValues(portfolio);
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var portfolio = _context.Portfolio.Find(id);
            if (portfolio != null)
            {
                _context.Portfolio.Remove(portfolio);
                _context.SaveChanges();
            }
        }
    }
}