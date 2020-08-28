using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using OfficeOpenXml;
using FlightInfo;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace FlightSchedule
{
    public partial class Form1 : Form
    {
        private string fName = "";

        public Form1()
        {
            InitializeComponent();
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/mm/yyyy HH:mm";
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEndDate.Value = dtpStartDate.Value.AddYears(1).AddMinutes(-1);
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

                
                if (!string.IsNullOrEmpty(fdlg.FileName))
                {
                    fName = fdlg.FileName;
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
                int rc = 150;
                gridView.RowCount = rc;
                gridView.ColumnCount = 6;
                //int k = 0;
                List<Flight> flights = new List<Flight>();
                Flight flight;
                // Loop through each row (altername rows only)
                for (int i = 2; i < rowCount+1; i+=2)
                {
                    flight = new Flight();
                    
                    string flightNumber = firstSheet.Cells[i, 1].Text;
                    flight.airline = flightNumber;
                    //TODO split flight into code and number
                    flight.consolidatedFlightNumber = flightNumber;
                    string departing = firstSheet.Cells[i, 2].Text;
 //                   gridView.Rows[k].Cells[l++].Value = departing;
                    flight.departingFrom = departing;
                    flight.departureTime = departing;
                    string duration = firstSheet.Cells[i, 4].Text;
 //                   gridView.Rows[k].Cells[l++].Value = duration;
                    string arriving = firstSheet.Cells[i, 5].Text;
 //                   gridView.Rows[k].Cells[l++].Value = arriving;
                    flight.arrivingAt = arriving;
                    flight.arrivalTime = duration;
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
 //                   gridView.Rows[k].Cells[l++].Value = daysOfOperaton;
                    string type = firstSheet.Cells[i, 15].Text;
 //                   gridView.Rows[k].Cells[l++].Value = type;
                    flights.Add(flight);
                    //k++;
                    //if(k >= rc)
                    //{
                    //    break;
                    //}

                }
                WriteXMLSchedule(flights);
            }

        }

        private void WriteXMLSchedule(List<Flight> flights)
        {
            // Settings for XmlWriter
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineChars = "\r\t";

            // Creat an instance of the XmkWriter
            using(XmlWriter writer=XmlWriter.Create
                (@"C:\Users\vicgr\source\repos\FlightSchedule\Demo.xml", settings))
            {
                writer.WriteStartElement("PFPX_FLIGHT_LIST");
                foreach (var flight in flights)
                {
                    writer.WriteStartElement("FLIGHT");
                    writer.WriteElementString("Airline", flight.airline);
                    writer.WriteElementString
                        ("ConsolidatedFlightNumber", flight.consolidatedFlightNumber);
                    writer.WriteElementString("From", flight.departingFrom);
                    writer.WriteElementString("To", flight.arrivingAt);
                    writer.WriteElementString("STD", flight.departureTime);
                    writer.WriteElementString("STA", flight.arrivalTime);
                    // End element 
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Value = dtpStartDate.Value.AddYears(1).AddMinutes(-1);
        }
    }


}

