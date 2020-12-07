using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace GETApplication.Models
{
    public class Exam
    {
        
        public int IspitId { get; set; }

        
        public string BrojIndeksa { get; set; }

        
        public int PredmetId { get; set; }

        [Required]
        public int Ocena { get; set; }

        public DateTime? DatumPolaganja { get; set; }

        public DateTime? DatumKreiranja { get; set;  }

        public DateTime? DatumPoslednjeIzmene { get; set; }

    }
}
