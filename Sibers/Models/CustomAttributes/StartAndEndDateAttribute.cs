using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Models.CustomAttributes
{
    public class StartAndEndDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(!(value is DateTime))
            {
                throw new Exception("Attribute must be used only for DateTime");
            }
            var date = (DateTime)value;
            return base.IsValid(value);
        }
    }
}
