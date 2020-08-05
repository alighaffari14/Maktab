using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class AddAccountType : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            con = Connection.authorize();
            string query = "insert into Tbl_AccontType(Acc_Type_Name,Acc_Type_Description)values('"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"')";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
        }
    }
}