using NSE.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Extensions.CustomDataAnnotations.CpfAnnotation
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return Cpf.Validate(value.ToString()) ? ValidationResult.Success : new ValidationResult("CPF em formato inválido");
        }
    }
}
