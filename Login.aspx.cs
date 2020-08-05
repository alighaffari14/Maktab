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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAllUserTypes();
            }
            
        }

        private void loadAllUserTypes()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_UserTypes";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "user_Type";
            DropDownList1.DataValueField = "UserType_Id";
            DropDownList1.DataBind();
            con.Close();
        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Users where User_Type='" + int.Parse(DropDownList1.SelectedValue) + "' and username='" + TextBox1.Text.ToString() + "' and password='" + TextBox2.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                if (int.Parse(DropDownList1.SelectedValue) == 1)
                {
                    Session["username"] = TextBox1.Text.ToString();
                    Response.Redirect("Dashboard.aspx");
                }
                else if (int.Parse(DropDownList1.SelectedValue) == 2)
                {

                }
                else if (int.Parse(DropDownList1.SelectedValue) == 3)
                {

                }
            }
            else
            {

            }
        }
    }
}