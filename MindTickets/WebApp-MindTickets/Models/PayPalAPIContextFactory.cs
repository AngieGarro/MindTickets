using PayPal.Api;
using System.Collections.Generic;

namespace WebApp_MindTickets.Models
{
	public class PayPalAPIContextFactory
	{
		private const string PayPalClientId = "AR-qrFaBUyFxkZByxOtiS_jR3k80e6NP7c0VJPM2n-Nq8czxl_60_JKX-mma3fjZ5U5drpTCePKygoYN";
		private const string PayPalClientSecret = "EBlxAWdg4qqm6Y-TLY5E0oroqdcAlbGxLwc83VhT63expor6C9S4YxszNWgy3wvCLItOqrWldnRE6LDS";

		public APIContext CreateAPIContext()
		{
			return new APIContext(GetAccessToken())
			{
				Config = GetConfig()
			};
		}

		private Dictionary<string, string> GetConfig()
		{
			return new Dictionary<string, string>
		{
			{ "mode", "sandbox" },
			{ "clientId", PayPalClientId },
			{ "clientSecret", PayPalClientSecret }
		};
		}

		private string GetAccessToken()
		{
			return new OAuthTokenCredential(PayPalClientId, PayPalClientSecret, GetConfig()).GetAccessToken();
		}
	}
}
