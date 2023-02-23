using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {
        public int StationId { get; set; }
        public double Logtitude { get; set; }
        public double Latitude { get; set; }
        public string StationName { get; set; }
        public string StationAddress { get; set; }
        public bool IsAvailableStation { get; set; }
        public IEnumerable <Line> ListOfLinesThatPassInStation { get; set; }
    }
}
