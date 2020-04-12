using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nats_client_metrics.Models;
using nats_client_metrics.Classes;
using Microsoft.Extensions.Logging;

namespace nats_client_metrics.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {

        private readonly ILogger<MetricsController> _logger;
        public MetricsController(ILogger<MetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {
                string natsServer = "http://127.0.0.1:8222";
                string exportedMetrics = "";
                string clientname = "";

                if (Environment.GetEnvironmentVariable("NATSMETRICSURL") != null) {
                    natsServer = Environment.GetEnvironmentVariable("NATSMETRICSURL");
                }

                // grab the URL above /conns and pull the client connection data
                ClientMetrics metrics = new ClientMetrics();
                List<ClientVariables> clientVars = await metrics.CollectMetrics(natsServer);
                foreach (ClientVariables c in clientVars) {
                    clientname = c.clientName.Replace("-","_");
                    exportedMetrics += "# HELP Total Messages Incoming for this client.\n";
                    exportedMetrics += "# TYPE openrmf_gnatds_in_msgs_total gauge\n";
                    exportedMetrics += "openrmf_gnatds_in_msgs_total{server_id=\"" + natsServer + "\",";
                    exportedMetrics += "clientname=\"" + clientname + "\"} " + c.inMessages + "\n"; 
                    
                    exportedMetrics += "# HELP Total Messages Outgoing for this client.\n";
                    exportedMetrics += "# TYPE openrmf_gnatds_out_msgs_total gauge\n";
                    exportedMetrics += "openrmf_gnatds_out_msgs_total{server_id=\"" + natsServer + "\",";
                    exportedMetrics += "clientname=\"" + clientname + "\"} " + c.outMessages + "\n"; 
                    
                    exportedMetrics += "# HELP Total Pending Bytes for this client.\n";
                    exportedMetrics += "# TYPE openrmf_gnatds_pending_bytes_total gauge\n";
                    exportedMetrics += "openrmf_gnatds_pending_bytes_total{server_id=\"" + natsServer + "\",";
                    exportedMetrics += "clientname=\"" + clientname + "\"} " + c.pendingBytes + "\n"; 
                    
                    exportedMetrics += "# HELP Total Bytes Incoming for this client.\n";
                    exportedMetrics += "# TYPE openrmf_gnatds_in_bytes_total gauge\n";
                    exportedMetrics += "openrmf_gnatds_in_bytes_total{server_id=\"" + natsServer + "\",";
                    exportedMetrics += "clientname=\"" + clientname + "\"} " + c.inBytes + "\n"; 
                    
                    exportedMetrics += "# HELP Total Bytes Outgoing for this client.\n";
                    exportedMetrics += "# TYPE openrmf_gnatds_out_bytes_total gauge\n";
                    exportedMetrics += "openrmf_gnatds_out_bytes_total{server_id=\"" + natsServer + "\",";
                    exportedMetrics += "clientname=\"" + clientname + "\"} " + c.outBytes + "\n"; 
                    
                    exportedMetrics += "# HELP Total Subscriptions for this client.\n";
                    exportedMetrics += "# TYPE openrmf_gnatds_subscriptions_total gauge\n";
                    exportedMetrics += "openrmf_gnatds_subscriptions_total{server_id=\"" + natsServer + "\",";
                    exportedMetrics += "clientname=\"" + clientname + "\"} " + c.subscriptions + "\n"; 
                }
                return Ok(exportedMetrics);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Get Metrics error");
                return BadRequest();
            }
        }
    }
}
