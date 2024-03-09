using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrainingSystem.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        TrainingSystemContext context = new TrainingSystemContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string Name = value.ToString();
            Course courseFromRequest = validationContext.ObjectInstance as Course;

            Course courseFromDB = context.Courses.Include(c=>c.department).FirstOrDefault(c => c.Name == Name && c.Dept_Id == courseFromRequest.Dept_Id);

            if (courseFromDB == null || courseFromRequest.Id == courseFromDB.Id)
                return ValidationResult.Success;
           
            return new ValidationResult($"Name Already Exists in {courseFromDB.department.Name}");
        }
    }
}
