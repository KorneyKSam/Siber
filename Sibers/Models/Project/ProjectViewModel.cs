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
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(50, ErrorMessage = "Название слишком большое")]
        public string ProjectName { get; set; }

        [DisplayName("Компания заказчик")]
        [Required(ErrorMessage = "Это обязательное поле!")]
        public long CustomerCompanyId { get; set; }

        [DisplayName("Компания исполнитель")]
        [Required(ErrorMessage = "Это обязательное поле!")]
        public long ExecutingCompanyId { get; set; }

        [DisplayName("Приоритет")]
        [Range(0, 100, ErrorMessage ="{0} должен быть в пределах от {1} до {2}" )]
        [Required(ErrorMessage = "Заполните приоритет!")]
        public int ProjectPriority { get; set; }

        [DisplayName("Дата начала")]
        [Required(ErrorMessage ="Нет даты!")]
        public DateTime StartDate { get; set; }

        [DisplayName("Дата завершения")]
        [Required(ErrorMessage = "Нет даты!")]
        public DateTime EndDate { get; set; }

        [DisplayName("Руководитель проекта")]
        [Required(ErrorMessage = "Это обязательное поле!")]
        public int ProjectLeaderId { get; set; }

        public DateTime DateTimeOfCreation { get; set; }

        public EmployeeViewModel ProjectLeader { get; set; }

        public CustomerCompanyViewModel CustomerCompany { get; set; }

        public ExecutingCompanyViewModel ExecutingCompany { get; set; }

    }
}
