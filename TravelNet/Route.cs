using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TravelNet.Verblijven;

namespace TravelNet.Vakanties
{
    internal class Route
    {
        public Route(string vertrekpunt, string eindpunt, VerblijfsType gekozenVerblijfstype, Formule gekozenFormule)
        {
            Vertrekpunt = vertrekpunt;
            Eindpunt = eindpunt;
            GekozenVerblijfstype = gekozenVerblijfstype;
            GekozenFormule = gekozenFormule;
        }
        public string Vertrekpunt { get; set; }
        public string Eindpunt { get; set; }
        public VerblijfsType GekozenVerblijfstype { get; set; }
        private Formule gekozenFormuleValue;
        public Formule GekozenFormule
        {
            get
            {
                return gekozenFormuleValue;
            }
            set
            {
                gekozenFormuleValue = value;
            }
        }
        /*private Formule ControleerFormule()
        {
            *//*if (GekozenFormule.ToString().Contains(GekozenVerblijfstype.BeschikbareVerblijfsformules.ToString()))
                throw new Exception($"De formule {GekozenFormule} is niet beschikbaar voor een {GekozenVerblijfstype.NaamVerblijf}, kies één van de beschikbare formules {GekozenVerblijfstype.BeschikbareVerblijfsformules}");*//*
            return GekozenFormule;
        }*/
        public decimal BerekenVerblijfsPrijsPerDag() => GekozenVerblijfstype.BasisprijsPerDag + (int)GekozenFormule;
        public override string ToString() => $"   {Vertrekpunt}      {Eindpunt}     {GekozenFormule}          {GekozenVerblijfstype.NaamVerblijf}           {GekozenVerblijfstype.BasisprijsPerDag}";
    }


}
