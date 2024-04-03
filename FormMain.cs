using AutoIt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace IQC_Auto_Data
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            //string csvFilePath = @"C:\Users\u42107\Desktop\ThanhDX\Thanh_Project\IPQC Auto Data\RK3-1574-000   &RK3-1575TABLE20240320091957.csv";
            ////string excelFilePath = "example.xlsx"; // Path to the Excel file to be created

            //// Check if the CSV file exists
            //if (!File.Exists(csvFilePath))
            //{
            //    Console.WriteLine("The CSV file does not exist.");
            //    return;
            //}

            //// Load CSV content
            //var csvContent = File.ReadAllLines(csvFilePath)
            //                     .Select(line => line.Split(','));
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //var mainWnd = AutoItX.WinGetHandle("UMC SAP System [3000PRD800 Vietnam Production]");
            var mainWnd = AutoItX.WinGetHandle($"UMC SAP System [3000PRD800 Vietnam Production]");
            var isMainOpen = AutoItX.WinExists(mainWnd);
            if (isMainOpen == 0)
            {
                MessageBox.Show("Cần mở phần mềm USAP");
                return;
            }

            //var a = AutoItX.ControlGetPos("UMC SAP System [3000PRD800 Vietnam Production]","New", "TcxButton20");
            var PartNoControl = AutoItX.ControlGetHandle(mainWnd, "[CLASS:TcxDBTextEdit; INSTANCE:37]");
            //var newButton = AutoItX.ControlGetHandle(mainWnd, "[CLASS:TcxButton; INSTANCE: 20]");
            string partNo = AutoItX.ControlGetText(mainWnd, PartNoControl);

            IntPtr checkUpSizeControl = AutoItX.WinGetHandle($"Check-up Size");

            var MainOpen = AutoItX.WinExists(checkUpSizeControl);
            if (MainOpen == 0)
            {
                MessageBox.Show("Cần mở phần Modify");
                return;
            }

            IntPtr LineControl = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxCustomInnerTextEdit; INSTANCE:1]");

            string line = AutoItX.ControlGetText(checkUpSizeControl, LineControl);
            if(line != "1")
            {
                MessageBox.Show("Phải bắt đầu từ Line 1");
                return;
            }

            // mở file CVS lấy data.

            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only allow CSV files
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1; // Set the default filter index to CSV files
            string filePath = null;
            // Display the dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the selected file path
                filePath = openFileDialog.FileName;
            }

            if (string.IsNullOrEmpty(filePath)) return;
            lbPath.Text = filePath;
            DataTable dataTable = ReadCsvIntoDataTable(filePath);

            IntPtr firstCheck = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxCustomDropDownInnerEdit; INSTANCE:5]");
            IntPtr secondCheck = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxCustomDropDownInnerEdit; INSTANCE:4]");
            IntPtr thirdCheck = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxCustomDropDownInnerEdit; INSTANCE:3]");
            IntPtr fourthCheck = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxCustomDropDownInnerEdit; INSTANCE:2]");
            IntPtr fifthCheck = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxCustomDropDownInnerEdit; INSTANCE:1]");

            int column = 7;
            while (column < dataTable.Columns.Count)
            {
                for (int i = 0; i < 5; i++)
                {
                    // Get the value in the 5th column (index 4) of the current row
                    string value = dataTable.Rows[i][column] == null? "" : dataTable.Rows[i][column].ToString(); // 4 represents the 5th column index (0-based index)

                    switch (i)
                    {
                        case 0:
                            AutoItX.ControlFocus(checkUpSizeControl, firstCheck);
                            AutoItX.ControlSetText(checkUpSizeControl, firstCheck, value);
                            break;
                        case 1:
                            AutoItX.ControlFocus(checkUpSizeControl, secondCheck);
                            AutoItX.ControlSetText(checkUpSizeControl, secondCheck, value);
                            break;
                        case 2:
                            AutoItX.ControlFocus(checkUpSizeControl, thirdCheck);
                            AutoItX.ControlSetText(checkUpSizeControl, thirdCheck, value);
                            break;
                        case 3:
                            AutoItX.ControlFocus(checkUpSizeControl, fourthCheck);
                            AutoItX.ControlSetText(checkUpSizeControl, fourthCheck, value);
                            break;
                        case 4:
                            AutoItX.ControlFocus(checkUpSizeControl, fifthCheck);
                            AutoItX.ControlSetText(checkUpSizeControl, fifthCheck, value);
                            break;
                    }
                }
                column++;
                Thread.Sleep(200);
                IntPtr OKbutton = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxButton; INSTANCE:2]");
                Thread.Sleep(200);
                AutoItX.ControlClick("Check-up Size","", "TcxButton2");
                Thread.Sleep(200);
                if (column >= dataTable.Columns.Count) return;
            }
        }
        static DataTable ReadCsvIntoDataTable(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                bool isFirstRow = true;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (isFirstRow)
                    {
                        // Assume the first row contains column names
                        foreach (string field in fields)
                        {
                            dataTable.Columns.Add(new DataColumn(field));
                        }
                        isFirstRow = false;
                    }
                    else
                    {
                        // Add data rows
                        dataTable.Rows.Add(fields);
                    }
                }
            }

            return dataTable;
        }
    }
}
