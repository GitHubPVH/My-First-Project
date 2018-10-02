using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NeverGiveUp
{
    public class DataProcess
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = null;
            conn = new SqlConnection("SERVER = DESKTOP-P94RDLC;Database=NeverGiveUp;uid=sa;pwd=12345");
            return conn;
        }
        public bool CheckLogin (string user, string pass)
        {
            string sql = "SELECT * FROM AccountAdmin WHERE _user = @u and _pass = @p";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = GetConnection();
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", pass);
            SqlDataReader rd = cmd.ExecuteReader();
            bool result = rd.HasRows;
            rd.Close();
            cmd.Connection.Close();
            return result;
        }
        public bool AddQuestion ( string id , string content , string a , string b ,string c,string d, string correct ,string sid)
        {
            string sql = "INSERT INTO tblQuestion (_id ,_content,_a,_b,_c,_d,_correct,_sid) VALUES ( @i,@ct,@a,@b,@c,@d,@crr,@s)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@i", id);
            cmd.Parameters.AddWithValue("@ct", content);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@crr", correct);
            cmd.Parameters.AddWithValue("@s", sid);
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result > 0;
        }
        public bool DeleteQuestion (string id )
        {
            string sql = "DELETE FROM tblQuestion WHERE _id = @i";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = GetConnection();
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@i", id);
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result > 0;
        }
        public bool UpdateQuestion (string id , string level , string content,string correct ,string a, string b, string c ,string d  )
        {
            string sql = "UPDATE tblQuestion SET _sid = @s,_content =@ct,_correct =@cr,_a=@a,_b=@b,_c=@c,_d=@d WHERE _id =@i";
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = GetConnection();
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@i", id);
                cmd.Parameters.AddWithValue("@s", level);
                cmd.Parameters.AddWithValue("@ct",content);
                cmd.Parameters.AddWithValue("@cr", correct);
                cmd.Parameters.AddWithValue("@a", a);
                cmd.Parameters.AddWithValue("@b", b);
                cmd.Parameters.AddWithValue("@c", c);
                cmd.Parameters.AddWithValue("@d", d);
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return result > 0;
            }
        }
        public DataTable GetQuestions()
        {
            string sql = "SELECT * FROM tblQuestion";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
            da.Fill(dt);
            return dt;
        }
        public DataTable SearchById(string id )
        {
            string sql = "SELECT * FROM tblQuestion WHERE _id = '" + id + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
            da.Fill(dt);
            return dt;
        }
        public Question GetQuestionByID(string id)
        {
            Question qs = new Question();
            string sql = "SELECT * FROM tblQuestion WHERE _id=@i";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@i", id);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                qs.ID = rd.GetString(0);
                qs.Content = rd.GetString(1);
                qs.A = rd.GetString(2);
                qs.B = rd.GetString(3);
                qs.C = rd.GetString(4);
                qs.D = rd.GetString(5);
                qs.Correct = rd.GetString(6);
            }
            cmd.Connection.Close();
            return qs;
        }
        public List<Question> GetQuestionByExam(string Examcode)
        {
            List<Question> list = new List<Question>();
            string sql = "SELECT * FROM Exam WHERE _Examcode = @ec";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@ec", Examcode);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Question q = GetQuestionByID(rd.GetString(0));
                list.Add(q);
            }
            rd.Close();
            cmd.Connection.Close();
            return list;

        }

    }
}
