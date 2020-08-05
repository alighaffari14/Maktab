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
    public partial class AccountTypes : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                gettingallAccountTypesOnLoad();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void gettingallAccountTypesOnLoad()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_AccontType";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }
    }
}