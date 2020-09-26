using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FundingMaktab
{
    public partial class AddEnrolledStudentExams : System.Web.UI.Page
    {
        SqlConnection con;
        int lastMonth = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                   
                    BindingCentersDropDownlist();
                    BindingClassesDropDownList();
                    BindingDropDownlistOfExamsMonth();
                    LoadLastMonthofLastRow();
                    LoadAllStudentsOnLoad();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
               
            }
        }

        private void LoadLastMonthofLastRow()
        {
            con = Connection.authorize();
            string query = "SELECT TOP 1 Month(Exam_Date) FROM Tbl_StudentsExamMarking where Office_Id='"+int.Parse(DropDownList3.SelectedValue)+"' and Class_Id='"+int.Parse(DropDownList4.SelectedValue)+"' ORDER BY Exam_Date DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lastMonth = int.Parse(reader[0].ToString());
            }
            con.Close();
        }

        private void LoadAllStudentsOnLoad()
        {
            con = Connection.authorize();
            SqlDataAdapter failed;
            SqlDataAdapter existance;
            DataTable dt = new DataTable();
            string query2 = "";
            string query1 = @"SELECT * FROM Tbl_Students WHERE Office_Id='" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id='" + int.Parse(DropDownList4.SelectedValue) + "' and Student_Id NOT IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm)";
            if (lastMonth != 0)
            {
                 query2 = @"SELECT st.Student_Id, st.Student_Name,e.* FROM Tbl_StudentsExamMarking AS e inner join Tbl_Students st on st.Student_Id = e.Student_Id WHERE Month(e.Exam_Date)='" + lastMonth + "' and e.Office_Id = '" + int.Parse(DropDownList3.SelectedValue) + "' AND e.Class_Id ='" + int.Parse(DropDownList4.SelectedValue) + "' AND e.Exam_Id = '" + int.Parse(DropDownList2.SelectedValue) + "' AND [Status] = 'Fail' AND NOT EXISTS (SELECT * FROM Tbl_StudentsExamMarking AS x WHERE x.Office_Id = e.Office_Id AND x.Student_id = e.Student_id AND x.Exam_Id = ( e.Exam_Id) AND x.[Status] = 'Pass') and exists(select * from Tbl_StudentsExamMarking as f where f.Student_Id=e.Student_Id and f.Office_Id = e.Office_Id  and f.Status = 'Fail' and f.Exam_Id = (e.Exam_Id)) order by e.StudentExamMarking_Id DESC ";
                failed = new SqlDataAdapter(query2, con);
                failed.Fill(dt);
            }
          
            existance = new SqlDataAdapter(query1,con);
            existance.Fill(dt);
            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        private void BindingDropDownlistOfExamsMonth()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_ExamsMonths";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "Exam_Name";
            DropDownList2.DataValueField = "Exam_Id";
            DropDownList2.DataBind();
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

        public void BindingClassesDropDownList()
        {
            con = Connection.authorize();
            string query = "select * from Tbl_Classes";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataTextField = "Class_Name";
            DropDownList4.DataValueField = "Class_Id";
            DropDownList4.DataBind();
            con.Close();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            
            int rowIndex = 0;
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                double totalpercentage = 0;
                int val = 0;
                string status = "";
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        int studentid = int.Parse(dtCurrentTable.Rows[val][0].ToString());
                        val++;
                        totalpercentage = (double.Parse(box1.Text) * 100) / double.Parse(TextBox1.Text);
                        if (totalpercentage< 50)
                        {
                             status = "Fail";
                        }
                        else
                        {
                            status = "Pass";
                        }
                        string query = "";
                             query = "insert into Tbl_StudentsExamMarking(Student_Id,Class_Id,Office_Id,Exam_Id,Exam_Date,TotalMarks,ObtainedMarks,Status)values('" + studentid + "','" + int.Parse(DropDownList4.SelectedValue) + "','" + int.Parse(DropDownList3.SelectedValue) + "','" + int.Parse(DropDownList2.SelectedValue) + "','" + TextBox2.Text.ToString() + "','" + int.Parse(TextBox1.Text) + "','" + int.Parse(box1.Text) + "','" + status + "')";
                        con = Connection.authorize();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        rowIndex++;
                    }
                }
            }
        }

        //private bool RecordExistChecking(int studentid, int classid, int officeid, int examid,  string examdate, string status)
        //{
        //    bool result = false;
        //    status = "";
        //    con = Connection.authorize();
        //    string query = "IF EXISTS(SELECT * FROM Tbl_StudentsExamMarking WHERE Office_Id='"+officeid+"' Month(Exam_Date)='"+lastMonth+"' and Year(Exam_Date)=2020 and Class_Id='"+classid+"' and Student_Id='"+studentid+"' and Exam_Id='"+examdate+"' and status='"+status+"') BEGIN PRINT '0' END ELSE BEGIN PRINT '1' END";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        status = reader[0].ToString();
        //        if (status == "0")
        //        {
        //            result = true;
        //        }
        //        else
        //        {
        //            result = false;
        //        }
        //    }
        //    return result;
        //}

        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            
            int studentid = 0;
            //string str = "";
            //for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            //{
            //    if (CheckBoxList1.Items[i].Selected == true)// getting selected value from CheckBox List  
            //    {
            //        int incremental = 1;
            //        string textboxval = "txtDynamic" + incremental;
                    
            //        TextBox txt = pnlTextBoxes.FindControl("txtDynamic1") as TextBox;
            //        string idvalus = txt.Text;
            //        string value = txt.Text;
            //        studentid += int.Parse(CheckBoxList2.Items[i].Text);
            //        //str += CheckBoxList1.Items[i].Text + " ," + "<br/>"; // add selected Item text to the String .  
            //        con = Connection.authorize();
            //        string query = "insert into Tbl_StudentEnrolledExams(Student_Id,Exam_Id,Class_Id,Office_Id,Year)values('"+studentid+"','"+DropDownList2.SelectedValue+"','"+DropDownList4.SelectedValue+"','"+DropDownList3.SelectedValue+"','"+DateTime.Now.ToString("yyyy")+"')";
            //        SqlCommand cmd = new SqlCommand(query, con);
            //        cmd.ExecuteNonQuery();
            //        incremental++;
            //    }


            //}
           

        }


       

        //private void CreateTextBox(string id)
        //{
        //    TextBox txt = new TextBox();
        //    txt.ID = id;
        //    pnlTextBoxes.Controls.Add(txt);

        //}

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLastMonthofLastRow();
            DataTable dt = new DataTable();
            if (int.Parse(DropDownList2.SelectedValue) == 1)
            {
               
                //con = Connection.authorize();
                //string query1 = @"SELECT * FROM Tbl_Students WHERE Office_Id='" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id='" + int.Parse(DropDownList4.SelectedValue) + "' and Student_Id NOT IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm)";
                //string query2 = "select st.Student_Id, st.Student_Name from Tbl_StudentsExamMarking sm inner join Tbl_Students st on st.Student_Id = sm.Student_Id where sm.Office_Id ='" + int.Parse(DropDownList3.SelectedValue) + "' and sm.Class_Id='" + int.Parse(DropDownList4.SelectedValue) + "' and sm.Exam_Id ='" + int.Parse(DropDownList2.SelectedValue) + "' and sm.Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                //DataTable dt2 = new DataTable();
                ////List<string> studentlist = new List<string>();
                ////List<int> studentidlist = new List<int>();
                ////SqlDataReader reader = cmd.ExecuteReader();
                ////while (reader.Read())
                ////{
                ////    studentidlist.Add(int.Parse(reader["Student_Id"].ToString()));
                ////    studentlist.Add(reader["Student_Name"].ToString());
                ////}
                //SqlDataAdapter existance = new SqlDataAdapter(query1, con);
                //existance.Fill(dt2);
                //SqlDataAdapter failed = new SqlDataAdapter(query2, con);
                //failed.Fill(dt2);
                //Gridview1.DataSource = dt2;
                //Gridview1.DataBind();
                //con.Close();

                LoadAllStudentsOnLoad();
            }
            else if (int.Parse(DropDownList2.SelectedValue) == 2)
            {

                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1",2);
                cmd.Parameters.AddWithValue("@exam_id2", 1);
                cmd.Parameters.AddWithValue("@lastmonth",lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();


            }

            else if (int.Parse(DropDownList2.SelectedValue) == 3)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 3);
                cmd.Parameters.AddWithValue("@exam_id2", 2);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 4)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 4);
                cmd.Parameters.AddWithValue("@exam_id2", 3);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 5)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 5);
                cmd.Parameters.AddWithValue("@exam_id2", 4);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 6)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1",6);
                cmd.Parameters.AddWithValue("@exam_id2", 5);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();
            }
           

        }

        

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLastMonthofLastRow();
            string query1 = "";
            string query2 = "";
            DataTable dt = new DataTable();
            if (int.Parse(DropDownList2.SelectedValue) == 1)
            {

                //con = Connection.authorize();
                //string query1 = @"SELECT * FROM Tbl_Students WHERE Office_Id='" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id='" + int.Parse(DropDownList4.SelectedValue) + "' and Student_Id NOT IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm)";
                //string query2 = "select st.Student_Id, st.Student_Name from Tbl_StudentsExamMarking sm inner join Tbl_Students st on st.Student_Id = sm.Student_Id where sm.Office_Id ='" + int.Parse(DropDownList3.SelectedValue) + "' and sm.Class_Id='" + int.Parse(DropDownList4.SelectedValue) + "' and sm.Exam_Id ='" + int.Parse(DropDownList2.SelectedValue) + "' and sm.Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                //DataTable dt2 = new DataTable();
                ////List<string> studentlist = new List<string>();
                ////List<int> studentidlist = new List<int>();
                ////SqlDataReader reader = cmd.ExecuteReader();
                ////while (reader.Read())
                ////{
                ////    studentidlist.Add(int.Parse(reader["Student_Id"].ToString()));
                ////    studentlist.Add(reader["Student_Name"].ToString());
                ////}
                //SqlDataAdapter existance = new SqlDataAdapter(query1, con);
                //existance.Fill(dt2);
                //SqlDataAdapter failed = new SqlDataAdapter(query2, con);
                //failed.Fill(dt2);
                //Gridview1.DataSource = dt2;
                //Gridview1.DataBind();
                //con.Close();

                LoadAllStudentsOnLoad();
            }
            else if (int.Parse(DropDownList2.SelectedValue) == 2)
            {

                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 2);
                cmd.Parameters.AddWithValue("@exam_id2", 1);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();


            }

            else if (int.Parse(DropDownList2.SelectedValue) == 3)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 3);
                cmd.Parameters.AddWithValue("@exam_id2", 2);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 4)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 4);
                cmd.Parameters.AddWithValue("@exam_id2", 3);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 5)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 5);
                cmd.Parameters.AddWithValue("@exam_id2", 4);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 6)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 6);
                cmd.Parameters.AddWithValue("@exam_id2", 5);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLastMonthofLastRow();
            string query1 = "";
            string query2 = "";
            DataTable dt = new DataTable();
            if (int.Parse(DropDownList2.SelectedValue) == 1)
            {

                //con = Connection.authorize();
                //string query1 = @"SELECT * FROM Tbl_Students WHERE Office_Id='" + int.Parse(DropDownList3.SelectedValue) + "' and Class_Id='" + int.Parse(DropDownList4.SelectedValue) + "' and Student_Id NOT IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm)";
                //string query2 = "select st.Student_Id, st.Student_Name from Tbl_StudentsExamMarking sm inner join Tbl_Students st on st.Student_Id = sm.Student_Id where sm.Office_Id ='" + int.Parse(DropDownList3.SelectedValue) + "' and sm.Class_Id='" + int.Parse(DropDownList4.SelectedValue) + "' and sm.Exam_Id ='" + int.Parse(DropDownList2.SelectedValue) + "' and sm.Status='Fail' and Month(Exam_Date)='" + lastMonth + "'";
                //DataTable dt2 = new DataTable();
                ////List<string> studentlist = new List<string>();
                ////List<int> studentidlist = new List<int>();
                ////SqlDataReader reader = cmd.ExecuteReader();
                ////while (reader.Read())
                ////{
                ////    studentidlist.Add(int.Parse(reader["Student_Id"].ToString()));
                ////    studentlist.Add(reader["Student_Name"].ToString());
                ////}
                //SqlDataAdapter existance = new SqlDataAdapter(query1, con);
                //existance.Fill(dt2);
                //SqlDataAdapter failed = new SqlDataAdapter(query2, con);
                //failed.Fill(dt2);
                //Gridview1.DataSource = dt2;
                //Gridview1.DataBind();
                //con.Close();

                LoadAllStudentsOnLoad();
            }
            else if (int.Parse(DropDownList2.SelectedValue) == 2)
            {

                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 2);
                cmd.Parameters.AddWithValue("@exam_id2", 1);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();


            }

            else if (int.Parse(DropDownList2.SelectedValue) == 3)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 3);
                cmd.Parameters.AddWithValue("@exam_id2", 2);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 4)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 4);
                cmd.Parameters.AddWithValue("@exam_id2", 3);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 5)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 5);
                cmd.Parameters.AddWithValue("@exam_id2", 4);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();

            }
            else if (int.Parse(DropDownList2.SelectedValue) == 6)
            {
                con = Connection.authorize();
                SqlCommand cmd = new SqlCommand("StudentsExamsMarkingStudentSelection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@office_id", int.Parse(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@class_id", int.Parse(DropDownList4.SelectedValue));
                cmd.Parameters.AddWithValue("@exam_id1", 6);
                cmd.Parameters.AddWithValue("@exam_id2", 5);
                cmd.Parameters.AddWithValue("@lastmonth", lastMonth);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewState["CurrentTable"] = dt;
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                con.Close();
            }
        }
    }
}