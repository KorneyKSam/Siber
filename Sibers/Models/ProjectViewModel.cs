using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Models
{
    public class ProjectViewModel
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public long CustomerCompanyId { get; set; }
        public long ExecutingCompanyId { get; set; }
        public int ProjectPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectLeaderId { get; set; }

        public DateTime DateTimeOfCreation { get; set; }

        public EmployeeViewModel ProjectLeader { get; set; }
        public CustomerCompanyViewModel CustomerCompany { get; set; }
        public ExecutingCompanyViewModel ExecutingCompany { get; set; }

    }
}
