using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos_Consultas;
using CapaDatos;

namespace CapaLogica_Consultas
{
    public class logicaConsultas
    {
        //String de id de usuario
        string sIdUsuario;
        //crear objeto de la clase sentencia de la dll de capa datos de seguridad
        sentencia s = new sentencia();

        //crear un constructor que reciba el nmombre de usuario ( necesario para usarlo en la bitacora)
        public logicaConsultas(string idUsuario)
        {
            this.sIdUsuario = idUsuario;
        }


        public DataTable consultaId(string nombreconsulta)
        {
            sentenciasConsultas sn = new sentenciasConsultas();
            OdbcDataAdapter datos = sn.consultarQuery(nombreconsulta, sIdUsuario);
            DataTable dtDatos = new DataTable();
            datos.Fill(dtDatos);
            if (dtDatos.Rows.Count > 0)
            {
                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    DataRow row = dtDatos.Rows[i];
                    string tab = row["nombreconsulta_consulta"].ToString();
                }
                MessageBox.Show("Query Existente", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query Inexistente", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtDatos;
        }

        

        public DataTable consultaId1()
        {
            sentenciasConsultas sn = new sentenciasConsultas();
            OdbcDataAdapter datos = sn.consultarQuery1(sIdUsuario);
            DataTable dtDatos = new DataTable();
            datos.Fill(dtDatos);
            return dtDatos;
        }

        public void tablas(ComboBox cmb)
        {
            sentenciasConsultas sen = new sentenciasConsultas();
            OdbcDataAdapter tablas = sen.ConsultarTablas();
            DataTable datTablas = new DataTable();
            tablas.Fill(datTablas);

            if (datTablas.Rows.Count > 0)
            {
                for (int i = 0; i < datTablas.Rows.Count; i++)
                {
                    DataRow row = datTablas.Rows[i];
                    string tab = row["Tables_in_proyectogeneral"].ToString();
                    cmb.Items.Add(tab);

                }
            }

        }

        public void campos(ComboBox box, string tabla)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcDataAdapter dCampos = sc.ConsultarCampos(tabla);
            DataTable datCampos = new DataTable();
            dCampos.Fill(datCampos);

            if (datCampos.Rows.Count > 0)
            {
                for (int i = 0; i < datCampos.Rows.Count; i++)
                {
                    DataRow rows = datCampos.Rows[i];
                    string cam = rows["Field"].ToString();
                    box.Items.Add(cam);
                }
            }

        }

        public void txt(TextBox box, string tabla)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcDataAdapter dtextos = sc.Insertarentxt1(tabla, sIdUsuario);
            DataTable datextos = new DataTable();
            dtextos.Fill(datextos);

            if (datextos.Rows.Count > 0)
            {
                for (int i = 0; i < datextos.Rows.Count; i++)
                {
                    DataRow rows = datextos.Rows[i];
                    string cam = rows["nombreconsulta_consulta"].ToString();
                    box.Text = cam;
                }
                MessageBox.Show("Query Existente", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Query Inexistente", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        public void consultaDescripcion(TextBox box, string tabla)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcDataAdapter dtextos = sc.Insertarentxt2(tabla, sIdUsuario);
            DataTable datextos = new DataTable();
            dtextos.Fill(datextos);

            if (datextos.Rows.Count > 0)
            {
                for (int i = 0; i < datextos.Rows.Count; i++)
                {
                    DataRow rows = datextos.Rows[i];
                    string cam = rows["descripcion_consulta"].ToString();
                    box.Text = cam;
                }
              //  MessageBox.Show("Query Existente", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("Query Inexistente", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }


        public void txt1(TextBox box, string tabla1)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcDataAdapter dtextos = sc.Insertarentxt(tabla1, sIdUsuario);
            DataTable datextos = new DataTable();
            dtextos.Fill(datextos);

            if (datextos.Rows.Count > 0)
            {
                for (int i = 0; i < datextos.Rows.Count; i++)
                {
                    DataRow rows = datextos.Rows[i];
                    string cam = rows["cadena_consulta"].ToString();
                    box.Text = cam;
                }
            }

        }

        public void InsertarCampos(string query, string nombre, string descripsion, string usuario)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcCommand command = sc.InsertarSentencia(query, nombre, descripsion, sIdUsuario);
            command.ExecuteNonQuery();
            s.insertarBitacora(sIdUsuario, "Creacion de Consulta", "Consultas");
        }

        public void EditarCampos(string query, string nombre, string usuario)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcCommand command = sc.EditarSentencia(query, nombre, sIdUsuario);
            command.ExecuteNonQuery();
            s.insertarBitacora(sIdUsuario, "Modificacion de Consulta", "Consultas");
        }

        public void EliminarCampos(string nombreconsulta)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcCommand command = sc.EliminarSentencia(nombreconsulta, sIdUsuario);
            command.ExecuteNonQuery();
            s.insertarBitacora(sIdUsuario, "Eliminacion de Consulta", "Consultas");

        }


        public void CargarConsultas(ComboBox comboBox, List<int> lista, List<string> consultas)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcDataAdapter odbcDataAdapter = sc.ObtenerConsultas(sIdUsuario);

            DataTable dataTable = new DataTable();
            odbcDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    lista.Add(Convert.ToInt32(row["KidConsulta"]));
                    consultas.Add(row["cadena_consulta"].ToString());
                    comboBox.Items.Add(row["nombreconsulta_consulta"].ToString());
                }
                s.insertarBitacora(sIdUsuario, "Carga de Consultas", "Consultas");
            }
        }

        public void CargarConsultas2(ComboBox comboBox, List<int> lista2, List<string> consultas2)
        {
            sentenciasConsultas sc = new sentenciasConsultas();
            OdbcDataAdapter odbcDataAdapter = sc.ObtenerConsultas2(sIdUsuario);

            DataTable dataTable = new DataTable();
            odbcDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    lista2.Add(Convert.ToInt32(row["KidConsulta"]));
                    consultas2.Add(row["cadena_consulta"].ToString());
                    comboBox.Items.Add(row["nombreconsulta_consulta"].ToString());
                }
                s.insertarBitacora(sIdUsuario, "Carga de Consultas", "Consultas");
            }
        }

        public void EjecutarConsultas(DataGridView tabla, string cadena)
        {
            try
            {
                sentenciasConsultas sc = new sentenciasConsultas();
                OdbcDataAdapter odbcDataAdapter = sc.EjecutarCadena(cadena);
                DataTable dataTable = new DataTable();
                odbcDataAdapter.Fill(dataTable);
                tabla.DataSource = dataTable;
            }
            catch
            {
                MessageBox.Show("Sentencia NO Valida", "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EjecutarConsultas2(DataGridView tabla, string cadena)
        {
            try
            {
                sentenciasConsultas sc = new sentenciasConsultas();
                OdbcDataAdapter odbcDataAdapter = sc.EjecutarCadena2(cadena);
                DataTable dataTable = new DataTable();
                odbcDataAdapter.Fill(dataTable);
                tabla.DataSource = dataTable;
            }
            catch
            {
                MessageBox.Show("Consulta NO Valida", "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    


    }
}
