using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTrainingRegistration.Models
{
    public class UserAccount
    {
        public int UserAccountID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
    }
}