using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Utility
{
    public class ServisPlacanje
    {
        public bool PlacanjeServis(CreditCard obj)
        {

            for (int i = 0; i < StaticData.creditCards.Count; i++)
            {
                if (StaticData.creditCards[i].CardOwnerName == obj.CardOwnerName &&
                    StaticData.creditCards[i].CardNumber == obj.CardNumber &&
                    StaticData.creditCards[i].ExpirationDate == obj.ExpirationDate &&
                    StaticData.creditCards[i].SecurityCode == obj.SecurityCode)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
