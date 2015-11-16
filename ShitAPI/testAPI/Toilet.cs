using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testAPI
{
    class Toilet
    {
        public string version { get; set; }
        public int toiletID { get; set; }
        public string command { get; set; }
        public bool occupy { get; set; }
        public long unixtime { get; set; }
        
    }
}
