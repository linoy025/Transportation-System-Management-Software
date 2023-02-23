using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LeavingLine
    {
        public int LineId { get; set; }     
        public TimeSpan StartingTime { get; set; }
        public bool IsAvailableLeavingLine { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
        
        

    }
}
