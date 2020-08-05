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
    public partial class CustodianTransactions : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                con = Connection.authorize();
                string query = @"select c.Custodian_Name,p.Purpose_Name, ca.Amount from Tbl_CustodianAccount ca
inner join Tbl_Custodian c on c.Custodian_Id = ca.Custodian_ID
inner join Tbl_Purpose p on p.Purpose_Id = ca.Account_CustodianPurpose_Id";
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