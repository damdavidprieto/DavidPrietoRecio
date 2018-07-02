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
    public partial class FormPrincipal : Form
    {

        private String actual;

        private OleDbConnection con;

        private DataSet ds;

        private OleDbDataAdapter daDataGird,daMovimientos,daLocalizacion;

        public FormPrincipal()
        {
            InitializeComponent();
            Actual = "";
        }

        public string Actual { get => actual; set => actual = value; }
        public DataSet Ds { get => ds; set => ds = value; }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\\temp\\GestionCintas.mdb");
            con.Open();

            Ds = new DataSet();

            daDataGird = new OleDbDataAdapter();
            daMovimientos = new OleDbDataAdapter();
            daLocalizacion = new OleDbDataAdapter();

            OleDbCommand cm = new OleDbCommand();
            OleDbCommand cm2 = new OleDbCommand();
            OleDbCommand cm3 = new OleDbCommand();

            cm.Connection = con;
            cm2.Connection = con;
            cm3.Connection = con;

            String sql = "Select IdCinta, NumeroCodigoFisico & LetraCodigoFisico as CódigoFisico, titulo, TipoCinta, Localizacion from Cintas as c,TipoCinta as t,Localizacion as l where l.IdLocalizacion = c.IdLocalizacion and c.IdTIpoCinta=t.IdTipoCinta";
            String sql2 = "Select IdCinta, ori.Localizacion as origen, des.Localizacion as Destino, Dia, Hora from Movimientos, Localizacion as ori, Localizacion as des where IdLocalizacionOrigen = ori.IdLocalizacion and IdLocalizacionDestino = des.IdLocalizacion";
            String sql3 = "Select * from Localizacion";

            cm.CommandText = sql;
            cm2.CommandText = sql2;
            cm3.CommandText = sql3;

            daDataGird.SelectCommand = cm;
            daMovimientos.SelectCommand = cm2;
            daLocalizacion.SelectCommand = cm3;

            daDataGird.Fill(Ds, "DataGrid");
            daMovimientos.Fill(Ds,"Movimientos");
            daLocalizacion.Fill(Ds,"Localizacion");

            con.Close();
        }

        private void cintasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Actual.Equals("cin"))
            {
                foreach (Form m in MdiChildren)
                {
                    m.Close();
                }
                Actual = "cin";
                FormRegCintas cintas = new FormRegCintas(this);
                cintas.Show();
            }
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Actual.Equals("mov"))
            {
                foreach (Form m in MdiChildren)
                {
                    m.Close();
                }
                Actual = "mov";
                FormMovimientos mov = new FormMovimientos(this);
                mov.Show();
            }
        }
    }
}
