using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class MuallimProgress : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {

                LoadMullimProgressOnLoad();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void LoadMullimProgressOnLoad()
        {
            con = Connection.authorize();
            string query = @"select m.Name,o.Office_Name, mr.Shariya,mr.Visiting_Date, mr.Total_Obtained_Marks, mr.Remarks from Tbl_MaktabReporting mr
  inner join Tbl_Muallim m on m.Muallim_Id = mr.Muallim_Id
  inner join Tbl_Offices o on o.Office_Id = mr.Office_Id";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}