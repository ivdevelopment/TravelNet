using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelNet.Vakanties;

namespace TravelNet.Vakanties
{
    internal class MTB : IActiviteit
    {
        public decimal PrijsUitrusting { get; set; }
        public decimal HuurprijsFietsPerUur { get; set; }
        public int AantalUren { get; set; }
        public string Naam { get; set; }

        public decimal BerekenPrijs() => PrijsUitrusting + AantalUren * HuurprijsFietsPerUur;

        public override string ToString() => $"{Naam} ({BerekenPrijs()} euro)";
    }
}
