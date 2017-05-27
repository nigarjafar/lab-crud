using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabCrud
{
    class Student
    {
        public int Id;
        public string Name;
        public string Surname;
        public DateTime BirthDate;
        public string Email;
        public bool Graduate;
        private SqlConnection con;
        private static string TableName = "Students";

        public Student(int id,string name,string surname,DateTime birthdate,string email,bool graduate){
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthdate;
            Email = email;
            Graduate = graduate;

            connectToDB();
            
        }

        public Student(int id)
        {
            Id = id;
            connectToDB();
        }

        public void connectToDB()
        {
            string conString = "server=DESKTOP-EHOD9B9\\SQLEXPRESS;database=LabCrud;UID=sa;password=Lenovo";
            SqlConnection con = new SqlConnection(conString);
            this.con = con;
        }
        public void Insert()
        {
            string query = "INSERT INTO "+ TableName + "(id,name,surname,birthDate,email,graduate) VALUES (@id,@name,@surname,@birthDate,@email,@graduate)";
            using (this.con)
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@surname", Surname);
                    command.Parameters.AddWithValue("@birthDate", BirthDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@email", Email);
                    command.Parameters.AddWithValue("@graduate", Graduate.ToString());

                    try {

                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("data is saved");
                    }
                    catch(Exception e) {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            
        }

        public void Delete()
        {
         
            string query = "DELETE FROM " + TableName + " WHERE id=@id";
            using (this.con)
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    try
                    {
                       
                        this.con.Open();
                       command.ExecuteNonQuery();
                        MessageBox.Show("data is deleted");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        public static DataTable GetAll()
        {
            string conString = "server=DESKTOP-EHOD9B9\\SQLEXPRESS;database=LabCrud;UID=sa;password=Lenovo";
            SqlConnection con = new SqlConnection(conString);
            DataTable dt = new DataTable();

            string query = "SELECT * FROM " + TableName;
            using (con)
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                   
                    try
                    {
                        con.Open();
                        dt.Load(command.ExecuteReader());

                        return dt;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);

                        return null;
                    }
                }
            }


        }

        public void Update()
        {
            string query = "UPDATE " + TableName + " SET name=@name,surname=@surname,birthDate=@birthDate,email=@email,graduate=@graduate WHERE id=@id";
            using (this.con)
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@surname", Surname);
                    command.Parameters.AddWithValue("@birthDate", BirthDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@email", Email);
                    command.Parameters.AddWithValue("@graduate", Graduate.ToString());

                    try
                    {

                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("data is updated");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

        }


    }
}
