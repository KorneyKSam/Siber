using Microsoft.EntityFrameworkCore;
using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class Project_Repository : Base_Repository<Project>
    {
        public Project_Repository(DBSibersContext context) : base(context) { }

        public override List<Project> GetAll()
        {
            return _dbSet.Include(project => project.CustomerCompany).Include(project => project.ExecutingCompany).Include(project => project.ProjectLeader).ToList();
        }

        public string GetProjectName(long id)
        {
            return _dbSet.Where(x => x.Id == id).SingleOrDefault()?.ProjectName;
        }
    }
}
