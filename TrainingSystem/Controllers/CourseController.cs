using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingSystem.Models;

namespace TrainingSystem.Controllers
{
    public class CourseController : Controller
    {
        TrainingSystemContext context = new TrainingSystemContext();

        public IActionResult CheckMinDegreeLessThanDegree(int MinDegree, int Degree)
        {
            if(MinDegree >= Degree)
                return Json(false);

            return Json(true);
        }
        public IActionResult Index()
        {
            List<Course> coursesModel = context.Courses.Include(c=>c.department).ToList();
            
            return View("Index",coursesModel);
        }

        public IActionResult Details(int id)
        {
            Course courseModel = context.Courses.Include(c=>c.department).FirstOrDefault(c=>c.Id== id);

            return View("Details", courseModel);
        }
        public IActionResult Add()
        {
            ViewBag.Depts = context.Departments.ToList();
            return View("Add");
        }

        [HttpPost]
        public IActionResult SaveAdd(Course course)
        {
            if (ModelState.IsValid == true)
            {
                context.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Depts = context.Departments.ToList();
            return View("Add", course);
        }
    }
}
