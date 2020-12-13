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

        [Required(ErrorMessage = "Index number is required.")]
        [StringLength(10, ErrorMessage = "Index number length must be {1}.", MinimumLength = 10)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Index number must be made of digits only.")]
        public string BrojIndeksa { get; set; }

        [Required(ErrorMessage = "Student first name is required.")]
        [StringLength(20, ErrorMessage = "Student first name length must be between {2} and {1}.", MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Student last name is required.")]
        [StringLength(20, ErrorMessage = "Student last name length must be between {2} and {1}.", MinimumLength = 2)]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [StringLength(20, ErrorMessage = "City name length must be between {2} and {1}.", MinimumLength = 2)]
        public string Grad { get; set; }

    }
}
