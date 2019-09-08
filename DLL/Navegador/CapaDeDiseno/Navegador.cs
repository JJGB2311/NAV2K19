using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace CapaDeDiseno
{
    public partial class Navegador : UserControl
    {
        Validaciones v = new Validaciones();
        logica logic = new logica();
        string tabla = "def";
        string sitio;
        int pos = 8;
        int noCampos = 1;
        int x = 30;
        int y = 30;
        int activar = 0;    //Variable para reconocer que funcion realizara el boton de guardar (1. Ingresar, 2. Modificar, 3. Eliminar)
        string[] tipoCampo = new string[30];
        string[] tablaCombo = new string[30];
        string[] campoCombo = new string[30];
        int noCombo = 0;
        int noComboAux = 0;
        public Navegador()
        {
            InitializeComponent();

        }
        bool presionado = false;

        private void Navegador_Load(object sender, EventArgs e)
        {
            if (tabla != "def")
            {
                int i=0;
                DataTable dt = logic.consultaLogica(tabla);
                dataGridView1.DataSource = dt;
                CreaComponentes();
                deshabilitarcampos_y_botones();
                Btn_Modificar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                foreach (Control componente in Controls)
                {
                    if (componente is TextBox || componente is DateTimePicker || componente is ComboBox )
                    {
                        componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                        i++;
                    }

                }
            }

        }

        //-----------------------------------------------Funciones-----------------------------------------------//
        public void asignarTabla(string table)
        {
            tabla = table;
        }
        public void asignarayuda(string sitiob)
        {
            sitio = sitiob;

        }
        public void asginarCombo(string tabla, string campo)
        {
            tablaCombo[noCombo] = tabla;
            campoCombo[noCombo] = campo;
            noCombo++;

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

                lb.Text = Campos[i];

                Point p = new Point(x + pos, y * pos);
                lb.Location = p;
                lb.Name = "lb_" + Campos[i];
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
                }
                noCampos++;

                i++;
            }
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

        void crearComboBox(String nom)
        {
            string[] items;
            if (tablaCombo[noComboAux] != null)
            {
                items = logic.items(tablaCombo[noComboAux], campoCombo[noComboAux]);
                if (noCombo > noComboAux) { noComboAux++; }
               
            }
            else
            {
                MessageBox.Show("NO " + noCombo.ToString());
                items = logic.items("Peliculas", "idPelicula");
                if (noCombo > noComboAux) { noComboAux++; }
            }

            ComboBox cb = new ComboBox();
            Point p = new Point(x + 125 + pos, y * pos);
            cb.Location = p;
            cb.Name = nom;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null) { cb.Items.Add(items[i]); }

            }

            this.Controls.Add(cb);
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
            string query = "UPDATE " + tabla + " SET estadoPelicula=1";
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
            return query;
        }

        string crearInsert()// crea el query de insert
        {
            string query = "INSERT INTO " + tabla + " VALUES (";
            int posCampo = 0;
            string campos = "";
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
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

            }
            campos = campos.TrimEnd(' ');
            campos = campos.TrimEnd(',');
            query += campos + ");";
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
            logic.nuevoQuery(crearInsert());
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                {
                    componente.Enabled = true;
                    componente.Text = "";
                  

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

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            logic.nuevoQuery(crearDelete());
                actualizardatagriew();
                presionado = false;
                Btn_Modificar.Enabled = true;
                Btn_Guardar.Enabled = false;
                Btn_Cancelar.Enabled = false;
                Btn_Ingresar.Enabled = true;
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
                while (i < dataGridView1.ColumnCount)
                {
                    foreach (Control componente in Controls)
                    {
                        if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                        {
                           componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                            i++;
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
                    while (i < dataGridView1.ColumnCount)
                    {
                        foreach (Control componente in Controls)
                        {
                            if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                            {
                                componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                                i++;
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
                while (i < dataGridView1.ColumnCount)
                {
                    foreach (Control componente in Controls)
                    {
                        if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                        {
                            componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                            i++;
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
                while (i < dataGridView1.ColumnCount)
                {

                    foreach (Control componente in Controls)
                    {
                        if (componente is TextBox || componente is DateTimePicker || componente is ComboBox)
                        {
                            componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                            i++;
                        }

                    }

                }
            }

        }

        private void Btn_Ayuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, " Página web ayuda/ayuda.chm", sitio);//Abre el menu de ayuda HTML
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Guardar.Enabled == true && Btn_Modificar.Enabled == false && Btn_Eliminar.Enabled == false)
                foreach (Control componente in Controls)
                {

                    if (componente.Text != "" && componente is TextBox)
                    {
                        //Opcion cuando esta guardando y queiere salir sin finalizar //
                        DialogResult Respuestagua;
                        Respuestagua = MessageBox.Show("Se ha detectado una operacion de guardado ¿Desea Guardar los datos? ", "Usted se enuentra abandonando el formulario " + tabla + "", MessageBoxButtons.YesNoCancel);
                        if (Respuestagua == DialogResult.Yes)
                        {
                            guardadoforsozo();
                        }
                        else if (Respuestagua == DialogResult.No)
                        {
                            Application.Exit();
                        }
                        else if (Respuestagua == DialogResult.Cancel)
                        {
                            return;
                        }

                        //------------------------------------------------------------------------------------------------------//
                    }
                }

   
            //Opcion cuando esta modificando o eliminando y queiere salir sin finalizar //
            if  (Btn_Modificar.Enabled == true  && Btn_Guardar.Enabled == false)
            {
                //|| Btn_Eliminar.Enabled == true && Btn_Cancelar.Enabled == true
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
            //Opcion cuando esta modificando o eliminando y queiere salir sin finalizar //
            if (Btn_Eliminar.Enabled == true && Btn_Guardar.Enabled == false)
            {
                //|| Btn_Eliminar.Enabled == true && Btn_Cancelar.Enabled == true
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
                    break;
                default:
                    break;
            }
            actualizardatagriew();
            int i = 0;
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker)
                {
                    componente.Text = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                    i++;
                }

            }
            deshabilitarcampos_y_botones();
           
            Btn_Guardar.Enabled = false;
            Btn_Eliminar.Enabled = true;
            Btn_Cancelar.Enabled = false;
            Btn_Modificar.Enabled = true;
            Btn_Ingresar.Enabled = true;
           
            
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

            }
        }

        private void Contenido_Click(object sender, EventArgs e)
        {

        }
    }
}
