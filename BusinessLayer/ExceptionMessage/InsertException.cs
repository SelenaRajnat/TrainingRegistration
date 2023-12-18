using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ExceptionMessage
{
    public class InsertException : Exception
    {
        public InsertException(string message, int value) : base($"{message} - value: {value}") { }
    }

}
