using Sibers.DbStuff.Models;
using Sibers.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class Customer_Company_Repository : Base_Repository<CustomerCompany>
    {
        public Customer_Company_Repository(DBSibersContext context) : base(context) { }

        public CustomerCompany FindExistingCustomerCompany(string company)
        {
            return _dbSet.SingleOrDefault(x => x.CompanyName == company);
        }

        public CustomerCompany GetCompanyByName(string company)
        {
            return _dbSet.FirstOrDefault(x => x.CompanyName == company);
        }

    }
}
