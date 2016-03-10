using ObjectStateValidator.cs.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator.Test
{
    public class MandatoryAttribute : ValidationAttribute
    {
        public MandatoryAttribute()
        {
            this.ErrorMessage = "{} cannot be null because it is required";
        }
        public override bool Validate(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            return true;
        }
    }
}
