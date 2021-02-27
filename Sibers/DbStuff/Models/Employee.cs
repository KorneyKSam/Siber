using System;
using System.Collections.Generic;

#nullable disable

namespace Sibers.DbStuff.Models
{
    public partial class Employee : BaseModel
    {
        public Employee()
        {
            EployeeProjects = new HashSet<EployeeProject>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int Company { get; set; }
        public DateTime DateTimeOfCreation { get; set; }

        public virtual ICollection<EployeeProject> EployeeProjects { get; set; }
    }
}
