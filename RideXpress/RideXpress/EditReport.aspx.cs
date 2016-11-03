using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RideXpress.BLL;
using RideXpress.Models;
using System.Configuration;

namespace RideXpress_StarterKit
{
    public partial class EditReport : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
                CarBLL car = new CarBLL(connectionString);
                List<CarViewModel> cars = car.GetCarInventory();
                foreach (CarViewModel item in cars)
                {
                    DD1.Items.Add(item.Name);
                }
                DD1.Items.Insert(0, new ListItem("-- Select a Ride --"));

                ReportBLL bll = new ReportBLL(connectionString);
                ReportViewModel report = bll.GetReportByID(Convert.ToInt32(Request.QueryString["ReportID"]));
                CarViewModel car1 = car.GetCarById(report.CarID);

                DD1.SelectedValue = car1.Name;
                DateTime date = report.DateOfIncident.Date;
                this.Date.Text = date.ToString("yyyy-MM-dd");
                Name.Text = report.ReportName;
                Description.Text = report.ReportDescription;
            }
            DateRange.MinimumValue = DateTime.Today.AddYears(-20).ToShortDateString();
            DateRange.MaximumValue = DateTime.Today.ToShortDateString();
            Page.Validate("AllValidators");
        }

        protected void ReportAddButton_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                //string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
                ReportBLL bll = new ReportBLL(connectionString);
                ReportViewModel report = new ReportViewModel();
                int ID = DD1.SelectedIndex;
                report.ReportID = Convert.ToInt32(Request.QueryString["ReportID"]);
                report.CarID = ID;
                report.DateOfIncident = Convert.ToDateTime(Date.Text);
                report.ReportName = Name.Text;
                report.ReportDescription = Description.Text;
                report.DateOfReport = DateTime.Today.Date;
                bll.EditReport(report);
                Response.Redirect("~/Reports.aspx");
            }
        }
    }
}