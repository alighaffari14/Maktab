using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                loadAllCenters();
                LoadTotalIncome();
                LoadTotalStudents();
                LoadTotalMuallimeen();
                LoadTotalCustodianInHandAmount();
                LoadTopMuallim();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            con.Close();
        }

        private void LoadTopMuallim()
        {
            con = Connection.authorize();
            string query = @"  select m.Name, max(r.Total_Obtained_Marks) as Marks from Tbl_MaktabReporting r
  inner join Tbl_Muallim m on m.Muallim_Id = r.Muallim_Id group by m.Name";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label6.Text = reader[0].ToString();
                Label7.Text = reader[1].ToString();
            }
            con.Close();
        }

        private void LoadTotalCustodianInHandAmount()
        {
            con = Connection.authorize();
            string query = "select sum(Amount) from Tbl_CustodianAccount";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label5.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void LoadTotalMuallimeen()
        {
            con = Connection.authorize();
            string query = "select count(Muallim_Id) from Tbl_Muallim";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label4.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void LoadTotalStudents()
        {
            con = Connection.authorize();
            string query = "select count(student_Id) from Tbl_Students";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label3.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void LoadTotalIncome()
        {
            con = Connection.authorize();
            string query = "select Sum(Acc_InitialAmount) from Tbl_Account";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label2.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void loadAllCenters()
        {
            con = Connection.authorize();
            string query = "select count(Office_Id) from Tbl_Offices";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label1.Text = reader[0].ToString();
            }
            con.Close();
        }
    }
}