using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETApplication.Models
{
    public class ExamSubjectsStudentsViewModel
    {
        public Exam Exam { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }

    }
}
