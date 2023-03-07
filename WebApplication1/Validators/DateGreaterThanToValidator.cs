using Domain.Models;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Validators
{
    public class DateGreaterThanToValidator: ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"To Date has to be in the future and greater than the To Date {DateTime.Now.Year}.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var reservation = (ReservationViewModel)validationContext.ObjectInstance;

            if (reservation.To <= reservation.From) 
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
