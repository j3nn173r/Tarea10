using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea_10.Clases;

namespace Tarea_10
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void cargararchivo()
        {
            string pell = @"C:\Users\alumno\Documents\Archivo cvs\crudDB.csv";
            clsArchivo an = new clsArchivo();
            clsconexion fn = new clsconexion();

            string[] arreglonotas = an.LeerArchivo(pell);
            string jefer_sql = "";
            int numlinea = 0;
            foreach(string linea in arreglonotas)
            {
                string[] datos = linea.Split(';');
                if (numlinea >0)
                {
                    jefer_sql = $"insert into Estudiantes values({datos[0]},'{datos[1]}',{datos[2]},{datos[3]},{datos[4]},{datos[5]},'{datos[6]}'";
                    fn.EjecutaSQLDirecto(jefer_sql);
                }
                numlinea++;
            }
            numlinea = 0;
        }
        public DataTable cargarsql(string condicion="1=1")
        {
            clsconexion fn = new clsconexion();
            DataTable sa = new DataTable();
            string dug = $"select * from Estudiantes where {condicion}";
            sa = fn.consultaTablaDirecta(dug);
            return sa;
        }


        protected void Buttoncargardatos_Click(object sender, EventArgs e)
        {
            cargararchivo();
        }
    }
}