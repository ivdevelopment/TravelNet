using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    internal class Appartement : VerblijfsType
    {
        public Appartement(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle, decimal schoonmaakprijsPerDag, bool lift) : base(naamVerblijf, basisPrijsPerDag, toeslagSingle)
        {
            SchoonmaakprijsPerDag = schoonmaakprijsPerDag;
            Lift = lift;
        }

        public decimal SchoonmaakprijsPerDag { get; set; }
        public bool Lift { get; set; }
        private readonly List<Formule> beschikbareVerblijfsformulesLijst = new() { Formule.Ontbijt, Formule.HalfPension };
        public override List<Formule> BeschikbareVerblijfsformules => beschikbareVerblijfsformulesLijst;
        public override decimal BerekenPrijsPerDag() => BasisprijsPerDag + SchoonmaakprijsPerDag;
    }
}
