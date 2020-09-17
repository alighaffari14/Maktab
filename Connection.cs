using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FundingMaktab
{
    public class Connection
    {
       

        public static SqlConnection authorize()
        {
            //string constring = @"Data Source=.\MSSQLSERVER01;Initial Catalog=FundingSystem;Integrated Security=True";
            //SqlConnection con = new SqlConnection(constring);
            //con.Open();
            //return con;
            string constring = "data source=maktabonline.ml;Initial Catalog=maktabon_Funding;Persist Security Info=True;User ID=ghaffari; Password=W#lm057g";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            return con;
        }
    }
}