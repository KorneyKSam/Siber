using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Models.CustomAttributes
{
    public class CheckNameAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"{name} must has at least one capital letter"
                : ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (value != null && !(value is string))
                throw new Exception("This attribute must be applied only for string fields");

            if(value == null)
                return false;

            var str = (string)value;
            //Check the name has one ore more capital letter
            return str.ToLower() != str;
        }

    }
}
