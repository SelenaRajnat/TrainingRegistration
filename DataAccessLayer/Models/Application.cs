using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public int TrainingID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime CurrentDate { get; set; }
        public int AttachmentID {  get; set; } 

    }
}
