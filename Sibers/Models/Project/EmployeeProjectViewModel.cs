using Sibers.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.Models.Project
{
    public class EmployeeProjectViewModel
    {
        [DisplayName("Проект")]
        public string ProjectName { get; set; }
        public long ProjectId { get; set; }
        public List<EmployeeFullNameViewModel> EmployeesInsideTheProjectViews { get; set; }
        public List<EmployeeFullNameViewModel> EmployeesOutsideTheProjectViewModels { get; set; }
    }
}
