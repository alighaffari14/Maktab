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
        int exam_id;
        int lastmonth;
        string status = "Fail";
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                 office_Id = int.Parse(Request.QueryString["Office_Id"]);
                 class_id = int.Parse(Request.QueryString["Class_Id"].ToString());
                 exam_id = int.Parse(Request.QueryString["Exam_Id"].ToString());
                 lastmonth = int.Parse(Request.QueryString["lastMonth"].ToString());
                LoadStudent();

            }
        }

        private void LoadStudent()
        {
            con = Connection.authorize();
            string query1 = @"SELECT st.Student_Name, st.Father_Name,c.Class_Name, o.Office_Name FROM Tbl_Students st inner join Tbl_Classes c on c.Class_Id=st.Class_Id inner join Tbl_Offices o on o.Office_Id= st.Office_Id WHERE o.Office_Id='"+office_Id+"' and c.Class_Id='"+class_id+"' and Student_Id NOT IN (SELECT Student_Id FROM Tbl_StudentsExamMarking sm)";
            string query = @"select st.Student_Name, st.Father_Name,c.Class_Name,o.Office_Name, sm.TotalMarks,sm.ObtainedMarks,sm.Exam_Date, sm.Status from Tbl_StudentsExamMarking sm
inner join Tbl_Students st on st.Student_Id = sm.Student_Id
inner join Tbl_Offices o on o.Office_Id = sm.Office_Id
inner join Tbl_Classes c on c.Class_Id = sm.Class_Id
where sm.Office_Id = '"+office_Id+"' and sm.Class_Id='"+class_id+"' and sm.Exam_Id = '"+exam_id+"' and Month(sm.Exam_Date)='"+lastmonth+"' and sm.Status='"+status+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.Fill(dt);
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
            sda1.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }
    }
}