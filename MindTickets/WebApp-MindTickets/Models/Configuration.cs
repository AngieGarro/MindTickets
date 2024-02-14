using PayPal;
using PayPal.Api;
using System;
using System.Collections.Generic;

namespace WebApp_MindTickets.Models
{
	public static class Configuration
	{
		public static Dictionary<string, string> GetConfig(string clientId, string clientSecret)
		{
			return new Dictionary<string, string>
		{
			{ "mode", "sandbox" },
			{ "clientId", clientId },
			{ "clientSecret", clientSecret }
		};
		}

		public static string GetAccessToken(string clientId, string clientSecret)
		{
			return new OAuthTokenCredential(clientId, clientSecret, GetConfig(clientId, clientSecret)).GetAccessToken();
		}

		public static APIContext GetAPIContext(string clientId, string clientSecret)
		{
			var accessToken = GetAccessToken(clientId, clientSecret);

			return new APIContext(accessToken)
			{
				Config = GetConfig(clientId, clientSecret)
			};
		}
	}
}