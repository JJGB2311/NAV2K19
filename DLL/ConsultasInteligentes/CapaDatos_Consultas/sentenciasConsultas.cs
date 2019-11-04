using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos_Consultas
{
    public class sentenciasConsultas
    {
        int eliminado = 0;
        int disponible = 1;
        public OdbcDataAdapter consultarQuery(string iIdQuery, string sidUsuario)
        {

            conexion cn = new conexion();
            cn.Conectar();
            //string sConsulta = "SELECT * FROM consulta WHERE NombreConsulta = '" + iIdQuery + "' AND disponible = 1";
            //string sConsulta = "SELECT * FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND disponible = 1";
            string sConsulta = "SELECT * FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND KidUsuario = '" + sidUsuario + "' AND disponible = 1";
            OdbcDataAdapter data = new OdbcDataAdapter(sConsulta, cn.Conectar());
            return data;
        }

        public OdbcDataAdapter consultarQuery2(string iIdQuery, string sidUsuario)
        {

            conexion cn = new conexion();
            cn.Conectar();
            //string sConsulta = "SELECT Descripcion FROM consulta WHERE NombreConsulta = '" + iIdQuery + "' AND disponible = 1";
            //string sConsulta = "SELECT descripcion_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND disponible = 1";
            string sConsulta = "SELECT descripcion_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND KidUsuario = '" + sidUsuario + "' AND disponible = 1";
            OdbcDataAdapter data = new OdbcDataAdapter(sConsulta, cn.Conectar());
            return data;
        }

        public OdbcDataAdapter consultarQuery1(string sidUsuario)
        {
            conexion cn = new conexion();
            cn.Conectar();
            //string sConsulta = "SELECT * FROM consulta WHERE disponible = 1";
            //string sConsulta = "SELECT * FROM tbl_consulta WHERE disponible = 1";
            string sConsulta = "SELECT * FROM tbl_consulta WHERE disponible = 1 AND KidUsuario = '" + sidUsuario + "'";
            OdbcDataAdapter data = new OdbcDataAdapter(sConsulta, cn.Conectar());
            return data;
        }

        public OdbcDataAdapter ConsultarTablas()
        {
            conexion con = new conexion();
            con.Conectar();
            string sTablas = "SHOW TABLES ";
            OdbcDataAdapter dat = new OdbcDataAdapter(sTablas, con.Conectar());
            return dat;
        }

        public OdbcDataAdapter ConsultarCampos(string tabla)
        {
            conexion cnc = new conexion();
            cnc.Conectar();
            string sCampos = "DESCRIBE " + tabla;
            OdbcDataAdapter dt = new OdbcDataAdapter(sCampos, cnc.Conectar());
            return dt;
        }

        public OdbcDataAdapter Insertarentxt(string iIdQuery, string sidUsuario)
        {
            conexion cncc = new conexion();
            cncc.Conectar();
            //string srelleno = "SELECT Cadena  FROM consulta WHERE NombreConsulta  = '" + iIdQuery + "' AND disponible = 1";
            //string srelleno = "SELECT cadena_consulta FROM tbl_consulta WHERE nombreconsulta_consulta  = '" + iIdQuery + "' AND disponible = 1";
            string srelleno = "SELECT cadena_consulta FROM tbl_consulta WHERE nombreconsulta_consulta  = '" + iIdQuery + "' AND disponible = 1 AND KidUsuario = '" + sidUsuario + "'";
            OdbcDataAdapter data = new OdbcDataAdapter(srelleno, cncc.Conectar());
            return data;

        }
        public OdbcDataAdapter Insertarentxt1(string iIdQuery, string sidUsuario)
        {
            conexion cnccc = new conexion();
            cnccc.Conectar();
            //string srelleno1 = "SELECT NombreConsulta  FROM consulta WHERE NombreConsulta = '" + iIdQuery + "' AND disponible = 1";
            //string srelleno1 = "SELECT nombreconsulta_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND disponible = 1";
            string srelleno1 = "SELECT nombreconsulta_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND disponible = 1 AND KidUsuario = '" + sidUsuario + "'";
            OdbcDataAdapter data = new OdbcDataAdapter(srelleno1, cnccc.Conectar());
            return data;
        }

        public OdbcDataAdapter Insertarentxt2(string iIdQuery, string sidUsuario)
        {
            conexion cnccc = new conexion();
            cnccc.Conectar();
            //string srelleno1 = "SELECT Descripcion FROM consulta WHERE NombreConsulta = '" + iIdQuery + "' AND disponible = 1";
            //string srelleno1 = "SELECT descripcion_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND disponible = 1";
            string srelleno1 = "SELECT descripcion_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = '" + iIdQuery + "' AND disponible = 1 AND KidUsuario = '" + sidUsuario + "'";
            OdbcDataAdapter data = new OdbcDataAdapter(srelleno1, cnccc.Conectar());
            return data;
        }



        public OdbcCommand InsertarSentencia(string query, string nombre, string descripsion, string usuario)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();
            //command.CommandText = "SELECT COUNT(*)+1 AS id FROM consulta";
            command.CommandText = "SELECT COUNT(*)+1 AS id FROM tbl_consulta";
            command.Connection = conexion.Conectar();

            OdbcDataAdapter mySqlDataAdapter = new OdbcDataAdapter(command);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);

            int iConteo = 0;

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                iConteo = Convert.ToInt32(row["id"]);
            }

            int comi = 34;
            string comi2 = ((char)(comi)).ToString();


            command.CommandText = "INSERT INTO tbl_consulta " +
             "VALUES (" + iConteo +
             "," + comi2 + query + comi2 + " ,'" + nombre + "','" + descripsion + "','" + usuario + "','" + disponible + "')";


            return command;
        }

        public OdbcCommand EditarSentencia(string query, string nombre, string usuario)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();

            //command.CommandText = "SELECT COUNT(*)+1 AS NombreConsulta FROM consulta WHERE NombreConsulta = " + nombre + "  AND disponible = 1";
            //command.CommandText = "SELECT COUNT(*)+1 AS nombreconsulta_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = " + nombre + "  AND disponible = 1";
            command.CommandText = "SELECT COUNT(*)+1 AS nombreconsulta_consulta FROM tbl_consulta WHERE nombreconsulta_consulta = " + nombre + "  AND disponible = 1 AND KidUsuario = '" + usuario + "'";
            command.Connection = conexion.Conectar();

            int iConteo = 0;
            OdbcDataAdapter mySqlDataAdapter = new OdbcDataAdapter(command);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Update(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                iConteo = Convert.ToInt32(row["nombreconsulta_consulta"]);
            }

            //ACTUALIZA
            int comi = 34;
            string comi2 = ((char)(comi)).ToString();

            command.Connection = conexion.Conectar();
            //command.CommandText = "UPDATE consulta SET Cadena=" + comi2 + query + comi2 + " , NombreConsulta='" + nombre + "', Usuario='" + usuario + "' WHERE NombreConsulta='" + nombre + "'";
            command.CommandText = "UPDATE tbl_consulta SET cadena_consulta=" + comi2 + query + comi2 + " , nombreconsulta_consulta='" + nombre + "', KidUsuario='" + usuario + "' WHERE nombreconsulta_consulta='" + nombre + "'";
            return command;
        }

        public OdbcCommand EliminarSentencia(string nombreconsulta, string usuario)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();

            //ACTUALIZA DISPONIBILIDAD 

            command.Connection = conexion.Conectar();
            //command.CommandText = "UPDATE consulta SET disponible='" + eliminado + "' WHERE NombreConsulta='" + nombreconsulta + "'";
            command.CommandText = "UPDATE tbl_consulta SET disponible='" + eliminado + "' WHERE nombreconsulta_consulta='" + nombreconsulta + "' AND KidUsuario = '" + usuario + "'";

            OdbcDataAdapter mySqlDataAdapter = new OdbcDataAdapter(command);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    nombreconsulta = Convert.ToString(row["nombreconsulta_consulta"]);
                }
            }
            else
            {
                MessageBox.Show("Query Eliminado/Inexistente", "Consultas Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return command;
        }


        public OdbcDataAdapter ObtenerConsultas(string usuario)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();
            //command.CommandText = "SELECT idConsulta,Cadena,NombreConsulta FROM consulta WHERE disponible = 1";
            command.CommandText = "SELECT KidConsulta,cadena_consulta,nombreconsulta_consulta FROM tbl_consulta WHERE disponible = 1 AND KidUsuario = '" + usuario + "'";
            command.Connection = conexion.Conectar();

            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(command);

            return odbcDataAdapter;
        }

        public OdbcDataAdapter ObtenerConsultas2(string usuario)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();
            //command.CommandText = "SELECT idConsulta,Cadena,NombreConsulta FROM consulta WHERE disponible = 1";
            command.CommandText = "SELECT KidConsulta,cadena_consulta,nombreconsulta_consulta FROM tbl_consulta WHERE disponible = 1 AND KidUsuario = '" + usuario + "'";
            command.Connection = conexion.Conectar();

            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(command);

            return odbcDataAdapter;
        }

        public OdbcDataAdapter EjecutarCadena(string cadena)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();

            command.CommandText = cadena;
            command.Connection = conexion.Conectar();
            command.CommandType = CommandType.Text;
            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(command);

            return odbcDataAdapter;
        }

        public OdbcDataAdapter EjecutarCadena2(string cadena)
        {
            conexion conexion = new conexion();
            OdbcCommand command = new OdbcCommand();

            command.CommandText = cadena;
            command.Connection = conexion.Conectar();
            command.CommandType = CommandType.Text;
            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(command);

            return odbcDataAdapter;
        }

    }
}
