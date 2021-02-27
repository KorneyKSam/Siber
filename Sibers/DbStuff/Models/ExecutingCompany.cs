using System;
using System.Collections.Generic;

#nullable disable

namespace Sibers.DbStuff.Models
{
    public partial class ExecutingCompany : BaseModel
    {
        public ExecutingCompany()
        {
            Projects = new HashSet<Project>();
        }
        public string CompanyName { get; set; }
        public string Distiption { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
