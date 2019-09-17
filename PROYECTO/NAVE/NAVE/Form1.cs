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
            navegador1.asignarcolorf(Color.DarkRed);
            navegador1.asginarComboConLista(1, "np|pp|");
            navegador1.asignarColor(Color.SeaShell);
            navegador1.asginarComboConTabla("Peliculas", "idPelicula");
            navegador1.asginarComboConTabla("Cines", "nombreCine");
            navegador1.asignarTabla("Funciones");
            navegador1.asignarA("1");

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
