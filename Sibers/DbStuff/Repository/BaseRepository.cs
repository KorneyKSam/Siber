using Microsoft.EntityFrameworkCore;
using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public abstract class BaseRepository<Model> where Model : BaseModel
    {
        protected DBSibersContext _context;
        protected DbSet<Model> _dbSet;

        public BaseRepository(DBSibersContext context)
        {
            _context = context;
            _dbSet = context.Set<Model>();
        }

        public Model Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<Model> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Save(Model user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var model = Get(id);
            _dbSet.Remove(model);
        }
    }
}
