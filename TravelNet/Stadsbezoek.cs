using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelNet.Vakanties;

namespace TravelNet.Vakanties
{
    internal class Stadsbezoek : IActiviteit
    {
        public string Naam { get; set; }
        public decimal PrijsGidsPer10Personen { get; set; }
        public int AantalPersonen { get; set; }


        public decimal BerekenPrijs()
        {
            if (AantalPersonen > 10)
                return PrijsGidsPer10Personen * 2;
            return PrijsGidsPer10Personen;
        }
        public override string ToString() => $"{Naam} ({BerekenPrijs()} euro)";
    }
}
