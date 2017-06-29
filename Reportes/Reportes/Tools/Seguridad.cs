using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Reportes.Tools
{
    class Seguridad
    {
        /// <summary>
        /// FUNCION ENCARGADA DE GENERAL LA CLAVE MD5 DE ENCRIPTACION PARA EL PASSWORD
        /// </summary>
        /// <param name="str">PASSWORD A ECRIPTAR</param>
        /// <returns>CADENA DE TEXTO DE LA CLAVE ENCRIPTADA</returns>
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
