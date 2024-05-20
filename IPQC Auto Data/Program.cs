using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace IQC_Auto_Data
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex singleton = new Mutex(true, "IQC Auto Data");
            if (!singleton.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("Phần mềm đang được bật rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(0);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
