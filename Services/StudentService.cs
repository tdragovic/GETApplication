using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GETApplication.Models
{
    public class StudentService
    {
        public string connectionString = "Data Source=DESKTOP-CUA3KF9\\SQLEXPRESS;Initial Catalog=getdb;Persist Security Info= False;User ID=tamara;password=123;";

       
        public IEnumerable<Student> AllStudents()
        {
            List<Student> studentsList = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student student = new Student();
                    student.StudentId = Convert.ToInt32(dr["StudentId"].ToString());
                    student.BrojIndeksa= dr["BrojIndeksa"].ToString();
                    student.Ime = dr["Ime"].ToString();
                    student.Prezime = dr["Prezime"].ToString();
                    student.Grad = dr["Grad"].ToString();

                    studentsList.Add(student);
                }

                con.Close();
            }
            return studentsList;
        }


        public Student GetStudentById(int? studentId)
        {
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                { 
                    student.StudentId = Convert.ToInt32(dr["StudentId"].ToString());
                    student.BrojIndeksa = dr["BrojIndeksa"].ToString();
                    student.Ime = dr["Ime"].ToString();
                    student.Prezime = dr["Prezime"].ToString();
                    student.Grad = dr["Grad"].ToString();
                }
                con.Close();
            }
            return student;
        }

        public void CreateStudent(Student student)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateStudent", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BrojIndeksa", student.BrojIndeksa);
                cmd.Parameters.AddWithValue("@Ime", student.Ime);
                cmd.Parameters.AddWithValue("@Prezime", student.Prezime);
                cmd.Parameters.AddWithValue("@Grad", student.Grad);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void EditStudent(Student student)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EditStudent", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@BrojIndeksa", student.BrojIndeksa);
                cmd.Parameters.AddWithValue("@Ime", student.Ime);
                cmd.Parameters.AddWithValue("@Prezime", student.Prezime);
                cmd.Parameters.AddWithValue("@Grad", student.Grad);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteStudent(int? studentId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteStudent", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentId", studentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
