using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace DontusSQL
{
    public partial class Form1 : Form
    {
        CommandsSql Conexões = new CommandsSql();
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label4.Text = "";
            richTextBox2.Text = "";
            if (richTextBox1.Text.Trim() != "")
            {
                var select = comboBox1.SelectedItem;
                if (select == null)
                {
                    richTextBox2.Text = Conexões.GerarCommands(richTextBox1.Text);

                }
                else
                {
                    richTextBox2.Text = Conexões.GerarCommands(richTextBox1.Text, select.ToString());
                }
                label4.Text = "QUERY EXECUTADA COM SUCESSO";
            }




        }





        private void Form1_Load(object sender, EventArgs e)
        {


            var databases = Conexões.RetornaTodosBancos();
            foreach (var item in databases)
            {
                comboBox1.Items.Add(item.name);
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string path = @"C:\\Users\\fabricio\\Desktop";

            //if (!File.Exists(path))
            //{                 
            //    // Create a file to write to.
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine(richTextBox2.Text);

            //    }
            //}

            //// Open the file to read from.
            //using (StreamReader sr = File.OpenText(path))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConectarServidor conectarServidor = new ConectarServidor();
            conectarServidor.Show();
            // ConectarServidor conectarServidor = new ConectarServidor();          
            // conectarServidor.ShowDialog();


        }


    }
}
