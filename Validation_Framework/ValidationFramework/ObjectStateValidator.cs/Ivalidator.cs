
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectStateValidator.cs
{
   public interface IValidator
    {
       void Validate();
       bool IsValid { get; }
        IDictionary<string, IList<string>> Errors { get; }
    }
}
