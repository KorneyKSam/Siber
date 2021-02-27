using Sibers.DbStuff.Models;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class CustomerCompanyRepository : BaseRepository<CustomerCompany>
    {
        public CustomerCompanyRepository(DBSibersContext context) : base(context) { }

    }
}
