using System;
using Newtonsoft.Json;

namespace nats_client_metrics.Models
{
    /// <summary>
    /// This is the class that holds the data from the /varz metrics endpoint of NATS
    /// </summary>
    [Serializable]
    public class SystemVariables {

        public SystemVariables() {

        }

        [JsonPropertyAttribute("server_id")]
        public string serverId { get; set; }
        [JsonPropertyAttribute("server_name")]
        public string serverName { get; set; }
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
        
        [JsonPropertyAttribute("mem")]
        public long memory { get; set; }
        public int cores { get; set; }
        public int connections { get; set; }
        [JsonPropertyAttribute("in_msgs")]
        public long inMessages { get; set; }
        [JsonPropertyAttribute("out_msgs")]
        public long outMessages { get; set; }
        [JsonPropertyAttribute("in_bytes")]
        public long inBytes { get; set; }
        [JsonPropertyAttribute("out_bytes")]
        public long outBytes { get; set; }
        [JsonPropertyAttribute("slow_consumers")]
        public int slowConsumers { get; set; }
        public int subscriptions { get; set; }
        public DateTime created { get; set; }
    }
}