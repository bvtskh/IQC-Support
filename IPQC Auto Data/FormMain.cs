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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System.Web.UI.WebControls;
using System.Management.Instrumentation;
using IPQC_Auto_Data;
using System.Web.UI.WebControls.WebParts;

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
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\IQC_SUPPORT\Configs");
            txtFolder.Text = key.GetValue("Configs") == null?"": key.GetValue("Configs").ToString();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = txtFolder.Text;
                if (string.IsNullOrEmpty(folderPath))
                {
                    MessageBox.Show("Chưa có đường dẫn đến file log"); return;
                }
                if (!Directory.Exists(folderPath))
                {
                    MessageBox.Show("Đường dẫn sai!"); return;
                }
                var mainWnd = AutoItX.WinGetHandle($"UMC SAP System [3000PRD800 Vietnam Production]");
                var isMainOpen = AutoItX.WinExists(mainWnd);
                if (isMainOpen == 0)
                {
                    MessageBox.Show("Cần mở phần mềm USAP");
                    return;
                }

                IntPtr checkUpSizeControl = AutoItX.WinGetHandle($"Check-up Size");

                var MainOpen = AutoItX.WinExists(checkUpSizeControl);
                if (MainOpen == 0)
                {
                    MessageBox.Show("Cần mở phần Modify");
                    return;
                }

                IntPtr LineControl = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxCustomInnerTextEdit; INSTANCE:1]");

                string line = AutoItX.ControlGetText(checkUpSizeControl, LineControl);
                if (line != "1")
                {
                    MessageBox.Show("Cần mở phần Modify và Phải bắt đầu từ Line 1");
                    return;
                }
                var PartNoControl = AutoItX.ControlGetHandle(mainWnd, "[CLASS:TcxDBTextEdit; INSTANCE:37]");
                string partNo = AutoItX.ControlGetText(mainWnd, PartNoControl);
                txtpart.Text = partNo;
                string filePath;
                // mở file CVS lấy data.
                if (checkDefault.Checked)
                {
                    // Tìm folder chứa file có tên bắt đầu là PartNo đang chọn và tìm file được tạo mới nhất.
                    filePath = GetMostRecentFile(folderPath, partNo);
                    if (string.IsNullOrEmpty(filePath))
                    {
                        MessageBox.Show("Không tìm thấy file, Hãy thử tắt tự động và tìm thủ công!"); return;
                    }
                    DataTable dataTable = ReadCsvIntoDataTable(filePath);
                    if (dataTable.Rows.Count < 0)
                    {
                        MessageBox.Show("File không có dữ liệu"); return;
                    }
                    ActionFillData(dataTable, checkUpSizeControl);
                }
                else
                {
                    // tìm thủ công
                    filePath = GetManualFile();
                    if (string.IsNullOrEmpty(filePath)) return;
                    DataTable dataTable = ReadCsvIntoDataTable(filePath);

                    if (dataTable.Rows.Count < 0)
                    {
                        MessageBox.Show("File không có dữ liệu"); return;
                    }
                    ActionFillData(dataTable, checkUpSizeControl);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra!");
            } 
        }

        private void ActionFillData(DataTable dataTable, IntPtr checkUpSizeControl)
        {
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
                    string value = dataTable.Rows[i][column] == null ? "" : dataTable.Rows[i][column].ToString(); // 4 represents the 5th column index (0-based index)

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
                Thread.Sleep(100);
                IntPtr OKbutton = AutoItX.ControlGetHandle(checkUpSizeControl, "[CLASS:TcxButton; INSTANCE:2]");
                Thread.Sleep(200);
                AutoItX.ControlClick("Check-up Size", "", "TcxButton2");
                Thread.Sleep(150);
                if (column >= dataTable.Columns.Count) return;
            }
        }

        private string GetManualFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only allow CSV files
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1; // Set the default filter index to CSV files

            // Display the dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the selected file path
                return openFileDialog.FileName;
            }
            return null;
        }

        private string GetMostRecentFile(string folderPath, string partNo)
        {
            string newPartNo = RemoveLastAlphabetic(partNo); // rơi vào trường hợp KH Brother tên part không chuẩn 
            // Check if the directory exists
            if (Directory.Exists(folderPath))
            {
                try
                {
                    var csvFiles = Directory.GetFiles(folderPath, "*.csv", System.IO.SearchOption.AllDirectories)
                                            .Where(file => Path.GetFileName(file).ToLower().Contains(newPartNo.ToLower()))
                                            .Select(file => new FileInfo(file))
                                            .OrderByDescending(file => file.CreationTime)
                                            .ToList();

                    if (csvFiles.Count > 0)
                    {
                        return csvFiles[0].FullName;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null ;
            }
        }
        static string RemoveLastAlphabetic(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder(input);

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsLetter(input[i]))
                {
                    result.Remove(i, 1);
                }
                else
                {
                    break;
                }
            }

            return result.ToString();
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the title of the dialog
            folderBrowserDialog.Description = "Select a folder";

            // Show the dialog and capture the result
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\IQC_SUPPORT\Configs");
            if (!string.IsNullOrEmpty(txtFolder.Text))
            {
                key.SetValue("Configs", txtFolder.Text);
                key.Close();
                MessageBox.Show("OK!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(panelconfig.Visible)
            {
                panelconfig.Visible =false;
            }
            else
            {
                panelconfig.Visible = true;
            }
        }
    }
}
