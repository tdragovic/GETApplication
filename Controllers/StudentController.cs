using Microsoft.AspNetCore.Mvc;
using GETApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETApplication.Controllers
{
    public class StudentController : Controller
    {
        StudentService service = new StudentService();

        // GET: /Student/
        // GET: /Student/Index
        [Route("Student/{Index?}")]
        public IActionResult Index()
        {
            //List<Student> students = new List<Student>();
            //students = service.AllStudents().ToList();
            return View();
        }

        //GET: /Student/Create
        [Route("Student/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //POST: /Student/Create
        [Route("Student/Create")]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Student student)
        {
            if (ModelState.IsValid)
            {
                service.CreateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //GET: /Student/Edit/5
        [Route("Student/Edit/{studentId}")]
        [HttpGet]
        public IActionResult Edit(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            Student student = service.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        //POST: /Student/Edit/5
        [Route("Student/Edit/{studentId}")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? studentId, [Bind] Student studentObject)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                service.EditStudent(studentObject);
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: /Student/Delete/5
        [Route("Student/Delete/{studentId}")]
        public IActionResult Delete(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            Student student = service.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [Route("Student/Delete/{studentId}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int? studentId)
        {
            service.DeleteStudent(studentId);
            return RedirectToAction("Index");
        }

        //GET: /Student/4
        [Route("Student/{studentId}")]
        [HttpGet]
        public IActionResult StudentById(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            Student student = service.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/AjaxMethod
        [Route("Student/AjaxMethod")]
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            List<Student> data = new List<Student>();

            data = service.AllStudents().ToList();


            return Json(data);
        }
    }
}
