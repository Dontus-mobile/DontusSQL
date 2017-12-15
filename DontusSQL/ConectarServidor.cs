using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DontusSQL
{
    public partial class ConectarServidor : Form
    {
        public ConectarServidor()
        {
            InitializeComponent();
            button2.Enabled = false;
        }



        CommandsSql Conexões = new CommandsSql();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               //Conexões.SqlConnection = Conexões.Conectar(textBox1.Text, textBox3.Text, textBox2.Text);
             //   Conexões.SqlConnection.Open();
                richTextBox1.ForeColor = Color.Green;
                richTextBox1.Text = "Conectado com sucesso";
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (SqlException ex)
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text = ex.Message;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            Conexões.SqlConnection.Close();
            this.Hide();
            Form1 form = new Form1();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void ConectarServidor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();     
            
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();

        }

        private void ConectarServidor_Load(object sender, EventArgs e)
        {

        }
    }
}
