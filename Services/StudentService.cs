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

            try { 
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
                        student.BrojIndeksa= dr["BrojIndeksa"].ToString().Trim();
                        student.Ime = dr["Ime"].ToString().Trim();
                        student.Prezime = dr["Prezime"].ToString().Trim();
                        student.Grad = dr["Grad"].ToString().Trim();

                        studentsList.Add(student);
                    }

                    con.Close();
                }
                return studentsList;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }


        public Student GetStudentById(int? studentId)
        {
            Student student = new Student();

            try { 
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
                        student.BrojIndeksa = dr["BrojIndeksa"].ToString().Trim();
                        student.Ime = dr["Ime"].ToString().Trim();
                        student.Prezime = dr["Prezime"].ToString().Trim();
                        student.Grad = dr["Grad"].ToString().Trim();
                    }
                    con.Close();
                }
                return student;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }

        public void CreateStudent(Student student)
        {
            try { 
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
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public void EditStudent(Student student)
        {
            try { 
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
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                
            }
        }

        public void DeleteStudent(int? studentId)
        {
            try { 
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
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                
            }
        }
    }
}
