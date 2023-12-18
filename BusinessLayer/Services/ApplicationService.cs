using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLayer.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRespository;
        public ApplicationService(IApplicationRepository applicationRespository)
        {
            _applicationRespository = applicationRespository;
        }
        public List<Application> GetEmployeeDetail()
        {
            return _applicationRespository.RetrieveEmployeeDetail();
        }

    }
}
