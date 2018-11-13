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
using WebApiContrib.Formatting;


namespace WindowsFormsApp1
{
    public class Orders
    {
        public double unit_price { get; set; }
        public string code { get; set; }
        public double amount { get; set; }

        public String TrataOrders(HttpWebRequest req)
        {
            using (var resposta = req.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                //Trata os parametros de retorno de sucesso ou falha para gerar o JSON corretamete
                string aux = objResponse.ToString();
                aux = aux.Remove(1, 33);
                aux = aux.Replace("]}}", "}");

                               
                Orders post = JsonConvert.DeserializeObject<Orders>(aux);
                string result;
                result = "Preço: " + post.unit_price.ToString();
                result = result + Environment.NewLine + "Código: " + post.code.ToString();
                result = result + Environment.NewLine + "Montante: " + post.amount.ToString();
                streamDados.Close();
                resposta.Close();

                return result;
            }
        }
    }
}
