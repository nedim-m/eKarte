using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
    public class Spol
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
    }
}
