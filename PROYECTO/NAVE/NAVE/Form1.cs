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
            // navegador1.asginarComboConTabla("Salas", "idSala");
            string[] alias = { "Cod Funcion", "Cod Pelicula", "Cod Sala", "Cine", "Horario", "Estado" };
            navegador1.asignarAlias(alias);
            navegador1.asginarComboConLista(1, "np|pp|");
            navegador1.asignarColor(Color.SeaShell);
            navegador1.asginarComboConTabla("Peliculas", "idPelicula");
            navegador1.asginarComboConTabla("Cines", "nombreCine");
            navegador1.asignarayuda("Página web ayuda/ayuda.chm", "menu.html");
            navegador1.asignarTabla("Funciones");
            
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.ShowDialog();
            navegador1.ObtenerIdUsuario(login.obtenerNombreUsuario());
        }

        private void Navegador1_Load(object sender, EventArgs e)
        {

        }

        private void Navegador1_Load_1(object sender, EventArgs e)
        {
     
        }
    }
}
