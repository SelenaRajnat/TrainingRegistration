using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Services;
using DataAccessLayer.Models;
using EmployeeTrainingRegistration.Models;

namespace EmployeeTrainingRegistration.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private readonly IRegisterService _register;
        public RegisterController(IRegisterService employee)
        {
            _register = employee;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Verify(Employee employee)
        {
            if (_register.RegisterResults(employee))
            {
                // Return a JSON response indicating success
                return Json(new { Success = true, url = Url.Action("Index", "Login") });
            }
            else
            {
                // Return a JSON response indicating failure
                return Json(new { Success = false, ErrorMessage = "Unable to register user!" });
            }
        }

    }
}


 
