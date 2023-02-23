using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public  class StationInLine
    {
        public int LineId { get; set; }
        public int StationId { get; set; }
        public int StationInLineLocation { get; set; }
        public bool DropOffStation { get; set; }
        public bool UploadStation { get; set; }
        public bool IsAvailableStationInLine { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
