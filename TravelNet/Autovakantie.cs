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
            var prijsRoutes = Routes.Select(route => route.BerekenVerblijfsPrijsPerDag()).Sum();
            prijsRoutes += Huurprijs;
            return prijsRoutes;
        }
        
        public override void ToonGegevens()
        {
            Console.WriteLine($"Boekingsnr: {BoekingsNr}   Bestemming: {Bestemming}");
            Console.WriteLine($" Vertrekdatum: {Vertrekdatum.Date.ToShortDateString()}    Terugkeerdatum: {Terugkeerdatum.Date.ToShortDateString()}");
            Console.WriteLine(" Routes:"); 
            Routes.ForEach(route => Console.WriteLine(route.ToString()));
            Console.WriteLine($" Totale verblijfsprijs: {BerekenVakantieprijs()} euro");
            Console.WriteLine($" Huurprijs: {Huurprijs} euro");
            ToonActiviteiten();
            Console.WriteLine($"Totale vakantieprijs: {BerekenVakantieprijs()} euro");
        }
    }
}
