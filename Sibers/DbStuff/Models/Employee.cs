using System;
using System.Collections.Generic;

#nullable disable

namespace Sibers.DbStuff.Models
{
    public partial class Employee : BaseModel
    {
        public Employee()
        {
            EmployeesProjects = new HashSet<EmployeeProject>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public long Company { get; set; }
        public DateTime DateTimeOfCreation { get; set; }

        public virtual ExecutingCompany ExecutingCompany { get; set; }
        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
