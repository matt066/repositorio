using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using RestSharp;

namespace WindowsFormsApp1
{
    public class Ticker
    {
        public double high { get; set; }
        public double low { get; set; }
        public int trades_quantity { get; set; }
        public double last { get; set; }
        public double buy { get; set; }
        public double sell { get; set; }
        public double volume { get; set; }
        public DateTime date { get; set; }

        public String TrataTicker(HttpWebRequest req)
        {
            using (var resposta = req.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                //Trata os parametros de retorno de sucesso ou falha para gerar o JSON corretamete
                string aux = objResponse.ToString();
                aux = aux.Remove(1, 23);
                aux = aux.Replace("}}", "}");

                
                Ticker post = JsonConvert.DeserializeObject<Ticker>(aux);
                string result; 
                result = "High: " + post.high.ToString();
                result = result + Environment.NewLine + "Low: " + post.low.ToString();
                result = result + Environment.NewLine + "TradesQTD: " + post.trades_quantity.ToString();
                result = result + Environment.NewLine + "Last: " + post.last.ToString();
                result = result + Environment.NewLine + "Buy: " + post.buy.ToString();
                result = result + Environment.NewLine + "Sell: " + post.sell.ToString();
                result = result + Environment.NewLine + "Volume: " + post.volume.ToString();
                result = result + Environment.NewLine + "Date: " + post.date.ToString();
                streamDados.Close();
                resposta.Close();

                return result;
            }
        }

    }

    
}
