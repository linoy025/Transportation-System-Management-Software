using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAvailableUser { get; set; }
    }
}
