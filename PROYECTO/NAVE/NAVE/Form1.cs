using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDiseno;

namespace NAVE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            string[] alias = { "Cod Funcion", "Cod Pelicula", "Cod Sala", "Cine", "Horario", "Estado" };
            navegador1.asignarAlias(alias); // asignar labels

            //navegador1.asginarComboConLista(4, "np|pp|");// ComboBox con Lista de items
            navegador1.asignarColorFondo(Color.LightBlue); // color de fondo del navegador
            
            navegador1.asignarColorFuente(Color.Black); // Color de letra del navegador
            navegador1.asignarComboConTabla("Peliculas", "idPelicula"); // LLenado de ComboBox
            navegador1.asignarComboConTabla("Salas", "idSala");
            navegador1.asignarComboConTabla("Cines", "nombreCine");
            navegador1.asignarAyuda("1");// Asignacion de ayuda con tabla
            navegador1.asignarTabla("Funciones");// Asignar tabla de trabajo al nav
            navegador1.asignarNombreForm("Funciones");// asignar el titulo del nav
            navegador1.tablaverificacion("ayuda");//ayuda averificar que la tabla


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.ShowDialog();
            navegador1.ObtenerIdUsuario(login.obtenerNombreUsuario());
            // navegador1.ObtenerIdUsuario("MiUsuario");
        }

        private void Navegador1_Load(object sender, EventArgs e)
        {

        }

        private void Navegador1_Load_1(object sender, EventArgs e)
        {
     
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(navegador1.obtenerDatoTabla(3));
            MessageBox.Show(navegador1.obtenerDatoCampos(2));
        }
    }
}
