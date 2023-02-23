using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class UserJourney
    {
        public int TripId { get; set; }
        public string UserName { get; set; }
        public int LineId { get; set; }
        public int UploadStationId { get; set; }
        public TimeSpan UploadTime { get; set; }
        public int DropOffStationId { get; set; }
        public TimeSpan DropOffTime { get; set; }
    }
}
