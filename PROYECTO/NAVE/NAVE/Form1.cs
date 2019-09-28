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
            string[] alias = { "Cod Producto", "Producto", "Proveedor", "Presentación", "Fecha Compra", "Unidades Minimas", "Bodega", "Estado" };
            navegador1.asignarAlias(alias);
            navegador1.asignarSalida(this);
            navegador1.asignarColorFondo(Color.LightBlue);
            navegador1.asignarColorFuente(Color.BlueViolet);
            navegador1.asignarComboConTabla("tbl_proveedor", "nombre");
            navegador1.asignarComboConLista(2, "Pequeña|Mediana|Grande|");
            navegador1.asignarComboConTabla("tbl_bodega", "nombre");
            navegador1.asignarAyuda("1");
            navegador1.asignarTabla("tbl_producto");
            navegador1.asignarNombreForm("Productos");
            ayuda_tp.IsBalloon = true;
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.ShowDialog();
            string aplicacionActiva = "1";
            navegador1.ObtenerIdUsuario(login.obtenerNombreUsuario());
            navegador1.botonesYPermisosInicial(login.obtenerNombreUsuario(), aplicacionActiva);
            navegador1.registros();
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
        }
    }
}
