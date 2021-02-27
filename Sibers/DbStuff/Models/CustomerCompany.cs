using System;
using System.Collections.Generic;

#nullable disable

namespace Sibers.DbStuff.Models
{
    public partial class CustomerCompany : BaseModel
    {
        public CustomerCompany()
        {
            Projects = new HashSet<Project>();
        }

        public string CompanyName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
