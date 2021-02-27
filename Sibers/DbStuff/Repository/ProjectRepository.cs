using Sibers.DbStuff.Models;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(DBSibersContext context) : base(context) { }
    }
}
