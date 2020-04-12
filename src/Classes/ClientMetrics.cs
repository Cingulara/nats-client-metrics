using System.Collections.Generic;
using nats_client_metrics.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace nats_client_metrics.Classes
{
    /// <summary>
    /// This is the class that polls the /connz metrics endpoint of the NATS URL passed in
    /// </summary>
    public class ClientMetrics {
        private readonly HttpClient client = new HttpClient();

        public async Task<List<ClientVariables>> CollectMetrics(string url) {
            List<ClientVariables> vars = new List<ClientVariables>();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "nats-client-metrics");
            var stringTask = await client.GetStringAsync(url + "/connz");
            // parse these out
            vars = JsonConvert.DeserializeObject<List<ClientVariables>>(stringTask);
            return vars;
        }
    }
}