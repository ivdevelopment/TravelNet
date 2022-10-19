using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelNet.Verblijven;

namespace TravelNet.Verblijven
{
    internal class Vakantiehuis : VerblijfsType
    {
        public Vakantiehuis(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle, decimal schoonmaakprijsPerDag, decimal linnengoedprijsPerDag) : base(naamVerblijf, basisPrijsPerDag, toeslagSingle)
        {
            SchoonmaakprijsPerDag = schoonmaakprijsPerDag;
            LinnengoedprijsPerDag = linnengoedprijsPerDag;
        }
        public decimal SchoonmaakprijsPerDag { get; set; }
        public decimal LinnengoedprijsPerDag { get; set; }
        private readonly List<Formule> beschikbareVerblijfsformulesLijst = new() { Formule.Ontbijt };
        public override List<Formule> BeschikbareVerblijfsformules => beschikbareVerblijfsformulesLijst;
        public override decimal BerekenPrijsPerDag() => BasisprijsPerDag + SchoonmaakprijsPerDag + LinnengoedprijsPerDag;
    }
}
