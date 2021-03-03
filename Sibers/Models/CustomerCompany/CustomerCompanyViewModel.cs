using Sibers.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Models.CustomerCompany
{
    public class CustomerCompanyViewModel
    {
        public long Id { get; set; }
        [UniqueCustomerCompanyName]
        public string CompanyName { get; set; }
        public string Description { get; set; }
    }
}
