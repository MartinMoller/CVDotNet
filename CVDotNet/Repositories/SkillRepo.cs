using System.Collections.Generic;
using CVDotNet.Models;

namespace CVDotNet.Repositories
{
    public interface ISkillRepo
    {
        IEnumerable<Skill> GetAll();
        Skill Create(Skill skill);
        Skill GetById(int id);
        void Update(Skill skill);
        void Delete(int id);
    }

    public class SkillRepo : ISkillRepo
    {
        private readonly cvDBContext _context;

        public SkillRepo(cvDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Skill> GetAll()
        {
            return _context.Skill;
        }

        public Skill Create(Skill skill)
        {
            _context.Skill.Add(skill);
            _context.SaveChanges();
            return skill;
        }

        public Skill GetById(int id)
        {
            return _context.Skill.Find(id);
        }

        public void Update(Skill skill)
        {
            var toBeUpdated = _context.Skill.Find(skill.Id);
            if (toBeUpdated != null)
            {
                _context.Entry(toBeUpdated).CurrentValues.SetValues(skill);
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var skill = _context.Skill.Find(id);
            if (skill != null)
            {
                _context.Skill.Remove(skill);
                _context.SaveChanges();
            }
        }
    }
}