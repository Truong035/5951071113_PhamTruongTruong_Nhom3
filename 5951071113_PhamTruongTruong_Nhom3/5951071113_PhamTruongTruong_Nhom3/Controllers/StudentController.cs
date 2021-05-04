
using _5951071113_PhamTruongTruong_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _5951071113_PhamTruongTruong_Nhom3.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/<controller>
      
        SqlDataAdapter adapter;
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-97ILKMOH;Initial Catalog=Nawab;Integrated Security=True");
        public IEnumerable<Models.Student> Get()
        {
          
            adapter = new SqlDataAdapter("Select * from Student", connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Student> students = new List<Student>();
            foreach (DataRow item in data.Rows)
            {
                students.Add(new ReaStudent(item)); 

            }


            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Models.Student> Get(int id)
        {
            adapter = new SqlDataAdapter(String.Format("Select * from Student where ID={0}",id), connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<Student> students = new List<Student>();
            foreach (DataRow item in data.Rows)
            {
                students.Add(new ReaStudent(item));

            }


            return students;
           
        }

        // POST api/<controller>
        public string Post([FromBody] Student student)
        {
            try
            {
                connection.Open();  
                string sql = string.Format(@"insert into student (f_name,m_name,l_name,adress,birthdate,score,dep_id)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",student.f_name, student.m_name, student.l_name,  student.adress, student.birthdate, student.score, student.dep_id);
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.ExecuteNonQuery();
                return "Them thanh cong";
            }
            catch(Exception e)
            {
                return "" + e.Message;
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}