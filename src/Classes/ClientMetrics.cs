using System.Collections.Generic;
using nats_client_metrics.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace nats_client_metrics.Classes
{
    /// <summary>
    /// This is the class that polls the /connz metrics endpoint of the NATS URL passed in
    /// </summary>
    public static class ClientMetrics {
        private static readonly HttpClient client = new HttpClient();

        public static ConnectionVariables CollectMetrics(string url) {
            ConnectionVariables vars = new ConnectionVariables();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "NATS Collector");
            var stringTask = client.GetStringAsync(url + "/connz");
            // parse these out
            vars = JsonConvert.DeserializeObject<ConnectionVariables>(stringTask.Result);
            return vars;
        }
    }
}