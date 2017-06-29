using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;


namespace Reportes.Tools
{
    //https://www.emailarchitect.net/easendmail/kb/csharp.aspx?cat=2
    class SendMail
    {
        private SmtpMail oMail = new SmtpMail("TryIt");
        private SmtpClient oSmtp = new SmtpClient();

        public SendMail(TYPE_EMAIL_SERVER tipo)
        {
            switch (tipo)
            {
                case TYPE_EMAIL_SERVER.HOTMAIL:
                    this.mSMTP = "smtp.live.com";
                    break;
                case TYPE_EMAIL_SERVER.GMAIL:
                    this.mSMTP = "smtp.gmail.com";
                    break;
            }
            this.mPort = 587;
        }

        /// <summary>
        /// FUNCION QUE VERIFICA SI SE TIENE ACCESO A INTERNET
        /// </summary>
        /// <returns>TRUE si hay acceso, FALSE si no hay</returns>
        public static Boolean isInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// FUNCION RESPONSABLE DEL ENVIO DEL CORREO ALECTRONICO
        /// </summary>
        /// <returns> REGRESA TRUE SI EL ENVIO FUE EXITOSO, FALSE SI SE PRESENTO ALGUN PROBLEMA</returns>
        public Boolean send()
        {
            if (!isInternet())
            {
                return false;
            }
            else
            {
                try
                {
                    /*
                     Configuracion de Correo electronico a enviar
                     */
                    oMail.From = this.mFrom;
                    oMail.To = this.mTo;
                    oMail.Subject = this.mSubject;
                    oMail.TextBody = this.mTextBody;
                    /*
                     Configuracion de servidor de correo y autentificacion
                     */
                    SmtpServer oServer = new SmtpServer(this.mSMTP);
                    oServer.Port = this.mPort;
                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                    oServer.User = this.mUser;
                    oServer.Password = this.mPassword;
                    //Se envia el correo
                    oSmtp.SendMail(oServer, oMail);
                    return true;
                }
                catch (Exception ex)
                {
                    ELog.save(this, ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// FUNCTION RESPONSBALE DE AGRAGAR DOCUMENTOS ADJUNTOS AL CORREO
        /// </summary>
        /// <param name="customPath">direccion del documento:
        /// ejemplo: 
        ///     d:\\test.pdf
        ///     http://www.emailarchitect.net/webapp/img/logo.jpg 
        ///     si se quiere poner una imagen a partir de una url</param>
        public void addAtachment(String customPath)
        {
            try
            {
                oMail.AddAttachment(customPath);
            }
            catch (Exception ex)
            {
                ELog.save(this, ex);
            }
        }

        #region "PROPIEDADES"
        public string mFrom { get; set; }
        public string mTo { get; set; }
        public string mSubject { get; set; }
        public string mTextBody { get; set; }
        public string mSMTP { get; set; }
        public int mPort { get; set; }
        public string mUser { get; set; }
        public string mPassword { get; set; }
        #endregion
    }

    public enum TYPE_EMAIL_SERVER
    {
        HOTMAIL,
        GMAIL
    }
}
