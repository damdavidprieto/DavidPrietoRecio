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
    public partial class FormRegCintas : Form
    {

        private FormPrincipal fPrincipal;

        private DataView dv;

        public DataView Dv { get => dv; set => dv = value; }
        public FormPrincipal FPrincipal { get => fPrincipal; set => fPrincipal = value; }

        public FormRegCintas(FormPrincipal form)
        {
            InitializeComponent();
            MdiParent = form;
            FPrincipal = form;
            WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FPrincipal.Actual = "";
            Dispose();
        }

        private void FormRegCintas_Load(object sender, EventArgs e)
        {
            Dv = new DataView(FPrincipal.Ds.Tables["DataGrid"]);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = Dv;
            DataGridViewColumn colum = new DataGridViewColumn();
            colum = dataGridView1.Columns[0];
            colum.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAlta alta = new FormAlta();
            alta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBuqueda fBusqueda = new FormBuqueda(this);
            fBusqueda.ShowDialog();
        }
    }
}
