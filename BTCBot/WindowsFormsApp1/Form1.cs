using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectionStart = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string op = "Ticker";
            //Chama método que identifica a moeda e devolve com a requisição Web do serviço, 
            //de acordo com o tipo de operação (Ticker, Orders, Etc)
            WebRequest t = IdentificaMoeda(op);
           
            //Traz as informações do Ticker de acordo com a moeda solecinada e popula o textbox
            Ticker ticker = new Ticker();
            var auxTicker = ticker.TrataTicker(((System.Net.HttpWebRequest)t)); // Converte a variavel t de WebRequest para HttpWebResquest
            textBox1.Text = auxTicker.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string op = "Orders";
            //Chama método que identifica a moeda e devolve com a requisição Web do serviço, 
            //de acordo com o tipo de operação (Ticker, Orders, Etc)
            WebRequest t = IdentificaMoeda(op);

            //Traz as informações do Ticker de acordo com a moeda solecinada e popula o textbox
            Orders order = new Orders();
            var auxOrder = order.TrataOrders(((System.Net.HttpWebRequest)t)); // Converte a variavel t de WebRequest para HttpWebResquest
            textBox2.Text = auxOrder.ToString();
        }

        public WebRequest IdentificaMoeda(string operacao)
        {
            string moeda = comboBox1.SelectedItem.ToString();
            ValidaURL url = new ValidaURL();

            //Solicita a URL de acordo com a moeda selecionada
            var requisicaoWeb = WebRequest.CreateHttp(url.pegaUrl(moeda,operacao));
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "Acessando Json";

            return requisicaoWeb;
        }
    }
}