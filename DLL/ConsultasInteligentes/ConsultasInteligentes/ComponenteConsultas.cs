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
using CapaDiseno;

namespace ConsultasInteligentes
{

    public partial class ComponenteConsultas : UserControl
    {
        string sIddUsuario;

        logicaConsultas log;
        HelpProvider ayuda = new HelpProvider();

        private string QuerySimple, QuerySimpleComplete, QueryComplejoCondicional, QueryComplejoComp, QueryComplejoOrden, QueryComplejoTotal;
        private string QuerySimple1, QuerySimpleComplete1, QueryComplejoCondicional1, QueryComplejoComp1, QueryComplejoOrden1, QueryComplejoTotal1;
        int contadorAgregar = 0, ContadorLogico = 0, ContadorComparacion = 0, ContadorAgrup = 0;
        int contadorAgregar1 = 0, ContadorLogico1 = 0, ContadorComparacion1 = 0, ContadorAgrup1 = 0,ContadorUnir=0;
        string Comilla = " ' ";
        string guardar;
        List<int> lista = new List<int>();
        List<string> consultas = new List<string>();
        int idConsulta;
        string unir, unirguardar;

        public ComponenteConsultas()
        {
            InitializeComponent();
            gbLogica.Enabled = false;
            gbComparacion.Enabled = false;
            gbTipoOrdenamiento.Enabled = false;
            gbAgrupar.Enabled = false;
            //log.conect();
            // cboTablasGeneral=log.listatablas();
        }

        public void ObtenerUsuario(String sIdUsuario)
        {
            sIddUsuario = sIdUsuario;
            log = new logicaConsultas(sIddUsuario);
            log.tablas(cboTablasGeneral);
            log.tablas(cboTablaGeneral1);
            log.CargarConsultas(Cbo_ListaTablas, lista, consultas);
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCampos.Items.Clear();
            cboCampoOrden.Items.Clear();
            cboCampoLogico.Items.Clear();
            cboCampoComparador.Items.Clear();
            log.campos(cboCampos, cboTablasGeneral.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (cboOpciones.Checked)
            {
                QuerySimple = " * ";
                QuerySimpleComplete = " SELECT " + QuerySimple + " FROM " + cboTablasGeneral.Text;
                MessageBox.Show(QuerySimpleComplete);


            }
            else
            {

                QuerySimpleComplete = "";
                cboCampos.Enabled = true;
                txtNombreRepresentativo.Enabled = true;
                if (txtNombreConsulta.Text == "" | cboCampos.Text == "" | cboTablasGeneral.Text == "" | txtNombreRepresentativo.Text == "")
                {
                    MessageBox.Show("No ha elegido datos");
                }
                else
                {
                    ContadorLogico++;
                    if (ContadorLogico > 1)
                    {
                        MessageBox.Show("No puede agregar mas de 2 querys simples");
                    }
                    else
                    {
                        QuerySimpleComplete = "SELECT " + QuerySimple + " FROM " + cboTablasGeneral.Text;
                        MessageBox.Show(QuerySimpleComplete);
                    }
                }

            }


            //log.listatablas();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string contat1 = string.Concat(Comilla, txtValorLogico, Comilla);
            if (cboCampoLogico.Text == "" | cboOpLogico.Text == "" | txtValorLogico.Text == "")
            {
                MessageBox.Show("Existen Campos Vacíos");
            }
            else
            {

                QueryComplejoCondicional += cboOpLogico.Text + " " + cboCampoLogico.Text + " = '" + txtValorLogico.Text + "'";
                MessageBox.Show(QueryComplejoCondicional);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtValorComp.Text = "";
            cboComparador.SelectedIndex = 0;
            cboCampoComparador.Text = "";
            log.campos(cboCampoComparador, cboTablasGeneral.Text);
            QueryComplejoComp = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAgregarOrden_Click(object sender, EventArgs e)
        {

            if (cboTipoSeleccion.Text == "" | cboCampoOrden.Text == "")
            {
                MessageBox.Show("Existen Campos Vacíos");
            }
            else
            {
                if (cboTipoSeleccion.Text == "Ordenar")
                {
                    // gbTipoOrdenamiento.Enabled = true;
                    if (rbAscendente.Checked)
                    {
                        QueryComplejoOrden = "ORDER BY " + cboCampoOrden.Text + " ASC ";
                    }
                    else if (rbDescendente.Checked)
                    {
                        QueryComplejoOrden = "ORDER BY " + cboCampoOrden.Text + " DESC ";
                    }
                }
                else if (cboTipoSeleccion.Text == "Agrupar")
                {
                    // gbTipoOrdenamiento.Enabled = false;
                    QueryComplejoOrden = "GROUP BY " + cboCampoOrden.Text;
                }
            }

            MessageBox.Show(QueryComplejoOrden);

        }

        private void btnCrearConsulta_Click(object sender, EventArgs e)
        {


            if (unirguardar == "" | QueryComplejoTotal == "")
            {
                MessageBox.Show("Debe generar una cadena antes");
            }
            else
            {
                if (ContadorUnir == 1)
                {
                    guardar = unirguardar;
                }
                else if (ContadorUnir == 0)
                {
                    guardar = QueryComplejoTotal;
                }
            }
       
            /*if (cbCondiciones.Checked == true)
            {
                if (QuerySimpleComplete == "" | QueryComplejoCondicional == "" | QueryComplejoComp == "" | QueryComplejoOrden == "")
                {
                    MessageBox.Show("No ha creado ninguna cadena");
                }
                else
                {
                    QueryComplejoTotal = QuerySimpleComplete + " " + QueryComplejoComp + " " + QueryComplejoCondicional + " " + QueryComplejoOrden;
                }
            }
            else
            {

                if (QuerySimpleComplete == "")
                {
                    MessageBox.Show("No ha creado ninguna cadena");
                }
                else
                {

                    QueryComplejoTotal = QuerySimpleComplete;


                }
            }*/
            txtCadena.Text = guardar;

            log.InsertarCampos(guardar, txtNombreConsulta.Text, txt_descri.Text, sIddUsuario);
            QuerySimpleComplete = "";
            QueryComplejoComp = "";
            QueryComplejoOrden = "";
            QueryComplejoTotal = "";
            unir = "";
            unirguardar = "";
            guardar = "";
            MessageBox.Show("Consulta Creada con Exito!");
        }

        private void btnCancelarGeneral_Click(object sender, EventArgs e)
        {
            CboGeneralCampos.Text = "";
            cboTablasGeneral.Text = "";
            cboOpciones.Checked = false;
            txtSeleccionados.Text = "";
            cboTablasGeneral.SelectedIndex = 0;
            cboCampos.SelectedIndex = 0;
            txtNombreConsulta.Text = "";
            txtNombreRepresentativo.Text = "";
            ContadorLogico = 0;
            contadorAgregar = 0;
            QuerySimple = "";
            QuerySimpleComplete = "";
        }

        private void btnCancelarLogico_Click(object sender, EventArgs e)
        {
            txtValorLogico.Text = "";
            cboOpLogico.SelectedIndex = 0;
            cboCampoLogico.Text = "";
            log.campos(cboCampoLogico, cboTablasGeneral.Text);
            QueryComplejoCondicional = "";


        }

        private void btnCancelarAgrup_Click(object sender, EventArgs e)
        {
            cboTipoSeleccion.SelectedIndex = 0;
            cboCampoOrden.Text = "";
            rbAscendente.Checked = false;
            rbDescendente.Checked = false;
            log.campos(cboCampoOrden, cboTablasGeneral.Text);
            QueryComplejoOrden = "";
        }

        private void btnBorrarProgreso_Click(object sender, EventArgs e)
        {
            //Contador
            ContadorUnir = 0;
            ContadorLogico = 0;
            ContadorAgrup = 0;
            ContadorComparacion = 0;
            contadorAgregar = 0;
            
            //Query
            QuerySimple = "";
            QueryComplejoTotal = "";
            QuerySimpleComplete = "";
            QueryComplejoComp = "";
            QueryComplejoCondicional = "";
            QueryComplejoOrden = "";
            //Txt
            txtSeleccionados.Text = "";
            txtNombreConsulta.Text = "";
            txtCadena.Text = "";
            txtNombreRepresentativo.Text = "";
            txtValorLogico.Text = "";
            txtNombreRepresentativo.Enabled = true;
            //gb
            gbComparacion.Enabled = false;
            gbLogica.Enabled = false;
            gbAgrupar.Enabled = false;
            //Cbo
            cboTablasGeneral.Text = "";
            cboCampos.Text = "";
            cboOpLogico.Text = "";
            cboCampoLogico.Text = "";
            txtValorComp.Text = "";
            cboComparador.Text = "";
            cboComparador.Text = "";
            cboCampoComparador.Text = "";
            cboTipoSeleccion.Text = "";
            cboCampoOrden.Text = "";
            cboCampos.Enabled = true;
            //check
            rbAscendente.Checked = false;
            rbDescendente.Checked = false;
            cboOpciones.Checked = false;
            cbCondiciones.Checked = false;




        }


        private void button3_Click_1(object sender, EventArgs e)
        {



            if (TxtEID.Text == "")
            {

                MessageBox.Show("Debe ingresar el nombre de la consulta para la busqueda");
            }
            else
            {
                log.txt(TxtNConsulta, TxtEID.Text);
                log.txt1(TxtEditarCadena, TxtEID.Text);
                gbGeneral1.Enabled = true;
                AgregarCondiciones1.Enabled = true;
                gbLogica1.Enabled = false;
                gbComparacion1.Enabled = false;
                gbTipoOrdenamiento1.Enabled = false;
                gbAgrupar1.Enabled = false;
            }
            if (TxtNConsulta.Text == "")
            {
                gbGeneral1.Enabled = false;
                AgregarCondiciones1.Checked = false;
            }



        }

        private void BtnEditarA1_Click(object sender, EventArgs e)
        {
            List<string> listacampos1 = new List<string>();

           
            if (chkedit.Checked)
            {


                if (TxtNConsulta.Text == "" | cboTablaGeneral1.Text == "")
                {
                    MessageBox.Show("Existen campos vacios");
                }
                else
                {
                    QuerySimple1 = " * ";
                    CboGeneralCampos.Enabled = false;
                    TxtNRepresentativoEdit.Enabled = false;
                    TxtSeleccionados1.Text = "Todos los campos han sido seleccionados";
                }

            }
            else
            {

                CboGeneralCampos.Enabled = true;
                TxtNRepresentativoEdit.Enabled = true;
                TxtSeleccionados1.Text = "";
                if (TxtNConsulta.Text == "" | CboGeneralCampos.Text == "" | cboTablaGeneral1.Text == "" | TxtNRepresentativoEdit.Text == "" | Txt_descripcion.Text == "")
                {

                    MessageBox.Show("No puede dejar campos vacíos");

                }

                else
                {
                    contadorAgregar1++;
                    if (contadorAgregar1 == 1)
                    {

                        if (TxtNRepresentativoEdit.Text != " ")
                        {
                            QuerySimple1 += CboGeneralCampos.Text + " as " + TxtNRepresentativoEdit.Text;
                        }
                        else
                        {
                            QuerySimple1 += CboGeneralCampos.Text;
                        }

                    }
                    else if (contadorAgregar1 >= 1)
                    {

                        if (TxtNRepresentativoEdit.Text != "")
                        {
                            QuerySimple1 += "," + CboGeneralCampos.Text + " as " + TxtNRepresentativoEdit.Text;
                        }
                        else
                        {
                            QuerySimple1 += " ," + CboGeneralCampos.Text;
                        }
                    }

                    listacampos1.Add(QuerySimple1);
                    for (int j = 0; j < listacampos1.Count; j++)
                    {
                        TxtSeleccionados1.Text = Convert.ToString(listacampos1[j]);
                    }

                }

                //limpiar
            }
        }

        private void BtnEditarA2_Click(object sender, EventArgs e)
        {
            if (chkedit.Checked)
            {
                QuerySimple1 = " * ";
                CboGeneralCampos.Enabled = false;
                TxtNRepresentativoEdit.Enabled = false;
                QuerySimpleComplete1 = " SELECT " + QuerySimple1 + " FROM " + cboTablaGeneral1.Text;
                MessageBox.Show(QuerySimpleComplete1);
            }

            else
            {
                QuerySimpleComplete1 = "";
                CboGeneralCampos.Enabled = true;
                TxtNRepresentativoEdit.Enabled = true;
                if (TxtNConsulta.Text == "" | CboGeneralCampos.Text == "" | cboTablaGeneral1.Text == "" | TxtNRepresentativoEdit.Text == "" | Txt_descripcion.Text == "")
                {
                    MessageBox.Show("No ha elegido datos");
                }

                else
                {
                    ContadorLogico1++;
                    if (ContadorLogico1 > 1)
                    {
                        MessageBox.Show("No se puede agregar mas de 2 queys simples");
                    }

                    else
                    {
                        QuerySimpleComplete1 = " SELECT " + QuerySimple1 + " FROM " + cboTablaGeneral1.Text;
                        MessageBox.Show(QuerySimpleComplete1);
                    }
                }
            }
        }

        private void BtnEditarC1_Click(object sender, EventArgs e)
        {

            TxtNRepresentativoEdit.Clear();
            cboTablaGeneral1.Text = "";
            CboGeneralCampos.Text = "";
            TxtSeleccionados1.Clear();
            TxtEID.Clear();
        }

        private void BtnEditarA3_Click(object sender, EventArgs e)
        {
            string contatt2 = string.Concat(Comilla, TxtCondicionesValor, Comilla);
            if (cboCondicionesCampo.Text == "" | cboOLogico.Text == "" | TxtCondicionesValor.Text == "")
            {
                MessageBox.Show("Existen campos vacios");
            }

            else
            {
                QueryComplejoCondicional1 += cboOLogico.Text + " " + cboCondicionesCampo.Text + " = '" + TxtCondicionesValor.Text + "'";
                MessageBox.Show(QueryComplejoCondicional1);
            }

        }

        private void BtnEditarC2_Click(object sender, EventArgs e)
        {
            TxtCondicionesValor.Clear();
            cboOLogico.Text = "";
            cboCondicionesCampo.Text = "";


        }

        private void BtnEditarA4_Click(object sender, EventArgs e)
        {


            if (cboComparacionCampo.Text == "" | cboComparacionTipo.Text == "" | TxtComparaValor.Text == "")
            {

                MessageBox.Show("Existen Campos Vacios");
            }
            else
            {

                ContadorComparacion1++;
                if (ContadorComparacion1 > 1)
                {

                    MessageBox.Show("No puede agregar 2 comparaciones en un mismo query");
                }
                else
                {

                    QueryComplejoComp1 = cboComparacionTipo.Text + " " + cboComparacionCampo.Text + " = '" + TxtComparaValor.Text + "'";

                    MessageBox.Show(QueryComplejoComp1);

                }
            }

        }

        private void BtnEditarC3_Click(object sender, EventArgs e)
        {
            TxtComparaValor.Clear();
            cboComparacionTipo.Text = "";
            cboComparacionCampo.Text = "";

        }

        private void BtnEditarA5_Click(object sender, EventArgs e)
        {

            if (cboOrdenarAgrupar.Text == "" | cboAgruparCampo.Text == "")
            {
                MessageBox.Show("Existen Campos Vacíos");
            }
            else
            {
                if (cboOrdenarAgrupar.Text == "Ordenar")
                {
                    // gbTipoOrdenamiento.Enabled = true;
                    if (RBasc.Checked)
                    {
                        QueryComplejoOrden1 = "ORDER BY " + cboAgruparCampo.Text + " ASC ";
                    }
                    else if (RBdesc.Checked)
                    {
                        QueryComplejoOrden1 = "ORDER BY " + cboAgruparCampo.Text + " DESC ";
                    }
                }
                else if (cboOrdenarAgrupar.Text == "Agrupar")
                {
                    // gbTipoOrdenamiento.Enabled = false;
                    QueryComplejoOrden1 = "GROUP BY " + cboAgruparCampo.Text;
                }
            }

            MessageBox.Show(QueryComplejoOrden1);

        }

        private void BtnEditarC4_Click(object sender, EventArgs e)
        {
            cboOrdenarAgrupar.Text = "";
            cboAgruparCampo.Text = "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ContadorLogico1 = 0;
            ContadorAgrup1 = 0;
            contadorAgregar1 = 0;
            ContadorComparacion1 = 0;

            QuerySimple1 = "";
            QueryComplejoTotal1 = "";
            QuerySimpleComplete1 = "";
            QueryComplejoComp1 = "";
            QueryComplejoCondicional1 = "";
            QueryComplejoOrden1 = "";

            TxtEditarCadena.Text = "";
            TxtEditarCadena.Text = "";
            TxtEID.Text = "";
            TxtNConsulta.Text = "";
            TxtNRepresentativoEdit.Text = "";
            TxtNRepresentativoEdit.Enabled = true;
            TxtCondicionesValor.Text = "";
            TxtSeleccionados1.Text = "";
            TxtComparaValor.Text = "";

            gbComparacion1.Enabled = false;
            gbGeneral1.Enabled = false;
            gbLogica1.Enabled = false;
            gbAgrupar1.Enabled = false;

            cboTablaGeneral1.Text = "";
            cboOLogico.Text = "";
            cboCondicionesCampo.Text = "";
            CboGeneralCampos.Text = "";
            CboGeneralCampos.Enabled = true;
            cboComparacionTipo.Text = "";
            cboComparacionCampo.Text = "";
            cboOrdenarAgrupar.Text = "";
            cboAgruparCampo.Text = "";

            chkedit.Checked = false;
            AgregarCondiciones1.Checked = false;
            RBasc.Checked = false;
            RBdesc.Checked = false;

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
         


            if (AgregarCondiciones1.Checked == true)
            {
                if (QuerySimpleComplete1 == "" | QueryComplejoCondicional1 == "" | QueryComplejoComp1 == "" | QueryComplejoOrden1 == "")
                {
                    MessageBox.Show("No ha creado ninguna cadena");
                }
                else
                {
                    QueryComplejoTotal1 = QuerySimpleComplete1 + " " + QueryComplejoComp1 + " " + QueryComplejoCondicional1 + " " + QueryComplejoOrden1;
                }
            }
            else
            {

                if (QuerySimpleComplete1 == "")
                {
                    MessageBox.Show("No ha creado ninguna cadena");
                }
                else
                {

                    QueryComplejoTotal1 = QuerySimpleComplete1;


                }
            }
            TxtEditarCadena.Text = QueryComplejoTotal1;

            log.EditarCampos(QueryComplejoTotal1, TxtNConsulta.Text, sIddUsuario);
            QuerySimpleComplete1 = "";
            QueryComplejoComp1 = "";
            QueryComplejoOrden1 = "";
            QueryComplejoTotal1 = "";
            MessageBox.Show("Consulta Creada con Exito!");

        }


        private void BtnBuscarEditar_Click(object sender, EventArgs e)
        {
            if (TxtIdEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la consulta para la busqueda");
            }
            else
            {
                string nombre = TxtIdEditar.Text;
                DataTable dtDatosDiseno = log.consultaId(nombre);
                dvgConsultas.DataSource = dtDatosDiseno;
            }


        }

        private void BtnEditarActualizar_Click(object sender, EventArgs e)
        {
            if (TxtIdEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la consulta para actualizar");
            }
            else
            {
                string nombre = TxtIdEditar.Text;
                DataTable dtDatosDiseno = log.consultaId(nombre);
                dvgConsultas.DataSource = dtDatosDiseno;
            }
        }

        private void BtnEliminarEditar_Click(object sender, EventArgs e)
        {
            if (TxtIdEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la consulta para eliminarlo");
            }
            else
            {
                string nombreconsulta = TxtIdEditar.Text;
                log.EliminarCampos(nombreconsulta);
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            DataTable dtDatosDiseno = log.consultaId1();
            dvgConsultas.DataSource = dtDatosDiseno;
            MessageBox.Show("Consultas Creadas", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cboTablasGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboOpLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampoLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboComparador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            log.EjecutarConsultas(dgvConsultas, textBox1.Text);
            MessageBox.Show("Busqueda realizada con Exito!");
        }


        private void Cbo_ListaTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_ListaTablas.Items.Count > 0)
            {
                int seleccionado = Cbo_ListaTablas.SelectedIndex;
                idConsulta = lista.ElementAt(seleccionado);
                textBox1.Text = consultas.ElementAt(seleccionado);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            /*Cbo_ListaTablas.Items.Clear();
            lista.Clear();
            consultas.Clear();
            log.CargarConsultas(Cbo_ListaTablas, lista, consultas);
            MessageBox.Show("Actualización realizada con Exito!");*/
        }


        private void TbCreacionConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboCampos.Items.Clear();
            //log.campos(CboGeneralCampos, cboTablaGeneral1.Text);
        }

        private void CboGeneralCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {


            if (AgregarCondiciones1.Checked)
            {

                if (QuerySimpleComplete1 == "")
                {
                    MessageBox.Show("Debe Generar el Query Simple primero");
                    AgregarCondiciones1.Checked = false;
                }

                else
                {
                    gbLogica1.Enabled = true;
                    gbComparacion1.Enabled = true;
                    gbAgrupar1.Enabled = true;
                    gbTipoOrdenamiento1.Enabled = true;
                    log.campos(cboComparacionCampo, cboTablaGeneral1.Text);
                    log.campos(cboAgruparCampo, cboTablaGeneral1.Text);
                    log.campos(cboCondicionesCampo, cboTablaGeneral1.Text);

                }


            }
            else
            {
                gbLogica1.Enabled = false;
                gbComparacion1.Enabled = false;
                gbTipoOrdenamiento1.Enabled = false;
                gbAgrupar1.Enabled = false;
            }


        }

        private void CboComparacionTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboOrdenarAgrupar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboTablaGeneral1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CboGeneralCampos.Items.Clear();
            cboCondicionesCampo.Items.Clear();
            log.campos(CboGeneralCampos, cboTablaGeneral1.Text);
        }

        private void GbGeneral1_Enter(object sender, EventArgs e)
        {

        }

        private void GbComparacion1_Enter(object sender, EventArgs e)
        {

        }

        private void Chkedit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboOpciones_Click(object sender, EventArgs e)
        {
            if (cboOpciones.Checked == true)
            {
                cboCampos.Enabled = false;
                txtNombreRepresentativo.Enabled = false;
            }
            else
            {
                cboCampos.Enabled = true;
                txtNombreRepresentativo.Enabled = true;
            }

        }

        private void TxtSeleccionados_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboCampoLogico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbConsultas_Click(object sender, EventArgs e)
        {

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }



        private void tbCreacionConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            int tabla;
            tabla = Convert.ToInt32(tbCreacionConsulta.TabCount.ToString());

            string tab;
            tab = tbCreacionConsulta.SelectedTab.Name;

            if (e.KeyData == Keys.F1)
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
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GbListado_Enter(object sender, EventArgs e)
        {

        }

        private void Label18_Click(object sender, EventArgs e)
        {

        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            if (cbCondiciones.Checked == true)
            {
                if (QuerySimpleComplete == "" | QueryComplejoCondicional == "" | QueryComplejoComp == "" | QueryComplejoOrden == "")
                {
                    MessageBox.Show("No ha creado ninguna cadena");
                }
                else
                {
                    QueryComplejoTotal = QuerySimpleComplete + " " + QueryComplejoComp + " " + QueryComplejoCondicional + " " + QueryComplejoOrden;
                    unir = QueryComplejoTotal;
                }
            }
            else
            {

                if (QuerySimpleComplete == "")
                {
                    MessageBox.Show("No ha creado ninguna cadena");
                }
                else
                {

                    QueryComplejoTotal = QuerySimpleComplete;
                    unir = QuerySimpleComplete;


                }
            }

            ContadorLogico = 0;
            ContadorAgrup = 0;
            ContadorComparacion = 0;
            contadorAgregar = 0;

            //Query
            QuerySimple = "";
            QueryComplejoTotal = "";
            QuerySimpleComplete = "";
            QueryComplejoComp = "";
            QueryComplejoCondicional = "";
            QueryComplejoOrden = "";
            //Txt
            txtSeleccionados.Text = "";
            txtNombreConsulta.Text = "";
            txtCadena.Text = "";
            txtNombreRepresentativo.Text = "";
            txtValorLogico.Text = "";
            txtNombreRepresentativo.Enabled = true;
            //gb
            gbComparacion.Enabled = false;
            gbLogica.Enabled = false;
            gbAgrupar.Enabled = false;
            //Cbo
            cboTablasGeneral.Text = "";
            cboCampos.Text = "";
            cboOpLogico.Text = "";
            cboCampoLogico.Text = "";
            txtValorComp.Text = "";
            cboComparador.Text = "";
            cboComparador.Text = "";
            cboCampoComparador.Text = "";
            cboTipoSeleccion.Text = "";
            cboCampoOrden.Text = "";
            cboCampos.Enabled = true;
            //check
            rbAscendente.Checked = false;
            rbDescendente.Checked = false;
            cboOpciones.Checked = false;
            cbCondiciones.Checked = false;
        }

        private void gbGeneral_Enter(object sender, EventArgs e)
        {

        }

        private void btn_unir_Click(object sender, EventArgs e)
        {
            ContadorUnir++;
            if (unir == "")
            {
                MessageBox.Show("no a creado una cadena previa");
            }
            else
            {
                if (ContadorUnir > 1)
                {
                    MessageBox.Show("no puede unir mas de dos consultas");
                }
                else if (ContadorUnir == 1)
                {
                    unirguardar = unir + "UNION" + QuerySimpleComplete;
                }
            }

            
        }

        private void TbCreacionConsulta_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == TbConsultas.Name)
            {
                Cbo_ListaTablas.Items.Clear();
                lista.Clear();
                consultas.Clear();
                log.CargarConsultas(Cbo_ListaTablas, lista, consultas);
            }

            if (e.TabPage.Name == TbEditar.Name)
            {
                ContadorLogico1 = 0;
                ContadorAgrup1 = 0;
                contadorAgregar1 = 0;
                ContadorComparacion1 = 0;

                QuerySimple1 = "";
                QueryComplejoTotal1 = "";
                QuerySimpleComplete1 = "";
                QueryComplejoComp1 = "";
                QueryComplejoCondicional1 = "";
                QueryComplejoOrden1 = "";

                TxtEditarCadena.Text = "";
                TxtEditarCadena.Text = "";
                TxtEID.Text = "";
                TxtNConsulta.Text = "";
                TxtNRepresentativoEdit.Text = "";
                TxtNRepresentativoEdit.Enabled = true;
                TxtCondicionesValor.Text = "";
                TxtSeleccionados1.Text = "";
                TxtComparaValor.Text = "";

                gbComparacion1.Enabled = false;
                gbGeneral1.Enabled = false;
                gbLogica1.Enabled = false;
                gbAgrupar1.Enabled = false;

                cboTablaGeneral1.Text = "";
                cboOLogico.Text = "";
                cboCondicionesCampo.Text = "";
                CboGeneralCampos.Text = "";
                CboGeneralCampos.Enabled = true;
                cboComparacionTipo.Text = "";
                cboComparacionCampo.Text = "";
                cboOrdenarAgrupar.Text = "";
                cboAgruparCampo.Text = "";

                chkedit.Checked = false;
                AgregarCondiciones1.Checked = false;
                RBasc.Checked = false;
                RBdesc.Checked = false;
            }

            gbGeneral1.Enabled = false;
            gbLogica1.Enabled = false;
            gbComparacion1.Enabled = false;
            gbTipoOrdenamiento1.Enabled = false;
            gbAgrupar1.Enabled = false;
            AgregarCondiciones1.Enabled = false;

        }

        private void Chkedit_Click(object sender, EventArgs e)
        {
            if (chkedit.Checked == true)
            {
                CboGeneralCampos.Enabled = false;
                TxtNRepresentativoEdit.Enabled = false;
            }

            else
            {
                CboGeneralCampos.Enabled = true;
                TxtNRepresentativoEdit.Enabled = true;
            }
        }

        private void CboOpciones_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboOLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboCampoSelectEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CboCampos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AgregarCondiciones1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GbComparacion_Enter(object sender, EventArgs e)
        {

        }

        private void cboCampoComparador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboTipoSeleccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampoOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrdenarAgrupar.Text == "Ordenar")
            {
                gbTipoOrdenamiento1.Enabled = true;

            }
            else if (cboOrdenarAgrupar.Text == "Agrupar")
            {
                gbTipoOrdenamiento1.Enabled = false;

            }
        }

        private void cboTipoSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoSeleccion.Text == "Ordenar")
            {
                gbTipoOrdenamiento.Enabled = true;

            }
            else if (cboTipoSeleccion.Text == "Agrupar")
            {
                gbTipoOrdenamiento.Enabled = false;

            }



        }


        private void cbCondiciones_Click(object sender, EventArgs e)
        {

            if (cbCondiciones.Checked)
            {

                if (QuerySimpleComplete == "")
                {
                    MessageBox.Show("Debe Generar el Query Simple primero");
                    cbCondiciones.Checked = false;
                }
                else
                {
                    gbLogica.Enabled = true;
                    gbComparacion.Enabled = true;
                    gbTipoOrdenamiento.Enabled = true;
                    gbAgrupar.Enabled = true;
                    log.campos(cboCampoComparador, cboTablasGeneral.Text);
                    log.campos(cboCampoOrden, cboTablasGeneral.Text);
                    log.campos(cboCampoLogico, cboTablasGeneral.Text);
                }


            }
            else
            {
                gbLogica.Enabled = false;
                gbComparacion.Enabled = false;
                gbTipoOrdenamiento.Enabled = false;
                gbAgrupar.Enabled = false;
            }

        }

        private void btnAgregarComp_Click(object sender, EventArgs e)
        {

            if (cboCampoComparador.Text == "" | cboComparador.Text == "" | txtValorComp.Text == "")
            {
                MessageBox.Show("Existen Campos Vacios");
            }
            else
            {
                ContadorComparacion++;
                if (ContadorComparacion > 1)
                {
                    MessageBox.Show("No puede agregar 2 comparaciones en un mismo query");
                }
                else
                {
                    QueryComplejoComp = cboComparador.Text + " " + cboCampoComparador.Text + " = '" + txtValorComp.Text + "'";
                    MessageBox.Show(QueryComplejoComp);

                }
            }


        }

        private void btnAgregarCampo_Click(object sender, EventArgs e)
        {
            
            List<string> listacampos = new List<string>();

            if (cboOpciones.Checked)
            {
                if (txtNombreConsulta.Text == "" | cboTablasGeneral.Text == "")
                {
                    MessageBox.Show("Existen campos vacios");
                }
                else
                {
                    QuerySimple = " * ";
                    cboCampos.Enabled = false;
                    txtNombreRepresentativo.Enabled = false;
                    txtSeleccionados.Text = "Todos los campos han sido seleccionados";
                }

            }
            else
            {

                cboCampos.Enabled = true;
                txtNombreRepresentativo.Enabled = true;
                txtSeleccionados.Text = "";
                if (txtNombreConsulta.Text == "" | cboCampos.Text == "" | cboTablasGeneral.Text == "" | txtNombreRepresentativo.Text == "")
                {


                    MessageBox.Show("No puede dejar campos vacíos");

                }

                else
                {
                    contadorAgregar++;
                    if (contadorAgregar == 1)
                    {

                        if (txtNombreRepresentativo.Text != " ")
                        {
                            QuerySimple += cboCampos.Text + " as " + txtNombreRepresentativo.Text;
                        }
                        else
                        {
                            QuerySimple += cboCampos.Text;
                        }
                    }
                    else if (contadorAgregar >= 1)
                    {

                        if (txtNombreRepresentativo.Text != "")
                        {
                            QuerySimple += "," + cboCampos.Text + " as " + txtNombreRepresentativo.Text;
                        }
                        else
                        {
                            QuerySimple += " ," + cboCampos.Text;
                        }

                    }
                    listacampos.Add(QuerySimple);
                    for (int j = 0; j < listacampos.Count; j++)
                    {
                        txtSeleccionados.Text = Convert.ToString(listacampos[j]);
                    }

                }
                //
            }

            //limpiar
        }
    }
}
