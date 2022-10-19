using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    internal class Cinema : IActiviteit
    {
        /*public Cinema(string naam, decimal inkom, decimal snoepgoed)
        {
            Naam = naam;
            Inkom = inkom;
            Snoepgoed = snoepgoed;
        }*/

        public decimal Inkom { get; set; }
        public decimal Snoepgoed { get; set; }
        public string Naam { get; set; }

        public decimal BerekenPrijs() => Inkom + Snoepgoed;
        public override string ToString() => $"{Naam} ({BerekenPrijs()} euro)";
    }
}
