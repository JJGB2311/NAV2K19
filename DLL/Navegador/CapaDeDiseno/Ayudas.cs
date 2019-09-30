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
    public partial class Ayudas : Form
    {
        logicaNav logic = new logicaNav();
        OdbcConnection conn = new OdbcConnection("Dsn=navegador");
        string[] aliasC = new string[40];

        public Ayudas()
        {
            InitializeComponent();

            llenartabla();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog rutaFile = new OpenFileDialog();
            rutaFile.InitialDirectory = "c:\\";
            rutaFile.Filter = "chm files (*.chm)|*.chm";
            if (rutaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                txtruta.Text = rutaFile.FileName;
            }
        }
      
        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog rutaFile = new OpenFileDialog();
            rutaFile.InitialDirectory = "c:\\";
            rutaFile.Filter = "chm files (*.html)|*.html";
            if (rutaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                txtindice.Text = rutaFile.FileName;
            }
        }

        void llenartabla()
        {
            OdbcCommand codigo = new OdbcCommand();
            codigo.Connection = conn;
            
              codigo.CommandText = ("SELECT Id_ayuda,Ruta,indice FROM ayuda WHERE estado =1");
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


			string query = "INSERT INTO ayuda ( Ruta , indice, estado) VALUES  ('" + txtruta.Text.Replace("\\", "/")
				+ "', '" + txtindice.Text + "', '" + "1" + "')";

			return query;
        
        }

                
        string crearDelete()// crea el query de delete
        {
            //Cambiar el estadoPelicula por estado
            string query = "UPDATE ayuda set estado = 0 " + " WHERE Id_ayuda =" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            return query;
        }

        string crearUpdate()// crea el query de update
        {
			/* string query = "UPDATE ayuda SET Ruta = 'Página web ayuda/ayuda.chm.', indice = 'Menúboletos.html.' WHERE ayuda.Id_ayuda = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();*/
			string query = "UPDATE ayuda SET Ruta = '" + txtruta.Text.Replace("\\", "/") + "', indice = '" + txtindice.Text + "' WHERE ayuda.Id_ayuda = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();


			return query;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (txtruta.Text == "" || txtindice.Text == "")
            {
                MessageBox.Show("Por favor, llene los campos de ruta e índice");
            }
            else
            {
                logic.nuevoQuery(crearInsert());
               
                txtindice.Clear();
                txtruta.Clear();
                MessageBox.Show("Ayuda agregada Correctamente!");
                llenartabla();
            }
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
               
                txtruta.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtindice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                MessageBox.Show("Porfavor Seleccione un registro de la tabla");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (txtruta.Text == "" || txtindice.Text == "")
            {
                MessageBox.Show("Por favor, llene ambos campos para continuar...");
            }
            else
            {
                logic.nuevoQuery(crearUpdate());

                txtindice.Clear();
                txtruta.Clear();
                MessageBox.Show("Ayuda modificada correctamente");
                llenartabla();
            }



            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (txtruta.Text == "" || txtindice.Text == "")
            {
                MessageBox.Show("Hola");
            }
            else
            {
                logic.nuevoQuery(crearDelete());

                txtindice.Clear();
                txtruta.Clear();
                MessageBox.Show("Ayuda eliminada Correctamente");
                llenartabla();
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
			OpenFileDialog rutaFile = new OpenFileDialog();
			rutaFile.InitialDirectory = "c:\\";
			rutaFile.Filter = "chm files (*.html)|*.html";
			if (rutaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{

				txtindice.Text = rutaFile.SafeFileName;

			}
		}
	}
}
