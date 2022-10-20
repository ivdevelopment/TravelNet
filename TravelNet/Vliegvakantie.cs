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
            var timespan = Terugkeerdatum - Vertrekdatum;
            int aantalDagen = timespan.Days;
            var totaalactiviteiten = Activiteiten.Select(activiteit => activiteit.BerekenPrijs()).Sum();

            return (Vliegticketprijs + totaalactiviteiten) * aantalDagen;
        }
        public override void ToonGegevens()
        {
            Console.WriteLine($"Boekingsnr: {BoekingsNr}   Bestemming: {Bestemming}");
            Console.WriteLine($" Vertrekdatum: {Vertrekdatum.Date.ToShortDateString()}    Terugkeerdatum: {Terugkeerdatum.Date.ToShortDateString()}");
            Console.WriteLine(" Routes:");
            Console.WriteLine(Route.ToString());
            Console.WriteLine($" Totale verblijfsprijs: {BerekenVakantieprijs()} euro");
            Console.WriteLine($" Huurprijs: {Vliegticketprijs} euro");
            Console.WriteLine(" Activiteiten:");
            Activiteiten.ForEach(activiteit => Console.WriteLine($"    {activiteit}"));
            decimal totaalBedragActiviteiten = Activiteiten.Select(activiteit => activiteit.BerekenPrijs()).Sum();
            Console.WriteLine($" Totaal bedrag activiteiten: {totaalBedragActiviteiten} euro");
            Console.WriteLine($"Totale vakantieprijs: {BerekenVakantieprijs() + totaalBedragActiviteiten} euro");
        }
    }
}
