namespace ConsultasInteligentes
{
    partial class ConsultaSencilla
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Creacion_Consulta = new System.Windows.Forms.TabControl();
            this.tb_creacion = new System.Windows.Forms.TabPage();
            this.Gpb_consultas = new System.Windows.Forms.GroupBox();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Btn_generar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Txt_query = new System.Windows.Forms.TextBox();
            this.Gpb_resultado = new System.Windows.Forms.GroupBox();
            this.Dgv_resultado = new System.Windows.Forms.DataGridView();
            this.Cpb_Tablas = new System.Windows.Forms.GroupBox();
            this.Btn_crearConsulta = new System.Windows.Forms.Button();
            this.Cbo_operador = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cbo_campo2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cbo_campo1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cbo_tabla = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Gpb_datos = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_descripsion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_nombre = new System.Windows.Forms.TextBox();
            this.tb_consulta = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DataGrid1 = new System.Windows.Forms.DataGridView();
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.Txt_mostrar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.Cbo_Query = new System.Windows.Forms.ComboBox();
            this.LblTabla = new System.Windows.Forms.Label();
            this.Creacion_Consulta.SuspendLayout();
            this.tb_creacion.SuspendLayout();
            this.Gpb_consultas.SuspendLayout();
            this.Gpb_resultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_resultado)).BeginInit();
            this.Cpb_Tablas.SuspendLayout();
            this.Gpb_datos.SuspendLayout();
            this.tb_consulta.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
            this.gbListado.SuspendLayout();
            this.SuspendLayout();
            // 
            // Creacion_Consulta
            // 
            this.Creacion_Consulta.Controls.Add(this.tb_creacion);
            this.Creacion_Consulta.Controls.Add(this.tb_consulta);
            this.Creacion_Consulta.Location = new System.Drawing.Point(3, 2);
            this.Creacion_Consulta.Name = "Creacion_Consulta";
            this.Creacion_Consulta.SelectedIndex = 0;
            this.Creacion_Consulta.Size = new System.Drawing.Size(794, 594);
            this.Creacion_Consulta.TabIndex = 0;
            this.Creacion_Consulta.Selected += new System.Windows.Forms.TabControlEventHandler(this.Creacion_Selected);
            this.Creacion_Consulta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Creacion_KeyDown);
            // 
            // tb_creacion
            // 
            this.tb_creacion.Controls.Add(this.Gpb_consultas);
            this.tb_creacion.Controls.Add(this.Gpb_resultado);
            this.tb_creacion.Controls.Add(this.Cpb_Tablas);
            this.tb_creacion.Controls.Add(this.Gpb_datos);
            this.tb_creacion.Location = new System.Drawing.Point(4, 22);
            this.tb_creacion.Name = "tb_creacion";
            this.tb_creacion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tb_creacion.Size = new System.Drawing.Size(786, 568);
            this.tb_creacion.TabIndex = 0;
            this.tb_creacion.Text = "CREACION";
            this.tb_creacion.UseVisualStyleBackColor = true;
            // 
            // Gpb_consultas
            // 
            this.Gpb_consultas.Controls.Add(this.Btn_cancelar);
            this.Gpb_consultas.Controls.Add(this.Btn_generar);
            this.Gpb_consultas.Controls.Add(this.label9);
            this.Gpb_consultas.Controls.Add(this.Txt_query);
            this.Gpb_consultas.Location = new System.Drawing.Point(19, 248);
            this.Gpb_consultas.Name = "Gpb_consultas";
            this.Gpb_consultas.Size = new System.Drawing.Size(750, 100);
            this.Gpb_consultas.TabIndex = 3;
            this.Gpb_consultas.TabStop = false;
            this.Gpb_consultas.Text = "Consultas";
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cancelar.Image = global::ConsultasInteligentes.Properties.Resources.decline__3_1;
            this.Btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_cancelar.Location = new System.Drawing.Point(651, 19);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(75, 60);
            this.Btn_cancelar.TabIndex = 28;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_cancelar.UseVisualStyleBackColor = true;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Btn_generar
            // 
            this.Btn_generar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_generar.Image = global::ConsultasInteligentes.Properties.Resources.writing__2_1;
            this.Btn_generar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_generar.Location = new System.Drawing.Point(565, 19);
            this.Btn_generar.Name = "Btn_generar";
            this.Btn_generar.Size = new System.Drawing.Size(75, 60);
            this.Btn_generar.TabIndex = 29;
            this.Btn_generar.Text = "Registrar";
            this.Btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_generar.UseVisualStyleBackColor = true;
            this.Btn_generar.Click += new System.EventHandler(this.Btn_generar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Query:";
            // 
            // Txt_query
            // 
            this.Txt_query.Location = new System.Drawing.Point(21, 48);
            this.Txt_query.Name = "Txt_query";
            this.Txt_query.Size = new System.Drawing.Size(522, 20);
            this.Txt_query.TabIndex = 0;
            // 
            // Gpb_resultado
            // 
            this.Gpb_resultado.Controls.Add(this.Dgv_resultado);
            this.Gpb_resultado.Location = new System.Drawing.Point(19, 354);
            this.Gpb_resultado.Name = "Gpb_resultado";
            this.Gpb_resultado.Size = new System.Drawing.Size(750, 200);
            this.Gpb_resultado.TabIndex = 2;
            this.Gpb_resultado.TabStop = false;
            this.Gpb_resultado.Text = "Resultado:";
            // 
            // Dgv_resultado
            // 
            this.Dgv_resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_resultado.Location = new System.Drawing.Point(21, 30);
            this.Dgv_resultado.Name = "Dgv_resultado";
            this.Dgv_resultado.RowHeadersWidth = 51;
            this.Dgv_resultado.Size = new System.Drawing.Size(706, 150);
            this.Dgv_resultado.TabIndex = 0;
            // 
            // Cpb_Tablas
            // 
            this.Cpb_Tablas.Controls.Add(this.Btn_crearConsulta);
            this.Cpb_Tablas.Controls.Add(this.Cbo_operador);
            this.Cpb_Tablas.Controls.Add(this.label7);
            this.Cpb_Tablas.Controls.Add(this.Cbo_campo2);
            this.Cpb_Tablas.Controls.Add(this.label5);
            this.Cpb_Tablas.Controls.Add(this.Cbo_campo1);
            this.Cpb_Tablas.Controls.Add(this.label4);
            this.Cpb_Tablas.Controls.Add(this.Cbo_tabla);
            this.Cpb_Tablas.Controls.Add(this.label3);
            this.Cpb_Tablas.Location = new System.Drawing.Point(19, 113);
            this.Cpb_Tablas.Name = "Cpb_Tablas";
            this.Cpb_Tablas.Size = new System.Drawing.Size(750, 129);
            this.Cpb_Tablas.TabIndex = 1;
            this.Cpb_Tablas.TabStop = false;
            this.Cpb_Tablas.Text = "Tablas";
            this.Cpb_Tablas.Enter += new System.EventHandler(this.Cpb_Tablas_Enter);
            // 
            // Btn_crearConsulta
            // 
            this.Btn_crearConsulta.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_crearConsulta.Image = global::ConsultasInteligentes.Properties.Resources.writing__2_1;
            this.Btn_crearConsulta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_crearConsulta.Location = new System.Drawing.Point(604, 37);
            this.Btn_crearConsulta.Name = "Btn_crearConsulta";
            this.Btn_crearConsulta.Size = new System.Drawing.Size(75, 60);
            this.Btn_crearConsulta.TabIndex = 28;
            this.Btn_crearConsulta.Text = "Crear ";
            this.Btn_crearConsulta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_crearConsulta.UseVisualStyleBackColor = true;
            this.Btn_crearConsulta.Click += new System.EventHandler(this.Btn_crearConsulta_Click);
            // 
            // Cbo_operador
            // 
            this.Cbo_operador.FormattingEnabled = true;
            this.Cbo_operador.Items.AddRange(new object[] {
            "=",
            "<=>",
            "<>",
            "!=",
            ">",
            ">=",
            "<",
            "<="});
            this.Cbo_operador.Location = new System.Drawing.Point(230, 83);
            this.Cbo_operador.Name = "Cbo_operador";
            this.Cbo_operador.Size = new System.Drawing.Size(151, 21);
            this.Cbo_operador.TabIndex = 11;
            this.Cbo_operador.SelectedIndexChanged += new System.EventHandler(this.Cbo_operador_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Operador:";
            // 
            // Cbo_campo2
            // 
            this.Cbo_campo2.FormattingEnabled = true;
            this.Cbo_campo2.Location = new System.Drawing.Point(390, 83);
            this.Cbo_campo2.Name = "Cbo_campo2";
            this.Cbo_campo2.Size = new System.Drawing.Size(151, 21);
            this.Cbo_campo2.TabIndex = 9;
            this.Cbo_campo2.SelectedIndexChanged += new System.EventHandler(this.Cbo_campo2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Campo:";
            // 
            // Cbo_campo1
            // 
            this.Cbo_campo1.FormattingEnabled = true;
            this.Cbo_campo1.Location = new System.Drawing.Point(72, 83);
            this.Cbo_campo1.Name = "Cbo_campo1";
            this.Cbo_campo1.Size = new System.Drawing.Size(151, 21);
            this.Cbo_campo1.TabIndex = 5;
            this.Cbo_campo1.SelectedIndexChanged += new System.EventHandler(this.Cbo_campo1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Campo:";
            // 
            // Cbo_tabla
            // 
            this.Cbo_tabla.FormattingEnabled = true;
            this.Cbo_tabla.Location = new System.Drawing.Point(230, 37);
            this.Cbo_tabla.Name = "Cbo_tabla";
            this.Cbo_tabla.Size = new System.Drawing.Size(151, 21);
            this.Cbo_tabla.TabIndex = 3;
            this.Cbo_tabla.SelectedIndexChanged += new System.EventHandler(this.Cbo_tabla_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tabla:";
            // 
            // Gpb_datos
            // 
            this.Gpb_datos.Controls.Add(this.label2);
            this.Gpb_datos.Controls.Add(this.Txt_descripsion);
            this.Gpb_datos.Controls.Add(this.label1);
            this.Gpb_datos.Controls.Add(this.Txt_nombre);
            this.Gpb_datos.Location = new System.Drawing.Point(19, 6);
            this.Gpb_datos.Name = "Gpb_datos";
            this.Gpb_datos.Size = new System.Drawing.Size(750, 101);
            this.Gpb_datos.TabIndex = 0;
            this.Gpb_datos.TabStop = false;
            this.Gpb_datos.Text = "Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion:";
            // 
            // Txt_descripsion
            // 
            this.Txt_descripsion.Location = new System.Drawing.Point(211, 36);
            this.Txt_descripsion.Multiline = true;
            this.Txt_descripsion.Name = "Txt_descripsion";
            this.Txt_descripsion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Txt_descripsion.Size = new System.Drawing.Size(516, 44);
            this.Txt_descripsion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // Txt_nombre
            // 
            this.Txt_nombre.Location = new System.Drawing.Point(21, 49);
            this.Txt_nombre.Name = "Txt_nombre";
            this.Txt_nombre.Size = new System.Drawing.Size(167, 20);
            this.Txt_nombre.TabIndex = 0;
            // 
            // tb_consulta
            // 
            this.tb_consulta.Controls.Add(this.groupBox5);
            this.tb_consulta.Controls.Add(this.gbListado);
            this.tb_consulta.Location = new System.Drawing.Point(4, 22);
            this.tb_consulta.Name = "tb_consulta";
            this.tb_consulta.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tb_consulta.Size = new System.Drawing.Size(786, 568);
            this.tb_consulta.TabIndex = 1;
            this.tb_consulta.Text = "CONSULTA";
            this.tb_consulta.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DataGrid1);
            this.groupBox5.Location = new System.Drawing.Point(16, 163);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(750, 386);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Resultado:";
            // 
            // DataGrid1
            // 
            this.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid1.Location = new System.Drawing.Point(21, 30);
            this.DataGrid1.Name = "DataGrid1";
            this.DataGrid1.RowHeadersWidth = 51;
            this.DataGrid1.Size = new System.Drawing.Size(706, 337);
            this.DataGrid1.TabIndex = 0;
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.Txt_mostrar);
            this.gbListado.Controls.Add(this.label8);
            this.gbListado.Controls.Add(this.Txt_Descripcion);
            this.gbListado.Controls.Add(this.BtnBuscar);
            this.gbListado.Controls.Add(this.Cbo_Query);
            this.gbListado.Controls.Add(this.LblTabla);
            this.gbListado.Location = new System.Drawing.Point(16, 15);
            this.gbListado.Name = "gbListado";
            this.gbListado.Size = new System.Drawing.Size(750, 127);
            this.gbListado.TabIndex = 2;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "Listado ";
            // 
            // Txt_mostrar
            // 
            this.Txt_mostrar.BackColor = System.Drawing.SystemColors.Control;
            this.Txt_mostrar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_mostrar.Location = new System.Drawing.Point(208, 47);
            this.Txt_mostrar.Multiline = true;
            this.Txt_mostrar.Name = "Txt_mostrar";
            this.Txt_mostrar.Size = new System.Drawing.Size(420, 60);
            this.Txt_mostrar.TabIndex = 117;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Descripcion:";
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.BackColor = System.Drawing.SystemColors.Control;
            this.Txt_Descripcion.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion.Location = new System.Drawing.Point(208, 47);
            this.Txt_Descripcion.Multiline = true;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.Size = new System.Drawing.Size(420, 60);
            this.Txt_Descripcion.TabIndex = 116;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Image = global::ConsultasInteligentes.Properties.Resources.loupe__1_1;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBuscar.Location = new System.Drawing.Point(652, 39);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 60);
            this.BtnBuscar.TabIndex = 8;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // Cbo_Query
            // 
            this.Cbo_Query.FormattingEnabled = true;
            this.Cbo_Query.Location = new System.Drawing.Point(21, 65);
            this.Cbo_Query.Name = "Cbo_Query";
            this.Cbo_Query.Size = new System.Drawing.Size(167, 21);
            this.Cbo_Query.TabIndex = 3;
            this.Cbo_Query.SelectedIndexChanged += new System.EventHandler(this.Cbo_Query_SelectedIndexChanged);
            // 
            // LblTabla
            // 
            this.LblTabla.Location = new System.Drawing.Point(22, 39);
            this.LblTabla.Name = "LblTabla";
            this.LblTabla.Size = new System.Drawing.Size(74, 15);
            this.LblTabla.TabIndex = 2;
            this.LblTabla.Text = "Consulta";
            // 
            // ConsultaSencilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Creacion_Consulta);
            this.Name = "ConsultaSencilla";
            this.Size = new System.Drawing.Size(800, 600);
            this.Creacion_Consulta.ResumeLayout(false);
            this.tb_creacion.ResumeLayout(false);
            this.Gpb_consultas.ResumeLayout(false);
            this.Gpb_consultas.PerformLayout();
            this.Gpb_resultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_resultado)).EndInit();
            this.Cpb_Tablas.ResumeLayout(false);
            this.Cpb_Tablas.PerformLayout();
            this.Gpb_datos.ResumeLayout(false);
            this.Gpb_datos.PerformLayout();
            this.tb_consulta.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Creacion_Consulta;
        private System.Windows.Forms.TabPage tb_creacion;
        private System.Windows.Forms.GroupBox Gpb_datos;
        private System.Windows.Forms.TabPage tb_consulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_nombre;
        private System.Windows.Forms.GroupBox Cpb_Tablas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_descripsion;
        private System.Windows.Forms.ComboBox Cbo_operador;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cbo_campo2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cbo_campo1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Cbo_tabla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Gpb_resultado;
        private System.Windows.Forms.Button Btn_crearConsulta;
        private System.Windows.Forms.GroupBox Gpb_consultas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Txt_query;
        private System.Windows.Forms.DataGridView Dgv_resultado;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Button Btn_generar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView DataGrid1;
        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.ComboBox Cbo_Query;
        private System.Windows.Forms.Label LblTabla;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.TextBox Txt_mostrar;
    }
}
