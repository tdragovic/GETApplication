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

        [Required]
        public string Naziv { get; set; }

    }
}
