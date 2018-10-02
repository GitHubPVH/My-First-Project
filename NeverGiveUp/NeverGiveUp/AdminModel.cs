using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NeverGiveUp
{
    public class AdminModel
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = null;
            conn = new SqlConnection("SERVER = DESKTOP-P94RDLC;Database=NeverGiveUp;uid=sa;pwd=12345");
            return conn;
        }
        public bool AddExam(string Examcode)
        {
            string sql = "INSERT INTO Exam (_Examcode) VALUES (@ex)";
            SqlCommand cmd = new SqlCommand(sql,GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@ex", Examcode);
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result > 0;
        }
        public bool AddExamDetail (string Examcode , string IdQuestion)
        {
            string sql = "INSERT INTO ExamDetail (_Examcode , _id)  VALUES (@ec,@iq)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@ec", Examcode);
            cmd.Parameters.AddWithValue("@iq", IdQuestion);
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result > 0;
        }
        public List<Question> GetQuestions(string type )
        {
            List<Question> list = new List<Question>();
            string sql = "SELECT * FROM tblQuestion WHERE _sid ='" + type + "'";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                Question q = new Question();
                q.ID = rd.GetString(0);
                q.Content = rd.GetString(1);
                q.A = rd.GetString(2);
                q.B = rd.GetString(3);
                q.C = rd.GetString(4);
                q.D = rd.GetString(5);
                q.Correct = rd.GetString(6);
                list.Add(q);
            }
            rd.Close();
            cmd.Connection.Close();
            return list;

        }
       
        public List<Question > GetRandomQuestion ( string type)
        {
            List<Question> q25 = new List<Question>();
            List<Question> listFull = GetQuestions(type);
            int count = 0;
            while(count < 4)
            {
                Random ran = new Random();
                int i = ran.Next(0, listFull.Count - 1);
                Question q = listFull[i];
                if(CheckExist(q.ID,q25))
                {
                    q25.Add(q);
                    count++;
                }
            }
            return q25;

        }
        public bool CheckExist ( string id ,List<Question>qs)
        {
            foreach (var item in qs)
                if (item.ID.Equals(id))
                    return false;
            return true;
        }
    }
        
}
