using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GETApplication.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string BrojIndeksa { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Grad { get; set; }

    }
}
