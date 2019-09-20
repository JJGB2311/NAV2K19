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
        int estado = 0;
        Color Cfuente = Color.White;
        Color nuevoColor = Color.White;
        bool presionado = false;
        sentencia sn = new sentencia(); //objeto del componente de seguridad para obtener el método de la bitácora
        string idUsuario = "";
        string idyuda;
        string AsRuta;
        string AsIndice;
        Font fuente = new Font("Century Gothic", 13.0f, FontStyle.Regular, GraphicsUnit.Pixel); //objeto para definir el tipo y tamaño de fuente de los labels
        public Navegador()
        {
            InitializeComponent();
            limpiarListaItems();
           

        }

        private void Navegador_Load(object sender, EventArgs e)
        {
            colorDialog1.Color = nuevoColor;
            this.BackColor = colorDialog1.Color;

            if (tabla != "def")
            {
                string TablaOK = logic.TestTabla(tabla);
                if (TablaOK=="" && correcto ==0)
                {
                    string EstadoOK = logic.TestEstado(tabla);
                    if (EstadoOK == "" && correcto == 0)
                    {
                        int i = 0;
                        DataTable dt = logic.consultaLogica(tabla);
                        dataGridView1.DataSource = dt;
                        CreaComponentes();
                        deshabilitarcampos_y_botones();
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        if (logic.TestRegistros(tabla) > 0)
                        {
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
                                    if (var1 == "1")
                                    {
                                        componente.Text = "Desactivado";
                                        componente.BackColor = Color.Red;
                                    }
                                    if (var1 == "0")
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
                        DialogResult validacion = MessageBox.Show(EstadoOK + "\n Solucione este error para continuar...", "Verificación de requisitos", MessageBoxButtons.OK);
                        if (validacion == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }

                }
                else
                {
                    DialogResult validacion = MessageBox.Show(TablaOK + "\n Solucione este error para continuar...", "Verificación de requisitos" , MessageBoxButtons.OK);
                    if (validacion == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }

            }

        }

        //-----------------------------------------------Funciones-----------------------------------------------//
        public void ObtenerIdUsuario(string idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        private void registros()
        {
            if (logic.TestRegistros(tabla)<=0)
            {
                Btn_Anterior.Enabled = false;
                Btn_Siguiente.Enabled = false;
                Btn_FlechaInicio.Enabled = false;
                Btn_FlechaFin.Enabled = false;
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
            }
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
                idyuda = ayudar;
                AsRuta = logic.MRuta(idyuda);
                AsIndice = logic.MIndice(idyuda);
            }
            else
            {
                DialogResult validacion = MessageBox.Show(AyudaOK + ", Por favor incluyala", "Verificación de requisitos", MessageBoxButtons.OK);
                if (validacion == DialogResult.OK)
                {
                    correcto = 1;
                }
            }
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

        public void asignarComboConTabla(string tabla, string campo)
        {
            string TablaOK = logic.TestTabla(tabla);
            if (TablaOK == "")
            {
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

        bool verificarListaItems()
        {
            bool limpio = true;

            for (int i=0; i<listaItems.Length;i++)
            {
                if (listaItems[i]!="") { limpio = false; }
              
            }
            return limpio;
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
                    case "text":
                        tipoCampo[noCampos - 1] = "Text";
                        if (LLaves[i] != "MUL")
                        {crearTextBoxtexto(Campos[i]);} else { crearComboBox(Campos[i]); }
                break;
                    case "time":
                        tipoCampo[noCampos - 1] = "Text";
                        crearTextBoxvarchar(Campos[i]);       
                        break;

                    case "tinyint":
                        tipoCampo[noCampos - 1] = "Num";
                        if (LLaves[i] != "MUL")
                        {
                            crearBotonEstado(Campos[i]);
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
                        estado = 0;
                    }
                    else
                    {
                        componente.Text = "Desactivado";
                        componente.BackColor = Color.Red;
                        //estado--;
                        estado = 1;
                    }

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

        private void Paravalidarnumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.CamposNumericos(e);
        }
        private void Paravalidarvarchar_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.CamposNumerosYLetras(e);
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

            ComboBox cb = new ComboBox();
            Point p = new Point(x + 125 + pos, y * pos);
            cb.Location = p;
            cb.Name = nom;
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
        }

        string crearDelete()// crea el query de delete
        {
            //Cambiar el estadoPelicula por estado
            string query = "UPDATE " + tabla + " SET estado=1";
            string whereQuery = " WHERE  ";
            int posCampo = 0;
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
                                whereQuery += componente.Name + " = '" + componente.Text;
                                break;
                            case "Num":
                                whereQuery += componente.Name + " = " + componente.Text;
                                break;
                        }

                    }
                    posCampo++;
                }

            }
            campos = campos.TrimEnd(' ');
            campos = campos.TrimEnd(',');
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
            string campos = "";
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox )
                {

                    switch (tipoCampo[posCampo])
                    {
                        case "Text":
                            campos += "'" + componente.Text + "' , ";
                            break;
                        case "Num":
                            campos += componente.Text + " , ";
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
            string campos = "";
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {

                    if (posCampo > 0)
                    {
                        switch (tipoCampo[posCampo])
                        {
                            case "Text":
                                campos += componente.Name + " = '" + componente.Text + "' , ";
                                break;
                            case "Num":
                                campos += componente.Name + " = " + componente.Text + " , ";
                                break;
                        }
                    }
                    else
                    {
                        switch (tipoCampo[posCampo])
                        {
                            case "Text":
                                whereQuery += componente.Name + " = '" + componente.Text;
                                break;
                            case "Num":
                                whereQuery += componente.Name + " = " + componente.Text;
                                break;
                        }

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
            activar = 2;
            habilitarcampos_y_botones();
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    componente.Enabled = true;
                    componente.Text = "";
                  

                }
                if(componente is Button)
                {
                    componente.Enabled = true;
                }

                Btn_Ingresar.Enabled = false;
                Btn_Modificar.Enabled = false;
                Btn_Eliminar.Enabled = false;
                Btn_Cancelar.Enabled = true;
            }
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            habilitarcampos_y_botones();
            activar = 1;
            int i = 0;
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                    i++;
                }

            }
            Btn_Ingresar.Enabled = false;
            Btn_Eliminar.Enabled = false;
        
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Btn_Modificar.Enabled = true;
            Btn_Guardar.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Ingresar.Enabled = true;
            Btn_Eliminar.Enabled = true;

            actualizardatagriew();
            registros();
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
                    if (componente is Button)
                    {
                        componente.Enabled = false;
                    }

                }
            }
            

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
                logic.nuevoQuery(crearDelete());
                actualizardatagriew();
                Btn_Modificar.Enabled = true;
                Btn_Guardar.Enabled = false;
                Btn_Cancelar.Enabled = false;
                Btn_Ingresar.Enabled = true;
                presionado = false;
            }
            registros();
        }

        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            //DLL DE CONSULTAS
        }

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            //DLL DE IMPRESION, FORATO DE REPORTES.
        }

        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
           
            actualizardatagriew();
            registros();
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
                        if (var1 == "1")
                        {
                            componente.Text = "Desactivado";
                            componente.BackColor = Color.Red;
                        }
                        if (var1 == "0")
                        {
                            componente.Text = "Activado";
                            componente.BackColor = Color.Green;
                        }
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
                        if (var1 == "1")
                        {
                            componente.Text = "Desactivado";
                            componente.BackColor = Color.Red;
                        }
                        if (var1 == "0")
                        {
                            componente.Text = "Activado";
                            componente.BackColor = Color.Green;
                        }
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
                        if (var1 == "1")
                        {
                            componente.Text = "Desactivado";
                            componente.BackColor = Color.Red;
                        }
                        if (var1 == "0")
                        {
                            componente.Text = "Activado";
                            componente.BackColor = Color.Green;
                        }
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
                        if (var1 == "1")
                        {
                            componente.Text = "Desactivado";
                            componente.BackColor = Color.Red;
                        }
                        if (var1 == "0")
                        {
                            componente.Text = "Activado";
                            componente.BackColor = Color.Green;
                        }
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
                        Respuestamodieli = MessageBox.Show("Se ha detectado una operacion de Modificado ¿Desea regresar? ", "Usted se enuentra abandonando el formulario " + tabla + "", MessageBoxButtons.YesNoCancel);
                        if (Respuestamodieli == DialogResult.Yes)
                        {
                            return;
                        }
                        else if (Respuestamodieli == DialogResult.No)
                        {
                            Application.Exit();
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
                        Respuestamodieli = MessageBox.Show("Se ha detectado una operacion de Eliminado ¿Desea regresar? ", "Usted se enuentra abandonando el formulario " + tabla + "", MessageBoxButtons.YesNoCancel);
                        if (Respuestamodieli == DialogResult.Yes)
                        {
                            return;
                        }
                        else if (Respuestamodieli == DialogResult.No)
                        {
                            Application.Exit();
                        }
                        else if (Respuestamodieli == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
            }



            //------------------------------------------------------------------------------------------------------//
            // opcion de salir basica, cuando alguien solo esta visualizando los datos de formularios.//  
            DialogResult Respuestasimple;
            Respuestasimple = MessageBox.Show("Si desea salir presione el boton Aceptar de lo contrario presione Cancelar. ", "Usted se encuentra abandonando el formulario " + tabla + "", MessageBoxButtons.OKCancel);
            if (Respuestasimple == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
            //-----------------------------------------------------------------------------------------//


        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
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
            actualizardatagriew();
            registros();
            if (logic.TestRegistros(tabla)>0)
            {
                int i = 0;
                foreach (Control componente in Controls)
                {
                    if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                    {
                        componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
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

            registros();
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
                    if (var1 == "1")
                    {
                        componente.Text = "Desactivado";
                        componente.BackColor = Color.Red;
                    }
                    if (var1 == "0")
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
    }
}
