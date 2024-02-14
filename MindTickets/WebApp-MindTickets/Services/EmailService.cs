using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using WebApp_MindTickets.Models.ViewModels;
using MailKit.Net.Smtp;

namespace WebApp_MindTickets.Services
{
    public class EmailService
    {
        private static string _Host = "smtp.gmail.com";
        private static int _Puerto = 587;

        private static string _NombreEnvia = "MindTickets";
        private static string _Correo = "agarrom@ucenfotec.ac.cr";
        private static string _Clave = "yqjbhfwdmcpdkvtt";

        public static bool Enviar(EmailDTO EmailDto)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress(_NombreEnvia, _Correo));
                email.To.Add(MailboxAddress.Parse(EmailDto.To));
                email.Subject = EmailDto.Message;
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = EmailDto.Content
                };

                var smtp = new SmtpClient();
                smtp.Connect(_Host, _Puerto, SecureSocketOptions.StartTls);

                smtp.Authenticate(_Correo, _Clave);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
