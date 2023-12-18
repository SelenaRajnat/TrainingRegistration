using System.Web.Mvc;
using BusinessLayer.Services;
using EmployeeTrainingRegistration.Models;

namespace EmployeeTrainingRegistration.Controllers
{
    public class LoginController : Controller
    { 
    private readonly ILoginService _loggingIn;

    public LoginController(ILoginService loggingIn)
    {
        _loggingIn = loggingIn;
    }
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
        public ActionResult LogIntoAccount(UserAccount userAccount)
        {
            var isAuthenticated = _loggingIn.LoginResults(userAccount.EmailAddress, userAccount.Password);

            if (isAuthenticated)
            {
                var userRoleID = _loggingIn.GetUserRoleByIdResult(userAccount.EmailAddress);

                if (userRoleID != -1) // Check if a valid RoleID is retrieved
                {
                    // Successful login
                    var urlAction = userRoleID == 1 
                        ? Url.Action("Index", "Training")
                        : Url.Action("Index", "Login");

                    this.Session["CurrentUser"] = userAccount;
                    this.Session["CurrentRole"] = userRoleID;

                    return Json(new { Success = true, url = urlAction });
                }
            }
            // Return a JSON response indicating failure
            return Json(new { Success = false, ErrorMessage = "Invalid credentials!!" });
        }

    }
}
       
