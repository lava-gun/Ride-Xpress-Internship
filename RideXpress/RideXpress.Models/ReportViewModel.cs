using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RideXpress.Models
{
    
    public class ReportViewModel
    { 
        DateTime ITemp, RTemp;
        public int ReportID { get; set; }
        public int CarID { get; set; }
        public string CarName { get; set; }
        public DateTime DateOfIncident
        {
            get { return ITemp; } 
            set { ITemp = value; }
        }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
        public DateTime DateOfReport {
            get { return RTemp; }
            set { RTemp = value; } }
        public string IncidentDisplay
        {
            get { return ITemp.ToShortDateString(); }
        }
        public string ReportDisplay
        {
            get { return RTemp.ToShortDateString(); }
        }

    }
}