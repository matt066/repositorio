using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        //Seta false no click do botão 1
        private bool button1WasClicked = false;
        //Seta false no click do botão 2
        private bool button2WasClicked = false;

        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;

            //Metodo para setar o diretório
            ChooseFolder();

            //string[] arquivos = Directory.GetFiles(@"D:\AM219875\Siglas\TV\WEB\primarios\fontes\c#\framework4.5.2", "*", SearchOption.AllDirectories);
            string[] arquivos = Directory.GetFiles(textBox1.Text, "*", SearchOption.AllDirectories);

            // Pegar quantidade de arquivos do diretórios e subdiretórios.
            int qtdReg = arquivos.Count();


            // Sort all items added previously.
            listBox1.Sorted = true;

            // Set the SelectionMode to select multiple items.
            listBox1.SelectionMode = SelectionMode.MultiExtended;

            // Laço para preencher a listbox de acordo com a quantidade de arquivos encontrados
            for (int i = 0; i < qtdReg; i++)
            {
                if (i < qtdReg)
                {
                    listBox1.Items.Add(arquivos[i]);
                }
            }

            for (int i = 0; i < qtdReg; i++)
            {
                // Select three initial items from the list.
                listBox1.SetSelected(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2WasClicked = true;
            ChooseFolder();

            string arq = label2.Text + "\\dir.txt";

            System.IO.StreamWriter sw = new System.IO.StreamWriter(arq);

            foreach (object item in listBox1.Items)

                sw.WriteLine(item.ToString());

            label2.Text = "Documento gerado em " + arq;
            label2.Visible = true;

            sw.Close();

        }

        //Metodo para manipular os diretorios
        public void ChooseFolder()
        {

            if (button1WasClicked == true)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                }
                button1WasClicked = false;
            }

            if (button2WasClicked == true)
            {

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    label2.Text = folderBrowserDialog1.SelectedPath;
                }
                button2WasClicked = false;
            }
        }


    }
}