using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public interface ITrainingRepository
    {
            List<Training> GetTrainingData();  
    }
}
