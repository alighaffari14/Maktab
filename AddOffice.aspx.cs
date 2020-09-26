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
    public partial class AddOffice : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                
            }
            
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            bool checkexistence = centernameexists();
            if (checkexistence == false)
            {
                con = Connection.authorize();
                string query = "insert into Tbl_Offices(Office_Name, Village_Mohalla, Tehsil_District)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int a = cmd.ExecuteNonQuery();
                con.Close();
                if (a > 0)
                {
                    Response.Write("<script>alert('Center Added Successfully!')</script>");
                }
            }
            
        }

        private bool centernameexists()
        {
            bool finalvalue = false;
            con = Connection.authorize();
            string query = "select * from Tbl_Offices where Office_Name = '"+ textBox1.Text.ToString()+ "'";
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader reader = cmd1.ExecuteReader();
            //int records = (int)cmd1.ExecuteScalar();

            if (reader.HasRows)
            {
                Response.Write("<script>alert('Center with this Name already Exist')</script>");
                finalvalue = true;
            }
            else
            {
                finalvalue = false;
            }
            con.Close();
            return finalvalue;
        }
    }
}