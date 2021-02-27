using System;
using System.Collections.Generic;

#nullable disable

namespace Sibers.DbStuff.Models
{
    public partial class Project : BaseModel
    {
        public Project()
        {
            EployeeProjects = new HashSet<EployeeProject>();
        }

        public string ProjectName { get; set; }
        public long CustomerCompanyId { get; set; }
        public long ExecutingCompanyId { get; set; }
        public int ProjectPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectLeaderId { get; set; }
        public DateTime DateTimeOfCreation { get; set; }

        public virtual CustomerCompany CustomerCompany { get; set; }
        public virtual ExecutingCompany ExecutingCompany { get; set; }
        public virtual ICollection<EployeeProject> EployeeProjects { get; set; }
    }
}
