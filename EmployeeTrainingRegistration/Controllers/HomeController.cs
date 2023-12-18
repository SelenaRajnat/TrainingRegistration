using System.Web.Mvc;
using EmployeeTrainingRegistration.Custom;
using EmployeeTrainingRegistration.DataService;

namespace EmployeeTrainingRegistration.Controllers
{
    [UserSession]
    public class HomeController : Controller
    {
        private readonly IDataAccessLayer _layer;

        public HomeController(IDataAccessLayer layer)
        {
            _layer = layer;
        }
        public ActionResult Index()
        { 
            ViewBag.Message = _layer.Connect();

            return RedirectToAction("Index", "Login");
        }

    }
}