using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Domain.Util
{
    public static class ObjectValidator
    {
        public static bool IsValid(object o)
        {
            return Validator.TryValidateObject(
                o,
                new ValidationContext(o), 
                new List<ValidationResult>(), 
                true);
        }
    }
}
