using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using DataAccessLayer.Repository;


namespace BusinessLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _accountRepository;
        public LoginService(ILoginRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public int GetUserRoleByIdResult(string emailAddress)
        {
            var userAccount = _accountRepository.GetUserRoleById(emailAddress);
            return userAccount?.RoleID ?? -1; // Return -1 if user not found or if RoleID is not set
        }

        public bool LoginResults(string emailAddress, string password)
        {
            return _accountRepository.IsAuthenticated(emailAddress, password);
        }

    }
}

