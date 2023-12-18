using System.Web.Mvc;
using EmployeeTrainingRegistration.Custom;

namespace EmployeeTrainingRegistration.Controllers
{
    [UserSession]
    public class LogoutController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        // GET: Logout
        public ActionResult Index()
        {
                Session.Clear();
                return RedirectToAction("Index", "Login");     
        }
    }

}
