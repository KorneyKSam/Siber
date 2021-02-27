using Sibers.DbStuff.Models;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(DBSibersContext context) : base(context) { }
    }
}
