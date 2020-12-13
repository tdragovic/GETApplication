using Microsoft.AspNetCore.Mvc;
using GETApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GETApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        StudentService service = new StudentService();

        [Route("Student/{Index?}")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Student/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Student/Create")]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Student student)
        {
            
            if (student == null) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Create new student in the database.");
                    service.CreateStudent(student);
                    _logger.LogInformation($"Student has been created.");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong: {ex}");
                    return StatusCode(500, "Internal server error.");
                }
            }

            return View(student);
        }

        [Route("Student/Edit/{studentId}")]
        [HttpGet]
        public IActionResult Edit(int? studentId)
        {
            if (studentId == null)return BadRequest();
            
            try {
                _logger.LogInformation("Fetching student by Id from the database.");
                Student student = service.GetStudentById(studentId);

                if (student == null) return NotFound();
                _logger.LogInformation($"Returning student by ID {studentId}.");

                return View(student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        
        [Route("Student/Edit/{studentId}")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? studentId, [Bind] Student studentObject)
        {
            if (studentId == null) return NotFound();
            

            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Edit student in the database.");
                    service.EditStudent(studentObject);
                    _logger.LogInformation($"Student by ID {studentId} has been updated.");

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong: {ex}");
                    return StatusCode(500, "Internal server error.");
                }
            }

            return View(studentObject);
        }

       
        [Route("Student/Delete/{studentId}")]
        [HttpGet]
        public IActionResult Delete(int? studentId)
        {
            if (studentId == null) return NotFound();
            
            try
            {
                _logger.LogInformation("Fetching subject by ID from the database.");
                Student student = service.GetStudentById(studentId);
                if (student == null) return NotFound();
                _logger.LogInformation($"Returning subject by ID {studentId}.");
                return View(student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [Route("Student/Delete/{studentId}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int? studentId)
        {
            if (studentId == null) return BadRequest();

            try
            {
                _logger.LogInformation("Deleting student by Id from the database.");
                service.DeleteStudent(studentId);
                _logger.LogInformation($"Student by ID {studentId} has been deleted.");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

       
        [Route("Student/{studentId}")]
        [HttpGet]
        public IActionResult StudentById(int? studentId)
        {
            if (studentId == null) return StatusCode(404, "Student not found. Internal server error.");
            
            try
            {
                _logger.LogInformation("Fetching studentt by Id from the database.");
                Student student = service.GetStudentById(studentId);
                 _logger.LogInformation($"Returning student by ID {studentId}.");
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [Route("Student/AjaxMethod")]
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            List<Student> data = new List<Student>();

            try {
                data = service.AllStudents().ToList();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Json(new { message = "Internal server error." });
            }
        }
    }
}
