using GETApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETApplication.Controllers
{
    public class ExamController : Controller
    {
        ExamService examService = new ExamService();

        // GET: /Exam/
        // GET: /Exam/Index
        [Route("Exam/{Index?}")]
        public IActionResult Index()
        {
            ExamSubjectViewModel ESVM = new ExamSubjectViewModel();
            ESVM.Exams = GetExamModel();
            ESVM.Subjects = GetSubjectsModel();
            return View(ESVM);
        }

        public List<Exam> GetExamModel()
        {
            List<Exam> exams = new List<Exam>();
            exams = examService.AllExams().ToList();
            return exams;
        }

        public List<Subject> GetSubjectsModel()
        {
            List<Subject> subjects = new List<Subject>();
            SubjectServices subjectService = new SubjectServices();
            subjects = subjectService.GetAllSubjects().ToList();
            return subjects;
        }

        public List<Student> GetStudentsModel()
        {
            List<Student> students = new List<Student>();
            StudentService studentService = new StudentService();
            students = studentService.AllStudents().ToList();
            return students;
        }

        //GET: /Exam/Create
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

        //POST: /Exam/Create
        [Route("Exam/Create")]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Exam exam)
        {
            if (ModelState.IsValid)
            {
                examService.CreateExam(exam);
                return RedirectToAction("Index");
            }
            return View(exam);
        }

        //GET: /Exam/Edit/5
        [Route("Exam/Edit/{examId}")]
        [HttpGet]
        public IActionResult Edit(int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            Exam exam = examService.GetExamById(examId);

            if (exam == null)
            {
                return NotFound();
            }

            ExamSubjectsStudentsViewModel ESSVM = new ExamSubjectsStudentsViewModel();
            ESSVM.Exam = exam;
            ESSVM.Subjects = GetSubjectsModel();
            ESSVM.Students = GetStudentsModel();
            return View(ESSVM);
        }

        //POST: /Exam/Edit/5
        [Route("Exam/Edit/{examId}")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? examId, [Bind] Exam examObject)
        {
            
            


            if (examId == null)
            {
                return NotFound();
            }
            System.Diagnostics.Debug.Write("Model state " + ModelState.IsValid);

            System.Diagnostics.Debug.Write("Model state ID " + examObject.IspitId);

            System.Diagnostics.Debug.Write("Model state BRI " + examObject.BrojIndeksa);
            System.Diagnostics.Debug.Write("Model state PID " + examObject.PredmetId);
            System.Diagnostics.Debug.Write("Model state O " + examObject.Ocena);

            System.Diagnostics.Debug.Write("Model state DP " + examObject.DatumPolaganja);
            System.Diagnostics.Debug.Write("Model state K " + examObject.DatumKreiranja);

            if (ModelState.IsValid)
            {
                examService.EditExam(examObject);
                return RedirectToAction("Index");
            }

            

            ExamSubjectsStudentsViewModel ESSVM = new ExamSubjectsStudentsViewModel();
            ESSVM.Exam = examObject;
            ESSVM.Subjects = GetSubjectsModel();
            ESSVM.Students = GetStudentsModel();

            return View(ESSVM);
        }

        // GET: /Exam/Delete/5
        [Route("Exam/Delete/{examId}")]
        public IActionResult Delete(int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            Exam exam = examService.GetExamById(examId);

            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        // POST: /Exam/Delete/5
        [Route("Exam/Delete/{examId}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int? examId)
        {
            examService.DeleteExam(examId);

            return RedirectToAction("Index");
        }

        // POST: /Exam/AjaxMethod
        [Route("Exam/AjaxMethod")]
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            List<Exam> exams = new List<Exam>();
            

            exams = examService.AllExams().ToList();
            List<Subject> subjects = GetSubjectsModel();

            List<Object> data = new List<object>();

            exams.ForEach(exam => {
                subjects.ForEach(subject => {
                    if (exam.PredmetId==subject.PredmetId) {
                        var objectExamWithName = new { examObject = exam, subjectName = subject.Naziv };
                        data.Add(objectExamWithName);
                    }
                });
                
            });

            return Json(data);
        }

    }
}
