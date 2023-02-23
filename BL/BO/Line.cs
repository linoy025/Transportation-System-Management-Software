using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;

namespace BO
{
    public class Line
    {
        public int LineId { get; set; }
        public int LineNumber { get; set; }
        public AREA Area { get; set; }
        public int FirstStationId { get; set; }
        public int LastStationId { get; set; }
        public bool IsNightLine { get; set; }
        public bool IsAvailableLine { get; set; }
        public bool IsUrbanLine { get; set; }
        public List<StationLine> ListOfStationLine{ get; set; }
    }
}
