using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTrainingRegistration.Models;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentID { get; set;}
        public string JobTitle { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
