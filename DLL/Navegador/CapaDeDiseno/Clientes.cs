using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CapaDeDiseno
{
    public partial class Clientes : Form
    {
		string ruta = "";
        public Clientes(string path)
        {
            InitializeComponent();
			ruta = path;
			OpenFileDialog arch = new OpenFileDialog();
		}

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void Frm_ReporteClientes_Load(object sender, EventArgs e)
        {
			try { 
			ReportDocument reportDocument = new ReportDocument();
			string filePath = ruta;
			reportDocument.Load(filePath);
			crystalReportViewer1.ReportSource = reportDocument;
		}
				catch (Exception)
				{
					MessageBox.Show("Error... No se puede abrir el reporte seleccioando...");
					//throw;
				}

	
		}

        private void Frm_ReporteClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
