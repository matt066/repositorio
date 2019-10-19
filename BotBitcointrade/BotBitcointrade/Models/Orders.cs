using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotBitcointrade.Models
{
    public class OrdersList
    {

        public List<Orders> data { get; set; }
    }

    public class Orders
    {
        public double unit_price { get; set; }
        public String code { get; set; }
        public String stop_limit_price { get; set; }
        public float amount { get; set; }
    }
}
