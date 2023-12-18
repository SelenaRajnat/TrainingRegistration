using System.Web.Mvc;
using BusinessLayer.Services;
using EmployeeTrainingRegistration.Custom;

namespace EmployeeTrainingRegistration.Controllers
{
    [UserSession]
    public class ApplicationController : Controller
    {
        // GET: Application
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
           
            var applicationData = _applicationService.GetEmployeeDetail();

            return View(applicationData);
               
        }
    }
}
