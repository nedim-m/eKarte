using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Utility
{
   public static class StaticData
    {
        public const string ErrorMessage = "Greška prilikom brisanja!";
        public const string SuccessMessage = "Uspješno izbrisano!";

        public const string StatusZauzeto = "Zauzeto";
        public const string StatusSlobodno = "Slobodno";

        public const string SuccessAdd = "Uspješno dodano!";
        public const string ErrorAdd = "Greška prilikom dodavanja!";

        public const string OznakaAvion = "Avion";
        public const string OznakaBus = "Bus";


        public const string Da = "DA";
        public const string Ne = "NE";

        public const string Admin = "Administrator";
        public const string User = "Korisnik";

        public const string Subject = "Karta";
        public const string htmlMessage = "Poštovani, Vaša karta se nalazi u priloženom pdf fajlu.";


        public static List<CreditCard> creditCards = new List<CreditCard>
       {
           new CreditCard("Nedim Misic","5454545454545454","10/25","000"),
           new CreditCard("Test Test","0000000000000000","10/25","000"),
           new CreditCard("Neko Neko","1111111111111111","11/25","111")
       };


    }
}
