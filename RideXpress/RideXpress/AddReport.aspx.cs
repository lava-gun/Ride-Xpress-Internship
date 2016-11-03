using RideXpress.BLL;
using RideXpress.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideXpress_StarterKit
{
    public partial class NewReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
                CarBLL car = new CarBLL(connectionString);
                List<CarViewModel> cars = car.GetCarInventory();
                foreach(CarViewModel item in cars)
                {
                    DD1.Items.Add(item.Name);
                }
                DD1.Items.Insert(0, new ListItem("-- Select a Ride --"));
            }
            DateRange.MinimumValue = DateTime.Today.AddYears(-20).ToShortDateString();
            DateRange.MaximumValue = DateTime.Today.ToShortDateString();
        }
        
        protected void ReportAddButton_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
                ReportBLL ReportBL = new ReportBLL(connectionString);
                ReportViewModel report = new ReportViewModel();
                int ID = DD1.SelectedIndex;
                report.CarID = ID;
                report.DateOfIncident = Convert.ToDateTime(Date.Text);
                report.ReportName = Name.Text;
                report.ReportDescription = Description.Text;
                report.DateOfReport = DateTime.Today;
                ReportBL.AddReport(report);
                Response.Redirect("~/Reports.aspx");
            }
        }
    }
}