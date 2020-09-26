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
    public partial class GetFailedStudents : System.Web.UI.Page
    {
        int office_Id;
        int class_id;
        int exam_id1;
        int exam_id2;
        int lastmonth;
        string status = "Fail";
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                 office_Id = int.Parse(Request.QueryString["Office_Id"]);
                 class_id = int.Parse(Request.QueryString["Class_Id"].ToString());
                 exam_id1 = int.Parse(Request.QueryString["Exam_Id"].ToString());
                if (exam_id1 == 1)
                {
                    exam_id2 = 1;
                }
                else if (exam_id1 == 2)
                {
                    exam_id2 = 1;
                }
                else if (exam_id1 == 3)
                {
                    exam_id2 = 2;
                }
                else if (exam_id1 == 4)
                {
                    exam_id2 = 3;
                }
                else if (exam_id1 == 5)
                {
                    exam_id2 = 4;
                }
                else if (exam_id1 == 6)
                {
                    exam_id2 = 5;
                }
                lastmonth = int.Parse(Request.QueryString["lastMonth"].ToString());
                LoadStudent();

            }
        }

        private void LoadStudent()
        {
            DataTable dt = new DataTable();
            string query1 = "";
            string query = "";
            con = Connection.authorize();
            if (exam_id1 == 1)
            {
                 query1 = @"SELECT st.Student_Name, st.Father_Name,c.Class_Name, o.Office_Name FROM Tbl_Students st inner join Tbl_Classes c on c.Class_Id=st.Class_Id inner join Tbl_Offices o on o.Office_Id= st.Office_Id WHERE o.Office_Id='" + office_Id + "' and c.Class_Id='" + class_id + "' and Student_Id NOT IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm)";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                sda1.Fill(dt);
                query = @"
SELECT st.Student_Name, st.Father_Name,c.Class_Name, o.Office_Name,sm.TotalMarks,sm.ObtainedMarks,sm.Exam_Date, sm.Status,sm.Exam_Id FROM Tbl_Students st 
inner join Tbl_Classes c on c.Class_Id=st.Class_Id 
inner join Tbl_Offices o on o.Office_Id= st.Office_Id 
inner join Tbl_StudentsExamMarking sm on sm.Student_Id = st.Student_Id
WHERE o.Office_Id='" + office_Id+ "' and c.Class_Id='"+class_id+ "' and st.Student_Id IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm where sm.Status='Fail' and sm.Exam_Id='"+exam_id1+"' and Month(sm.Exam_Date)='" + lastmonth+ "') and st.Student_Id NOT IN (select Student_Id from Tbl_StudentsExamMarking sm where sm.Status='Pass' and sm.Exam_Id='"+exam_id1+ "' and MONTH(sm.Exam_Date)='"+lastmonth+"')";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
            }
            //string query1 = @"SELECT st.Student_Name, st.Father_Name,c.Class_Name, o.Office_Name FROM Tbl_Students st inner join Tbl_Classes c on c.Class_Id=st.Class_Id inner join Tbl_Offices o on o.Office_Id= st.Office_Id WHERE o.Office_Id='"+office_Id+"' and c.Class_Id='"+class_id+"' and Student_Id NOT IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm)";
            //            string query = @"select st.Student_Name, st.Father_Name,c.Class_Name,o.Office_Name, sm.TotalMarks,sm.ObtainedMarks,sm.Exam_Date, sm.Status from Tbl_StudentsExamMarking sm
            //inner join Tbl_Students st on st.Student_Id = sm.Student_Id
            //inner join Tbl_Offices o on o.Office_Id = sm.Office_Id
            //inner join Tbl_Classes c on c.Class_Id = sm.Class_Id
            //where sm.Office_Id = '"+office_Id+"' and sm.Class_Id='"+class_id+"' and sm.Exam_Id = '"+exam_id+"' and Month(sm.Exam_Date)='"+lastmonth+"' and sm.Status='"+status+"'";
            else
            {
                query = @"Select st.Student_Id, st.Student_Name,st.Father_Name,c.Class_Name,o.Office_Name,sm.TotalMarks,sm.ObtainedMarks,sm.Exam_Date, sm.Status,sm.Exam_Id from Tbl_StudentsExamMarking sm
inner join Tbl_Students st on st.Student_Id = sm.Student_Id
inner join Tbl_Offices o on o.Office_Id = sm.Office_Id
inner join Tbl_Classes c on c.Class_Id = sm.Class_Id
 where sm.Office_Id = '" + office_Id + "' and sm.Class_Id = '" + class_id + "' and sm.exam_id = '" + exam_id1 + "' and status = 'Fail' and Month(sm.Exam_Date)= '" + lastmonth + "' and not exists(select * from Tbl_StudentsExamMarking as f where f.Student_Id = sm.Student_Id and f.Office_Id = sm.Office_Id  and f.Status = 'pass' and f.Exam_Id = (sm.Exam_Id + 1)) and exists(select* from Tbl_StudentsExamMarking as f where f.Student_Id = sm.Student_Id and f.Office_Id = sm.Office_Id  and f.Status = 'Pass' and f.Exam_Id = (sm.Exam_Id - 1)) and not exists(select * from Tbl_StudentsExamMarking as f where f.Student_Id = sm.Student_Id and f.Office_Id = sm.Office_Id  and f.Status = 'Pass' and f.Exam_Id = (sm.Exam_Id)) Union Select st.Student_Id, st.Student_Name,st.Father_Name,c.Class_Name,o.Office_Name,sm.TotalMarks,sm.ObtainedMarks,sm.Exam_Date, sm.Status,sm.Exam_Id from Tbl_StudentsExamMarking sm inner join Tbl_Offices o on o.Office_Id = sm.Office_Id inner join Tbl_Classes c on c.Class_Id = sm.Class_Id inner join Tbl_Students st on st.Student_Id = sm.Student_Id where sm.Office_Id = '" + office_Id + "' and sm.Class_Id = '" + class_id + "' and sm.exam_id = '" + exam_id2 + "' and status = 'Pass' and Month(sm.Exam_Date)= '" + lastmonth + "' AND NOT EXISTS(SELECT * FROM Tbl_StudentsExamMarking AS x WHERE x.Office_Id = sm.Office_Id AND x.Student_id = sm.Student_id AND x.Exam_Id = (sm.Exam_Id + 1) AND x.[Status] = 'Pass') AND NOT EXISTS(SELECT * FROM Tbl_StudentsExamMarking AS x WHERE x.Office_Id = sm.Office_Id AND x.Student_id = sm.Student_id AND x.Exam_Id = (sm.Exam_Id + 1) AND x.[Status] = 'Fail')";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
            }
            
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }
    }
}