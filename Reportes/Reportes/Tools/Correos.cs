using System.Net.Mail;


namespace Reportes.Tools
{
    class Correos
    { 
        /*
            Cliente SMTP 
            Gmail: smtp.gmail.com puerto 587
            Hotmail: smtp.live.com puerto:25   587
         */
        SmtpClient server = new SmtpClient("smtp.live.com",587);
        public Correos() {
            
            server.Credentials = new System.Net.NetworkCredential("cacn86@hotmail.com","@Facac2017");
            server.EnableSsl = true;
        }

        public Correos(string Usuario, string password) {
            server.Credentials = new System.Net.NetworkCredential(Usuario,password);
            server.EnableSsl = true;
        }
        public void MandarCorreo(MailMessage mensaje) {
            server.Send(mensaje);
        }
    }
}
