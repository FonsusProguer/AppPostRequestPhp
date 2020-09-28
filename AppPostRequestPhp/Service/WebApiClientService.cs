using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPostRequestPhp.Service
{
    public class WebApiClientService
    {
        Uri urlBase = new Uri("http://192.168.140.2");


        public async Task<T> executeRequestPost<T>(object objectParams)
        {
            string requestUri = "/WebServicePost/index.php";

            var client = new HttpClient();
            client.BaseAddress = urlBase;

            string jsonData = JsonConvert.SerializeObject(objectParams);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(requestUri, content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }

    }
}
