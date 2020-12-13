using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GETApplication.Models
{
    public class Subject
    {
        public int PredmetId { get; set; }

        [Required(ErrorMessage = "Subject name is required.")]
        [StringLength(20, ErrorMessage = "Subject name length must be between {2} and {1}.", MinimumLength = 2)]
        public string Naziv { get; set; }

    }
}
