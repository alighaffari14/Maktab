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
    public partial class Accounts : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                gettingallAccountsOnLoad();
            }
        }

        private void gettingallAccountsOnLoad()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Account";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }
    }
}