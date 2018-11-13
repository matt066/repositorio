using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DominioUrl
    {
        public string tickerBTC { get; set; }
        public string tickerETH { get; set; }
        public string orderBTC { get; set; }
        public string orderETH { get; set; }

        public string FuncUrl(string tipoMoeda, string tipoOperacao)
        {
            this.tickerBTC = "https://api.bitcointrade.com.br/v1/public/BTC/ticker";
            this.tickerETH = "https://api.bitcointrade.com.br/v1/public/ETH/ticker";
            this.orderBTC = "https://api.bitcointrade.com.br/v1/public/BTC/orders";
            this.orderETH = "https://api.bitcointrade.com.br/v1/public/ETH/orders";
            string url;

            if (tipoMoeda == "BTC" && tipoOperacao == "Ticker")
            {
                url = tickerBTC;
            }
            else if (tipoMoeda == "ETH" && tipoOperacao == "Ticker")
            {
                url = tickerETH;
            }
            else if (tipoMoeda == "BTC" && tipoOperacao == "Orders")
            {
                url = orderBTC;
            }
            else
            {
                url = orderETH;
            }
            return url;
        }

    }
}
