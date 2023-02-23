using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class StationLine
    {
        public string StationName { get; set; } 
        public int LineId { get; set; }
        public int PreviousStationId { get; set; }
        public int StationId { get; set; }
        public int NextStationId { get; set; }
        public bool DropOffStation { get; set; }
        public bool UploadStation { get; set; }
        public double DistanceBetweenTwoAdjacentSations { get; set; }
        public double AverageTravelTime { get; set; }
        public double PreviousDistanceBetweenTwoAdjacentSations { get; set; }
        public double NextAverageTravelTime { get; set; }
        public bool IsAvailableStationInLine { get; set; }
        public int StationInLineLocation { get; set; }
    }
}
