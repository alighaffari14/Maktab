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
    public partial class PurposeTransactions : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] != null)
            {
                con = Connection.authorize();
                string queyr = @"select p.Purpose_Name, a.Acc_Name,pt.Amount from Tbl_PurposeTransactions pt
                                    inner join Tbl_Purpose p on p.Purpose_Id = pt.Purpose_Id
                                    inner join Tbl_Account a on a.Acc_Id = pt.Account_Id";
                SqlDataAdapter sda = new SqlDataAdapter(queyr, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Repeater2.DataSource = dt;
                Repeater2.DataBind();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

           
        }
    }
}