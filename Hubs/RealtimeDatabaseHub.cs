using GETApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;


namespace GETApplication.Hubs
{
    public class RealtimeDatabaseHub : Hub
    {
        public string connectionString = "Data Source=DESKTOP-CUA3KF9\\SQLEXPRESS;Initial Catalog=getdb;Persist Security Info= False;User ID=tamara;password=123;";
       
        [Route("/examhub")]
        [HubMethodName("GetExams")]
        public async Task GetExams()
        {
             List<ExamExt> _lst = new List<ExamExt>();
            
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GetAllExamsSorted", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Notification = null;

                    DataTable dt = new DataTable();
                    SqlDependency dependency = new SqlDependency(cmd);

                    dependency.OnChange += dependency_OnChange;

                    if (connection.State == ConnectionState.Closed) connection.Open();

                    SqlDependency.Start(connectionString);

                    var reader = cmd.ExecuteReader();

                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            _lst.Add(new ExamExt
                            {
                                IspitId = Int32.Parse(dt.Rows[i]["IspitId"].ToString()),
                                PredmetId = Int32.Parse(dt.Rows[i]["PredmetId"].ToString()),
                                BrojIndeksa = dt.Rows[i]["BrojIndeksa"].ToString().Trim(),
                                Ocena = Int32.Parse(dt.Rows[i]["Ocena"].ToString().Trim()),
                                DatumPolaganja = Convert.ToDateTime(dt.Rows[i]["DatumPolaganja"]),
                                DatumKreiranja = Convert.ToDateTime(dt.Rows[i]["DatumKreiranja"]),
                                DatumPoslednjeIzmene = Convert.ToDateTime(dt.Rows[i]["DatumKreiranja"]),
                                NazivPredmeta = dt.Rows[i]["Naziv"].ToString().Trim(),
                                Student = dt.Rows[i]["Ime"].ToString().Trim() + dt.Rows[i]["Prezime"].ToString().Trim(),
                                
                            }); 
                        }
                    }
                }
            }

            
            await Clients.All.SendAsync("ExamsChanged", _lst);
        }

        void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
           if (e.Type == SqlNotificationType.Change)
            {
                RealtimeDatabaseHub _dataHub = new RealtimeDatabaseHub();
                _dataHub.GetExams();
            }
        }
    }
}
