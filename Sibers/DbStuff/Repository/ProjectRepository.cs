using Microsoft.EntityFrameworkCore;
using Sibers.DbStuff.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(DBSibersContext context) : base(context) { }

        public override List<Project> GetAll()
        {
            return _dbSet.Include(project => project.CustomerCompany).Include(project => project.ExecutingCompany).Include(project => project.ProjectLeader).ToList();
        }

    }
}
