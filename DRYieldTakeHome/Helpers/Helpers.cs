using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRYieldTakeHome.Helpers
{
    class Helpers
    {
        public static DataForVis createDataForVis(int index, string path)
        {
            return new DataForVis(index, path);
        }
    }

    class DataForVis
    {
        public DataForVis(int index, string filePath)
        {
            Index= index;
            FilePath= filePath;
        }

        public int Index { get; set; }
        public string FilePath { get; set; }
        public bool ProgChange { get; set; }

    }
}

namespace ExtensionMethods
{
    public static class StringExtMthd
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return str == null || str.Length == 0;
        }
    }
}
