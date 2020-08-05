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
    public partial class Transactions : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    gettingAllTransactionsOnLoad();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            
        }

        private void gettingAllTransactionsOnLoad()
        {
            con = Connection.authorize();
            string query = @"select t.Transaction_Amount_Credit, t.Transaction_Amount_Debit,t.Transaction_Date,t.Transaction_Purpose,
 a.Acc_Name, d.Donar_Name, c.Custodian_Name, o.Office_Name from Tbl_Transaction t
 inner join Tbl_Account a on a.Acc_Id = t.Transaction_Acc_Id
left join Tbl_Donar d on d.Donar_Id = t.Trasaction_Donar_Id
 inner join Tbl_Custodian c on c.Custodian_Id = t.Transaction_Custodian_Id
 inner join Tbl_Offices o on o.Office_Id = t.Transaction_Office_Id";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
            con.Close();
        }
    }
}