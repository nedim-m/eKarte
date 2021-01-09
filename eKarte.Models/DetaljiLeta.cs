using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
   public class DetaljiLeta
    {
        public int Id { get; set; }

        public int OsobljeId { get; set; }
        public virtual Osoblje Osoblje { get; set; }

        public int LetId { get; set; }
        public virtual Let Let { get; set; }

       

    }
}
