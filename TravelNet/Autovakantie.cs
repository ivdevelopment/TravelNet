using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    internal class Autovakantie : Vakantie
    {
        public Autovakantie(int boekingsNr, Bestemming bestemming, DateTime vertrekdatum, DateTime terugkeerDatum, List<IActiviteit> activiteitenList, List<Route> routes, WagenType wagenType, decimal huurprijs) : base(boekingsNr, bestemming, vertrekdatum, terugkeerDatum, activiteitenList)
        {
            Routes = routes;
            WagenType = wagenType;
            Huurprijs = huurprijs;
        }
        public List<Route> Routes { get; set; }
        public override string Naam => "Autovakantie";
        public WagenType WagenType { get; set; }
        private decimal huurpijsValue;
        public decimal Huurprijs
        {
            get { return huurpijsValue; }
            set
            {
                if (WagenType == WagenType.Eigenwagen)
                    huurpijsValue = 0m;
                else 
                    huurpijsValue = value;
            }
        }
        public override decimal BerekenVakantieprijs()
        {
            decimal totalePrijs = 0m;
            foreach (var route in Routes)
            {
                totalePrijs += route.BerekenVerblijfsPrijsPerDag();
            }
            totalePrijs += Huurprijs;
            return totalePrijs;
        }
        
        public override void ToonGegevens()
        {
            Console.WriteLine("Autovakanties");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine($"Boekingsnr: {BoekingsNr}   Bestemming: {Bestemming}");
            Console.WriteLine($" Vertrekdatum: {Vertrekdatum.Date.ToShortDateString()}    Terugkeerdatum: {Terugkeerdatum.Date.ToShortDateString()}");
            Console.WriteLine(" Routes:");
            decimal totaalBedragRoutes = 0;
            foreach (var route in Routes)
            {
                Console.WriteLine(route.ToString());
                totaalBedragRoutes += route.BerekenVerblijfsPrijsPerDag();
            }
            Console.WriteLine($" Totale verblijfsprijs: {BerekenVakantieprijs()} euro");
            Console.WriteLine($" Huurprijs: {Huurprijs} euro");
            ToonActiviteiten();
            Console.WriteLine($"Totale vakantieprijs: {BerekenVakantieprijs()} euro");
        }
    }
}
