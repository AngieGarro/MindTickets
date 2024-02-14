using DTOs;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using static System.Net.WebRequestMethods;

namespace Core.RESTManagers
{
	public class ValidateUserManager
	{
		internal Boolean IsEmailValid(string? email)
		{
			if (email == null)
			{
				return false;
			}
			string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
			return (Regex.IsMatch(email, pattern));
		}

		internal Boolean IsPhoneValid(string? phoneNumber)
		{
			if (phoneNumber == null)
			{
				return false;
			}
			Regex validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
			return (validatePhoneNumberRegex.IsMatch(phoneNumber));
		}

		public String generateTemporalPassword()
		{
			var characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			// Create a random number generator
			var random = new Random();

			// Generate a string of 8 random characters
			var randomString = new string(
				Enumerable.Repeat(characters, 8)
						  .Select(s => s[random.Next(s.Length)])
						  .ToArray());
			return randomString;
		}

		public void ValidatePassword(string password)
		{
			if (password.Length < 8)
			{
				throw new Exception("Error: La longitud de la contraseña debe ser como mínimo de 8 caracteres.");
			}

			if (!Regex.IsMatch(password, @"[A-Z]"))
			{
				throw new Exception("Error: La contraseña debe tener como mínimo una mayúscula.");
			}

			if (!Regex.IsMatch(password, @"[a-z]"))
			{
				throw new Exception("Error: La contraseña debe tener como mínimo una minúscula.");
			}

			if (!Regex.IsMatch(password, @"[\W_]"))
			{
				throw new Exception("Error: La contraseña debe tener como mínimo un caracter especial.");
			}
		}

		//Notificacion para restablecer contraseña
		public void EmailRestartPswd(User usr, string newPswrd)
		{
			var subject = "Hola!" + " " + " " + " " + "Se ha realizado la actulización de su contraseña:";
			var body = "Su nueva contraseña es: " + newPswrd + " " + "Ingrese y actualice su contraseña.";
			PushEmailPswd(subject, body).Wait();
		}

		private async Task PushEmailPswd(string subjectText, string body)
		{
			var apiKey = "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";
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("agarrom@ucenfotec.ac.cr", "MindTickets");
			var subject = subjectText;
			var to = new EmailAddress("angiegm5565@gmail.com", "");
			var htmlContent = "<strong>" + body + "</strong>";
			var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", htmlContent);
			var response = client.SendEmailAsync(msg);
		}
	}
}

