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
    public partial class AddMuallim : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    BindingCentersDropdownlist();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                
            }
        }

        

        private void BindingCentersDropdownlist()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Offices";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "Office_Name";
            DropDownList3.DataValueField = "Office_Id";
            DropDownList3.DataBind();
            con.Close();

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            con = Connection.authorize();
            string query = "insert into Tbl_Muallim(Name,Father_Name,Deeni_Taleem,Dunyawi_Taleem,Contact_Number,Madrisah_Education_Name,Office_Id)values('"+textBox1.Text.ToString()+"','"+ textBox2.Text.ToString() + "','"+ textBox3.Text.ToString() + "','"+ textBox4.Text.ToString() + "','"+ textBox5.Text.ToString() + "','"+ textBox6.Text.ToString() + "','"+DropDownList3.SelectedValue+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
    }
}