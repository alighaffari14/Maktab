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
            string constring = @"Data Source=.\MSSQLSERVER01;Initial Catalog=FundingSystem;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            return con;
            //string constring = "data source=odfa.xyz;Initial Catalog=odfaxyz_funding;Persist Security Info=True;User ID=hassan; Password=G#@3012*";
            //SqlConnection con = new SqlConnection(constring);
            //con.Open();
            //return con;
        }
    }
}