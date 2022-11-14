using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DRYieldTakeHome
{
    internal class VisualizationBL
    {
        public static DeserRes Deserialize(string filePath)
        {
            int counter = 0;
            DeserRes res = new DeserRes();
            List<PIRData> pirObjs = new List<PIRData>();
            PIRData pirObj = null;
            PTR PTRObj;
            int chipNum = 0;
            int paramNum = 0;
            double[] paramResults = new double[16];
            double[] stdDevPerParam = new double[16];
            int passChips = 0;
            // Read the file and display it line by line.  
            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                System.Console.WriteLine(line);
                counter++;
                switch (line.Split(':')[0].Trim())
                {
                    case "MIR":
                        var MIRObj = CreateMIRObject(line);
                        res.MIRObj = MIRObj;
                        break;
                    case "PIR":
                        pirObj = new PIRData();
                        pirObj.ChipNum = chipNum;
                        chipNum++;
                        break;
                    case "PTR":
                        PTRObj = CreatePTRObject(line, chipNum);
                        pirObj?.PTRs.Add(PTRObj);
                        paramResults[paramNum] += Convert.ToDouble(PTRObj.RESULT);
                        paramNum++;
                        break;
                    case "PRR":
                        res.PIRs.Add(pirObj);
                        if (chipTestSuccess(line))
                        {
                            passChips++;
                        }
                        paramNum = 0;
                        break;
                    default: break;
                }
            }
            for(int i = 0; i < paramResults.Length; i++)
            {
                paramResults[i] /= chipNum;
            }
            //std dev per parameter
            foreach (var pir in res.PIRs)
            {
                int pNum = 0;
                foreach (var ptr in pir.PTRs)
                {
                    stdDevPerParam[pNum] += Math.Pow(Convert.ToDouble(ptr.RESULT) - paramResults[pNum], 2);
                    pNum++;
                }
            }
            for(int i = 0; i<stdDevPerParam.Length; i++)
            {
                stdDevPerParam[i] /= (chipNum - 1);
            }
            foreach (var pir in res.PIRs)
            {
                int pNum = 0;
                foreach(var ptr in pir.PTRs)
                {
                    ptr.MEAN = paramResults[pNum];
                    ptr.STD_DEV = stdDevPerParam[pNum];
                    pNum++;
                }
            }
            res.MIRObj.YIELD = (double)passChips / (double)chipNum;
            return res;
        }
        public static bool chipTestSuccess(string line)
        {
            var res = line.Split(new[] { ':' }, 2)[1].Split('|')[4];
            return res.Trim().Equals("P") ? true : false;
        }

        public static MIR CreateMIRObject(string line)
        {
            MIR result = new MIR();
            var data = line.Split(new[] { ':' }, 2)[1].Split('|');
            result.LOT_ID = data[0];
            result.PART_TYP = data[1];
            result.JOB_NAM = data[2];
            result.NODE_NAM= data[3];
            result.TSTR_TYP= data[4];
            result.SETUP_TYP= data[5];
            result.START_T = data[6];
            result.OPER_NAM= data[7];
            result.MODE_COD= data[8];
            result.STAT_NUM= data[9];
            result.SBLOT_ID= data[10];
            result.TEST_COD= data[11];
            return result;
        }

        public static PTR CreatePTRObject(string line, int chipNum)
        {
            PTR result = new PTR();
            var data = line.Split(new[] { ':' }, 2)[1].Split('|');
            result.CHIPN = chipNum;
            result.RESULT = data[3];
            result.TEST_TXT = data[6];
            result.UNITS = data[9];
            result.LO_SPEC= data[15];
            result.HI_SPEC= data[16];
            return result;
        }
    }
    class DeserRes
    {
        public MIR MIRObj { get; set; }
        public List<PIRData> PIRs { get; set; } = new List<PIRData>();
    }

    class PIRData
    {
        public int ChipNum { get; set; }
        public List<PTR> PTRs { get; set; } = new List<PTR>();
    }
}
