using System.Net;

namespace ProjectX.Helpers
{
    public static class IPHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetLoggedInUserIp()
        {
            var webClient = new WebClient();
            var ip = webClient.DownloadString("http://icanhazip.com");
            var location = webClient.DownloadString("https://freegeoip.app/json/" + ip);

            return location;
        }

    }
}