using Sibers.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Models.ExecutingCompany
{
    public class ExecutingCompanyViewModel
    {
        [Required]
        public long Id { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(50, ErrorMessage = "Название слишком большое")]
        //[UniqueExecutingCompanyName(ErrorMessage = "Такая компания уже есть!")]
        public string CompanyName { get; set; }

        [MaxLength(250, ErrorMessage = "Описание слишком большое")]
        public string Description { get; set; }
    }
}
