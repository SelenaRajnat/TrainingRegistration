using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public interface IApplicationRepository
    {
        List<Application> RetrieveEmployeeDetail();
    }
}
