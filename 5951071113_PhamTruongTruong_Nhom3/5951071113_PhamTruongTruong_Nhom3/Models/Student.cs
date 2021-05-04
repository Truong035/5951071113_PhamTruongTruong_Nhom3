using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _5951071113_PhamTruongTruong_Nhom3.Models

{
    public class Student
    {
     public int ID { get; set; }
      public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string adress { get; set; }
        public string birthdate { get; set; }
        public string score { get; set; }
        public string dep_id { get; set; }

    }
    class ReaStudent : Student
    {
        public ReaStudent(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"].ToString());
            f_name = row["f_name"].ToString();
            m_name = row["m_name"].ToString();
            l_name = row["l_name"].ToString();
            adress = row["adress"].ToString();
            birthdate = row["birthdate"].ToString();
            score = row["score"].ToString();
            dep_id = row["dep_id"].ToString();
         
        }
    }
}