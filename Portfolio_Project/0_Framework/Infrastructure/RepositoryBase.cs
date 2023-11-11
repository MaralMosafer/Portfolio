using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _0_Framework.Infrastructure
{
    public class RepositoryBase<Model> : IRepositoryBase<Model> where Model : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public bool CheckDataExists() => _context.Set<Model>().Any();

        public void CreateAndSave(Model entity) => _context.Add(entity);

        public bool Exists(Expression<Func<Model, bool>> predicate) => _context.Set<Model>().Any(predicate);

        public Model GetBy(long id) => _context.Find<Model>(id);


        public List<Model> GetList() => _context.Set<Model>().ToList();

        public void SaveChanges() => _context.SaveChanges();
    }
}
