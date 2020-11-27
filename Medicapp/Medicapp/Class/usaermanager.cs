using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Medicapp.Class
{
    class usaermanager
    {
        const string URL = "http://192.168.0.4/WebServiceXamarin/listado.php";

        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        public async Task<IEnumerable<user>> getusers()
        {
            HttpClient client = getClient();

            var res = await client.GetAsync(URL);

            if(res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<user>>(content);
            }

            return Enumerable.Empty<user>();
        }

    }
}
