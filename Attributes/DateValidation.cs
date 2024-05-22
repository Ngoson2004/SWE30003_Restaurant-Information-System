using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Attributes
{
    public class DateRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Reservation date must be after current time.");
                }
            }
            return new ValidationResult("Invalid date and time");
        }
    }
}
