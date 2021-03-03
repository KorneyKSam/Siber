using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.Models.Employee
{
    public class EmployeeFullNameViewModel
    {
        [Required]
        public long Id { get; set; }
        public string FullName { get; set; }
    }
}
