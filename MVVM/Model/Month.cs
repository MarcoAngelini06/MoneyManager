using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Money_Tracker.MVVM.Model
{
    public class Month
    {
        public int monthID {  get; set; }
        public double subscription {  get; set; }
        public string name { get; set; }
        public double income { get; set; }
        public double expenses { get; set; }
        public double tot
        {
            get
            {
                return income - expenses-subscription;
            }
        }
    }
}
