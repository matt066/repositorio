using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotBitcointrade.Models
{
    public class BalanceList
    {
        public List<Balance> lista { get; set; }
    }

    public class Balance
    {
        public int available_amount { get; set; }
        public string currency_code { get; set; }
        public int locked_amount { get; set; }
    }
}
