using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeLogica;
using CapaDatos;

namespace CapaDeDiseno
{
    public partial class Reportes : Form
    {
        logicaNav logic = new logicaNav();
        OdbcConnection conn = new OdbcConnection("Dsn=navegador");
        string[] aliasC = new string[40];

        public Reportes()
        {
            InitializeComponent();

            llenartabla();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
			string txtruta = "";
			OpenFileDialog rutaFile = new OpenFileDialog();
			rutaFile.InitialDirectory = "c:\\";
			rutaFile.Filter = "chm files (*.rpt)|*.rpt";
			if (rutaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{

				txtruta = rutaFile.FileName;
			}
			txtpath.Text = txtruta;
			
        }
      
        private void Button2_Click(object sender, EventArgs e)
        {
		
        }

        void llenartabla()
        {
            OdbcCommand codigo = new OdbcCommand();
            codigo.Connection = conn;
            
              codigo.CommandText = ("SELECT * FROM reportes");
            try
            {
                OdbcDataAdapter ejecutar = new OdbcDataAdapter();
                ejecutar.SelectCommand = codigo;
                DataTable datostabla = new DataTable();
                ejecutar.Fill(datostabla);
                dataGridView1.DataSource = datostabla;
                ejecutar.Update(datostabla);
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR" + e.ToString());
                conn.Close();
            }



    
        }



		string crearInsert()// crea el query de insert
		{


			string query = "INSERT INTO Reportes (Ruta) VALUES  ('" + txtpath.Text.Replace("\\", "/")+"')";

			return query;

		}


		string crearDelete()// crea el query de delete
		{
			//Cambiar el estadoPelicula por estado
			string query = "UPDATE reportes set estado = 0 " + " WHERE Id_reporte =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
			return query;
		}

		string crearUpdate()// crea el query de update
		{
			string query = "UPDATE reportes SET Ruta = '" + txtpath.Text.Replace("\\", "/") + "' WHERE Id_reporte = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();


			return query;
		}

		private void Button3_Click(object sender, EventArgs e)
        {
            if (txtpath.Text == "" )
            {
                MessageBox.Show("Por favor, seleccione un Reporte...");
            }
           else
            {
                logic.nuevoQuery(crearInsert());

				txtpath.Clear();

				MessageBox.Show("Reporte agregado Correctamente!");
				llenartabla();
			}
		}


			private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			if (dataGridView1.SelectedRows.Count == 1)
			{

				txtpath.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				
			}
			else
			{
				MessageBox.Show("Porfavor Seleccione un registro de la tabla");
			}
		}

        private void Button5_Click(object sender, EventArgs e)
        {
         if (txtpath.Text == "" )
			{
				MessageBox.Show("Por favor, Seleccione un Reporte...");
			}
			else
			{
				logic.nuevoQuery(crearUpdate());

				txtpath.Clear();
				MessageBox.Show("Reporte modificado correctamente");
				llenartabla();
			}




		}

		private void Button4_Click(object sender, EventArgs e)
        {
			DialogResult Respuestamodieli;
			Respuestamodieli = MessageBox.Show("Desea eliminar el Reporte Seleccionado", "", MessageBoxButtons.YesNo);
			if (Respuestamodieli == DialogResult.Yes)
			{
				logic.nuevoQuery(crearDelete());

				txtpath.Clear();

				MessageBox.Show("Reporte eliminado Correctamente");
				llenartabla();

			}
			else if (Respuestamodieli == DialogResult.No)
			{
			}

				
			

		}

        private void Ayudas_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

		private void Button2_Click_1(object sender, EventArgs e)
		{
			//OpenFileDialog rutaFile = new OpenFileDialog();
			//rutaFile.InitialDirectory = "c:\\";
			//rutaFile.Filter = "chm files (*.html)|*.html";
			//if (rutaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			//{

			//	txtindice.Text = rutaFile.SafeFileName;

			//}
		}

		private void Button2_Click_2(object sender, EventArgs e)
		{
			if (txtpath.Text!="")
			{
				
					Clientes cl = new Clientes(txtpath.Text);
					cl.Show();
				
				
			}
			
		}

		private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
