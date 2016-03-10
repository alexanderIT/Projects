using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectStateValidator.cs.Annotation
{
   public abstract class ValidationAttribute: Attribute
    {
        public string ErrorMessage { get; set; }
       public abstract bool Validate(object obj);
    }
}
