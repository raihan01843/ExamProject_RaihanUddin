using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamProject_Raihan
{
    class InsertedMethod
    {
        string cs = ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public void insertedData(string query)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
