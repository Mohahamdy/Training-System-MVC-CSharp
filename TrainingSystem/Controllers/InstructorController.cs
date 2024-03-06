using Microsoft.AspNetCore.Mvc;
using TrainingSystem.Models;
using TrainingSystem.ViewModel;

namespace TrainingSystem.Controllers
{
    public class InstructorController : Controller
    {
        TrainingSystemContext context = new TrainingSystemContext();
        public IActionResult Index()
        {
            var instructorsModel = context.Instructors.Select(i=> new {i.Id,i.Name,i.ImgUrl,i.Salary,i.Address,Department = i.department.Name,Course = i.course.Name }).ToList();
            return View("ShowAll", instructorsModel);
        }

        public IActionResult Detail(int id)
        {
            var instructorModel = context.Instructors.Where(i=> i.Id == id).Select(i => new { i.Id, i.Name, i.ImgUrl, i.Salary, i.Address, Department = i.department.Name, Course = i.course.Name }).ToList();
            return View("Details", instructorModel);
        }

        public IActionResult Add()
        {
            InstructorWithDeptsAndCrsVM insVM = new InstructorWithDeptsAndCrsVM() {
                Departments = context.Departments.ToList(),
                Courses = context.Courses.ToList()
            };
            return View("Add",insVM);
        }

        [HttpPost]
        public IActionResult SaveAdd(InstructorWithDeptsAndCrsVM insVM,IFormFile file)
        {
            if(file != null && file.Length > 0 && file.ContentType.Split("/")[0] == "image")
            {
                
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = $"wwwroot/Images/{fileName}";
                FileStream fs = new FileStream(imgPath, FileMode.Create);
                file.CopyTo(fs);
                fs.Close();
                insVM.ImgUrl = fileName;
            }

            if(insVM.Name != null && insVM.Salary > 2000)
            {
                Instructor instructor = new Instructor()
                {
                    Name = insVM.Name,
                    Salary = insVM.Salary,
                    Address = insVM.Address,
                    ImgUrl = insVM.ImgUrl,
                    Dept_Id = insVM.Dept_Id,
                    Crs_Id = insVM.Crs_Id,
                };
                context.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            insVM.Departments = context.Departments.ToList();
            insVM.Courses = context.Courses.ToList();

            return View("Add", insVM);
        }

        public IActionResult Edit(int id)
        {
            Instructor insModel = context.Instructors.FirstOrDefault(i => i.Id == id);
            if (insModel == null)
                return NotFound();
            InstructorWithDeptsAndCrsVM insVM = new InstructorWithDeptsAndCrsVM()
            {
                Id = insModel.Id,
                Name = insModel.Name,
                Salary = insModel.Salary,
                Address = insModel.Address,
                ImgUrl = insModel.ImgUrl,
                Dept_Id = insModel.Dept_Id,
                Crs_Id = insModel.Crs_Id,
                Departments = context.Departments.ToList(),
                Courses = context.Courses.ToList()
            };

            return View("Edit", insVM);
        }

        [HttpPost]
        public IActionResult SaveEdit(InstructorWithDeptsAndCrsVM insVM,IFormFile file)
        {
            if(file!=null && file.Length>0 && file.ContentType.Split("/")[0] == "image")
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = $"wwwroot/Images/{fileName}";
                FileStream fs = new FileStream(imgPath,FileMode.Create);
                file.CopyTo(fs);
                fs.Close();
                insVM.ImgUrl = fileName;
            }

            if(insVM.Name != null && insVM.Salary != 0)
            {
                Instructor insModel = context.Instructors.FirstOrDefault(i => i.Id == insVM.Id);
                if (insModel == null)
                    return NotFound();
                insModel.Name = insVM.Name;
                insModel.Salary = insVM.Salary;
                insModel.Address = insVM.Address;
                insModel.ImgUrl = insVM.ImgUrl;
                insModel.Dept_Id = insVM.Dept_Id;
                insModel.Crs_Id = insVM.Crs_Id;

                context.Update(insModel);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", insVM);
        }
    }
}
