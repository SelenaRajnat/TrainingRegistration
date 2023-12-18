using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Models;
using EmployeeTrainingRegistration.DataService;

namespace DataAccessLayer.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IDataAccessLayer _dataAccessLayer;

        public ApplicationRepository(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        public List<Application> RetrieveEmployeeDetail()
        {
            try
            {
                string sql = "SELECT * FROM Application";
                using (SqlDataReader reader = _dataAccessLayer.RetrieveData(sql))
                {
                    var applicationDetail = new List<Application>();

                    while (reader.Read())
                    {
                        var fetchedApplication = new Application
                        {
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                            TrainingID = Convert.ToInt32(reader["TrainingID"]),
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),

                        };
                        applicationDetail.Add(fetchedApplication);
                    }
                    return applicationDetail;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }   
        
    }
}
