using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using BotBitcointrade.Models;


namespace BotBitcointrade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string URI = "";
        int page = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            EscondeComponentesTrades();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                GetAllTicker();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                GetAllOrders();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                GetAllTrades(page);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                GetBalance();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page == 1) { page = 1; } else { page--; }
            GetAllTrades(page);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetAllTrades(page++);
        }

        private async void GetAllTicker()
        {
            URI = textBox1.Text;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var TickerJsonString = await response.Content.ReadAsStringAsync();
                        String TickerSerializado = TickerJsonString.ToString();
                        TickerSerializado = TickerSerializado.Remove(0, 35);
                        TickerSerializado = TickerSerializado.Replace("}}", "}]");
                        TickerSerializado = TickerSerializado.Replace("{", "[{");
                        dataGridView1.DataSource = JsonConvert.DeserializeObject<Ticker[]>(TickerSerializado).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o Ticker : " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetAllOrders()
        {
            URI = textBox1.Text;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var OrdersJsonString = await response.Content.ReadAsStringAsync();
                        String OrdersSerializado = OrdersJsonString.ToString();

                        OrdersSerializado = OrdersSerializado.Remove(0, 43);
                        OrdersSerializado = OrdersSerializado.Replace("}}", "");
                        OrdersSerializado = OrdersSerializado.Replace("\"asks\":[", "");
                        OrdersSerializado = OrdersSerializado.Replace("}]", "}");
                        OrdersSerializado += "]";
                        dataGridView1.DataSource = JsonConvert.DeserializeObject<Orders[]>(OrdersSerializado).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter as Ordens : " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetAllTrades(int page)
        {
            URI = textBox1.Text;
            using (var client = new HttpClient())
            {

                //yourDateTime.ToUniversalTime()
                //        .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

                var date1 = dateTimePicker1.Value;
                var date2 = dateTimePicker2.Value;

                //TODO: ARRUMAR AQUI!!! 
                var stringDate1 = date1.ToString("yyyy'-'MM'-'dd'T'00':'00':'00'-'03:00");
                var stringDate2 = date2.ToString("yyyy'-'MM'-'dd'T'23':'59':'59'-'03:00");
                String dataInicio = "start_time=" + stringDate1 + "&";
                String dataTermino = "end_time=" + stringDate2 + "&";
                String pagina = "page_size=" + textBox2.Text + "&";

                URI = URI + dataInicio + dataTermino + pagina + "current_page=" + page.ToString();

                using (var response = await client.GetAsync(URI))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var TradesJsonString = await response.Content.ReadAsStringAsync();
                        String TradesSerializado = TradesJsonString.ToString();

                        int posicao = TradesSerializado.IndexOf(",\"trades\":");
                        TradesSerializado = TradesSerializado.Remove(0, posicao + 10);
                        TradesSerializado = TradesSerializado.Replace("}}", "");
                        TradesSerializado = TradesSerializado.Replace("\"asks\":[", "");
                        TradesSerializado = TradesSerializado.Replace("}}", "");
                        dataGridView1.DataSource = JsonConvert.DeserializeObject<Trades[]>(TradesSerializado).ToList();
                        label5.Text = "Quantidade de Registros: " + dataGridView1.Rows.Count.ToString();
                        label6.Text = "Página: " + page;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter as Negociações : " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetBalance()
        {
            URI = textBox1.Text;
            using (var client = new HttpClient())
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, URI))
                {

                    //Arrumar esta parte, sapara o token
                    string token = "U2FsdGVkX19unZM+UQPqcpAXrekHkSvLye/5deKyu3MOVY89nxVQNosHeQKym1Qv";
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("ApiToken", token);
                    var response = await client.SendAsync(requestMessage);

                    if (response.IsSuccessStatusCode)
                    {
                        var BalanceJsonString = await response.Content.ReadAsStringAsync();

                        String BalanceSerializado = BalanceJsonString.ToString();

                        BalanceSerializado = BalanceSerializado.Remove(0, 35);
                        BalanceSerializado = BalanceSerializado.Replace("[[", "[");
                        BalanceSerializado = BalanceSerializado.Replace("]}", "]");


                        dataGridView1.DataSource = JsonConvert.DeserializeObject<Balance[]>(BalanceSerializado).ToList();
                        label5.Text = "Quantidade de Registros: " + dataGridView1.Rows.Count.ToString();
                        label6.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o Balanço : " + response.StatusCode);
                    }
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                URI = "https://api.bitcointrade.com.br/v2/public/BRLBTC/ticker";
                textBox1.Text = URI;
                EscondeComponentesTrades();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                URI = "https://api.bitcointrade.com.br/v2/public/BRLBTC/orders";
                textBox1.Text = URI;
                EscondeComponentesTrades();
            } else if (comboBox1.SelectedIndex == 2)
            {
                URI = "https://api.bitcointrade.com.br/v2/public/BRLBTC/trades?";
                textBox1.Text = URI;
                MostraComponentesTrades();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                URI = "https://api.bitcointrade.com.br/v2/wallets/balance";
                textBox1.Text = URI;
                EscondeComponentesTrades();
            }

        }

        private void EscondeComponentesTrades()
        {
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            textBox2.Hide();
            button2.Hide();
            button3.Hide();
        }

        private void MostraComponentesTrades()
        {
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            textBox2.Show();
            button2.Show();
            button3.Show();
        }
    }
}