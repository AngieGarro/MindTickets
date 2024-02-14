using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace WebApp_MindTickets.Models.PayPal2
{
    public static class PayPalConfiguration
    {
        public readonly static string ClientId;
        public static string ClientSecret;

        static PayPalConfiguration()
        {
            ClientId = "AR-qrFaBUyFxkZByxOtiS_jR3k80e6NP7c0VJPM2n-Nq8czxl_60_JKX-mma3fjZ5U5drpTCePKygoYN";
            ClientSecret = "EBlxAWdg4qqm6Y-TLY5E0oroqdcAlbGxLwc83VhT63expor6C9S4YxszNWgy3wvCLItOqrWldnRE6LDS";
        }

        public static Dictionary<string, string> GetConfig()
        {
            return new Dictionary<string, string>()
            {
                {"mode", "sandbox" }
            };
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, new Dictionary<string, string>()
            {
                {"mode","sandbox" }
            }).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}
