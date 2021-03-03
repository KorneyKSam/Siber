using Sibers.DbStuff.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sibers.Models.CustomAttributes
{
    public class UniqueCustomerCompanyNameAttribute : ValidationAttribute
    {

        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"{name} is not unique name!"
                : ErrorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if( value != null && !(value is string))
                throw new Exception("This Attribute must be applied for string");
            if (value == null)
                return new ValidationResult("Value can't be null");

            var company = (string)value;
            var customerCompanyRepository= validationContext.GetService(typeof(Customer_Company_Repository)) as Customer_Company_Repository;
            var existingCompany = customerCompanyRepository.FindExistingCustomerCompany(company);
            
            if (existingCompany != null)
                return new ValidationResult(FormatErrorMessage(company));

            return ValidationResult.Success;
        }
    }
}
