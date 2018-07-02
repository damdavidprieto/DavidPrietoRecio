using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavidPrietoRecio
{
    public partial class FormAlta : Form
    {

        private OleDbConnection con;

        public FormAlta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String aux = "select max(IdCinta)+1 from Cintas";
            OleDbCommand command = new OleDbCommand(aux, con);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                aux = reader.GetValue(0).ToString();
            }

            String sql = "insert into Cintas values("+aux+",'"+maskedTextBox1.Text.ToUpper()+"',"+textBox2.Text+","+(comboBox1.SelectedIndex+1)+",'"+textBox3.Text+ "'," + (comboBox1.SelectedIndex+1) + ");";
            command = new OleDbCommand(sql, con);
            command.ExecuteNonQuery();
            Dispose();
        }

        private void FormAlta_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\\temp\\GestionCintas.mdb");
            con.Open();
            String sql = "Select TipoCinta from TipoCinta";
            OleDbCommand command = new OleDbCommand(sql, con);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            sql = "Select Localizacion from Localizacion";
            command = new OleDbCommand(sql, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader.GetString(0));
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            String s= maskedTextBox1.Text;
            s = s.ToUpper();
            String sql = "select max(NumeroCodigoFisico)+1 from Cintas where LetraCodigoFisico like '"+s+"'";
            OleDbCommand command = new OleDbCommand(sql, con);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox2.Text = reader.GetValue(0).ToString();
                if (textBox2.Text.Equals(""))
                {
                    textBox2.Text = "00001";
                }
            }
        }

        private void FormAlta_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
    }
}
