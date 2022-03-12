using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models
{
   public class CreditCard
    {
        public CreditCard(string v1, string v2, string v3, string v4)
        {
            CardOwnerName = v1;
            CardNumber = v2;
            ExpirationDate = v3;
            SecurityCode = v4;
        }

        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    
    }
}
