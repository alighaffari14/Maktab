using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class UpdateDonor : System.Web.UI.Page
    {
        SqlConnection con;
        int donarid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    donarid = int.Parse(Request.QueryString["Donar_Id"].ToString());
                    gettingDonarDetialWithIDOnLoad();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
          
        }

        private void gettingDonarDetialWithIDOnLoad()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Donar where Donar_Id='"+donarid+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox1.Text = reader[0].ToString();
                txtName.Text = reader[1].ToString();
                txtCity.Text = reader[2].ToString();
                txtCountry.Text = reader[3].ToString();
            }

            con.Close();
        }

        public void Update_Button_click(object sender, EventArgs e)
        {
            con = Connection.authorize();
            string query = "UPDATE Tbl_Donar set Donar_Name='" + txtName.Text.ToString()+"',Donar_City='"+txtCity.Text.ToString()+"', Donar_Country='"+txtCountry.Text.ToString()+"' where Donar_Id='"+int.Parse(TextBox1.Text)+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Response.Redirect("Donors.aspx");
            }
            con.Close();
        }
    }
}