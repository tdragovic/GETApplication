using GETApplication.Data;
using GETApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GETApplication.Controllers
{
   
    public class SubjectController : Controller
    {
        public ILogger<SubjectController> _logger;

        public SubjectController(ILogger<SubjectController> logger)
        {
            _logger = logger;
        }

        public SubjectServices subjectService = new SubjectServices();

        [Route("Subject/{Index?}")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("Subject/Delete/{subjectId}")]
        [HttpGet]
        public IActionResult Delete(int? subjectId) 
        {
            if (subjectId == null) return BadRequest();

            try
            {
                _logger.LogInformation("Fetching subject by Id from the database.");
                Subject subject = subjectService.GetSubjectById(subjectId);

                if (subject == null) return NotFound();
                _logger.LogInformation($"Returning subject by ID {subjectId}.");
                
                return View(subject);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

      
        [Route("Subject/Delete/{subjectId}")]
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubject(int? subjectId) {

            if (subjectId == null) return BadRequest();

            try
            {
                _logger.LogInformation("Deleting subject by Id from the database.");
                subjectService.DeleteSubject(subjectId);
                 _logger.LogInformation($"Subject by ID {subjectId} has been deleted.");
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        
        [Route("Subject/Edit/{subjectId}")]
        [HttpGet]
        public IActionResult Edit(int? subjectId)
        {
            if (subjectId == null) return BadRequest();
             
            try
            {
                _logger.LogInformation("Fetching subject by Id from the database.");
                Subject subject = subjectService.GetSubjectById(subjectId);
                _logger.LogInformation($"Returning subject by ID {subjectId}.");

                if (subject == null) return NotFound();

                return View(subject);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

       
        [Route("Subject/Edit/{subjectId}")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? subjectId, [Bind] Subject subjectObject)
        {
            if (subjectId == null) return NotFound();
            
            if (ModelState.IsValid) {
                try
                {
                    _logger.LogInformation("Edit subject in the database.");
                    subjectService.EditSubject(subjectObject);
                    _logger.LogInformation($"Subject by ID {subjectId} has been updated.");

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong: {ex}");
                    return StatusCode(500, "Internal server error.");
                }
            }
            
            return View(subjectObject);
        }

       
        [Route("Subject/Create")]
        [HttpGet]
        public IActionResult Create() {
            return View();
        }


        [Route("Subject/Create")]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Subject subject)
        {
            if (subject == null) return BadRequest();

            if (ModelState.IsValid) {
                try
                {
                    _logger.LogInformation("Create new subject in the database.");
                    subjectService.CreateSubject(subject);
                    _logger.LogInformation($"Subject has been created.");
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

            return View(subject);
        }


        [Route("Subject/{subjectId}")]
        [HttpGet]
        public IActionResult SubjectById(int? subjectId)
        {
            if (subjectId == null) return BadRequest();

            try
            {
                _logger.LogInformation("Fetching subject by Id from the database.");
                Subject subject = subjectService.GetSubjectById(subjectId);

                if (subject == null) return NotFound();
                _logger.LogInformation($"Returning subject by ID {subjectId}.");

                return Ok(subject);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error.");
            }
            
        }


        [Route("Subject/AjaxMethod")]
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            List<Subject> data = new List<Subject>();
            try {
                data = subjectService.GetAllSubjects().ToList();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return Json(new { message = "Internal server error."});
            }

        }

    }
}
