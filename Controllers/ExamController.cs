using GETApplication.Hubs;
using GETApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace GETApplication.Controllers
{
    public class ExamController : Controller
    {
        private readonly ILogger<ExamController> _logger;

        public ExamController(ILogger<ExamController> logger)
        {
            _logger = logger;
        }
        
        ExamService examService = new ExamService();
        SubjectServices subjectService = new SubjectServices();
        StudentService studentService = new StudentService();

        [Route("Exam/{Index?}")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Exam/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            ExamSubjectsStudentsViewModel ESSVM = new ExamSubjectsStudentsViewModel();
            ESSVM.Exam = new Exam();
            ESSVM.Subjects = GetSubjectsModel();
            ESSVM.Students = GetStudentsModel();

            return View(ESSVM);
        }

        [Route("Exam/Create")]
        [HttpPost, ActionName("Create")]
        public IActionResult Create([FromBody] Exam exam)
        {
            if (exam==null) return BadRequest();

            try
            {
                _logger.LogInformation("Create new exam in the database.");
                examService.CreateExam(exam);
                _logger.LogInformation($"Exam has been created.");
                return RedirectToAction("Index");

            }
            catch (SqlException ex)
            {
                _logger.LogError($"Something went wrong SQL: {ex}");
                return StatusCode(500, "Internal server error. Element not created.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [Route("Exam/Edit/{examId}")]
        [HttpGet]
        public IActionResult Edit(int? examId)
        {
            if (examId == null) return BadRequest();

           try
            {
                _logger.LogInformation("Fetching exam by Id from the database.");
                Exam exam = examService.GetExamById(examId);
                _logger.LogInformation($"Returning exam by ID {examId}.");

                if (exam == null) return NotFound();

                ExamSubjectsStudentsViewModel ESSVM = new ExamSubjectsStudentsViewModel();
                ESSVM.Exam = exam;
                ESSVM.Subjects = GetSubjectsModel();
                ESSVM.Students = GetStudentsModel();

                return View(ESSVM);
         
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [Route("Exam/Edit")]
        [HttpPost, ActionName("Edit")]
        public IActionResult Edit([FromBody] Exam examObject)
        {
            if (examObject == null) return BadRequest();

            try
            {
                _logger.LogInformation("Edit exam in the database.");
                examService.EditExam(examObject);
                _logger.LogInformation($"Exam by ID {examObject.IspitId} has been updated.");
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        
        [Route("Exam/Delete/{examId}")]
        [HttpGet]
        public IActionResult Delete(int? examId)
        {
            if (examId == null) return BadRequest();

            try
            {
                _logger.LogInformation("Fetching exam by Id from the database.");
                Exam exam = examService.GetExamById(examId);

                if (exam == null) return NotFound();
                _logger.LogInformation($"Returning exam by ID {examId}.");

                return View(exam);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }


        [Route("Exam/Delete/{examId}")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStudent(int? examId)
        {
            if (examId==null) return BadRequest();
            
            try
            {
                _logger.LogInformation("Deleting exam by Id from the database.");
                examService.DeleteExam(examId);
                _logger.LogInformation($"Exam by ID {examId} has been deleted.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [Route("Exam/GetAllExams")]
        [HttpPost]
        public JsonResult GetAllExams()
        {
            try
            {
                List<ExamExt> exams = examService.AllExams();
                return Json(exams);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Json(new { message = "Internal server error." });
            }
        }

        public List<Subject> GetSubjectsModel()
        {
            try {
                List<Subject> subjects = subjectService.GetAllSubjects().ToList();
                return subjects;
            }
            catch (Exception ex) {
                _logger.LogError($"Something went wrong: {ex}");
                return null;
            }
          
        }

        public List<Student> GetStudentsModel()
        {
            try
            {
                List<Student> students = studentService.AllStudents().ToList();
                return students;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return null;
            }
        }
    }
}
 