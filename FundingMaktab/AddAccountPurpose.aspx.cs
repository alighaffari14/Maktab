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
    public partial class AddAccountPurpose : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingAccountDropdownListOnLoad();
            }
           
        }

        private void BindingAccountDropdownListOnLoad()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Account";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataValueField = "Acc_Id";
            DropDownList1.DataTextField = "Acc_Name";
            DropDownList1.DataBind();
            con.Close();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            con = Connection.authorize();
            string query = "insert into Tbl_Purpose(Purpose_Name,Purpose_Account_Id)values('"+textBox1.Text.ToString()+"','"+DropDownList1.SelectedValue+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
    }
}