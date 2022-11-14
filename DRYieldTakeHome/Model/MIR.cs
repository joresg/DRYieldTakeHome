using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRYieldTakeHome
{
    internal class MIR
    {
        public MIR()
        {

        }
        public string LOT_ID { get; set; }
        public string PART_TYP { get; set; }
        public string JOB_NAM { get; set; }
        public string NODE_NAM { get; set; }
        public string TSTR_TYP { get; set; }
        public string SETUP_TYP { get; set; }
        public string START_T { get; set; }
        public string OPER_NAM { get; set; }
        public string MODE_COD { get; set; }
        public string STAT_NUM { get; set; }
        public string SBLOT_ID { get; set; }
        public string TEST_COD { get; set; }
        public double YIELD { get; set; }
    }
}
