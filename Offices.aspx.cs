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
    public partial class Offices : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                string query = @"select o.Registeration_Number,o.Office_Name,o.Village_Mohalla,o.Tehsil_District from Tbl_Offices o";
                con = Connection.authorize();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Repeater2.DataSource = dt;
                Repeater2.DataBind();
                con.Close();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            
        }
    }
}