﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eKarte.Models
{
    public class AvioKarta
    {
        public int Id { get; set; }
        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public int LetId { get; set; }

        public Let Let { get; set; }

        public string KorisnikMail { get; set; }

        public double KonacnaCijena { get; set; }

        [NotMapped]
        public CreditCard CreditCard { get; set; }



    }   
}
