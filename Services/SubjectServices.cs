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
                    predmet.Naziv = dr["Naziv"].ToString();

                    listaPredmeta.Add(predmet);
                }

                con.Close();
            }
            return listaPredmeta;
        }

        public Subject GetSubjectById(int? predmetId)
        {
            Subject predmet = new Subject();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetSubjectById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PredmetId", predmetId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    predmet.PredmetId = Convert.ToInt32(dr["PredmetId"].ToString());
                    predmet.Naziv = dr["Naziv"].ToString();
                }
                con.Close();
            }
            return predmet;
        }

        public void DeleteSubject(int? subjectId)
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

        public void EditSubject(Subject predmet)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EditSubject", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PredmetId", predmet.PredmetId);
                cmd.Parameters.AddWithValue("@Naziv", predmet.Naziv);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void CreateSubject(Subject predmet)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateSubject", con);

                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@naziv", predmet.Naziv);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }
    }
}
