using MCFin.Constants;
using System;
using System.Collections.Generic;
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
    }
}
