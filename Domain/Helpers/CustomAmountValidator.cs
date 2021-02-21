using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class CustomAmountValidator : ValidationAttribute
    {
        public CustomAmountValidator()
        {
        }

        public override bool IsValid(object value)
        {
            var amount = (decimal)value;
            if (amount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
