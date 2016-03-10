using ObjectStateValidator.cs.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator.Test
{
    public class RangeAttribute : ValidationAttribute
    {
      private int min;
      private int max;
      public RangeAttribute(int min, int max)
      {
          this.min = min;
          this.max = max;
          this.ErrorMessage = "{0} should be between" + min + "and" + max + ".";
      }

      public override bool Validate(object obj)
      {
          if (obj is int)
          {
              var objAsInt = (int)obj;
              if (min<=objAsInt && objAsInt<=max)
              {
                  return true;
              }
              
          }
          return false;
      }
    }
}
