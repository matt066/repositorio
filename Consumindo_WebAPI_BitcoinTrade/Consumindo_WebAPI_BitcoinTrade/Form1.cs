using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Consumindo_WebAPI_BitcoinTrade
{


    private void Form1_Load(object sender, EventArgs e)
    {
        InitializeComponent();
    }


    string URI = "";

    private async void GetAllTickers()
    {
        URI = txtURI.Text;
        using (var client = new HttpClient())
        {
            using (var response = await client.GetAsync(URI))
            {
                if (response.IsSuccessStatusCode)
                {
                    var TickerJsonString = await response.Content.ReadAsStringAsync();
                    dataGridView1.DataSource = JsonConvert.DeserializeObject<Ticker[]>(TickerJsonString).ToList();
                }
                else
                {
                    MessageBox.Show("Não foi possível obter o ticker : " + response.StatusCode);
                }
            }
        }

    }

    private void btnGet_Click(object sender, EventArgs e)
    {
        GetAllTickers();
    }
}
}
