using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.Models
{
    public class EmployeeViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int Company { get; set; }
    }
}
