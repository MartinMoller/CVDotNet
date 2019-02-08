using System.Collections.Generic;
using CVDotNet.Models;

namespace CVDotNet.Repositories
{
    public interface ILanguageRepo
    {
        IEnumerable<Language> GetALl();
        Language GetById(int id);
        Language Create(Language language);
        void Update(Language language);
        void Delete(int id);
    }

    public class LanguageRepo : ILanguageRepo
    {
        private readonly cvDBContext _context;

        public LanguageRepo(cvDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetALl()
        {
            return _context.Language;
        }

        public Language GetById(int id)
        {
            return _context.Language.Find(id);
        }

        public Language Create(Language language)
        {
            _context.Language.Add(language);
            _context.SaveChanges();
            return language;
        }

        public void Update(Language language)
        {
            var toBeUpdated = _context.Language.Find(language.Id);
            if (toBeUpdated != null)
            {
                _context.Entry(toBeUpdated).CurrentValues.SetValues(language);
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var language = _context.Language.Find(id);
            if (language != null)
            {
                _context.Language.Remove(language);
                _context.SaveChanges();
            }
        }
    }
}