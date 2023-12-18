using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;


namespace BusinessLayer.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRespository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRespository = trainingRepository;
        }
        public List<Training> GetTraining()
        {
            return _trainingRespository.GetTrainingData();
        }
    }
}
