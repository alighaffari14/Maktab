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
    public partial class Muallims : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    con = Connection.authorize();
                    string query = @"select m.Name, m.Father_Name, m.Deeni_Taleem, m.Dunyawi_Taleem, m.Contact_Number,
                                        m.Madrisah_Education_Name, o.Office_Name from Tbl_Muallim m
                                        inner join Tbl_Offices o on o.Office_Id = m.Office_Id";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Repeater2.DataSource = dt;
                    Repeater2.DataBind();
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