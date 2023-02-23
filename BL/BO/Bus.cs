using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;

namespace BO
{
    public class Bus
    {
        public int LicenseNumber { get; set; }
        public DateTime LicensingDate { get; set; }
        public DateTime DateOfLastCare { get; set; }
        public double Km { get; set; }
        public double KmSinceLastCare { get; set; }
        public double CurrentFuelContent { get; set; }
        public STATUS Status { get; set; }
        public bool IsAvailableBus { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsFireSafety { get; set; }
    }
}
