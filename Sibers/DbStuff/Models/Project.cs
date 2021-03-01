using System;
using System.Collections.Generic;

#nullable disable

namespace Sibers.DbStuff.Models
{
    public partial class Project : BaseModel
    {
        public Project()
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
        }

        public string ProjectName { get; set; }
        public long CustomerCompanyId { get; set; }
        public long ExecutingCompanyId { get; set; }
        public int ProjectPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long ProjectLeaderId { get; set; }
        public DateTime DateTimeOfCreation { get; set; }

        public virtual CustomerCompany CustomerCompany { get; set; }
        public virtual ExecutingCompany ExecutingCompany { get; set; }
        public virtual Employee ProjectLeader { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
