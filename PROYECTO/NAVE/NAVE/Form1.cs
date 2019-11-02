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
        ToolTip ayuda_tp = new ToolTip();
        public Form1()
        {
            InitializeComponent();
			string[] alias = { "Categoria", "Estado" };
			navegador1.asignarAlias(alias);
			navegador1.asignarSalida(this);
			Color Hotel = Color.FromArgb(171, 166, 191);
			navegador1.asignarColorFondo(Hotel);
			navegador1.asignarColorFuente(Color.Black);
			navegador1.asignarAyuda("1");
			navegador1.asignarTabla("tbl_categorias_habitacion");
			navegador1.asignarComboConTabla("tbl_tipo_habitacion", "KidTipoHabitacion", 0);
			navegador1.asignarNombreForm("Categorias Habitación");
			ayuda_tp.IsBalloon = true;
            
            /*
            string[] alias = { "Cod Asiento", "Cod Funcion", "Estado" };
            navegador1.asignarAlias(alias);
            navegador1.asignarSalida(this);
            navegador1.asignarColorFondo(Color.LightBlue);
            navegador1.asignarColorFuente(Color.BlueViolet);
            navegador1.asignarAyuda("1");
            navegador1.asignarTabla("pruebaai");
            navegador1.asignarNombreForm("PruebaAI");     
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.ShowDialog();
            string aplicacionActiva = "1";
            navegador1.ObtenerIdUsuario(login.obtenerNombreUsuario());
            navegador1.botonesYPermisosInicial(login.obtenerNombreUsuario(), aplicacionActiva);
            //na
           // navegador1.registros();
            navegador1.ObtenerIdAplicacion(aplicacionActiva);             
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
			Form2 nuevo = new Form2();
			nuevo.Show();
        }
    }
}
