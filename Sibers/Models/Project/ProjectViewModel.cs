using Sibers.Models.CustomAttributes;
using Sibers.Models.CustomerCompany;
using Sibers.Models.Employee;
using Sibers.Models.ExecutingCompany;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Models.Project
{
    public class ProjectViewModel
    {
        public long Id { get; set; }

        [DisplayName("Название проекта")]
        [Required(ErrorMessage = "Где название проекта?")]
        public string ProjectName { get; set; }

        [DisplayName("Компания заказчик")]
        public long CustomerCompanyId { get; set; }

        [DisplayName("Компания исполнитель")]
        public long ExecutingCompanyId { get; set; }

        [DisplayName("Приоритет")]
        public int ProjectPriority { get; set; }

        [DisplayName("Дата начала")]
        [Required(ErrorMessage ="Где дата?")]
        public DateTime StartDate { get; set; }

        [DisplayName("Дата завершения")]
        [Required(ErrorMessage = "Где дата?")]
        public DateTime EndDate { get; set; }

        [DisplayName("Руководитель проекта")]
        public int ProjectLeaderId { get; set; }

        public DateTime DateTimeOfCreation { get; set; }

        public EmployeeViewModel ProjectLeader { get; set; }

        public CustomerCompanyViewModel CustomerCompany { get; set; }

        public ExecutingCompanyViewModel ExecutingCompany { get; set; }

    }
}
