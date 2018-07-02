using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavidPrietoRecio
{
    public partial class FormBuqueda : Form
    {

        private FormRegCintas fRegCintas;

        public FormBuqueda(FormRegCintas form)
        {
            InitializeComponent();
            fRegCintas = form;
        }

        private void FormBuqueda_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = fRegCintas.FPrincipal.Ds.Tables["Localizacion"];
            comboBox1.DisplayMember = "Localizacion";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fRegCintas.Dv.RowFilter = "";
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow dr = fRegCintas.FPrincipal.Ds.Tables["Localizacion"].DefaultView[comboBox1.SelectedIndex].Row;
            fRegCintas.Dv.RowFilter = "Localizacion= '" + dr["Localizacion"].ToString()+"'";
            Dispose();
        }
    }
}
