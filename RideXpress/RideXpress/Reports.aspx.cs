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
    public partial class Reports : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RideXpressConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void ReportList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ReportID = Convert.ToInt32(ReportList.DataKeys[e.RowIndex].Value.ToString());
            ReportBLL reportBL = new RideXpress.BLL.ReportBLL(connectionString);
            reportBL.DeleteReport(ReportID);
            BindData();
        }

        private void BindData()
        {
            ReportBLL reportBL = new RideXpress.BLL.ReportBLL(connectionString);
            ReportList.DataSource = reportBL.GetAllReports();
            ReportList.DataBind();
        }
    }
}