using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.IO;
using System.Web;

namespace Reportes.Tools
{
    class ELog
    {
        /// <summary>
        /// FUNCION ENCARGADA DE REGISTRAR LA INFORMACION EN EL ARCHIVO DE LOG
        /// </summary>
        /// <param name="obj">CLASE EN LA QUE SE PRODUJO EL ERROR</param>
        /// <param name="e">OBJETO DE ERROR</param>
        public static void save(object obj, Exception e)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = Directory.GetCurrentDirectory() + "/Log/" + fecha + ".txt";
            crearCarpeta();

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + e.Message);
            sw.WriteLine("SuZuMa - - - - - - ");

            sw.Flush();
            sw.Close();
        }
        public static void saveDebug(object obj, String texto)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = Directory.GetCurrentDirectory() + "/Log/debug_" + fecha + ".txt";
            crearCarpeta();

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + texto);
            sw.WriteLine("SuZuMa - - - - - - ");

            sw.Flush();
            sw.Close();
        }


        /// <summary>
        /// FUNCION QUE VERIFICA SI EXISTE LA CARPETA DE LOG, SI NO EXISTE LA CREA
        /// </summary>
        private static void crearCarpeta()
        {
            string path = Directory.GetCurrentDirectory() + "/Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
