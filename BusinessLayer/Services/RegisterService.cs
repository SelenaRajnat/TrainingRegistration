using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLayer.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterService(IRegisterRepository employeeRepository)
        {
            _registerRepository = employeeRepository;
        }
        public bool RegisterResults(Employee employee)
        {
                return _registerRepository.InsertNewEmployee(employee);
        }

    }
}

