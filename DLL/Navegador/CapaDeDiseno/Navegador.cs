using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeLogica;
using CapaDatos;

namespace CapaDeDiseno
{
    public partial class Navegador : UserControl
    {
        Validaciones v = new Validaciones();
        logicaNav logic = new logicaNav();
        Form cerrar;
        int correcto = 0;
        string tabla = "def";
        string nomForm;
        int pos = 8;
		string idRepo = "";
		
		int[] modoCampoCombo = new int[40];
		int noCampos = 1;
        int x = 30;
        int y = 30;
        int activar = 0;    //Variable para reconocer que funcion realizara el boton de guardar (1. Ingresar, 2. Modificar, 3. Eliminar)
        string[] aliasC = new string[40];
        string[] tipoCampo = new string[30];//
        string[] tablaCombo = new string[30];
        string[] campoCombo = new string[30];
        string[] listaItems = new string[30];
        int posCombo = 10;
        int noCombo = 0;
        int noComboAux = 0;
        int estado = 1;
        Color Cfuente = Color.White;
        Color nuevoColor = Color.White;
        bool presionado = false;
        sentencia sn = new sentencia(); //objeto del componente de seguridad para obtener el método de la bitácora
        string idUsuario = "";
        string idAplicacion = "";
        //las siguientes dos variables son para el método botonesYPermisos();
        string userActivo = ""; //1
        string aplActivo = "";  //2
        string idyuda;
        string AsRuta;
        string AsIndice;
        string Asayuda;
        // string rutaa;
        Font fuente = new Font("Century Gothic", 13.0f, FontStyle.Regular, GraphicsUnit.Pixel); //objeto para definir el tipo y tamaño de fuente de los labels
        ToolTip ayuda_tp = new ToolTip();
        public Navegador()
        {
            InitializeComponent();
            limpiarListaItems();
            ayuda_tp.IsBalloon = true;
            ayuda_tp.SetToolTip(Btn_Ingresar, "Escribir nuevo registro");
            ayuda_tp.SetToolTip(Btn_Modificar, "Cambiar un registro");
            ayuda_tp.SetToolTip(Btn_Guardar, "Guardar cambios");
            ayuda_tp.SetToolTip(Btn_Cancelar, "Cancelar Acciones");
            ayuda_tp.SetToolTip(Btn_Eliminar, "Eliminar un registro");
            ayuda_tp.SetToolTip(Btn_Consultar, "Ir a Consultas inteligentes");
            ayuda_tp.SetToolTip(Btn_Imprimir, "Ir a Reporteador");
            ayuda_tp.SetToolTip(Btn_Refrescar, "Actualizar tabla");
            ayuda_tp.SetToolTip(Btn_FlechaInicio, "Primer registro");
            ayuda_tp.SetToolTip(Btn_Anterior, "Posición superior en tabla");
            ayuda_tp.SetToolTip(Btn_Siguiente, "Posición inferior en tabla");
            ayuda_tp.SetToolTip(Btn_FlechaFin, "Fin de la tabla");
           ayuda_tp.SetToolTip(Btn_Ayuda, "Ayuda del formulario");
            ayuda_tp.SetToolTip(Btn_Salir, "Salir del formulario");
        }

        private void Navegador_Load(object sender, EventArgs e)
        {
            colorDialog1.Color = nuevoColor;
            this.BackColor = colorDialog1.Color;

            if (tabla != "def")
            {
                string TablaOK = logic.TestTabla(tabla);
                if (TablaOK == "" && correcto == 0)
                {
                    string EstadoOK = logic.TestEstado(tabla);
                    if (EstadoOK == "" && correcto == 0)
                    {
                        Asayuda = logic.verificacion("");
                        if (Asayuda == "0")
                        {
                            MessageBox.Show("No se encontró ningún registro en la tabla Ayuda");
                            Application.Exit();
                        }
                        else
                        {
                            if (numeroAlias()== logic.contarCampos(tabla))
                            {
                                int i = 0;
                                DataTable dt = logic.consultaLogica(tabla);
                                dataGridView1.DataSource = dt;
                                int head = 0;
                                while (head< logic.contarCampos(tabla))
                                {
                                    dataGridView1.Columns[head].HeaderText = aliasC[head];
                                    head++;
                                }
                                CreaComponentes();
								colorTitulo();
								lblTabla.ForeColor = Cfuente;
                                deshabilitarcampos_y_botones();
                                
                                Btn_Modificar.Enabled = true;
                                Btn_Eliminar.Enabled = true;

                                //habilitar y deshabilitar según Usuario FUNCION SOLO PARA INICIO                                                                                               
                                //botonesYPermisosInicial(userActivo, aplActivo);
                                //registros();
                                if (logic.TestRegistros(tabla) > 0)
                                {
									int numCombo = 0;
									foreach (Control componente in Controls)
									{
										if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
										{
											if (componente is ComboBox)
											{
												if (modoCampoCombo[numCombo] == 1)
												{
													componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

												}
												else
												{
													componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
												}

												numCombo++;
											}
											else
											{
												componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
											}

											i++;
										}
										if (componente is Button)
										{
											string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
											if (var1 == "0")
											{
												componente.Text = "Desactivado";
												componente.BackColor = Color.Red;
											}
											if (var1 == "1")
											{
												componente.Text = "Activado";
												componente.BackColor = Color.Green;
											}
											componente.Enabled = false;

										}
									}
								}
                                else
                                {
                                    Btn_Anterior.Enabled = false;
                                    Btn_Siguiente.Enabled = false;
                                    Btn_FlechaInicio.Enabled = false;
                                    Btn_FlechaFin.Enabled = false;
                                    Btn_Modificar.Enabled = false;
                                    Btn_Eliminar.Enabled = false;
                                }
                            }
                            else
                            {
                                if (numeroAlias() < logic.contarCampos(tabla))
                                {
                                    DialogResult validacion = MessageBox.Show(EstadoOK + "El numero de Alias asignados es menor que el requerido \n Solucione este error para continuar...", "Verificación de requisitos", MessageBoxButtons.OK);
                                    if (validacion == DialogResult.OK)
                                    {
                                        Application.Exit();
                                    }
                                }
                                else
                                {
                                    if (numeroAlias() > logic.contarCampos(tabla))
                                    {
                                        DialogResult validacion = MessageBox.Show(EstadoOK + "El numero de Alias asignados es mayor que el requerido \n Solucione este error para continuar...", "Verificación de requisitos", MessageBoxButtons.OK);
                                        if (validacion == DialogResult.OK)
                                        {
                                            Application.Exit();
                                        }
                                    }
                                }
                             }                                                      
                        }
                    }
                    else
                    {
                        DialogResult validacion = MessageBox.Show(EstadoOK + "\n Solucione este error para continuar...", "Verificación de requisitos", MessageBoxButtons.OK);
                        if (validacion == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    DialogResult validacion = MessageBox.Show(TablaOK + "\n Solucione este error para continuar...", "Verificación de requisitos", MessageBoxButtons.OK);
                    if (validacion == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
            }
            //botonesYPermisosInicial(userActivo, aplActivo);
            //registros();
        }

        //-----------------------------------------------Funciones-----------------------------------------------//
        
		void colorTitulo()
		{
			foreach (Control componente in Controls)
			{
				if (componente is Label)
				{

					componente.ForeColor = Cfuente;
				}
			}
		}
        public void ObtenerIdUsuario(string idUsuario)
        {
            this.idUsuario = idUsuario;            
        }
        
        public void ObtenerIdAplicacion(string idAplicacion)
        {
            this.idAplicacion = idAplicacion;            
        }
        /*
        private void permisos()
        {
          sentencia s = new sentencia();
          bool permiso = s.consultarPermisos(IdUsuario,idAplicacion,5);
        } */

        private int numeroAlias()
            {
            int i = 0;
            foreach (string cad  in aliasC)
            {
                if (cad!=null && cad!="")
                {
                    i++;
                } 
            }
            return i;
            }       

        public string obtenerDatoTabla(int pos)
        {
            pos=pos - 1;
          return  dataGridView1.CurrentRow.Cells[pos].Value.ToString();
        }

        public string obtenerDatoCampos(int pos)
        {

            int i = 0;
            pos = pos - 1;
            string dato = "";
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    if (i==pos)
                    {
                        dato = componente.Text;
                    }
                    i++;
                }
            }
                return dato;
        }
        public void asignarAlias(string[] alias)
        {
            alias.CopyTo(aliasC, 0);   
        }

        public void asignarAyuda(string ayudar)
        {
            string AyudaOK = logic.TestTabla("ayuda");
            if (AyudaOK == "")
            {
                if (logic.contarRegAyuda(ayudar)>0)
                {
                    idyuda = ayudar;
                    AsRuta = logic.MRuta(idyuda);
                    AsIndice = logic.MIndice(idyuda);
                    if (AsRuta=="" || AsIndice=="" || AsRuta == null || AsIndice == null)
                    {
                        DialogResult validacion = MessageBox.Show("La Ruta o índice de la ayuda está vacía", "Verificación de requisitos", MessageBoxButtons.OK);
                        if (validacion == DialogResult.OK)
                        {
                            correcto = 1;
                        }
                    }
                }
                else
                {
                    DialogResult validacion = MessageBox.Show("Por favor verifique el id de Ayuda asignado al form", "Verificación de requisitos", MessageBoxButtons.OK);
                    if (validacion == DialogResult.OK)
                    {
                        correcto = 1;
                    }
                }
               
            }
            else
            {
                DialogResult validacion = MessageBox.Show(AyudaOK + ", Por favor incluirla", "Verificación de requisitos", MessageBoxButtons.OK);
                if (validacion == DialogResult.OK)
                {
                    correcto = 1;
                }
            }
        }

		public void asignarReporte(string repo)
		{
			idRepo = repo;
		}
		public void asignarSalida(Form salida)
        {
            cerrar = salida;
        }
        public void asignarColorFuente(Color FuenteC)
        {

            Cfuente = FuenteC;
        }
        public void asignarTabla(string table)
        {
            tabla = table;
        }
        public void asignarNombreForm(string nom)
        {
            nomForm = nom;
            lblTabla.Text = nomForm;
        }

        public void asignarComboConTabla(string tabla, string campo, int modo)
        {
			
            string TablaOK = logic.TestTabla(tabla);
            if (TablaOK == "")
            {
				modoCampoCombo[noCombo] = modo;
				tablaCombo[noCombo] = tabla;
                campoCombo[noCombo] = campo;
                noCombo++;
            }
            else
            {
                DialogResult validacion = MessageBox.Show(TablaOK +", o el campo seleccionado\n para el ComboBox es incorrecto", "Verificación de requisitos", MessageBoxButtons.OK);
                if (validacion == DialogResult.OK)
                {
                    correcto = 1;
                }
            }
           

        }

        public void asignarColorFondo(Color nuevo)
        {
            nuevoColor = nuevo;
        }

        public void asignarComboConLista(int pos,string lista)
        {
            posCombo = pos-1;
            limpiarLista(lista);
			modoCampoCombo[noCombo] = 0;
			noCombo++;
        }

        void limpiarLista(string cadena)
        {
            limpiarListaItems();
            int contadorCadena = 0;
            int contadorArray = 0;
            string palabra = "";
            while (contadorCadena < cadena.Length)
            {
                if (cadena[contadorCadena] != '|')
                {
                    palabra += cadena[contadorCadena];
                    contadorCadena++;
                }
                else
                {

                    listaItems[contadorArray] = palabra;
                    palabra = "";
                    contadorArray++;
                    contadorCadena++;
                }
            }
        }

        void limpiarListaItems()
        {
            for (int i =0; i< listaItems.Length;i++)
            {
                listaItems[i] = "";
            }
        }


        void CreaComponentes()
        {
            string[] Campos = logic.campos(tabla);
            string[] Tipos = logic.tipos(tabla);
            string[] LLaves = logic.llaves(tabla);
            int i = 0;
            int fin = Campos.Length;
            while (i < fin)
            {
                if (noCampos == 6 || noCampos == 11 || noCampos == 16 || noCampos == 21) { pos = 8; }
                if (noCampos >= 6 && noCampos < 10) { x = 300; }
                if (noCampos >= 11 && noCampos < 15) { x = 600; }
                if (noCampos >= 16 && noCampos < 20) { x = 900; }
                if (noCampos >= 21 && noCampos < 25) { x = 900; }
                Label lb = new Label();

                lb.Text = aliasC[i];

                Point p = new Point(x + pos, y * pos);
                lb.Location = p;
                lb.Name = "lb_" + Campos[i];
                lb.Font = fuente;
                lb.ForeColor = Cfuente;
                this.Controls.Add(lb);
                if (LLaves[i]=="PRI" && i!=0)
                {
                    LLaves[i] = "MUL";
                }

                switch (Tipos[i])
                {
                    case "int":
                        tipoCampo[noCampos - 1] = "Num";
                        if (LLaves[i] != "MUL") { crearTextBoxnumerico(Campos[i]); } else { crearComboBox(Campos[i]); }
                        
                        break;
                    case "varchar":
                        tipoCampo[noCampos - 1] = "Text";

                        if (LLaves[i] != "MUL")
                        { crearTextBoxvarchar(Campos[i]);} else { crearComboBox(Campos[i]); }
                break;
                    case "date":
                        tipoCampo[noCampos - 1] = "Text";
                        if (LLaves[i] != "MUL")
                        {crearDateTimePicker(Campos[i]);} else { crearComboBox(Campos[i]); }
                        break;
                    case "datetime":
                        tipoCampo[noCampos - 1] = "Text";
                        if (LLaves[i] != "MUL")
                        { crearDateTimePicker(Campos[i]); }
                        else { crearComboBox(Campos[i]); }
                        break;
                    case "text":
                        tipoCampo[noCampos - 1] = "Text";
                        if (LLaves[i] != "MUL")
                        { crearTextBoxvarchar(Campos[i]); }
                        else { crearComboBox(Campos[i]); }
                        break;
                    case "time":
                        tipoCampo[noCampos - 1] = "Text";
                        crearcampohora(Campos[i]);
                        break;

                    case "float":
                        tipoCampo[noCampos - 1] = "Text";
                        crearcampodecimales(Campos[i]);
                        break;

                    case "decimal":
                        tipoCampo[noCampos - 1] = "Text";
                        crearcampodecimales(Campos[i]);
                        break;

                    case "double":
                        tipoCampo[noCampos - 1] = "Text";
                        crearcampodecimales(Campos[i]);
                        break;



                    case "tinyint":
                        tipoCampo[noCampos - 1] = "Num";
                        if (LLaves[i] != "MUL")
                        {
                            crearBotonEstado(Campos[i]);
                        }
                        break;

                    default:

                        if (Tipos[i]!=null && Tipos[i] != "")
                        {
                            DialogResult validacion = MessageBox.Show("La tabla "+tabla+" posee un campo "+Tipos[i]+ ", este tipo de dato no es reconocido por el navegador\n Solucione este problema...", "Verificación de requisitos", MessageBoxButtons.OK);
                            if (validacion == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                        }
                        
                        break;
                }
                noCampos++;

                i++;
            }
        }
        void func_click(object sender, EventArgs e)
        {
            foreach (Control componente in Controls)
            {
                if (componente is Button)
                {
                    if (estado == 1)
                    {
                        componente.Text = "Activado";
                        componente.BackColor = Color.Green;
                        //estado++;
                        estado = 1;
                    }
                    else 
                    {
                        componente.Text = "Activado";
                        componente.BackColor = Color.Green;
                        //estado++;
                        estado = 1;
                    }
                   /* else
                    {
                        componente.Text = "Desactivado";
                        componente.BackColor = Color.Red;
                        //estado--;
                        estado = 1
                    }
                    if(estado == 0)
                    {
                        componente.Text = "Activado";
                        componente.BackColor = Color.Green;
                        //estado++;
                        estado = 1;
                    }
                    else
                    {

                        componente.Text = "Activado";
                        componente.BackColor = Color.Green;
                        //estado++;
                        estado = 0;
                    }*/
                  
                }
            }
        }
        void crearBotonEstado(String nom)
        {
            Button btn = new Button();
            Point p = new Point(x + 125 + pos, y * pos);
            btn.Location = p;
            btn.Text = "Activado";
            btn.BackColor = Color.Green;
            btn.Click += new EventHandler(func_click);
            btn.Name = nom;
            btn.Enabled = false;
            this.Controls.Add(btn);
            pos++;
        }
        void crearTextBoxnumerico(String nom)
        {

          
            TextBox tb = new TextBox();
            Point p = new Point(x + 125 + pos, y * pos);
            tb.Location = p;
            tb.Name = nom;
            this.Controls.Add(tb);
            tb.KeyPress += Paravalidarnumeros_KeyPress;
            this.KeyPress += Paravalidarnumeros_KeyPress;
            //+= new System.Windows.Forms.KeyPressEventHandler(this.Txt_telefono_KeyPress);
            pos++;

        }

        void crearTextBoxvarchar(String nom)
        {

  
            TextBox tb = new TextBox();
            Point p = new Point(x + 125 + pos, y * pos);
            tb.Location = p;
            tb.Name = nom;
            this.Controls.Add(tb);
            tb.KeyPress += Paravalidarvarchar_KeyPress;
            this.KeyPress += Paravalidarvarchar_KeyPress;      
            pos++;

        }
        void crearTextBoxtexto(String nom)
        {

            TextBox tb = new TextBox();
            Point p = new Point(x + 125 + pos, y * pos);
            tb.Location = p;
            tb.Name = nom;
            this.Controls.Add(tb);
            tb.KeyPress += Paravalidartexto_KeyPress;
            this.KeyPress += Paravalidartexto_KeyPress;          
            pos++;

        }

        void crearcampohora(String nom)
        {
            TextBox tb = new TextBox();
            Point p = new Point(x + 125 + pos, y * pos);
            tb.Location = p;
            tb.Name = nom;
            this.Controls.Add(tb);
            tb.KeyPress += Paravalidarhora_KeyPress;
            this.KeyPress += Paravalidarhora_KeyPress;
            //+= new System.Windows.Forms.KeyPressEventHandler(this.Txt_telefono_KeyPress);
            pos++;
        }

       
        void crearcampodecimales(String nom)
        {
            TextBox tb = new TextBox();
            Point p = new Point(x + 125 + pos, y * pos);
            tb.Location = p;
            tb.Name = nom;
            this.Controls.Add(tb);
            tb.KeyPress += Paravalidardecimales_KeyPress;
            this.KeyPress += Paravalidardecimales_KeyPress;
            //+= new System.Windows.Forms.KeyPressEventHandler(this.Txt_telefono_KeyPress);
            pos++;


        }

        private void Paravalidardecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.Camposdecimales(e);
        }

        private void Paravalidarnumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.CamposNumericos(e);
        }

        private void Paravalidarhora_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.CamposHora(e);
        }

        private void Paravalidarvarchar_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.CamposVchar(e);
        }
        private void Paravalidartexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.CamposLetras(e);
        }
        private void Paravalidacombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.Combobox(e);
        }

        void crearComboBox(String nom)
        {
            string[] items;
            if (noComboAux == posCombo)
            {
                items = listaItems;
                noComboAux++;
             
            }
            else
            {

                if (tablaCombo[noComboAux] != null)
                {
                    items = logic.items(tablaCombo[noComboAux], campoCombo[noComboAux]);
                    if (noCombo > noComboAux) { noComboAux++; }

                }
                else
                {
                    items = logic.items("Peliculas", "idPelicula");
                    if (noCombo > noComboAux) { noComboAux++; }
                }
            }
            int combols = 0;
            bool comboVacio = true;
            while (combols<items.Length)
            {
                if (items[combols]!="" && items[combols] !=null)
                {
                    comboVacio = false;
                }
                combols++;
            }

            if (comboVacio!=false)
            {
                DialogResult validacion = MessageBox.Show("La tabla " + tabla + "No tiene registros en el campo asociado al comboBox\n Solucione este problema...", "Verificación de requisitos", MessageBoxButtons.OK);
                if (validacion == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
          
            ComboBox cb = new ComboBox();
            Point p = new Point(x + 125 + pos, y * pos);
            cb.Location = p;
            cb.Name = nom;
            cb.Sorted = true;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i]!="")
                    {
                        cb.Items.Add(items[i]);
                    }
                }

            }

            this.Controls.Add(cb);
            cb.KeyPress += Paravalidacombo_KeyPress;
            this.KeyPress += Paravalidacombo_KeyPress;
            pos++;
            
        }

  
        void crearDateTimePicker(String nom)
        {
            DateTimePicker dtp = new DateTimePicker();
            Point p = new Point(x + 125 + pos, y * pos);
            dtp.Location = p;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd";
            dtp.Width = 100;
            dtp.Name = nom;
            this.Controls.Add(dtp);
            pos++;
        }

        public void deshabilitarcampos_y_botones()
        {
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    componente.Enabled = false; //De esta menera bloqueamos todos los textbox por si solo quiere ver los registros

                }

            }
            Btn_Modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_Guardar.Enabled = false;
            Btn_Cancelar.Enabled = false;

        }

        public void habilitarcampos_y_botones()
        {
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    componente.Enabled = true; //De esta menera bloqueamos todos los textbox por si solo quiere ver los registros

                }

            }
            Btn_Modificar.Enabled = true;
            Btn_Eliminar.Enabled = true;
            Btn_Guardar.Enabled = true;
            Btn_Cancelar.Enabled = true;

        }

        public void actualizardatagriew()
        {
            DataTable dt = logic.consultaLogica(tabla);
            dataGridView1.DataSource = dt;
            int head = 0;
            while (head < logic.contarCampos(tabla))
            {
                dataGridView1.Columns[head].HeaderText = aliasC[head];
                head++;
            }
        }

        string crearDelete()// crea el query de delete
        {
            //Cambiar el estadoPelicula por estado
            string query = "UPDATE " + tabla + " SET estado=0";
            string whereQuery = " WHERE  ";
            int posCampo = 0;
			int i = 0;
            string campos = "";

            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    if (posCampo == 0)
                    {
                        switch (tipoCampo[posCampo])
                        {
                            case "Text":
								if (componente is ComboBox)
								{

									if (modoCampoCombo[i] == 1)
									{
										whereQuery += componente.Name + " = '" + logic.llaveCampolo(tablaCombo[i], campoCombo[i], componente.Text) + "' , ";
									}
									else
									{
										whereQuery += componente.Name + " = '" + componente.Text + "' , ";
									}

									i++;
								}
								else
								{
									whereQuery += componente.Name + " = '" + componente.Text + "' , ";
								}

								
                                break;
                            case "Num":
								if (componente is ComboBox)
								{

									if (modoCampoCombo[i] == 1)
									{
										whereQuery += componente.Name + " = " + logic.llaveCampolo(tablaCombo[i], campoCombo[i], componente.Text);
										 
									}
									else
									{
										whereQuery += componente.Name + " = " + componente.Text;
									}

									i++;
								}
								else
								{
									whereQuery += componente.Name + " = " + componente.Text;
								}
								
                                break;
                        }
						
                    }
                    posCampo++;
                }

            }
            campos = campos.TrimEnd(' ');
            campos = campos.TrimEnd(',');
			whereQuery = whereQuery.TrimEnd(' ');
			whereQuery = whereQuery.TrimEnd(',');
			//query += campos + whereQuery + ";";
			query += whereQuery + ";";
			Console.Write(query);
            sn.insertarBitacora(idUsuario, "Se eliminó un registro", tabla);
            return query;
        }

        string crearInsert()// crea el query de insert
        {
            string query = "INSERT INTO " + tabla + " VALUES (";
            int posCampo = 0;
			int i = 0;
            string campos = "";
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox )
                {

                    switch (tipoCampo[posCampo])
                    {
                        case "Text":
							if (componente is ComboBox)
							{

								if (modoCampoCombo[i] == 1)
								{
									campos += "'" + logic.llaveCampolo(tablaCombo[i],campoCombo[i],componente.Text) + "' , ";
								}
								else
								{
									campos += "'" + componente.Text + "' , ";
								}

								i++;
							}
							else
							{
								campos += "'" + componente.Text + "' , ";
							}
						

							break;
                        case "Num":
							if (componente is ComboBox)
							{

								if (modoCampoCombo[i] == 1)
								{
									campos +=  logic.llaveCampolo(tablaCombo[i], campoCombo[i], componente.Text) + " , ";
								}
								else
								{
									campos += componente.Text + " , ";
								}

								i++;
							}
							else
							{
								campos += componente.Text + " , ";
							}
						


                            break;
                    }
                    posCampo++;

                }
                if (componente is Button)
                {
                    switch (tipoCampo[posCampo])
                    {
                        case "Num":
                            campos += "'" + estado + "' , ";
                           // campos += "' 0 ' , ";
                            break;
                          
                    }
                    posCampo++;
                }

            }
            campos = campos.TrimEnd(' ');
            campos = campos.TrimEnd(',');
            query += campos + ");";
            sn.insertarBitacora(idUsuario, "Se creó un nuevo registro", tabla);
            return query;
        }


        string crearUpdate()// crea el query de update
        {
            string query = "UPDATE " + tabla + " SET ";
            string whereQuery = " WHERE  ";
            int posCampo = 0;
			int i = 0;
            string campos = "";
            string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {

                    if (posCampo > 0)
                    {
                        switch (tipoCampo[posCampo])
                        {
                            case "Text":
								if (componente is ComboBox)
								{

									if (modoCampoCombo[i] == 1)
									{
										campos += componente.Name + " = '" + logic.llaveCampolo(tablaCombo[i], campoCombo[i], componente.Text) + "' , ";
									}
									else
									{
										campos += componente.Name + " = '" + componente.Text + "' , ";
									}

									i++;
								}
								else
								{
									campos += componente.Name + " = '" + componente.Text + "' , ";
								}
							
                                break;
                            case "Num":
								if (componente is ComboBox)
								{

									if (modoCampoCombo[i] == 1)
									{
										campos += componente.Name + " = " + logic.llaveCampolo(tablaCombo[i], campoCombo[i], componente.Text) + " , ";
									}
									else
									{
										campos += componente.Name + " = " + componente.Text + " , ";
									}

									i++;
								}
								else
								{
									campos += componente.Name + " = " + componente.Text + " , ";
								}
                                break;
                        }
                    }
                    else
                    {
						if (tipoCampo[0]=="Text")
						{
							if (componente is ComboBox)
							{

								if (modoCampoCombo[i] == 1)
								{
									campos += componente.Name + " = '" + logic.llaveCampolo(tablaCombo[i], campoCombo[i], componente.Text) + "' , ";
								}
								else
								{
									campos += componente.Name + " = '" + componente.Text + "' , ";
								}

								i++;
							}
							else
							{
								campos += componente.Name + " = '" + componente.Text + "' , ";
							}
						}
                        switch (tipoCampo[posCampo])
                        {
                            case "Text":
								if (componente is ComboBox)
								{

									if (modoCampoCombo[i] == 1)
									{
										whereQuery += componente.Name + " = '" + logic.llaveCampolo(tablaCombo[i], campoCombo[i], dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'";
										 
									}
									else
									{
										whereQuery += componente.Name + " = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString()+ "'";
									}

									i++;
								}
								else
								{
									whereQuery += componente.Name + " = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString()+ "'";
								}
								
                                break;
                            case "Num":
								if (componente is ComboBox)
								{

									if (modoCampoCombo[i] == 1)
									{
										whereQuery += componente.Name + " = " + logic.llaveCampolo(tablaCombo[i], campoCombo[i], componente.Text);

									}
									else
									{
										whereQuery += componente.Name + " = " + componente.Text;
									}

									i++;
								}
								else
								{
									whereQuery += componente.Name + " = " + componente.Text;
								}
								
                                break;
                        }
                       

                    }
                    posCampo++;                
                }
                if (componente is Button)
                {
                    switch (tipoCampo[posCampo])
                    {
                        
                        case "Num":
                            string var2 = dataGridView1.CurrentRow.Cells[posCampo].Value.ToString();
                            campos += componente.Name + " = '" + estado + "' , ";

                            break;

                    }
                    posCampo++;
                }




            }
            campos = campos.TrimEnd(' ');
            campos = campos.TrimEnd(',');
            query += campos + whereQuery + ";";
            //contenido.Text = query;
            sn.insertarBitacora(idUsuario, "Se actualizó un registro", tabla);
            return query;
        }

        public void guardadoforsozo()
        {
            logic.nuevoQuery(crearInsert());
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    componente.Enabled = true;
                    componente.Text = "";

                }

            }
            actualizardatagriew();
        }

        public void habilitarallbotones()//habilita todos los botnes
        {
            Btn_Guardar.Enabled = true;
            Btn_Ingresar.Enabled = true;
            Btn_Modificar.Enabled = true;
            Btn_Cancelar.Enabled = false;
            Btn_Eliminar.Enabled = true;

        }




        //-----------------------------------------------Funcionalidad de Botones-----------------------------------------------//

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            string[] Tipos = logic.tipos(tabla);

            //codigo para aplicar el autoincrementable             
            string[] Extras = logic.extras(tabla);
            bool tipoInt = false;
            bool ExtraAI = false;
			string auxId = "";
			int auxLastId = 0;

			if (Tipos[0] == "int")
            {
                tipoInt = true;
				if (Extras[0] == "auto_increment")
				{
					ExtraAI = true;
					 auxId = (logic.lastID(tabla));
					auxLastId = Int32.Parse(auxId);

				}
			}
           

            activar = 2;
            habilitarcampos_y_botones();        

            foreach (Control componente in Controls)
            {
                if (componente is TextBox && tipoInt && ExtraAI)
                {
					//MessageBox.Show("El ID nuevo será: " + (auxLastId + 1));
					auxLastId += 1;
                    componente.Text = auxLastId.ToString();
                    componente.Enabled = false;
                    tipoInt = false;
                    ExtraAI = false;
                }
                else if (componente is TextBox || componente is DateTimePicker || componente is ComboBox )
                {
                    componente.Enabled = true;
                    componente.Text = "";
                }
                else if (componente is Button)
                {
                    componente.Enabled = true;
                   
                }

                Btn_Ingresar.Enabled = false;
                Btn_Modificar.Enabled = false;
                Btn_Eliminar.Enabled = false;
                Btn_Cancelar.Enabled = true;
            }

            //habilitar y deshabilitar según Usuario => Randy
            botonesYPermisos();
            Btn_Ingresar.Enabled = false;
            Btn_Guardar.Enabled = true;
            Btn_Modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;           
            Btn_Cancelar.Enabled = true;
            Btn_Consultar.Enabled = false;
            Btn_Imprimir.Enabled = false;
            Btn_Refrescar.Enabled = false;            

        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            habilitarcampos_y_botones();
            activar = 1;
            int i = 0;
			string[] Tipos = logic.tipos(tabla);
			int numCombo = 0;
			foreach (Control componente in Controls)
			{
				if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
				{
					if (i == 0 && Tipos[0]=="int")
					{
						componente.Enabled = false;
					}
					if (componente is ComboBox)
					{
						if (modoCampoCombo[numCombo] == 1)
						{
							componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

						}
						else
						{
							componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						}

						numCombo++;
					}
					else
					{
						componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
					}

					i++;
				}
				if (componente is Button)
				{
                    componente.Enabled = true;
                    string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                    
					if (var1 == "0")
					{
						componente.Text = "Desactivado";
						componente.BackColor = Color.Red;
                        estado = 0;
					}
					if (var1 == "1")
					{
						componente.Text = "Activado";
						componente.BackColor = Color.Green;
                        estado = 1;
					}
					componente.Enabled = true;

				}
			}


			//habilitar y deshabilitar según Usuario
			botonesYPermisos();

            Btn_Ingresar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_Modificar.Enabled = false;
            Btn_Consultar.Enabled = false;
            Btn_Imprimir.Enabled = false;
            Btn_Refrescar.Enabled = false;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Btn_Modificar.Enabled = true;
            Btn_Guardar.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Ingresar.Enabled = true;
            Btn_Eliminar.Enabled = true;
            Btn_Refrescar.Enabled = true;

            actualizardatagriew();            
            if (logic.TestRegistros(tabla)>0)
            {
                int i = 0;
				int numCombo = 0;
				foreach (Control componente in Controls)
				{
					if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
					{
						if (componente is ComboBox)
						{
							if (modoCampoCombo[numCombo] == 1)
							{
								componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

							}
							else
							{
								componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
							}

							numCombo++;
						}
						else
						{
							componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						}
						componente.Enabled = false;
						i++;
					}
					if (componente is Button)
					{
						string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						if (var1 == "0")
						{
							componente.Text = "Desactivado";
							componente.BackColor = Color.Red;
						}
						if (var1 == "1")
						{
							componente.Text = "Activado";
							componente.BackColor = Color.Green;
						}
						componente.Enabled = false;

					}
				}
			}

            //habilitar y deshabilitar según Usuario
            botonesYPermisos();            
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (presionado == false)
            {
                Btn_Guardar.Enabled = false;
                Btn_Modificar.Enabled = false;
                Btn_Eliminar.Enabled = true;
                Btn_Cancelar.Enabled = true;
                Btn_Ingresar.Enabled = false;
                presionado = true;
            }
            else
            {

                DialogResult Respuestamodieli;
                Respuestamodieli = MessageBox.Show("Desea eliminar el registro?", "Desea realizar la siguiente operación en el formulario  " + nomForm + "?", MessageBoxButtons.YesNo);
                if (Respuestamodieli == DialogResult.Yes)
                {
                    logic.nuevoQuery(crearDelete());
                    actualizardatagriew();
                    Btn_Modificar.Enabled = true;
                    Btn_Guardar.Enabled = false;
                    Btn_Cancelar.Enabled = false;
                    Btn_Eliminar.Enabled = true;
                    Btn_Ingresar.Enabled = true;
                    presionado = false;

                }
                else if (Respuestamodieli == DialogResult.No)
                {
                    Btn_Guardar.Enabled = false;
                    Btn_Modificar.Enabled = false;
                    Btn_Eliminar.Enabled = true;
                    Btn_Cancelar.Enabled = true;
                    Btn_Ingresar.Enabled = false;
                    presionado = true;

                }
                // presionado = false;
            }
            //habilitar y deshabilitar según Usuario
            botonesYPermisos();
            presionado = true;            
        }

        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
			//DLL DE CONSULTAS
			sentencia con = new sentencia();
			bool per1 = con.consultarPermisos(idUsuario, idAplicacion, 1);
			bool per2 = con.consultarPermisos(idUsuario, idAplicacion, 2);
			bool per3 = con.consultarPermisos(idUsuario, idAplicacion, 3);
			bool per4 = con.consultarPermisos(idUsuario, idAplicacion, 4);
			bool per5 = con.consultarPermisos(idUsuario, idAplicacion, 5);

			if (per1==true && per2 == true && per3 == true && per4 == true && per5 == true)
			{
				Compleja nuevo = new Compleja(idUsuario);
				nuevo.Show();
			}
			else
			{
				 Simple nueva = new Simple(idUsuario);
				nueva.Show();
			}

			//habilitar y deshabilitar según Usuario
			botonesYPermisos();
        }

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
			//DLL DE IMPRESION, FORATO DE REPORTES.
			string llave = "";
			if (idRepo!="")
			{
				llave= logic.ObtenerIdReporte(idRepo);
				
			}
			else
			{
				MessageBox.Show("No se asigno ningun reporte....");
			}
			
			if (llave!="")
			{
				Clientes cl = new Clientes(llave);
				cl.Show();
			}
			else
			{
				MessageBox.Show("El Id Asignado es incorrecto");
			}
			
            //habilitar y deshabilitar según Usuario
            botonesYPermisos();
        }

        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {           
            actualizardatagriew();
			//MessageBox.Show(logic.ObtenerIdModulo(idAplicacion)); Obtener ID modulo prueba
			int i=0;
			int numCombo = 0;
			foreach (Control componente in Controls)
			{
				if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
				{
					if (componente is ComboBox)
					{
						if (modoCampoCombo[numCombo] == 1)
						{
							componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

						}
						else
						{
							componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						}
						
						numCombo++;
					}
					else
					{
						componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
					}
					
					i++;
				}
				if (componente is Button)
				{
					string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
					if (var1 == "0")
					{
						componente.Text = "Desactivado";
						componente.BackColor = Color.Red;
					}
					if (var1 == "1")
					{
						componente.Text = "Activado";
						componente.BackColor = Color.Green;
					}
					componente.Enabled = false;

				}
			}
			//habilitar y deshabilitar según Usuario
			botonesYPermisos();            
        }

        private void Btn_Anterior_Click(object sender, EventArgs e)
        {
            int i = 0;
            string[] Campos = logic.campos(tabla);

            int fila = dataGridView1.SelectedRows[0].Index;
            if (fila > 0)
            {
                dataGridView1.Rows[fila - 1].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[fila - 1].Cells[0];

				int numCombo = 0;
				foreach (Control componente in Controls)
				{
					if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
					{
						if (componente is ComboBox)
						{
							if (modoCampoCombo[numCombo] == 1)
							{
								componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

							}
							else
							{
								componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
							}

							numCombo++;
						}
						else
						{
							componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						}

						i++;
					}
					if (componente is Button)
					{
						string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						if (var1 == "0")
						{
							componente.Text = "Desactivado";
							componente.BackColor = Color.Red;
						}
						if (var1 == "1")
						{
							componente.Text = "Activado";
							componente.BackColor = Color.Green;
						}
						componente.Enabled = false;

					}
				}
			}            
        }

        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            int i = 0;
                string[] Campos = logic.campos(tabla);

                int fila = dataGridView1.SelectedRows[0].Index;
                if (fila < dataGridView1.Rows.Count - 1)
                {
                    dataGridView1.Rows[fila + 1].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[fila + 1].Cells[0];

				int numCombo = 0;
				foreach (Control componente in Controls)
				{
					if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
					{
						if (componente is ComboBox)
						{
							if (modoCampoCombo[numCombo] == 1)
							{
								componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

							}
							else
							{
								componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
							}

							numCombo++;
						}
						else
						{
							componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						}

						i++;
					}
					if (componente is Button)
					{
						string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						if (var1 == "0")
						{
							componente.Text = "Desactivado";
							componente.BackColor = Color.Red;
						}
						if (var1 == "1")
						{
							componente.Text = "Activado";
							componente.BackColor = Color.Green;
						}
						componente.Enabled = false;

					}
				}

			}
        }

        private void Btn_FlechaFin_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0];

            int i = 0;
            string[] Campos = logic.campos(tabla);

            int fila = dataGridView1.SelectedRows[0].Index;
            if (fila < dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0];

				int numCombo = 0;
				foreach (Control componente in Controls)
				{
					if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
					{
						if (componente is ComboBox)
						{
							if (modoCampoCombo[numCombo] == 1)
							{
								componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

							}
							else
							{
								componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
							}

							numCombo++;
						}
						else
						{
							componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						}

						i++;
					}
					if (componente is Button)
					{
						string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						if (var1 == "0")
						{
							componente.Text = "Desactivado";
							componente.BackColor = Color.Red;
						}
						if (var1 == "1")
						{
							componente.Text = "Activado";
							componente.BackColor = Color.Green;
						}
						componente.Enabled = false;

					}
				}

			}
        }

        private void Btn_FlechaInicio_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];

            int i = 0;
            string[] Campos = logic.campos(tabla);

            int fila = dataGridView1.SelectedRows[0].Index;
            if (fila < dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];


				int numCombo = 0;
				foreach (Control componente in Controls)
				{
					if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
					{
						if (componente is ComboBox)
						{
							if (modoCampoCombo[numCombo] == 1)
							{
								componente.Text = logic.llaveCampoRev(tablaCombo[numCombo], campoCombo[numCombo], dataGridView1.CurrentRow.Cells[i].Value.ToString());

							}
							else
							{
								componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
							}

							numCombo++;
						}
						else
						{
							componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						}

						i++;
					}
					if (componente is Button)
					{
						string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						if (var1 == "0")
						{
							componente.Text = "Desactivado";
							componente.BackColor = Color.Red;
						}
						if (var1 == "1")
						{
							componente.Text = "Activado";
							componente.BackColor = Color.Green;
						}
						componente.Enabled = false;

					}
				}


			}

        }

        private void Btn_Ayuda_Click(object sender, EventArgs e)
        {                    
            Help.ShowHelp(this, AsRuta, AsIndice);//Abre el menu de ayuda HTML            
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Guardar.Enabled == true && Btn_Cancelar.Enabled == true && Btn_Eliminar.Enabled == false && Btn_Modificar.Enabled == false && Btn_Ingresar.Enabled == false && Btn_Eliminar.Enabled == false)
                foreach (Control componente in Controls)
                {

                    if (componente.Text != "" && componente is TextBox)
                    {
                        //Opcion cuando esta guardando y queiere salir sin finalizar //
                        DialogResult Respuestagua;
                        Respuestagua = MessageBox.Show("Se ha detectado una operacion de guardado ¿Desea Guardar los datos? ", "Usted se enuentra abandonando el formulario " + nomForm + "", MessageBoxButtons.YesNoCancel);
                        if (Respuestagua == DialogResult.Yes)
                        {
                            guardadoforsozo();
                            cerrar.Visible = false;
                        }
                        else if (Respuestagua == DialogResult.No)
                        {
                            cerrar.Visible = false;
                        }
                        else if (Respuestagua == DialogResult.Cancel)
                        {
                            return;
                        }

                        //------------------------------------------------------------------------------------------------------//
                    }
                }


            //Opcion cuando esta #modificando# o eliminando y queiere salir sin finalizar //
            if (Btn_Modificar.Enabled == true && Btn_Guardar.Enabled == true && Btn_Cancelar.Enabled == true && Btn_Ingresar.Enabled == false)
            {

                foreach (Control componente in Controls)
                {

                    if (componente.Text != "" && componente is TextBox)
                    {

                        DialogResult Respuestamodieli;
                        Respuestamodieli = MessageBox.Show("Se ha detectado una operacion de Modificado ¿Desea regresar? ", "Usted se enuentra abandonando el formulario " + nomForm + "", MessageBoxButtons.YesNoCancel);
                        if (Respuestamodieli == DialogResult.Yes)
                        {
                            return;
                        }
                        else if (Respuestamodieli == DialogResult.No)
                        {
                            cerrar.Visible = false;
                        }
                        else if (Respuestamodieli == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
            }

            //------------------------------------------------------------------------------------------------------//
            //Opcion cuando esta modificando o #eliminando# y queiere salir sin finalizar //
            if (Btn_Eliminar.Enabled == true && Btn_Cancelar.Enabled == true && Btn_Modificar.Enabled == false && Btn_Guardar.Enabled == false && Btn_Ingresar.Enabled == false)
            {
                foreach (Control componente in Controls)
                {
                    if (componente.Text != "" && componente is TextBox)
                    {
                        DialogResult Respuestamodieli;
                        Respuestamodieli = MessageBox.Show("Se ha detectado una operacion de Eliminado ¿Desea regresar? ", "Usted se enuentra abandonando el formulario " + nomForm + "", MessageBoxButtons.YesNoCancel);
                        if (Respuestamodieli == DialogResult.Yes)
                        {
                            return;
                        }
                        else if (Respuestamodieli == DialogResult.No)
                        {
                            cerrar.Visible = false;
                        }
                        else if (Respuestamodieli == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
            }




            cerrar.Visible = false;
            //---------------------------------------------------------------------------------//

        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            bool lleno =true;
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    if (componente.Text=="")
                    {
                        lleno = false;
                    }
                }

            }
            if (lleno==true)
            {
                switch (activar)
                {
                    case 1:
                        logic.nuevoQuery(crearUpdate());
                        break;
                    case 2:
                        logic.nuevoQuery(crearInsert());
                        Btn_Anterior.Enabled = true;
                        Btn_Siguiente.Enabled = true;
                        Btn_FlechaInicio.Enabled = true;
                        Btn_FlechaFin.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Por favor llene todos los campos...");
            }
           
            actualizardatagriew();            
            if (logic.TestRegistros(tabla)>0)
            {
                int i = 0;
                foreach (Control componente in Controls)
                {
                    if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                    {
                        componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
						componente.Enabled = false;
						i++;
                    }

                }
            }
           
            deshabilitarcampos_y_botones();
           
            Btn_Guardar.Enabled = false;
            Btn_Eliminar.Enabled = true;
            Btn_Cancelar.Enabled = false;
            Btn_Modificar.Enabled = true;
            Btn_Ingresar.Enabled = true;
            Btn_Refrescar.Enabled = true;            

            //habilitar y deshabilitar según Usuario
            botonesYPermisos();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                    i++;
                }
                if (componente is Button)
                {
                    string var1 = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                    if (var1 == "0")
                    {
                        componente.Text = "Desactivado";
                        componente.BackColor = Color.Red;
                    }
                    if (var1 == "1")
                    {
                        componente.Text = "Activado";
                        componente.BackColor = Color.Green;
                    }
                }

            }
        }

        private void Contenido_Click(object sender, EventArgs e)
        {

        }

         /*
                try
                {
                    sentencia sen = new sentencia();                                        
                    if (sen.consultarPermisos(idUsuario, idAplicacion, 1) == true)
                    {
                        Btn_Ingresar.Enabled = true;
                    }
                    else
                    {
                        Btn_Ingresar.Enabled = false;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error en el Void Registros. Favor llamar Administrador. Error: " + ex);
                } 
            if (logic.TestRegistros(tabla)<=0)
            {                
                Btn_Anterior.Enabled = false;
                Btn_Siguiente.Enabled = false;
                Btn_FlechaInicio.Enabled = false;
                Btn_FlechaFin.Enabled = false;
                Btn_Ingresar.Enabled = false;
                Btn_Modificar.Enabled = false;
                Btn_Eliminar.Enabled = false; 
            }
            else
            {
                Btn_Anterior.Enabled = true;
                Btn_Siguiente.Enabled = true;
                Btn_FlechaInicio.Enabled = true;
                Btn_FlechaFin.Enabled = true;
                Btn_Modificar.Enabled = true;
                Btn_Eliminar.Enabled = true;                
            } */

        public void botonesYPermisos()
        {
            try
            {
                if (logic.TestRegistros(tabla) <= 0)
                {                    
                    Btn_Ingresar.Enabled = false;
                    Btn_Modificar.Enabled = false;
                    Btn_Guardar.Enabled = false;
                    Btn_Cancelar.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                    Btn_Consultar.Enabled = false;
                    Btn_Imprimir.Enabled = false;
                    Btn_Refrescar.Enabled = false;
                    Btn_FlechaInicio.Enabled = false;
                    Btn_Anterior.Enabled = false;
                    Btn_Siguiente.Enabled = false;                    
                    Btn_FlechaFin.Enabled = false;
                    MessageBox.Show("Tabla Vacía! Debe ingresa registros!");
                    try
                    {
                        sentencia sent = new sentencia();
                        if (sent.consultarPermisos(idUsuario, idAplicacion, 1) == true)
                        {
                            MessageBox.Show("Si tiene permisos para ingresar");
                            Btn_Ingresar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("NO tiene permisos paraINGRESAR");
                        }
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Estamos en Tabla Vacía! Determinanos si el usuario Activo puede ingresar! ERROR: " + exx);
                    }
                }
                else
                {
                    //validamos con TRY CATCH por si llegará a existir un problema 
                    try
                    {
                        sentencia sen = new sentencia();
                        string[] permisosText = { "INGRESAR", "CONSULTAR", "MODIFICAR", "ELIMINAR", "IMPRIMIR" };
                        for (int i = 1; i < 6; i++)
                        {
                            if (sen.consultarPermisos(idUsuario, idAplicacion, i) == true)
                            {
                                //mostramos un mensaje para indicar que si tiene permiso
                                //MessageBox.Show("Tiene permiso para " + permisosText[i - 1]);
                                //bloqueamos botones
                                switch (permisosText[i - 1])
                                {
                                    case "INGRESAR":
                                        Btn_Ingresar.Enabled = true; break;
                                    case "CONSULTAR":
                                        Btn_Consultar.Enabled = true; break;
                                    case "MODIFICAR":
                                        Btn_Modificar.Enabled = true; break;
                                    case "ELIMINAR":
                                        Btn_Eliminar.Enabled = true; break;
                                    case "IMPRIMIR":
                                        Btn_Imprimir.Enabled = true; break;
                                    default:
                                        MessageBox.Show("Entro al case default! TIENE PERMISO! Por favor hablar con Administrador!"); break;
                                }
                            }
                            else
                            {
                                //MessageBox.Show("No tiene permiso para " + permisosText[i - 1]);
                                switch (permisosText[i - 1])
                                {
                                    case "INGRESAR":
                                        Btn_Ingresar.Enabled = false; break;
                                    case "CONSULTAR":
                                        Btn_Consultar.Enabled = false; break;
                                    case "MODIFICAR":
                                        Btn_Modificar.Enabled = false; break;
                                    case "ELIMINAR":
                                        Btn_Eliminar.Enabled = false; break;
                                    case "IMPRIMIR":
                                        Btn_Imprimir.Enabled = false; break;
                                    default:
                                        MessageBox.Show("Entro al case default! NO TIENE PERMISO! Por favor hablar con Administrador!"); break;
                                }
                            }
                            /* 1 ingresar - 2 consultar - 3 modificar - 4 eliminar - 5 imprimir */
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Surgió el siguiente problema: " + ex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error General en Botones y Permisos. ERROR: " + ex);
            }
        }

        public void botonesYPermisosInicial(string userActivo, string appActivo)
        {
            try
            {
                if (logic.TestRegistros(tabla) <= 0)
                {
                    Btn_Ingresar.Enabled = false;
                    Btn_Modificar.Enabled = false;
                    Btn_Guardar.Enabled = false;
                    Btn_Cancelar.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                    Btn_Consultar.Enabled = false;
                    Btn_Imprimir.Enabled = false;
                    Btn_Refrescar.Enabled = false;
                    Btn_FlechaInicio.Enabled = false;
                    Btn_Anterior.Enabled = false;
                    Btn_Siguiente.Enabled = false;
                    Btn_FlechaFin.Enabled = false;
                    MessageBox.Show("Tabla Vacía! Debe ingresar un registro!");
                    try
                    {
                        sentencia sent = new sentencia();
                        if (sent.consultarPermisos(userActivo, appActivo, 1) == true)
                        {
                            MessageBox.Show("Tabla Vacía! SI puede INGRESAR");
                            Btn_Ingresar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Tabla Vacía! NO puede INGRESAR");
                        }
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Estamos en Tabla Vacía! Determinanos si el usuario Activo puede ingresar! ERROR: " + exx);
                    }
                }
                else
                {
                    //validamos con TRY CATCH por si llegará a existir un problema 
                    try
                    {
                        sentencia sen = new sentencia();
                        string[] permisosText = { "INGRESAR", "CONSULTAR", "MODIFICAR", "ELIMINAR", "IMPRIMIR" };
                        for (int i = 1; i < 6; i++)
                        {
                            if (sen.consultarPermisos(userActivo, appActivo, i) == true)
                            {
                                //mostramos un mensaje para indicar que si tiene permiso
                                //MessageBox.Show("Tiene permiso para " + permisosText[i - 1]);
                                //bloqueamos botones
                                switch (permisosText[i - 1])
                                {
                                    case "INGRESAR":
                                        Btn_Ingresar.Enabled = true; break;
                                    case "CONSULTAR":
                                        Btn_Consultar.Enabled = true; break;
                                    case "MODIFICAR":
                                        Btn_Modificar.Enabled = true; break;
                                    case "ELIMINAR":
                                        Btn_Eliminar.Enabled = true; break;
                                    case "IMPRIMIR":
                                        Btn_Imprimir.Enabled = true; break;
                                    default:
                                        MessageBox.Show("Entro al case default! TIENE PERMISO! Por favor hablar con Administrador!"); break;
                                }
                            }
                            else
                            {
                                //MessageBox.Show("No tiene permiso para " + permisosText[i - 1]);
                                switch (permisosText[i - 1])
                                {
                                    case "INGRESAR":
                                        Btn_Ingresar.Enabled = false; break;
                                    case "CONSULTAR":
                                        Btn_Consultar.Enabled = false; break;
                                    case "MODIFICAR":
                                        Btn_Modificar.Enabled = false; break;
                                    case "ELIMINAR":
                                        Btn_Eliminar.Enabled = false; break;
                                    case "IMPRIMIR":
                                        Btn_Imprimir.Enabled = false; break;
                                    default:
                                        MessageBox.Show("Entro al case default! NO TIENE PERMISO! Por favor hablar con Administrador!"); break;
                                }
                            }
                            /* 1 ingresar - 2 consultar - 3 modificar - 4 eliminar - 5 imprimir */
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Surgió el siguiente problema: " + ex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error General en Botones y Permisos Inicial. ERROR: " + ex);
            }

        }

        private void Btn_Ayuda_Click_1(object sender, EventArgs e)
        {
            Help.ShowHelp(this, AsRuta, AsIndice);//Abre el menu de ayuda HTML     
        }

        private void Btn_MasAyuda_Click(object sender, EventArgs e)
        {
            string AyudaOK = logic.TestTabla("ayuda");
            if (AyudaOK == "")
            {
                Ayudas nuevo = new Ayudas();
                nuevo.Show();
            }
            else
            {
                DialogResult validacion = MessageBox.Show(AyudaOK +" \n Solucione este error para continuar...", "Verificación de requisitos", MessageBoxButtons.OK);
                if (validacion == DialogResult.OK)
                {
                    
                }
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LblTabla_Click(object sender, EventArgs e)
        {

        }
    }
}
