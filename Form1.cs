using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using OfficeOpenXml;
using FlightInfo;
using System.Collections.Generic;

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
            using (var package = new ExcelPackage(new FileInfo(fileName)))
            {
                var firstSheet = package.Workbook.Worksheets["First Sheet"];
                var rowCount = firstSheet.Dimension.Rows;
                var colCount = firstSheet.Dimension.Columns;
                int rc = 25;
                gridView.RowCount = rc;
                gridView.ColumnCount = 6;
                int k = 0;
                List<Flight> flights = new List<Flight>();
                Flight flight;
                // Loop through each row (altername rows only)
                for (int i = 2; i < rowCount+1; i+=2)
                {
                    int l = 0;
                    flight = new Flight();
                    
                    string flightNumber = firstSheet.Cells[i, 1].Text;
                    gridView.Rows[k].Cells[l++].Value = flightNumber;
                    flight.airline = flightNumber;
                    //TODO split flight into code and number
                    flight.consolidatedFlightNumber = flightNumber;
                    string departing = firstSheet.Cells[i, 2].Text;
                    gridView.Rows[k].Cells[l++].Value = departing;
                    flight.departingFrom = departing;
                    //TODO split departing into ICAO and departure time
                    string duration = firstSheet.Cells[i, 4].Text;
                    gridView.Rows[k].Cells[l++].Value = duration;
                    string arriving = firstSheet.Cells[i, 5].Text;
                    gridView.Rows[k].Cells[l++].Value = arriving;
                    flight.arrivingAt = arriving;
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
                    gridView.Rows[k].Cells[l++].Value = daysOfOperaton;
                    string type = firstSheet.Cells[i, 15].Text;
                    gridView.Rows[k].Cells[l++].Value = type;
                    flights.Add(flight);
                    k++;
                    if(k >= rc)
                    {
                        break;
                    }

                }
            }

        }
    }


}

