using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LeavingLine
    {
        public int LineId { get; set; }
        public TimeSpan StartingTime { get; set; }
        public bool IsAvailableLeavingLine { get; set; }
    }
}
