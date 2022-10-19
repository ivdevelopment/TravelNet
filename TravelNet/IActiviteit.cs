using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    internal interface IActiviteit
    {
        public string Naam { get; }
        public decimal BerekenPrijs();
    }
}
