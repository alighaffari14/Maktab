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
    public partial class SelectDonationEntry : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["username"] != null)
                {
                    BindingAccountDropDown();
                    BindingAccountTypeDropDown();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

               
            }

        }

        private void BindingAccountTypeDropDown()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Account";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Acc_Name";
            DropDownList1.DataValueField = "Acc_Id";
            DropDownList1.DataBind();
            con.Close();
        }

        private void BindingAccountDropDown()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_AccontType";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "Acc_Type_Name";
            DropDownList2.DataValueField = "Acc_Type_Id";
            DropDownList2.DataBind();
            con.Close();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            int accountid = int.Parse(DropDownList1.SelectedValue);
            int accountypeid = int.Parse(DropDownList2.SelectedValue);
            if (int.Parse(DropDownList2.SelectedValue) == 1)
            {
                Response.Redirect(string.Format("DonationIncome.aspx?Acc_Id={0} &Acc_Type_Id={1}",accountid,accountypeid));
            }
            else
            {
                Response.Redirect(string.Format("DonationExpense.aspx?Acc_Id={0}",accountid));
            }
        }
    }
}