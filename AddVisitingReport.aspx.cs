using Microsoft.SqlServer.Server;
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
    public partial class AddVisitingReport : System.Web.UI.Page
    {
        SqlConnection con;
        int muallim_Id = 0;
        int lastMonth = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {

                    BindingCentersDropDownlist();
                    GettingAllInformationRelatedToCenterOnLoad();
                    gettingTotalVipStudents();
                    gettingTotalDarjaeAtfaalStudents();
                    gettingTotalDarjaeAwwalStudents();
                    gettingTotalStudentsInCenter();
                    BindingExamsEnrolledMonths();
                    LoadLastMonthofLastRow();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

               
            }
           
        }

        private void gettingTotalStudentsInCenter()
        {
            con = Connection.authorize();
            string query = @"select count(Student_Id) total from Tbl_Students where Office_Id = '" + DropDownList3.SelectedValue + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox7.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void gettingTotalDarjaeAwwalStudents()
        {
            con = Connection.authorize();
            string query = @"select count(Student_Id) total from Tbl_Students where Office_Id = '" + DropDownList3.SelectedValue + "' and Class_Id = 2";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox6.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void gettingTotalDarjaeAtfaalStudents()
        {
            con = Connection.authorize();
            string query = @"select count(Student_Id) total from Tbl_Students where Office_Id = '" + DropDownList3.SelectedValue + "' and Class_Id = 1";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox5.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void gettingTotalVipStudents()
        {
            con = Connection.authorize();
            string query = @"select count(Student_Id) total from Tbl_Students where Office_Id = '" + DropDownList3.SelectedValue + "' and Class_Id = 4";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox4.Text = reader[0].ToString();
            }
            con.Close();
        }

        private void GettingAllInformationRelatedToCenterOnLoad()
        {
            con = Connection.authorize();
            string query = @"select o.Registeration_Number,o.Village_Mohalla,o.Tehsil_District, o.Office_Name, m.* from Tbl_Muallim m
inner join Tbl_Offices o on o.Office_Id = m.Office_Id
where m.Office_Id='" + DropDownList3.SelectedValue+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                textBox14.Text = reader[0].ToString();
                textBox1.Text = reader[1].ToString();
                textBox2.Text = reader[2].ToString();
                textBox3.Text = reader[5].ToString();
                muallim_Id = int.Parse(reader[4].ToString());
            }
            con.Close();
        }

        private void BindingCentersDropDownlist()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Offices";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "Office_Name";
            DropDownList3.DataValueField = "Office_Id";
            DropDownList3.DataBind();
            con.Close();
        }

        int totalmarks = 0;
        public void Button1_Click(object sender, EventArgs e)
        {
            gettingMuallimID();
            con = Connection.authorize();
            string date_time = textBox15.Text.ToString();
            string query = @"insert into Tbl_MaktabReporting(Office_Id,Muallim_Id,Visiting_Date,VIP_Students,Atfaal_Students,Awwal_Students,
Total_Students,Shariya,Disciplane_Marks,Cleaning_Marks,Books_Exams,Oral_Exams,No_Of_Books,Total_Obtained_Marks,Remarks)
values('"+int.Parse(DropDownList3.SelectedValue)+"','"+muallim_Id+"','"+ date_time + "','"+int.Parse(textBox4.Text)+"','"+int.Parse(textBox5.Text)+"','"+int.Parse(textBox6.Text)+"','"+int.Parse(textBox7.Text)+"','"+int.Parse(textBox16.Text)+"','"+int.Parse(textBox8.Text)+"','"+int.Parse(textBox9.Text)+"','"+ int.Parse(textBox10.Text) + "','"+ int.Parse(textBox11.Text) + "','"+ int.Parse(textBox12.Text) + "','"+int.Parse(Label1.Text.ToString())+"','"+ textBox13.Text.ToString()+ "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void gettingMuallimID()
        {
            con = Connection.authorize();
            string query = @"select * from Tbl_Muallim where Office_Id ='" + DropDownList3.SelectedValue + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                muallim_Id = int.Parse(reader[7].ToString());
            }
            con.Close();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GettingAllInformationRelatedToCenterOnLoad();
            BindingExamsEnrolledMonths();
            gettingTotalVipStudents();
            gettingTotalDarjaeAtfaalStudents();
            gettingTotalDarjaeAwwalStudents();
            gettingTotalStudentsInCenter();
        }

        private void LoadLastMonthofLastRow()
        {
            con = Connection.authorize();
            string query = "SELECT TOP 1 Month(Exam_Date) FROM Tbl_StudentsExamMarking where Office_Id='" + int.Parse(DropDownList3.SelectedValue) + "' ORDER BY Exam_Date DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lastMonth = int.Parse(reader[0].ToString());
            }
            con.Close();
        }


        private void BindingExamsEnrolledMonths()
        {
            LoadLastMonthofLastRow();
            for (int i = 1; i < 7; i++)
            {
                if (i == 1)
                {
                    con = Connection.authorize();
                    string query = @"select count(Student_Id) total from Tbl_StudentsExamMarking where Office_Id = '"+int.Parse(DropDownList3.SelectedValue)+"' and Class_Id = 1 and Exam_id=1 and Status='Fail' and Month(Exam_Date)='"+lastMonth+"'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Label2.Text = reader[0].ToString();
                        
                    }
                    con.Close();
                }
                else if (i == 2)
                {
                    con = Connection.authorize();
                    string query = @"select count(Student_Id) total from Tbl_StudentsExamMarking where Office_Id = '" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id = 1 and Exam_id=2 and Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        Label3.Text = reader[0].ToString();
                    }
                    con.Close();
                }
                else if (i == 3)
                {

                    con = Connection.authorize();
                    string query = @"select count(Student_Id) total from Tbl_StudentsExamMarking where Office_Id = '" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id = 1 and Exam_id=3 and Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        Label4.Text = reader[0].ToString();
                        
                    }
                    con.Close();
                }

                else if (i == 4)
                {
                    con = Connection.authorize();
                    string query = @"select count(Student_Id) total from Tbl_StudentsExamMarking where Office_Id = '" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id = 1 and Exam_id=4 and Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                      
                        Label5.Text = reader[0].ToString();
                       
                    }
                    con.Close();
                }
                else if (i == 5)
                {
                    con = Connection.authorize();
                    string query = @"select count(Student_Id) total from Tbl_StudentsExamMarking where Office_Id = '" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id = 1 and Exam_id=5 and Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        Label6.Text = reader[0].ToString();
                    }
                    con.Close();
                }
                else if (i == 6)
                {
                    con = Connection.authorize();
                    string query = @"select count(Student_Id) total from Tbl_StudentsExamMarking where Office_Id = '" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id = 1 and Exam_id=6 and Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        Label7.Text = reader[0].ToString();
                    }
                    con.Close();
                }


            }
            
        }

        protected void textBox12_TextChanged(object sender, EventArgs e)
        {
           
                totalmarks += int.Parse(textBox8.Text) + int.Parse(textBox9.Text) + int.Parse(textBox10.Text) + int.Parse(textBox11.Text) + int.Parse(textBox12.Text);
                Label1.Text = totalmarks.ToString();
            
            
        }

        
    }
}