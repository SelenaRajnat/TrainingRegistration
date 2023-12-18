using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public interface IRegisterRepository
    {
        bool InsertNewEmployee(Employee employee);
        bool NationalIdentityNumberAlreadyExists(string nationalIdentityNumber);
        bool PhoneNumberAlreadyExists(string phoneNumber);
    }
}
