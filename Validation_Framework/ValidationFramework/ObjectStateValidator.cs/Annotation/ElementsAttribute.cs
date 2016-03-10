using ObjectStateValidator.cs.Annotation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validator.Test
{
   public class ElementsAttribute : ValidationAttribute
    {
       private int maxCount;
       public ElementsAttribute(int maxCount)
       {
           this.maxCount = maxCount;
           this.ErrorMessage = "{0} should have maximum of " + maxCount + "elements.";
       }
       public int MinCount { get; set; }

       public override bool Validate(object obj)
       {
           if (obj is string)
           {
               string objAsString = (string)obj;
               if (this.MinCount<=objAsString.Length && objAsString.Length<=maxCount)
               {
                   return true;
               }
           }
           if (obj is ICollection)
           {
               var collection = (ICollection)obj;
               if (this.MinCount <= collection.Count && collection.Count <= maxCount)
               {
                   return true;
               }
           }
           return false;
       }
    }
}
