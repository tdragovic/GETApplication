using GETApplication.Data;
using GETApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETApplication.Controllers
{
   
    public class SubjectController : Controller
    {
        SubjectServices subjectService = new SubjectServices();

       
        // GET: /Subject/Index
        [Route("Subject/Index")]
        public IActionResult Index()
        {
            //List<Subject> subjectsList = new List<Subject>();
            //subjectsList = subjectService.GetAllSubjects().ToList();
            return View();
        }

        // GET: /Subject/Delete/5
        [Route("Subject/Delete/{subjectId}")]
        public IActionResult Delete(int? subjectId) 
        {
            if (subjectId == null) {
                return NotFound();
            }

            Subject subject  = subjectService.GetSubjectById(subjectId);
            
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: /Subject/Delete/5
        [Route("Subject/Delete/{subjectId}")]
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubject(int? subjectId) {
            subjectService.DeleteSubject(subjectId);
            return RedirectToAction("Index");
        }

        //GET: /Subject/Edit/5
        [Route("Subject/Edit/{subjectId}")]
        [HttpGet]
        public IActionResult Edit(int? subjectId)
        {
            if (subjectId == null)
            {
                return NotFound();
            }

            Subject subject = subjectService.GetSubjectById(subjectId);

            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        //POST: /Subject/Edit/5
        [Route("Subject/Edit/{subjectId}")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? subjectId, [Bind] Subject subjectObject)
        {
            if (subjectId == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid) {
                subjectService.EditSubject(subjectObject);
                return RedirectToAction("Index");
            }
            
            return View(subjectService);
        }

        //GET: /Subject/Create
        [Route("Subject/Create")]
        [HttpGet]
        public IActionResult Create() {
            return View();
        }


        //POST: /Subject/Create
        [Route("Subject/Create")]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Subject subject)
        {
            if (ModelState.IsValid) {
                subjectService.CreateSubject(subject);
                return RedirectToAction("Index");
            }
            return View(subject);
        }


        //GET: /Subject/4
        [Route("Subject/{subjectId}")]
        [HttpGet]
        public IActionResult SubjectById(int? subjectId)
        {
            if (subjectId == null)
            {
                return NotFound();
            }

            Subject subject = subjectService.GetSubjectById(subjectId);

            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }



        // POST: /Subject/AjaxMethod
        [Route("Subject/AjaxMethod")]
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            List<Subject> data = new List<Subject>();

            data = subjectService.GetAllSubjects().ToList();
 

            return Json(data);
        }

    }
}
