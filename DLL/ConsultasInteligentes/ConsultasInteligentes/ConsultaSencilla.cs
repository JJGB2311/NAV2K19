using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica_Consultas;

namespace ConsultasInteligentes
{
    public partial class ConsultaSencilla : UserControl
    {
        private string nombre, descripsion;
        private string tabla1, tabla2, campo1, campo2;
        private string operadorActual;
        private string select = "SELECT ";
        private string where = " WHERE ";
        private string from = " FROM ";
        private string cadenaFinal = "";
        private bool seleccionado = false;
        private bool seleccionado1 = false;
        private bool seleccionado2 = false;
        private bool seleccionado3 = false;
        string sIddUsuario;
        logicaConsultas log;
        int idConsulta;
        List<int> lista2 = new List<int>();
        List<string> consultas2 = new List<string>();

        public ConsultaSencilla()
        {
            InitializeComponent();
        }

        private void Cbo_campo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionado1 = true;
        }

        private void Cbo_campo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionado2 = true;
        }

        private void Cbo_operador_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionado3 = true;
        }


        public void ObtenerUsuario(String sIdUsuario)
        {
            sIddUsuario = sIdUsuario;
            log = new logicaConsultas(sIddUsuario);
            log.tablas(Cbo_tabla);
            //log.campos(Cbo_campo1, Cbo_tabla.Text);
            //log.campos(Cbo_campo2, Cbo_tabla.Text);
            //log.CargarConsultas(Cbo_ListaTablas, lista, consultas);
        }

        private void Cpb_Tablas_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if(Cbo_Query.Text == "")
            {
                MessageBox.Show("Primero debe seleccionar una consulta", "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                log.EjecutarConsultas2(DataGrid1, Txt_Descripcion.Text);
                MessageBox.Show("Busqueda realizada con Exito!");
            }
            
        }

        private void Cbo_Query_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_Query.Items.Count > 0)
            {
                int seleccionado1 = Cbo_Query.SelectedIndex;
                idConsulta = lista2.ElementAt(seleccionado1);
                Txt_Descripcion.Text = consultas2.ElementAt(seleccionado1);
                log.consultaDescripcion(Txt_mostrar,Cbo_Query.Text);
                


            }
        }

        private void Creacion_Selected(object sender, TabControlEventArgs e)
        {

            if (e.TabPage.Name == tb_consulta.Name)
            {
                Cbo_Query.Items.Clear();
                lista2.Clear();
                consultas2.Clear();
                log.CargarConsultas2(Cbo_Query, lista2, consultas2);
            }

        }

        private void Creacion_KeyDown(object sender, KeyEventArgs e)
        {
            int tabla;
            tabla = Convert.ToInt32(Creacion_Consulta.TabCount.ToString());

            string tab;
            tab = Creacion_Consulta.SelectedTab.Name;

          /*  if (e.KeyData == Keys.F1)
            {
                if (tab == "TbCrecion")
                {
                    //Help.ShowHelp(this, "C:/Users/sindy/Downloads/ConsultasInteligentes/Ayudas/AyudaConsultas.chm", "creacion.html");
                    Help.ShowHelp(this, "Ayudas/AyudaConsultas.chm", "creacion.html");
                }
                else if (tab == "TbConsultas")
                {
                    //Help.ShowHelp(this, "C:/Users/sindy/Downloads/ConsultasInteligentes/Ayudas/AyudaConsultas.chm", "consulta.html");
                    Help.ShowHelp(this, "Ayudas/AyudaConsultas.chm", "consulta.html");
                }
                else if (tab == "TbEliminar")
                {
                    //Help.ShowHelp(this, "C:/Users/sindy/Downloads/ConsultasInteligentes/Ayudas/AyudaConsultas.chm", "AyudaEditar.html");
                    Help.ShowHelp(this, "Ayudas/AyudaConsultas.chm", "AyudaEditar.html");
                }
                else if (tab == "TbEditar")
                {
                    //Help.ShowHelp(this, "C:/Users/sindy/Downloads/ConsultasInteligentes/Ayudas/AyudaConsultas.chm", "eliminacion.html");
                    Help.ShowHelp(this, "Ayudas/AyudaConsultas.chm", "eliminacion.html");
                }
            }*/
        }

        private void Cbo_tabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbo_campo1.Items.Clear();
            Cbo_campo2.Items.Clear();
            log.campos(Cbo_campo1, Cbo_tabla.Text);
            log.campos(Cbo_campo2, Cbo_tabla.Text);
            seleccionado = true;
        }

        private void Btn_crearConsulta_Click(object sender, EventArgs e)
        {
            if (seleccionado == true && seleccionado1 == true && seleccionado2 == true && seleccionado3 == true) 
            {
                nombre = Txt_nombre.Text;
                descripsion = Txt_descripsion.Text;
                cadenaFinal = select + "*" + from + Cbo_tabla.SelectedItem.ToString() +
                    where + Cbo_campo1.SelectedItem.ToString() + " " + Cbo_operador.SelectedItem.ToString() +
                    " " + Cbo_campo2.SelectedItem.ToString();

                Txt_query.Text = cadenaFinal;
            }
            else
            {
                MessageBox.Show("Faltan Campos");
            }
        }

        private void Btn_generar_Click(object sender, EventArgs e)
        {
            if (nombre != "" && descripsion != "" && cadenaFinal != "")
            {
                log.InsertarCampos(cadenaFinal, nombre, descripsion, "MiUsuario");
                log.EjecutarConsultas(Dgv_resultado, cadenaFinal);
                limpiar();
                MessageBox.Show("Consulta Registrada");
            }
            else
            {
                MessageBox.Show("Faltan Campos");
            }
        }

        private void limpiar()
        {
            nombre = "";
            descripsion = "";
            cadenaFinal = "";
            Txt_query.Text = null;
            Txt_nombre.Text = null;
            Txt_descripsion.Text = null;
        }
    }
}
