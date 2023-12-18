using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Models;
using EmployeeTrainingRegistration.DataService;
using static DataAccessLayer.Repository.TrainingRepository;

namespace DataAccessLayer.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
            private readonly IDataAccessLayer _dataAccessLayer;

            public TrainingRepository(IDataAccessLayer dataAccessLayer)
            {
                _dataAccessLayer = dataAccessLayer;
            }
            public List<Training> GetTrainingData()
            {
                try
                {
                    string sql = "SELECT * FROM Training";
                    using (SqlDataReader reader = _dataAccessLayer.RetrieveData(sql))
                    {
                        var trainingData = new List<Training>();

                    while (reader.Read())
                    {
                        var fetchedTraining = new Training
                        {
                            TrainingID = Convert.ToInt32(reader["TrainingID"]),
                            TrainingName = reader["TrainingName"].ToString(),
                            TrainingDescription = reader["TrainingDescription"].ToString(),
                            LimitedSeat = Convert.ToInt32(reader["LimitedSeat"]),
                            ScheduleTime = Convert.ToDateTime(reader["ScheduleTime"]),
                            Deadline = Convert.ToDateTime(reader["Deadline"]),
                            PreRequisiteID = Convert.ToInt32(reader["PreRequisiteID"]),
                            DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                        };
                        trainingData.Add(fetchedTraining);
                    }
                        return trainingData;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
    }
    
}
