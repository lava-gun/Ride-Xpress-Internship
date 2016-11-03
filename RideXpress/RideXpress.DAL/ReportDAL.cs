using RideXpress.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideXpress.DAL
{
    public class ReportDAL
    {
        private string _connectionString;
        public ReportDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<ReportViewModel> GetAllReports()
        {
            string sqlQuery = "SELECT * FROM IncidentReport INNER JOIN Car ON Car.CarID = IncidentReport.CarID";
            List<ReportViewModel> reports = new List<ReportViewModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReportViewModel temp = new ReportViewModel()
                        {
                            ReportID = Convert.ToInt32(reader["ReportID"]),
                            CarID = Convert.ToInt32(reader["CarID"]),
                            DateOfIncident = Convert.ToDateTime(reader["DateOfIncident"]).Date,
                            ReportName = reader["ReportName"].ToString(),
                            ReportDescription = reader["ReportDescription"].ToString(),
                            DateOfReport = Convert.ToDateTime(reader["DateOfReport"]).Date,
                            CarName=reader["Name"].ToString()
                        };
                        reports.Add(temp);
                    }
                }
            }
            return reports;
        }
        public ReportViewModel GetReportByID(int id)
        {
            ReportViewModel report = new ReportViewModel();
            string sqlQuery = "SELECT * from IncidentReport WHERE ReportID=@ReportID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ReportID", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        report.ReportID = Convert.ToInt32(reader["ReportID"]);
                        report.CarID = Convert.ToInt32(reader["CarID"]);
                        report.DateOfIncident = Convert.ToDateTime(reader["DateOfIncident"]);
                        report.ReportName = reader["ReportName"].ToString();
                        report.ReportDescription = reader["Reportdescription"].ToString();
                        report.DateOfReport = Convert.ToDateTime(reader["DateOfReport"]);
                    }
                }
            }
            return report;
        }
        public int EditReport(ReportViewModel edit)
        {
            string sqlQuery = "UPDATE IncidentReport SET DateOfIncident=@DateOfIncident, ReportName=@ReportName, ReportDescription=@ReportDescription, DateOfReport=@DateOfReport WHERE ReportID=@ReportID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ReportID", SqlDbType.Int).Value = edit.ReportID;
                cmd.Parameters.Add("@CarID", SqlDbType.Int).Value = edit.CarID;
                cmd.Parameters.Add("@DateOfIncident", SqlDbType.DateTime).Value = edit.DateOfIncident;
                cmd.Parameters.Add("@ReportName", SqlDbType.VarChar).Value = edit.ReportName;
                cmd.Parameters.Add("@ReportDescription", SqlDbType.VarChar).Value = edit.ReportDescription;
                cmd.Parameters.Add("@DateOfReport", SqlDbType.DateTime).Value = edit.DateOfReport;
                return cmd.ExecuteNonQuery();
            }
        }
        public int AddReport(ReportViewModel add)
        {
            string sqlQuery = "INSERT INTO IncidentReport(CarID, DateOfIncident, ReportName, ReportDescription, DateOfReport)" +
                "Values (@CarID, @DateOfIncident, @ReportName, @ReportDescription, @DateOfReport)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand (sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ReportID", SqlDbType.Int).Value = add.ReportID;
                cmd.Parameters.Add("@CarID", SqlDbType.Int).Value = add.CarID;
                cmd.Parameters.Add("@DateOfIncident", SqlDbType.DateTime).Value = add.DateOfIncident;
                cmd.Parameters.Add("@ReportName", SqlDbType.VarChar).Value = add.ReportName;
                cmd.Parameters.Add("@ReportDescription", SqlDbType.VarChar).Value = add.ReportDescription;
                cmd.Parameters.Add("@DateOfReport", SqlDbType.DateTime).Value = add.DateOfReport;
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteReport(int id)
        {
            string sqlQuery = "DELETE FROM IncidentReport WHERE ReportID = @ReportID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ReportID", SqlDbType.Int).Value = id;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
