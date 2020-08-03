using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using OfficeOpenXml;

namespace FlightSchedule
{
    public partial class Form1 : Form
    {
        private string fName = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Schedule File Dialog",
                InitialDirectory = @"C:\Users\vicgr\source\repos\FlightSchedule",
                Filter = "All files (*.*)|*.*|Excel files (*.*)|*.xlsm",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                // Open file for reading
                fName = fdlg.FileName;
                if (!string.IsNullOrEmpty(fName))
                {
                    OpenAndReadFile(fdlg.FileName);
                }
            }
        }

        private void OpenAndReadFile(string fileName)
        {
            //using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            //{
            //    string line;
            //    int i;
            //    using (var sr = new StreamReader(fs, Encoding.UTF8))
            //    {


            //        while ((line = sr.ReadLine()) != null)
            //        {
            //            i = 1;
            //        }

            //    }
            //}
            using (var package = new ExcelPackage(new FileInfo(fileName)))
            {
                var firstSheet = package.Workbook.Worksheets["First Sheet"];
                var rowCount = firstSheet.Dimension.Rows;
                var colCount = firstSheet.Dimension.Columns;
                gridView.RowCount = rowCount;
                gridView.ColumnCount = colCount;
                // Loop through each row (altername rows only)
                for (int i = 2; i < rowCount+1; i+=2)
                {

                    string flight = firstSheet.Cells[i, 1].Text;
                    //TODO split flight into code and number
                    string departing = firstSheet.Cells[i, 2].Text;
                    //TODO split departing into ICAO and departure time
                    string duration = firstSheet.Cells[i, 4].Text;
                    string arriving = firstSheet.Cells[i, 5].Text;
                    //TODO split arriving onto ICAO and arrival time
                    StringBuilder sb = new StringBuilder();
                   
                    for (int j = 7; j < 14; j++)
                    {
                        string day = firstSheet.Cells[i, j].Text;

                        if (firstSheet.Cells[i, j].Text.Length > 0)
                        {
                            sb.Append(day);
                        }
                    }
                    string daysOfOperaton = sb.ToString();
                    string type = firstSheet.Cells[i, 15].Text;

                }
            }

        }
    }


}

