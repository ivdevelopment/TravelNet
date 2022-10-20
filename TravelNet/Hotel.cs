
namespace TravelNet.Verblijven
{
    internal class Hotel : VerblijfsType
    {
        public Hotel(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle, bool internet, decimal? wellnessprijsPerDag = 0) : base(naamVerblijf, basisPrijsPerDag, toeslagSingle)
        {
            WellnessprijsPerDag = wellnessprijsPerDag ?? 0;
            Internet = internet;
        }
        private decimal? wellnessprijsPerDagValue;
        public decimal? WellnessprijsPerDag
        {
            get
            {
                return wellnessprijsPerDagValue;
            }
            set
            {
                wellnessprijsPerDagValue = value;

            }
        }
        public bool Internet { get; set; }
        private readonly List<Formule> beschikbareVerblijfsformulesLijst = new() { Formule.Ontbijt, Formule.HalfPension, Formule.VolPension };
        public override List<Formule> BeschikbareVerblijfsformules => beschikbareVerblijfsformulesLijst;
        public override decimal BerekenPrijsPerDag()
        {
            if (WellnessprijsPerDag != null)
                BasisprijsPerDag += (decimal)WellnessprijsPerDag;
            return BasisprijsPerDag;
        }
    }
}
