using System;
using Newtonsoft.Json;

namespace nats_client_metrics.Models
{
    /// <summary>
    /// This is the class that holds the data from the /connz metrics endpoint of NATS
    /// </summary>
    [Serializable]
    public class ClientVariables {

        public ClientVariables() {
        }

        [JsonPropertyAttribute("cid")]
        public int clientId { get; set; }
        [JsonPropertyAttribute("name")]
        public string clientName { get; set; }
        [JsonPropertyAttribute("lang")]
        public string language{ get; set; }
        [JsonPropertyAttribute("ip")]
        public string ipAddress { get; set; }
        [JsonPropertyAttribute("server_id")]
        public string serverId { get; set; }
        public string rtt { get; set; }
        public decimal roundTripTime { get {
            if (!string.IsNullOrEmpty(rtt))
                return Convert.ToDecimal(rtt.Replace("ms","").Replace("s",""));
            else
                return 0;
        } }

        public string uptime { get; set; }
        public int uptimeDays { get {
            if (string.IsNullOrEmpty(uptime))
                return 0;
            else {
                if (uptime.IndexOf("d") > 0)
                    return int.Parse(uptime.Substring(0,uptime.IndexOf("d")));
                else
                    return 0;
            }
        }  }
        public int uptimeHours { get {
            if (string.IsNullOrEmpty(uptime))
                return 0;
            else {
                // get the time before the H
                if (uptime.IndexOf("h") <= 0)
                    return 0;
                if (uptime.IndexOf("d") > 0)
                    return int.Parse(uptime.Substring(uptime.IndexOf("d")+1,uptime.IndexOf("h")-uptime.IndexOf("d")-1));
                else 
                    return int.Parse(uptime.Substring(0,uptime.IndexOf("h")-uptime.IndexOf("d")-1));
            }
        }  }
        public int uptimeMinutes { get {
            if (string.IsNullOrEmpty(uptime))
                return 0;
            else {
                // get the time between the H and the M
                if (uptime.IndexOf("m") <= 0)
                    return 0;
                if (uptime.IndexOf("h") > 0)
                    return int.Parse(uptime.Substring(uptime.IndexOf("h")+1,uptime.IndexOf("m")-uptime.IndexOf("h")-1));
                else 
                    return int.Parse(uptime.Substring(0,uptime.IndexOf("m")-uptime.IndexOf("h")-1));
            }
        }  }
        public int uptimeSeconds { get {
            if (string.IsNullOrEmpty(uptime))
                return 0;
            else {
                // get the last number, remove the "s", send it
                if (uptime.IndexOf("s") <= 0)
                    return 0;
                if (uptime.IndexOf("m") > 0)
                    return int.Parse(uptime.Substring(uptime.IndexOf("m")+1).Replace("s",""));
                else 
                    return int.Parse(uptime.Replace("s",""));         
            }
        }  }

        public string idle { get; set; }     
        public int idleDays { get {
            if (string.IsNullOrEmpty(idle))
                return 0;
            else {
                // get the time before the D
                if (idle.IndexOf("d") > 0)
                    return int.Parse(idle.Substring(0,idle.IndexOf("d")));
                else
                    return 0;
            }
        }  } 
        public int idleHours { get {
            if (string.IsNullOrEmpty(idle))
                return 0;
            else {
                // get the time before the H
                if (idle.IndexOf("h") <= 0)
                    return 0;
                if (idle.IndexOf("d") > 0)
                    return int.Parse(idle.Substring(idle.IndexOf("d")+1,idle.IndexOf("h")-idle.IndexOf("d")-1));
                else 
                    return int.Parse(idle.Substring(0,idle.IndexOf("h")-idle.IndexOf("d")-1));
            }
        }  }
        public int idleMinutes { get {
            if (string.IsNullOrEmpty(idle))
                return 0;
            else {
                if (idle.IndexOf("m") <= 0)
                    return 0;
                if (idle.IndexOf("h") > 0)
                    return int.Parse(idle.Substring(idle.IndexOf("h")+1,idle.IndexOf("m")-idle.IndexOf("h")-1));
                else 
                    return int.Parse(idle.Substring(0,idle.IndexOf("m")-idle.IndexOf("h")-1));                
            }
        }  }
        public int idleSeconds { get {
            if (string.IsNullOrEmpty(idle))
                return 0;
            else {
                if (idle.IndexOf("s") <= 0)
                    return 0;
                if (idle.IndexOf("m") > 0)
                    return int.Parse(idle.Substring(idle.IndexOf("m")+1).Replace("s",""));
                else 
                    return int.Parse(idle.Replace("s",""));                
            }
        }  }

        [JsonPropertyAttribute("in_msgs")]
        public long inMessages { get; set; }
        [JsonPropertyAttribute("out_msgs")]
        public long outMessages { get; set; }
        [JsonPropertyAttribute("in_bytes")]
        public long inBytes { get; set; }
        [JsonPropertyAttribute("out_bytes")]
        public long outBytes { get; set; }
        public int subscriptions { get; set; }
        [JsonPropertyAttribute("pending_bytes")]
        public long pendingBytes { get; set; }
    }
}