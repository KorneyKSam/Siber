using Sibers.DbStuff.Models;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class Executing_Company_Repository : Base_Repository<ExecutingCompany>
    {
        public Executing_Company_Repository(DBSibersContext context) : base(context) { }

        public ExecutingCompany FindExistingExecutingCompany(string company)
        {
            return _dbSet.SingleOrDefault(x => x.CompanyName == company);
        }
    }
}
