using Sibers.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Models.CustomerCompany
{
    public class CustomerCompanyViewModel
    {
        [Required]
        public long Id { get; set; }
        [Required(ErrorMessage = "Это обязательное поле!")]
        [MaxLength(50,ErrorMessage ="Название слишком большое")]
        //Здесь есть проверка на уникальность, но я с самого начала неправильно работал с View и ViewModel. 
        //Из-за того, что я объединил функции ADD и Change эта проверка не даёт изменить запись, быстрые решения — это костыли. 
        //[UniqueCustomerCompanyName(ErrorMessage = "Такая компания уже есть!")]
        public string CompanyName { get; set; }
        [MaxLength(250, ErrorMessage = "Описание слишком большое")]
        public string Description { get; set; }
    }
}
