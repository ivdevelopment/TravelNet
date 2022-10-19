using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    internal abstract class VerblijfsType
    {
        public VerblijfsType(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle)
        {
            NaamVerblijf = naamVerblijf;
            BasisprijsPerDag = basisPrijsPerDag;
            ToeslagSingle = toeslagSingle;
        }
        public string NaamVerblijf { get; set; }
        public decimal BasisprijsPerDag { get; set; }
        private bool toeslagSingleValue;
        public bool ToeslagSingle
        {
            get
            {
                return toeslagSingleValue;
            }
            set
            {
                if (value == true)
                    BasisprijsPerDag += 5m;
                toeslagSingleValue = value;
            }
        }
        public abstract List<Formule> BeschikbareVerblijfsformules { get; }
        public virtual decimal BerekenPrijsPerDag() => BasisprijsPerDag;
    }
}
