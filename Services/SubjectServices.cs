using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace GETApplication.Models
{
    public class SubjectServices
    {
        public string connectionString = "Data Source=DESKTOP-CUA3KF9\\SQLEXPRESS;Initial Catalog=getdb;Persist Security Info= False;User ID=tamara;password=123;";

        public IEnumerable<Subject> GetAllSubjects()
        {
            List<Subject> listaPredmeta = new List<Subject>();
            try {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllSubjects", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
               
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Subject predmet = new Subject();
                        predmet.PredmetId = Convert.ToInt32(dr["PredmetId"].ToString());
                        predmet.Naziv = dr["Naziv"].ToString().Trim();

                        listaPredmeta.Add(predmet);
                    }
                    con.Close();
                }

                return listaPredmeta;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
        }
        public Subject GetSubjectById(int? subjectId)
        {
            Subject subject = new Subject();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetSubjectById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PredmetId", subjectId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("Entered");
                        if (dr["PredmetId"].ToString() != "")
                        {
                            subject.PredmetId = Convert.ToInt32(dr["PredmetId"].ToString());
                            subject.Naziv = dr["Naziv"].ToString().Trim();
                        }
                    }
                    con.Close();
                }
               
                if (subject.Naziv == null)
                {
                    throw new Exception("Exception was thrown due to Subject name being null");
                }
                return subject;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err);
                return null;
            }
        }
        public void DeleteSubject(int? subjectId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteSubject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PredmetId", subjectId);
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
        public void EditSubject(Subject subject)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditSubject", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PredmetId", subject.PredmetId);
                    cmd.Parameters.AddWithValue("@Naziv", subject.Naziv);
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
        public void CreateSubject(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@naziv", subject.Naziv);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
