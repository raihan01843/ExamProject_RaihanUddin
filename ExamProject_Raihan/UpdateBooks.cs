using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamProject_Raihan
{
    class UpdateBooks
    {
        string cs = ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        public void UpdateBookInfo(string query)
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
