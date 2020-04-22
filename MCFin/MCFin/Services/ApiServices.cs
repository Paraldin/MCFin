using MCFin.Constants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MCFin.Services
{
    public class ApiServices
    {
        public static async Task<string> GetDataFromService(string queryString)
        {
            string json = "";
            var client = APIConstants.Client;

            try
            {
                var response = await client.GetAsync(queryString).ConfigureAwait(false);
                if (response != null)
                {
                    json = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return error;
            }

            return json;
        }
        public static async Task<string> EncodedGetData(string queryString, string token)
        {
            string json = "";
            var client = APIConstants.Client;

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{APIConstants.Root}/api/Account/UserInfo");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                json = await response.Content.ReadAsStringAsync();
                //var response = await client.GetAsync(queryString).ConfigureAwait(false);
                //if (response != null)
                //{
                //    json = response.Content.ReadAsStringAsync().Result;
                //}
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return error;
            }

            return json;
        }
    }
}
