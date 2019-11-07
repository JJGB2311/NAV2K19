using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using System.Data.Odbc;
using CapaDatos;

namespace CapaDeLogica
{
  
    public class logicaNav
    {
        sentencias sn = new sentencias();
        //metodo para llamar la funcion Obtener ID => Randy 
        public string lastID(string tabla) //ver el ultimo ID
        {
            string lastId = sn.obtenerId(tabla);
            Console.WriteLine(lastId);
            return lastId;
        }
        //metodo para llamar la funcion Obtener Extra => Randy 
        public string[] extras(string tabla)
        {
            string[] Extras = sn.obtenerExtra(tabla);

            return Extras;
        }
        public DataTable consultaLogica(string tabla)  //obtener datos de la consulta
        {
            OdbcDataAdapter dt = sn.llenaTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        /*eli*/
       /* public DataTable consultaLogica2()  //obtener datos de la consulta
        {
            OdbcDataAdapter dt = sn.llenaTbl2();
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }*/

        /**/
        public string MIndice(string Indice1)
        {
            string indice = sn.modIndice(Indice1);

            return indice;
        }
        public string MRuta(string Ruta1)
        {
            string ruta = sn.modRuta(Ruta1);

            return ruta;
        }
        public string verificacion(string valor)
        {
            string indice2 = sn.VerificacionR(valor);

            return indice2;
        }
        public string TestTabla(string tabla)
        {
            return sn.ProbarTabla(tabla);
        }
        public string TestEstado(string tabla)
        {
            return sn.ProbarEstado(tabla);
        }
        public int TestRegistros(string tabla)
        {
            return sn.ProbarRegistros(tabla);
        }
        /*
        public int obtenerMaxId(string tabla)
        {
            return sn.maxId(tabla);
        } */
        public int contarCampos(string tabla)
        {
            return sn.contarAlias(tabla);
        }

        public int contarRegAyuda(string tabla)
        {
            return sn.contarReg(tabla);
        }
        public string[] campos(string tabla)
        {
            string[] Campos = sn.obtenerCampos(tabla);

            return Campos;
        }
        public string[] tipos(string tabla)
        {
            string[] Tipos = sn.obtenerTipo(tabla);

            return Tipos;
        }

        public string[] llaves(string tabla)
        {
            string[] LLaves= sn.obtenerLLave(tabla);

            return LLaves;
        }

        public string[] items(string tabla, string campo)
        {
            string[] Items = sn.obtenerItems(tabla, campo);

            return Items;
        }

		public string llaveCampolo(string tabla, string campo, string valor)
		{
			string llave = sn.llaveCampo(tabla, campo, valor);
			return llave;
		}

		public string llaveCampoRev(string tabla, string campo, string valor)
		{
			string llave = sn.llaveCampoReverso(tabla, campo, valor);
			return llave;
		}

		public string ObtenerIdModulo(string aplicacion)
		{
			string llave = sn.IdModulo(aplicacion);
			return llave;
		}

		public string ObtenerIdReporte(string id)
		{
			string llave = sn.rutaReporte(id);
			return llave;
		}

		public void nuevoQuery(String query)//trasporta el query de la capa de disenio a Datos
        {
            sn.ejecutarQuery(query);
        }


    }
}
