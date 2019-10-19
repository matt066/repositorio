using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumindo_WebAPI_BitcoinTrade
{
    public class Ticker
    {
        public double buy { get; set; }
        public double high { get; set; }
        public double last { get; set; }
        public double low { get; set; }
        public double sell { get; set; }
        public int trades_quantity { get; set; }
        public long volume { get; set; }
        public DateTime date { get; set; }

    }
}
