using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    internal class Vliegvakantie : Vakantie
    {
        public Vliegvakantie(int boekingsNr, Bestemming bestemming, DateTime vertrekdatum, DateTime terugkeerDatum, List<IActiviteit> activiteitenList, Route route, decimal vliegticketprijs) : base(boekingsNr, bestemming, vertrekdatum, terugkeerDatum, activiteitenList)
        {
            Route = route;
            Vliegticketprijs = vliegticketprijs;
        }

        public Route Route { get; set; }
        public override string Naam => "Vliegvakantie";
        public decimal Vliegticketprijs { get; set; }
        public override decimal BerekenVakantieprijs()
        {
            decimal totalePrijs = 0;
            var timespan = Terugkeerdatum - Vertrekdatum;
            int aantalDagen = timespan.Days;
            foreach (var activiteit in Activiteiten)
            {
                totalePrijs += activiteit.BerekenPrijs();
            }

            return (Vliegticketprijs + totalePrijs) * aantalDagen;
        }
        public override void ToonGegevens()
        {
            Console.WriteLine("Vliegvakanties");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine($"Boekingsnr: {BoekingsNr}   Bestemming: {Bestemming}");
            Console.WriteLine($" Vertrekdatum: {Vertrekdatum.Date.ToShortDateString()}    Terugkeerdatum: {Terugkeerdatum.Date.ToShortDateString()}");
            Console.WriteLine(" Routes:");
            Console.WriteLine(Route.ToString());
            Console.WriteLine($" Totale verblijfsprijs: {BerekenVakantieprijs()} euro");
            Console.WriteLine($" Huurprijs: {Vliegticketprijs} euro");
            Console.WriteLine(" Activiteiten:");
            decimal totaalBedragActiviteiten = 0;
            foreach (var activiteit in Activiteiten)
            {
                Console.WriteLine($"    {activiteit}");
                totaalBedragActiviteiten += activiteit.BerekenPrijs();
            }
            Console.WriteLine($" Totaal bedrag activiteiten: {totaalBedragActiviteiten} euro");
            Console.WriteLine($"Totale vakantieprijs: {BerekenVakantieprijs() + totaalBedragActiviteiten} euro");
        }
    }
}
