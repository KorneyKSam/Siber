using Microsoft.EntityFrameworkCore;
using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public abstract class Base_Repository<Model> where Model : BaseModel
    {
        protected DBSibersContext _context;
        protected DbSet<Model> _dbSet;

        public Base_Repository(DBSibersContext context)
        {
            _context = context;
            _dbSet = context.Set<Model>();
        }

        public Model Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public virtual List<Model> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual string Save(Model model)
        {
            try
            {
                if (model.Id > 0)
                {
                    _dbSet.Update(model);
                    _context.SaveChanges();
                    return "Success";
                }
                _dbSet.Add(model);
                _context.SaveChanges();
            }
            catch (System.Exception exception)
            {
                return exception.Message;
            }
            return "Success";
        }

        public string Delete(long id)
        {
            try
            {
                var model = Get(id);
                _dbSet.Remove(model);
                _context.SaveChanges();
            }
            catch (System.Exception exception)
            {
                return exception.Message;
            }
            return "Success";
        }
        public string Delete(Model model)
        {
            try
            {
                _dbSet.Remove(model);
                _context.SaveChanges();
            }
            catch (System.Exception exception)
            {
                return exception.Message;
            }
            return "Success";
        }
    }
}
