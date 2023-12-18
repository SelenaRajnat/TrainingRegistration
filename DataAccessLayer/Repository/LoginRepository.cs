using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using EmployeeTrainingRegistration.Models;
using EmployeeTrainingRegistration.DataService;

namespace DataAccessLayer.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDataAccessLayer _dataAccesslayer;
        public LoginRepository(IDataAccessLayer layer)
        {
            _dataAccesslayer = layer;
        }
        public UserAccount GetAccountByEmailAddress(string emailAddress)
        {
            try
            {

                UserAccount userAccount = new UserAccount();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@emailAddress", emailAddress));
                const string AccountUsingEmailAddress = @"SELECT UserAccountID, EmailAddress, HashedPassword,RoleID 
                                                                FROM UserAccount WHERE EmailAddress=@emailAddress";
                using (SqlDataReader reader = _dataAccesslayer.GetDataWithConditions(AccountUsingEmailAddress, parameters))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        userAccount.UserAccountID = Convert.ToInt32(reader["UserAccountID"]);
                        userAccount.EmailAddress = reader["EmailAddress"].ToString();
                        userAccount.Password = reader["HashedPassword"].ToString();
                        userAccount.RoleID = Convert.ToInt32(reader["RoleID"]);
                    }
                }

                return userAccount;
            }
            catch (Exception) {throw;}
        }

        public UserRole GetUserRoleById(string emailAddress)
        {
            try
            {
                UserRole userRole = new UserRole();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@emailAddress", emailAddress));

                const string GETROLEID = @"SELECT RoleID, RoleName FROM UserRole WHERE RoleID IN (SELECT RoleID FROM UserAccount 
                                                WHERE EmailAddress=@emailAddress)";
                using (SqlDataReader reader = _dataAccesslayer.GetDataWithConditions(GETROLEID, parameters))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        userRole.RoleID = Convert.ToInt32(reader["RoleID"]);
                        userRole.RoleName = reader["RoleName"].ToString();
                    }
                }
                return userRole;
            }
            catch (Exception) { throw; }

        }

        public bool InsertedNewAccount(UserAccount newUser)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@EmailAddress", newUser.EmailAddress));
                parameters.Add(new SqlParameter("@HashedPassword", newUser.Password));
                parameters.Add(new SqlParameter("@RoleID", newUser.RoleID));

                const string NewAccount = @"INSERT INTO UserAccount(EmailAddress, Password, RoleID) 
                                                  VALUES(@EmailAddress, @HashedPassword, @UserAccountStatus, @RoleID)";
                int userCount = _dataAccesslayer.ExecuteQuery(NewAccount, parameters);

                return userCount > 0;
            }
            catch (Exception) {throw; }
        }

        public bool IsAuthenticated(string emailAddress, string password)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
            {
            new SqlParameter("@EmailAddress", SqlDbType.VarChar, 100) { Value = emailAddress },
            new SqlParameter("@Password", SqlDbType.VarChar, 30) { Value = password}
             };
                const string AuthenticateUserAccount = @"SELECT 1 FROM UserAccount WHERE EmailAddress=@EmailAddress AND HashedPassword = @Password";
                using (SqlDataReader reader = _dataAccesslayer.GetData(AuthenticateUserAccount, parameters))
                {
                    return reader.HasRows;
                }
            }
            catch (Exception){ throw; }
        }

    }
}

