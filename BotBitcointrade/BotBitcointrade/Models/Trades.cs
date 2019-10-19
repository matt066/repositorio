using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotBitcointrade.Models
{
    class Trades
    {
        public String type { get; set; }
        public float amount { get; set; }
        public float unit_price { get; set; }
        public String active_order_code { get; set; }
        public String passive_order_code { get; set; }
        public DateTime date { get; set; }
    }
}

