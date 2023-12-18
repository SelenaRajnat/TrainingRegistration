using System.Web.Mvc;

namespace EmployeeTrainingRegistration.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
