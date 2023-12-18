using System.Collections.Generic;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public interface IApplicationService
    {
        List<Application> GetEmployeeDetail();
    }
}
