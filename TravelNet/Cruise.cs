using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    internal class Cruise : Vakantie
    {
        public Cruise(int boekingsNr, Bestemming bestemming, DateTime vertrekdatum, DateTime terugkeerDatum, List<IActiviteit> activiteitenList, string vertrekpunt, string eindpunt, List<string> aanlegplaatsen, decimal allInPrijs) : base(boekingsNr, bestemming, vertrekdatum, terugkeerDatum, activiteitenList)
        {
            Vertrekpunt = vertrekpunt;
            Eindpunt = eindpunt;
            Aanlegplaatsen = aanlegplaatsen;
            AllInPrijs = allInPrijs;
        }
        public override string Naam => "Cruisevakantie";
        public string Vertrekpunt { get; set; }
        public string Eindpunt { get; set; }
        public List<string> Aanlegplaatsen { get; set; }
        public decimal AllInPrijs { get; set; }

        public override decimal BerekenVakantieprijs() => AllInPrijs;

        public override void ToonGegevens()
        {
            Console.WriteLine("Cruisevakanties");
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine($"Boekingsnr: {BoekingsNr}   Bestemming: {Bestemming}");
            Console.WriteLine($" Vertrekdatum: {Vertrekdatum.Date.ToShortDateString()}    Terugkeerdatum: {Terugkeerdatum.Date.ToShortDateString()}");
            Console.WriteLine(" Routes:");
            Console.WriteLine($"  {Vertrekpunt}     {Eindpunt}");
            foreach (var aanlegplaats in Aanlegplaatsen)
            {
                Console.WriteLine(aanlegplaats);
            }
            Console.WriteLine($" Totale verblijfsprijs: {BerekenVakantieprijs()} euro");
/*            Console.WriteLine($" Huurprijs: {Vliegticketprijs}");
*/            Console.WriteLine(" activiteiten:");
            decimal totaalBedragActiviteiten = 0;
            foreach (var activiteit in Activiteiten)
            {
                activiteit.ToString();
                totaalBedragActiviteiten += activiteit.BerekenPrijs();
            }
            Console.WriteLine($" Totaal bedrag activiteiten: {totaalBedragActiviteiten} euro");
            Console.WriteLine($"Totale vakantieprijs: {BerekenVakantieprijs() + totaalBedragActiviteiten} euro");
        }
    }
}
