using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class SecurityCodeValidator : ValidationAttribute
    {
        public SecurityCodeValidator()
        {
        }

        public override bool IsValid(object value)
        {
            var code = (string)value;
            if (code != "")
            {
                if (code.Length == 3)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
