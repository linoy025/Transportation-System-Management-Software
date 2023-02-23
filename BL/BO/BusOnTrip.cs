using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BusOnTrip
    {
        public int BusOnTripId { get; set; }
        public int BusLineId { get; set; }
        public int LicenseNumber { get; set; }
        public int LineId { get; set; }
        public TimeSpan PlannedTakeOff { get; set; }
        public TimeSpan ActualTakeOff { get; set; }
        public int LastStopIdInBusOnTrip { get; set; }
        public TimeSpan TransitTimeLastStopIdInBusOnTrip { get; set; }
        public int GettingTimetoNextStation { get; set; }
        public int DriverId { get; set; }
    }
}
