using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTrainingRegistration.Models;

namespace BusinessLayer.Services
{
    public interface ILoginService
    {
        int GetUserRoleByIdResult(string emailAddress);
        bool LoginResults(string emailAddress,string password);
    }
}
