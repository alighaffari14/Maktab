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
    public partial class AccountAssignTypes : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            gettingAllAccountsWithTheirTypesOnLoad();
        }

        private void gettingAllAccountsWithTheirTypesOnLoad()
        {
            con = Connection.authorize();
            string query = @" select a.Acc_Name, t.Acc_Type_Name from Tbl_AccountControl ac
 inner join Tbl_AccontType t on t.Acc_Type_Id = ac.Acc_Type_Id
 inner join Tbl_Account a on a.Acc_Id = ac.Acc_Id";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}