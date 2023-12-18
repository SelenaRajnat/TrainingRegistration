using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using EmployeeTrainingRegistration.DataService;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly IDataAccessLayer _dataAccesslayer;
        public RegisterRepository(IDataAccessLayer layer)
        {
            _dataAccesslayer = layer;
        }
        public bool InsertNewEmployee(Employee employee)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                new SqlParameter("@NIC", SqlDbType.VarChar, 15) { Value = employee.NationalIdentityNumber },
                new SqlParameter("@FirstName", SqlDbType.VarChar, 50) { Value = employee.FirstName },
                new SqlParameter("@LastName", SqlDbType.VarChar, 50) { Value = employee.LastName },
                new SqlParameter("@PhoneNumber", SqlDbType.Int) { Value = employee.PhoneNumber},
                //new SqlParameter("@Department", SqlDbType.VarChar, 50) { Value = employee.Department },
                //new SqlParameter("@ManagerName", SqlDbType.VarChar, 50) { Value = employee.ManagerName },
                //new SqlParameter("@JobTitle", SqlDbType.VarChar, 50) { Value = employee.JobTitle},
                //new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50) { Value = employee.EmailAddress},
                //new SqlParameter("@Password", SqlDbType.VarChar, 50) { Value = employee.NewPassword},
                };
                const string sql = "INSERT INTO employee1 VALUES " +
                    "('10',@NIC,@FirstName,@LastName/*,@PhoneNumber,@Department,@ManagerName,@JobTitle,@EmailAddress, @Password*/)";
                int userCount = _dataAccesslayer.ExecuteQuery(sql, parameters);

                return userCount > 0;
            }
            catch (Exception exInsert)
            {
                Console.Error.WriteLine("Error occur at Insertion." + exInsert.Message);
            }
            return false;
        }

        public bool NationalIdentityNumberAlreadyExists(string nationalIdentityNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NationalIdentityNumber", nationalIdentityNumber));
            const string CheckIfNationalIdentityNumberAlreadyExists = @"SELECT EmployeeID FROM Employee 
                                                                            WHERE NationalIdentityNumber=@NationalIdentityNumber";
            using (SqlDataReader reader = _dataAccesslayer.GetDataWithConditions(CheckIfNationalIdentityNumberAlreadyExists, parameters))
            {
                return reader.HasRows;
            }
        }

        public bool PhoneNumberAlreadyExists(string phoneNumber)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
            const string CheckIfPhoneNumberAlreadyExists = @"SELECT EmployeeID FROM Employee WHERE PhoneNumber=@PhoneNumber";
            using (SqlDataReader reader = _dataAccesslayer.GetDataWithConditions(CheckIfPhoneNumberAlreadyExists, parameters))
            {
                return reader.HasRows;
            }
        }
    }
}

