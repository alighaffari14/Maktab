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
    public partial class AccountPurpose : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            gettingallpurposeofAccount();
        }

        private void gettingallpurposeofAccount()
        {
            con = Connection.authorize();
            string query = "select p.Purpose_Name, a.Acc_Name from Tbl_Purpose p inner join Tbl_Account a on a.Acc_Id = p.Purpose_Account_Id ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}