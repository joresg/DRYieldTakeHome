using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRYieldTakeHome
{
    internal class PTR
    {
        public PTR() { }

        public int CHIPN { get; set; }
        public string RESULT { get; set; }
        public string TEST_TXT { get; set; }
        public string UNITS { get; set; }
        public string LO_SPEC { get; set; }
        public string HI_SPEC { get; set; }
        public double MEAN { get; set; }
        public double STD_DEV { get; set; }
    }
}
