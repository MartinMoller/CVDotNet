using System.Collections.Generic;
using System.Linq;
using CVDotNet.Helpers;
using CVDotNet.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CVDotNet.Repositories
{
    public interface IWorkRepo
    {
        IEnumerable<Work> GetAllWork();
        Work GetById(int id);
        Work Create(Work work);
        void Update(Work work);
        void Delete(int id);
    }

    public class WorkRepo : IWorkRepo
    {
        private readonly cvDBContext _context;

        public WorkRepo(cvDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Work> GetAllWork()
        {
            return _context.Work;
        }

        public Work GetById(int id)
        {
            return _context.Work.Find(id);
        }

        public Work Create(Work work)
        {
            _context.Add(work);
            _context.SaveChanges();
            return work;
        }

        public void Update(Work work)
        {
            Work toBeUpdated = _context.Work.Find(work.Id);
            if (toBeUpdated != null)
            {
                _context.Entry(toBeUpdated).CurrentValues.SetValues(work);
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var work = _context.Work.Find(id);
            if (work != null)
            {
                _context.Work.Remove(work);
                _context.SaveChanges();
            }
        }
    }
}