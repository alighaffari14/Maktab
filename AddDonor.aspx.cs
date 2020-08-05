using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class AddDonor : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = Connection.authorize();
            string query = "insert into Tbl_Donar(Donar_Name,Donar_City, Donar_Country)values('"+txtName.Text.ToString()+ "','" + txtCity.Text.ToString() + "','" + txtCountry.Text.ToString() + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Response.Write("Donors.aspx");
            }
        }
    }
}