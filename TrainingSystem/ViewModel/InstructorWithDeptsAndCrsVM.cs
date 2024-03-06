using TrainingSystem.Models;

namespace TrainingSystem.ViewModel
{
    public class InstructorWithDeptsAndCrsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public int Dept_Id { get; set; }
        public int Crs_Id { get; set; }

        public List<Department> Departments { get; set; }

        public  List<Course> Courses { get; set; }
    }
}
