using nats_client_metrics.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System;

namespace nats_client_metrics.Classes
{
    /// <summary>
    /// This is the class that polls the /varz metrics endpoint of the NATS URL passed in
    /// </summary>
    public static class SystemMetrics {
        private static readonly HttpClient client = new HttpClient();

        public static SystemVariables CollectMetrics(string url) {
            SystemVariables vars = new SystemVariables();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "NATS Collector");
            var stringTask = client.GetStringAsync(url + "/varz");
            // parse these out
            vars = JsonConvert.DeserializeObject<SystemVariables>(stringTask.Result);
            return vars;
        }
    }
}