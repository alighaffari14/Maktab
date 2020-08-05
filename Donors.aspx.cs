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
    public partial class Donors : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    string query = "select * from Tbl_Donar";
                    con = Connection.authorize();
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                    con.Close();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
           
        }

       


    }
}