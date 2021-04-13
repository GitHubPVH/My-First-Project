using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClientApp
{
    public class Dataprocess
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = null;
            conn = new SqlConnection("SERVER = DESKTOP-P94RDLC;Database=NeverGiveUp;uid=sa;pwd=12345");
            return conn;
        }
       GetConnection();
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", pass);
            SqlDataReader rd = cmd.ExecuteReader();
            bool result = rd.HasRows;
            rd.Close();
            cmd.Connection.Close();
            return result;
        }
        public List<Questions> GetQuestions()
        {
            List<Questions> list = new List<Questions>();
            string sql = "SELECT * FROM Exam";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Questions q = new Questions();
                q.ID = rd.GetString(0);
                q.A = rd.GetString(1);
                q.B = rd.GetString(2);
                q.C = rd.GetString(3);
                q.D = rd.GetString(4);
                q.Correct = rd.GetString(7);
                list.Add(q);
            }
            rd.Close();
            cmd.Connection.Close();
            return list;
        }
    }

}




