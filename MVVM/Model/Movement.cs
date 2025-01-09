using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Tracker.MVVM.Model
{
    public class Movement
    {
        public int movementId { get; set; }
        public double movementValue { get; set; } 
        public DateTime date { get; set; }
        public int type { get; set; }
        public int month { get; set; }
        public string description { get; set; }
    }
}
