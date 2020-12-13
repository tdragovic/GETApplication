using GETApplication.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace GETApplication.Models
{
    public class ExamService
    {
        public string connectionString = "Data Source=DESKTOP-CUA3KF9\\SQLEXPRESS;Initial Catalog=getdb;Persist Security Info= False;User ID=tamara;password=123;";
    
       public List<ExamExt> AllExams()
        {
            List<ExamExt> examsList = new List<ExamExt>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllExamsSorted", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ExamExt exam = new ExamExt();

                    exam.IspitId = Convert.ToInt32(dr["IspitId"].ToString().Trim());
                    exam.BrojIndeksa = dr["BrojIndeksa"].ToString().Trim();
                    exam.PredmetId = Convert.ToInt32(dr["PredmetId"].ToString().Trim());
                    exam.Ocena = Convert.ToInt32(dr["Ocena"].ToString());
                    exam.DatumPolaganja = Convert.ToDateTime(dr["DatumPolaganja"]);
                    exam.DatumKreiranja = Convert.ToDateTime(dr["DatumKreiranja"]);
                    exam.DatumPoslednjeIzmene = Convert.ToDateTime(dr["DatumPoslednjeIzmene"]);
                    exam.NazivPredmeta = dr["Naziv"].ToString().Trim();
                    exam.Student = dr["Ime"].ToString().Trim() + dr["Prezime"].ToString().Trim();
                   
                    examsList.Add(exam);
                }

                con.Close();
            }
            return examsList;
        }

        public Exam GetExamById(int? examId)
        {
            Exam exam = new Exam();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetExamById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IspitId", examId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    exam.IspitId = Convert.ToInt32(dr["IspitId"].ToString().Trim());
                    exam.BrojIndeksa = dr["BrojIndeksa"].ToString().Trim();
                    exam.PredmetId = Convert.ToInt32(dr["PredmetId"].ToString().Trim());
                    exam.Ocena = Convert.ToInt32(dr["Ocena"].ToString().Trim());
                    exam.DatumPolaganja = Convert.ToDateTime(dr["DatumPolaganja"]);
                    exam.DatumKreiranja = Convert.ToDateTime(dr["DatumKreiranja"]);
                    exam.DatumPoslednjeIzmene = Convert.ToDateTime(dr["DatumPoslednjeIzmene"]);
                }
                con.Close();
            }
            return exam;
        }

        public void CreateExam(Exam exam)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateExam", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BrojIndeksa", exam.BrojIndeksa);
                cmd.Parameters.AddWithValue("@PredmetId", exam.PredmetId);
                cmd.Parameters.AddWithValue("@Ocena", exam.Ocena);
                cmd.Parameters.AddWithValue("@DatumPolaganja", exam.DatumPolaganja);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void EditExam(Exam exam)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EditExam", con);
                
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IspitId", exam.IspitId);
                cmd.Parameters.AddWithValue("@BrojIndeksa", exam.BrojIndeksa);
                cmd.Parameters.AddWithValue("@PredmetId", exam.PredmetId);
                cmd.Parameters.AddWithValue("@Ocena", exam.Ocena);
                cmd.Parameters.AddWithValue("@DatumPolaganja", exam.DatumPolaganja);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteExam(int? examId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteExam", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IspitId", examId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

    }
    }
