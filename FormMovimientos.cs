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
    public partial class FormMovimientos : Form
    {

        private FormPrincipal fPrincipal;

        private DataView dv;

        public FormMovimientos(FormPrincipal form)
        {
            InitializeComponent();
            fPrincipal = form;
            MdiParent = form;
            fPrincipal = form;
            WindowState = FormWindowState.Maximized;
        }

        private void FormMovimientos_Load(object sender, EventArgs e)
        {
            dv = new DataView(fPrincipal.Ds.Tables["Movimientos"]);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dv;
            DataGridViewColumn colum = new DataGridViewColumn();
            colum = dataGridView1.Columns[0];
            colum.Visible = false;

            comboBox1.DataSource = fPrincipal.Ds.Tables["DataGrid"];
            comboBox1.DisplayMember = "LetraCodigoFisico";

            comboBox3.DataSource = fPrincipal.Ds.Tables["DataGrid"];
            comboBox3.DisplayMember = "NumeroCodigoFisico";


        }
    }
}
