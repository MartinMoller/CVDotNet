using System.Collections.Generic;
using CVDotNet.Models;

namespace CVDotNet.Repositories
{
    public interface IEducationRepo
    {
        IEnumerable<Education> GetAll();
        Education GetById(int id);
        Education Create(Education education);
        void Update(Education education);
        void Delete(int id);
    }

    public class EducationRepo : IEducationRepo
    {
        private readonly cvDBContext _context;

        public EducationRepo(cvDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Education> GetAll()
        {
            return _context.Education;
        }

        public Education GetById(int id)
        {
            return _context.Education.Find(id);
        }

        public Education Create(Education education)
        {
            _context.Education.Add(education);
            _context.SaveChanges();
            return education;
        }

        public void Update(Education education)
        {
            var toBeUpdated = _context.Education.Find(education.Id);
            if (toBeUpdated != null)
            {
                _context.Entry(toBeUpdated).CurrentValues.SetValues(education);
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var education = _context.Education.Find(id);
            if (education != null)
            {
                _context.Education.Remove(education);
            }

            _context.SaveChanges();
        }
    }
}