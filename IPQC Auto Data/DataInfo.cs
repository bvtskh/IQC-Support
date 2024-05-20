using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPQC_Auto_Data
{
    internal class DataInfo
    {
        public string PartNo { get; set; }
        public string FolderPath { get; set; }
        public IntPtr Control  { get; set; }

        public DataInfo(string part, string folder, IntPtr control)
        {
            PartNo = part;
            FolderPath = folder;
            Control = control;
        }
    }
}
