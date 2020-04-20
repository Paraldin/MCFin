using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MCFin.Constants
{
    static class APIConstants
    {
        public static string Root = "https://mcportalapi.azurewebsites.net";
        public static HttpClient Client = new HttpClient();
    }
}
