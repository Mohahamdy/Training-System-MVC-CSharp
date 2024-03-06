using Microsoft.AspNetCore.Mvc;
using TrainingSystem.Models;
using TrainingSystem.ViewModel;

namespace TrainingSystem.Controllers
{
    public class TraineeController : Controller
    {
        TrainingSystemContext context = new TrainingSystemContext();

        public List<StNameAndCrsNameAndDegreeAndClr> GetResults(int stId = 0 ,int crsId = 0)
        {
            var q = context.CrsResults.AsQueryable();

            if (stId == 0)
                q = q.Where(c => c.Crs_Id == crsId);
            else if (crsId == 0)
                q = q.Where(c => c.Trainee_Id == stId);
            else
                q = q.Where(c => c.Trainee_Id == stId && c.Crs_Id == crsId);

            var CrsDegreesVM = q.Select(c => new StNameAndCrsNameAndDegreeAndClr
            {
                StName = c.trainee.Name,
                CrsName= c.course.Name,
                Degree = c.Degree,
                Clr = (c.Degree > c.course.MinDegree)? "green":"red"
            }).ToList();

            return CrsDegreesVM;
        }
        public IActionResult ShowResult(int id,int CrsId)
        {
            StNameAndCrsNameAndDegreeAndClr crsDegreesVM = GetResults(id, CrsId)[0];
            return View("showResult", crsDegreesVM);
        }

        public IActionResult ShowCourseResult(int id)
        {
            List<StNameAndCrsNameAndDegreeAndClr> crsDegreesVM = GetResults(0,id);
            return View("ShowCourseResult", crsDegreesVM);
        }

        public IActionResult ShowTraineeResult(int id)
        {
            List<StNameAndCrsNameAndDegreeAndClr> crsDegreesVM = GetResults(id);
            return View("ShowTraineeResult", crsDegreesVM);
        }
    }
}
