using Sibers.DbStuff.Models;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class ExecutingCompanyRepository : BaseRepository<ExecutingCompany>
    {
        public ExecutingCompanyRepository(DBSibersContext context) : base(context) { }
    }
}
