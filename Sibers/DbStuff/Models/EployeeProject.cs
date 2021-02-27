using System;
using System.Collections.Generic;

#nullable disable

namespace Sibers.DbStuff.Models
{
    public partial class EployeeProject
    {
        public long EmployeeId { get; set; }
        public long ProjectId { get; set; }
        public DateTime DateTimeOfCreation { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
