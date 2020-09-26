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
    public partial class AddStudent : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    BindingCenterDropdownlist();
                    BindingClassDropdownlist();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                
            }
           
        }

        private void BindingClassDropdownlist()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Classes";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Class_Name";
            DropDownList1.DataValueField = "Class_Id";
            DropDownList1.DataBind();
            con.Close();
        }

        private void BindingCenterDropdownlist()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Offices";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "Office_Name";
            DropDownList2.DataValueField = "Office_Id";
            DropDownList2.DataBind();
            con.Close();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            bool exist = centernameexists();
            if (exist == false)
            {
                con = Connection.authorize();
                string query = "insert into Tbl_Students(Student_Name,Father_Name,Class_Id,Office_Id)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + DropDownList1.SelectedValue + "','" + DropDownList2.SelectedValue + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int a= cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Write("<script>alert('Student has been Added Successfully!')</script>");
                }
            }
            
        }

        private bool centernameexists()
        {
            bool finalvalue = false;
            con = Connection.authorize();
            string query = "select * from Tbl_Students where Student_Name = '" + textBox1.Text.ToString() + "' and Father_Name='"+ textBox2.Text.ToString() + "' and Office_Id='"+ DropDownList2.SelectedValue + "' and Class_Id='"+ DropDownList1.SelectedValue + "'";
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader reader = cmd1.ExecuteReader();
            //int records = (int)cmd1.ExecuteScalar();

            if (reader.HasRows)
            {
                Response.Write("<script>alert('Student Name already Exist')</script>");
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