using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingSystem.Models;

namespace TrainingSystem.ViewModel
{
    public class InstructorWithDeptsAndCrsVM
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string? ImgUrl { get; set; }

        [Range(6000,20000,ErrorMessage ="Salary must be between 6000 and 20000")]
        public int Salary { get; set; }

        [RegularExpression("(Smart|Menofia|Mansoura|Minia)",ErrorMessage = "Address must be one of (Smart|Menofia|Mansoura|Minia)")]
        public string Address { get; set; }

        [Display(Name="Departent")]
        public int Dept_Id { get; set; }

        [Display(Name ="Course")]
        public int Crs_Id { get; set; }

        public List<Department>? Departments { get; set; }

        public  List<Course>? Courses { get; set; }
    }
}
