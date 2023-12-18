using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Training
    {
        public int TrainingID { get; set; } 
        public string TrainingName { get; set; }
        public string TrainingDescription {  get; set; }
        public int LimitedSeat {  get; set; }
        public DateTime ScheduleTime { get; set; }
        public DateTime Deadline {  get; set; }
        public int PreRequisiteID { get; set; }
        public int DepartmentID { get; set; }

    }
}
