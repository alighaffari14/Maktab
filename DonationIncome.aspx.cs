using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class DonationIncome : System.Web.UI.Page
    {
        SqlConnection con;
        int AccountID;
        int Account_TypeID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    //Account_TypeID = int.Parse(Request.QueryString["Acc_Type_Id"]);
                    gettingAccountID();
                    gettingAccountName();
                    gettingAllAccountPurpose();
                    gettingAllOffices();
                    gettingAllDonors();
                    gettingAllCustodian();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                
            }
           
        }

        private void gettingAccountID()
        {
            int Account_ID = int.Parse(Request.QueryString["Acc_Id"]);
            con = Connection.authorize();
            string query = "select * from Tbl_Account where Acc_Id='"+Account_ID+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AccountID = int.Parse(reader[0].ToString());
            }
        }

        private void gettingAllCustodian()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Custodian";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataTextField = "Custodian_Name";
            DropDownList4.DataValueField = "Custodian_Id";
            DropDownList4.DataBind();
            con.Close();
        }

        private void gettingAllDonors()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Donar";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "Donar_Name";
            DropDownList3.DataValueField = "Donar_Id";
            DropDownList3.DataBind();
            con.Close();
        }

        private void gettingAllOffices()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Offices";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "Office_Name";
            DropDownList2.DataValueField = "Office_Id";
            DropDownList2.DataBind();
            con.Close();
        }

        private void gettingAllAccountPurpose()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Purpose where Purpose_Account_Id='"+AccountID+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Purpose_Name";
            DropDownList1.DataValueField = "Purpose_Id";
            DropDownList1.DataBind();
            con.Close();
        }

        private void gettingAccountName()
        {
            con = Connection.authorize();
            string query = "select Acc_Name from Tbl_Account where Acc_Id='"+AccountID+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
            }
            con.Close();
        }




       
        public void Button2_Click(object sender, EventArgs e)
        {
            gettingAccountID();
            insertingIntoDonationTable();
            insertingIntoTransactionTable();
            checkingCustodianAccountTable();
            checkingPurposeAmountFromPurposeTransactionTable();
            LoadingAmountOfAccountFromAccountTable();
            
           
        }

        private void checkingPurposeAmountFromPurposeTransactionTable()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_PurposeTransactions where Purpose_Id='" + int.Parse(DropDownList1.SelectedValue) + "' and Account_Id='" + AccountID + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                con.Close();
                gettingAmountOfPurpose();
            }
            else
            {
                con.Close();
                insertingIntoPurposeTransactionsTable();
            }
            
        }

        private void insertingIntoPurposeTransactionsTable()
        {
            con = Connection.authorize();
            string query = "insert into Tbl_PurposeTransactions(Purpose_Id,Account_Id,Amount)values('"+int.Parse(DropDownList1.SelectedValue)+"','"+AccountID+"','"+int.Parse(textBox4.Text)+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private void updatingPurposeTransactionTable(int purposeamount)
        {
            int finalamount = purposeamount + int.Parse(textBox4.Text);
            con = Connection.authorize();
            string query = "update Tbl_PurposeTransactions set Amount='"+finalamount+"' where Purpose_Id='"+int.Parse(DropDownList1.SelectedValue)+"' and Account_Id='"+AccountID+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void gettingAmountOfPurpose()
        {
            int purpose_amount = 0;
            con = Connection.authorize();
            string query = "select Amount from Tbl_PurposeTransactions where Account_Id= '"+AccountID+"' and Purpose_Id='"+int.Parse(DropDownList1.SelectedValue)+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                purpose_amount = int.Parse(reader[0].ToString());
            }
            con.Close();
            updatingPurposeTransactionTable(purpose_amount);
        }

        private void checkingCustodianAccountTable()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_CustodianAccount where Custodian_ID='"+int.Parse(DropDownList4.SelectedValue)+"' and Account_Custodian_Id='"+AccountID+"' and Account_CustodianPurpose_Id='"+int.Parse(DropDownList1.SelectedValue)+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count>0)
            {
                updatingCustodianAccountTable();
            }
            else
            {
                insertingIntoCustodianAccountTable();
            }
            
        }

        private void updatingCustodianAccountTable()
        {
            gettingCustodianAmount();
        }

        private void gettingCustodianAmount()
        {
            int custodian_amount = 0;
            con = Connection.authorize();
            string query = "select Amount from Tbl_CustodianAccount where Custodian_ID='" + int.Parse(DropDownList4.SelectedValue) + "' and Account_Custodian_Id='" + AccountID + "' and Account_CustodianPurpose_Id='" + int.Parse(DropDownList1.SelectedValue) + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                custodian_amount = int.Parse(reader[0].ToString());
            }
            int finalAmount = custodian_amount + int.Parse(textBox4.Text);
            con.Close();
            updatingCustodianAmountInCustodianAccountTable(finalAmount);
        }

        private void updatingCustodianAmountInCustodianAccountTable(int custodianAmount)
        {
            con = Connection.authorize();
            string query = "update Tbl_CustodianAccount set Amount = '"+custodianAmount+ "'  where Custodian_ID='" + int.Parse(DropDownList4.SelectedValue) + "' and Account_Custodian_Id='" + AccountID + "' and Account_CustodianPurpose_Id='" + int.Parse(DropDownList1.SelectedValue) + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private void LoadingAmountOfAccountFromAccountTable()
        {
            int accountamount = 0;
            con = Connection.authorize();
            string query = "select * from Tbl_Account where Acc_Id='"+AccountID+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                accountamount = int.Parse(reader[2].ToString());
            }
           
            updatingAccountAmountInTable(accountamount);
        }

        private void updatingAccountAmountInTable(int amount)
        {
            int finalamount = amount + int.Parse(textBox4.Text);
            con = Connection.authorize();
            string query = "update Tbl_Account set Acc_InitialAmount='"+ finalamount + "' where Acc_Id='"+AccountID+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private void insertingIntoCustodianAccountTable()
        {
            con = Connection.authorize();
            string query = @"insert into Tbl_CustodianAccount(Custodian_ID,Account_Custodian_Id,Account_CustodianPurpose_Id,Amount)
                            values('" + int.Parse(DropDownList4.SelectedValue) + "','" + AccountID + "','" + int.Parse(DropDownList1.SelectedValue) + "','" + int.Parse(textBox4.Text) + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private void insertingIntoTransactionTable()
        {
            string time = DateTime.Now.ToShortTimeString();
            string date_time = textBox2.Text.ToString() + " " + time;
            con = Connection.authorize();
            string query = @"insert into Tbl_Transaction(Transaction_Acc_Id,Trasaction_Donar_Id,Transaction_Amount_Credit,Transaction_Amount_Debit,Transaction_Purpose,Transaction_Date,Transaction_Custodian_Id,Transaction_Office_Id)
                            values('" + AccountID + "','" + int.Parse(DropDownList3.SelectedValue) + "','" + int.Parse(textBox4.Text) + "',Null,'" + DropDownList1.SelectedItem.ToString() + "','" + date_time + "','" + int.Parse(DropDownList4.SelectedValue) + "','" + int.Parse(DropDownList2.SelectedValue) + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private void insertingIntoDonationTable()
        {
            string time = DateTime.Now.ToShortTimeString();
            string date_time = textBox2.Text.ToString() +" "+ time;
            con = Connection.authorize();
            string query = @"insert into Tbl_Donations(Donar_Acc_Id,Donation_Purpose,Donar_Amount,Donar_Id,Donation_Date,Donation_Custodian_Id,Donation_Office_Id)
                            values('" + AccountID + "','" + int.Parse(DropDownList1.SelectedValue) + "','" + int.Parse(textBox4.Text) + "','" + int.Parse(DropDownList3.SelectedValue) + "','" + date_time.ToString() + "','" + int.Parse(DropDownList4.SelectedValue) + "','" + int.Parse(DropDownList2.SelectedValue) + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
    }
}