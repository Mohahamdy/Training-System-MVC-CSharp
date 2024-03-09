using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingSystem.Models;
using TrainingSystem.Repository;

namespace TrainingSystem.Controllers
{
    public class CourseController : Controller
    {
        //TrainingSystemContext context = new TrainingSystemContext();
        ICourseRepository _courseRepository;
        IDepartmentRepository _departmentRepository;
        public CourseController(ICourseRepository courseRepository,IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }
        public IActionResult CheckMinDegreeLessThanDegree(int MinDegree, int Degree)
        {
            if(MinDegree >= Degree)
                return Json(false);

            return Json(true);
        }
        public IActionResult Index()
        {
            List<Course> coursesModel = _courseRepository.GetAll().OrderBy(c=>c.department.Name).ToList();
            
            return View("Index",coursesModel);
        }

        public IActionResult Details(int id)
        {
            Course courseModel = _courseRepository.GetById(id);

            return View("Details", courseModel);
        }
        public IActionResult Add()
        {
            ViewBag.Depts = _departmentRepository.GetAll();
            return View("Add");
        }

        [HttpPost]
        public IActionResult SaveAdd(Course course)
        {
            if (ModelState.IsValid == true)
            {
                _courseRepository.Insert(course);
                _courseRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Depts = _departmentRepository.GetAll();
            return View("Add", course);
        }

        public IActionResult Edit(int id)
        {
            Course courseModel = _courseRepository.GetById(id);
            ViewBag.Depts = _departmentRepository.GetAll();
            return View("Edit",courseModel);
        }

        public IActionResult SaveEdit(Course course)
        {
            if (ModelState.IsValid == true)
            {
                _courseRepository.Update(course);
                _courseRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Depts = _departmentRepository.GetAll();
            return View("Edit", course);
        }

        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);
            _courseRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
