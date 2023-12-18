using EmployeeTrainingRegistration.Models;

namespace DataAccessLayer.Repository
{
    public interface ILoginRepository
    {
        UserAccount GetAccountByEmailAddress(string emailAddress);
        UserRole GetUserRoleById(string emailAddress);
        bool InsertedNewAccount(UserAccount account);
        bool IsAuthenticated(string emailAddress, string password);

    }
}
