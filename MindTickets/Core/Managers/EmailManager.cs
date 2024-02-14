using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using WebApp_MindTickets.Models.ViewModels;
using DTOs;
using SendGrid.Helpers.Mail;
using SendGrid;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Managers
{
	public class EmailManager
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

		//Autenticacion:
		public void SendEmailAuth(User user)
		{
			string OTP = generateOtp();
			user.Token = OTP;
			var subject = "Hola!" + " " + " " + " " + "Por favor verifique su cuenta:";
			var body = "Su código de autenticación es: " + user.Token + " " + "Ingrese: " +
				"https://localhost:7161/Home/Authenticated";

			if (user.Email != null)
				PushEmail(user.Email, user.FullName, subject, body).Wait();
			else
				throw new Exception("Email cannot Null");
		}

		private async Task PushEmail(string _email, string name, string subjectText, string body)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("csalazarg@ucenfotec.ac.cr", "MindTickets");
			var subject = subjectText;
			var to = new EmailAddress(_email, name);
			var htmlContent = "<strong>" + body + "</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", htmlContent);
			var response = client.SendEmailAsync(msg);
		}

		//PARA SMS
		public void SendSMS(User user)
		{
			//Misma logica que el envio del correo.
			var msj = "Hola!" + " " + " " + " " + "Por favor verifique su cuenta: " +
				"Su código de autenticación es: " + user.Token + " " + "Ingrese: " +
				"https://localhost:7161/Home/Authenticated";
			PushSMS(user.Phone, msj);
		}

		private void PushSMS(string phone, string text)
		{
			// Find your Account SID and Auth Token at twilio.com/console
			// and set the environment variables. See http://twil.io/secure
			string accountSid = "AC49e7a6186bba7a5ddc56c7889fb21372";
			string authToken = "41ae01d81e3458743618dba0e21ef3ce";

			TwilioClient.Init(accountSid, authToken);

			var message = MessageResource.Create(
				body: text,
				from: new Twilio.Types.PhoneNumber("+14175413363"),
				to: new Twilio.Types.PhoneNumber("+50664788712")
			);

		}
		public string generateOtp()
		{
			Random rand = new Random();
			return rand.Next(100000, 999999).ToString();
		}

		//Restablecer Clave:
		public void SendEmailPasswrd(string Email)
		{
			var usr = new User();
			var subject = "Hola! " + " Restablezaca su clave:" + " " + " " + "";
			var body = "Por favor ingrese al siguiente enlace a restablecer su cuenta: " +
				"https://localhost:7161/Home/Actualizar";

			if (Email != null)
				PushEmailPswd(Email, subject, body).Wait();
			else
				throw new Exception("Email cannot Null");
		}

		private async Task PushEmailPswd(string _email, string subjectText, string body)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("csalazarg@ucenfotec.ac.cr", "MindTickets");
			var subject = subjectText;
			var to = new EmailAddress(_email);
			var htmlContent = "<strong>" + body + "</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", htmlContent);
			var response = client.SendEmailAsync(msg);
		}

		//PROCESO DE FACTURACION:
		public void SendEmailTransaction(User usr, Transaction transact)
		{ 
			var subject = "Factura Electronica - MindTickets - " + transact.IdTransaction;
			var body = " ";

			if (usr.Email != null)
				PushEmailTransaction(usr.Email, usr.FullName, subject, body).Wait();
			else
				throw new Exception("Email cannot Null");
		}

		private async Task PushEmailTransaction(string _email, string name, string subjectText, string body)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("csalazarg@ucenfotec.ac.cr", "MindTickets");
			var subject = subjectText;
			var to = new EmailAddress(_email, name);
			var htmlContent = "<strong>" + body + "</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", htmlContent);
			var response = client.SendEmailAsync(msg);
		}

		//INFORME ADMI NUEVO:
		public void SendEmailAdmi(User usr)
		{
			var subject = "Bienvenido a MindTickets - " + usr.FullName;
			var body = "Se le ha asignado una cuenta de administrador en nuestra Plataforma. " + 
				"Le adjuntamos sus datos de ingreso para que pueda acceder a su cuenta. " +
				"Usuario: " + usr.Email + " " + "Contraseña: " + usr.Password;

			if (usr.Email != null)
				PushEmailAdmi(usr.Email, usr.FullName, subject, body).Wait();
			else
				throw new Exception("Email cannot Null");
		}

		private async Task PushEmailAdmi(string _email, string name, string subjectText, string body)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("csalazarg@ucenfotec.ac.cr", "MindTickets");
			var subject = subjectText;
			var to = new EmailAddress(_email, name);
			var htmlContent = "<strong>" + body + "</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", htmlContent);
			var response = client.SendEmailAsync(msg);
		}

	}
}
