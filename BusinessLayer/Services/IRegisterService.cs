using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using EmployeeTrainingRegistration.Models;

namespace BusinessLayer.Services
{
    public interface IRegisterService
    {
        bool RegisterResults(Employee employee);
    }
}
