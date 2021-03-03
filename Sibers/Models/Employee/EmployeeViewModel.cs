using Sibers.Models.ExecutingCompany;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sibers.Models.Employee
{
    public class EmployeeViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(50, ErrorMessage = "Название слишком большое")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(50, ErrorMessage = "Название слишком большое")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(50, ErrorMessage = "Название слишком большое")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(50, ErrorMessage = "Название слишком большое")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        public long Company { get; set; }

        public DateTime DateTimeOfCreation { get; set; }
        public ExecutingCompanyViewModel ExecutingCompany { get; set; }
    }
}
