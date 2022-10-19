using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    internal abstract class Vakantie
    {
        public Vakantie(int boekingsNr, Bestemming bestemming, DateTime vertrekdatum, DateTime terugkeerDatum, List<IActiviteit> activiteiten)
        {
            BoekingsNr = boekingsNr;
            Bestemming = bestemming;
            Vertrekdatum = vertrekdatum;
            Terugkeerdatum = terugkeerDatum;
            Activiteiten = activiteiten;
        }
        public int BoekingsNr { get; }
        public abstract string Naam { get; }
        public Bestemming Bestemming { get; set; }
        public DateTime Vertrekdatum { get; set; }
        private DateTime terugkeerdatumValue;
        public DateTime Terugkeerdatum
        {
            get => terugkeerdatumValue;
            set
            {
                terugkeerdatumValue = value;
                if (Terugkeerdatum.Day < Vertrekdatum.Day)
                {
                    throw new CustomException($"Reis met boekingsnr {BoekingsNr} : terugkeerdatum ({Terugkeerdatum.Date.ToShortDateString()}) moet later zijn dan vertrekdatum ({Vertrekdatum.Date.ToShortDateString()})");
                }
                

            }
        }

        public List<IActiviteit> Activiteiten { get; set; }

        public abstract decimal BerekenVakantieprijs();

        public void ToonActiviteiten()
        {
            Console.WriteLine(" Activiteiten:");
            decimal totaleKostprijs = 0;
            foreach (var activiteit in Activiteiten)
            {
                Console.WriteLine($"    {activiteit.Naam} ({activiteit.BerekenPrijs()} euro)");
                totaleKostprijs += activiteit.BerekenPrijs();
            }
            Console.WriteLine($" Totaal bedrag activiteiten: {totaleKostprijs} euro");
        }
        public abstract void ToonGegevens();
    }

    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {
            Console.WriteLine(msg);
        }
    }
}
