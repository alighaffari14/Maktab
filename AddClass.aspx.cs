using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class AddClass : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            con = Connection.authorize();
            string query = "insert into Tbl_Classes(Class_Name)values('"+textBox1.Text.ToString()+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
    }
}