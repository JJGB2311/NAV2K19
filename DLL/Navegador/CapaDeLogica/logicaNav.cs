using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using System.Data.Odbc;

namespace CapaDeLogica
{
  
    public class logicaNav
    {
        sentencias sn = new sentencias();
        public DataTable consultaLogica(string tabla)  //obtener datos de la consulta
        {
            OdbcDataAdapter dt = sn.llenaTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }



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
        public void nuevoQuery(String query)//trasporta el query de la capa de disenio a Datos
        {
            sn.ejecutarQuery(query);
        }


    }

}
