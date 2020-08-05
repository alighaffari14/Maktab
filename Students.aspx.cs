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
    public partial class Students : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    gettingAllStudentsOnLoad();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                
            }
        }

        private void gettingAllStudentsOnLoad()
        {
            con = Connection.authorize();
            string query = @"select s.Student_Name, s.Father_Name, c.Class_Name, o.Office_Name from tbl_students s
inner join tbl_Classes c on c.Class_Id = s.Class_Id
inner join Tbl_Offices o on o.Office_Id = s.Office_Id";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}