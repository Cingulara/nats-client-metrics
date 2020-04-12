using System;
using System.Collections.Generic;

namespace nats_client_metrics.Models
{
    /// <summary>
    /// This is the class that holds the data from the /connz metrics endpoint of NATS
    /// </summary>
    [Serializable]
    public class ConnectionVariables {

        public ConnectionVariables() {
            connections = new List<ClientVariables>();
        }

        public List<ClientVariables> connections { get; set; }
    }
}