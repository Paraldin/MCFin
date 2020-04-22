using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MCFin.Models;

namespace MCFin.Constants
{
    static class APIConstants
    {
        public static string Root = "https://mcportalapi.azurewebsites.net";
        public static HttpClient Client { get; set; }
        public static int HouseId;
        public static string UserId;

        public static void IntializeClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Root);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
