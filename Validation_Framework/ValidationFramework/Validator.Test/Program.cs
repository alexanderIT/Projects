using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectStateValidator.cs;
using Validator.Test;


namespace ValidatorObject.Test
{
    class Program
    {
        static void Main()
        {
            var student = new Student
            {
                FirstName = "Sasho",
                LastName = "Milushev",
                Age = 29,
                Marks = new List<int> {4,5,5,6,6},
                Mentor = new Student
                {
                    FirstName="Ivan",                    
                    Age=35,
                    Marks = new List<int> { 6, 6, 6, 6 },
                }
            };

            var studentValidator =new ValidatorForObject(student);
            studentValidator.Validate();
            if (!studentValidator.IsValid)
            {
                foreach (var error in studentValidator.Errors)
                {
                    Console.WriteLine(error.Key);
                }
            }
        }
    }
}
