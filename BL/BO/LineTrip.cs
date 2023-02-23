using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineTrip
    {
        public int LineNumber { get; set; }
        public string NameOfLastStation { get; set; }
        public TimeSpan  LeavingTime { get; set; }
        public  TimeSpan ArrivingTime { get; set; }
    }
}
