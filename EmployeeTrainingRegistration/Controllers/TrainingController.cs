using System.Web.Mvc;
using BusinessLayer.Services;
using EmployeeTrainingRegistration.Custom;

namespace EmployeeTrainingRegistration.Controllers
{
    [UserSession]
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        // GET: Training
        public ActionResult Index()
        {
            var trainingData = _trainingService.GetTraining();
            return View(trainingData); 

        }
        public ActionResult EnrolledList()
        {
            return View("EnrolledList");

        }
    }

}