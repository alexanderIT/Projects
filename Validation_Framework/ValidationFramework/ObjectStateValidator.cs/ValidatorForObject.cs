using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectStateValidator.cs.Annotation;
using System.Collections;

namespace ObjectStateValidator.cs
{
   public class ValidatorForObject: IValidator
    {
       private object validatableObject;
       private IDictionary<string, IList<string>> errors;
       private bool? objectValidated;
       public ValidatorForObject(object validatableObject)
       {
           if (validatableObject == null)
           {
               throw new ArgumentNullException("Object cannot be null!");
           }
           this.validatableObject = validatableObject;
           this.errors = new Dictionary<string, IList<string>>();
       }
       public void Validate()
       {
          this.objectValidated = true;
          this.Validate(this.validatableObject);
       }

       public bool IsValid
       {
           get 
           {
               if (!this.objectValidated.HasValue)
               {
                   throw new InvalidOperationException("You must invoke the Validate() method first!");
               }
               return this.errors.Count == 0;
           }
       }

       public IDictionary<string, IList<string>> Errors
       {
           get { return this.errors; }
       }
       private void Validate(object obj)
       {

           if (obj == null)
           {
               return;
           }
           var type = obj.GetType();
           foreach (var property in type.GetProperties())
           {
              var propertyName = property.Name;
              var valueToValidate = property.GetValue(obj);
               var validationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
               foreach (var attribute in validationAttributes)
               {
                   
                   var attributeAsValidation=((ValidationAttribute)attribute);
                   var result = attributeAsValidation.Validate(valueToValidate);
                   if (!result)
                   {
                       var errorMsg = attributeAsValidation.ErrorMessage;
                       this.LogError(propertyName, string.Format(errorMsg, propertyName));
                   }
               }
               if (valueToValidate!=null && (valueToValidate is ICollection) && property.PropertyType.IsClass)
               {
                   this.Validate(valueToValidate);
               }
           }
           
       }
       private void LogError(string name, string error)
       {
           if (!this.errors.ContainsKey(name))
           {
              this.errors.Add(name,new List<string>());
           }
           this.errors[name].Add(error);
       }
    }
}
