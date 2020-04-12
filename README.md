# NATS Client Metrics
This is something to run inside Docker or Kubernetes (k8s) to gather client specific connection metrics for NATS. 
It will show the server and the client connected and for each, print out the Prometheus based metrics strings 
along with the help information. 

I purposely did this with a /metrics web API in .NET Core 2.2 without the heavy running of the Metrics middleware. I 
only needed this data so did the minimal listing required just for this reason. This I did for my OpenRMF application
so I could see which client was the busiest, had the most messages, most bytes, per client and not just the server as 
a whole. 

It is a WIP still and needs to error nicely, allow certs and login/pwd authentication, as well as add tests. 
But this is a good start IMO. Currently, it works inside a k8s namespace for non-exposed Prometheus as well as a 
localized Docker Compose setup.

## Build
```
make build
```

## Make a Docker images
```
make docker
```

Available Docker Image: https://hub.docker.com/r/cingulara/nats-client-metrics


## Run in Docker or Kubernetes
There is a URL below that is in the NATSMETRICSURL environment variable to launch with this. The default is localhost which 
in Docker/K8s world means "itself" which won't work. Make sure you update the URL environment variable to match the metrics
endpoint.

```
"NATSMETRICSURL" : "http://127.0.0.1:8222"
"ASPNETCORE_ENVIRONMENT": "Development"
"ASPNETCORE_URLS": "http://*:7778"
```

## Grafana Dashboard Definition
The [Dashboard JSON](./grafana-dashboard.json) can be imported into Grafana and pointed to the Prometheus data source to view this information.

## Example Output

```
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_controls"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_controls"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_controls"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_controls"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_controls"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_controls"} 2
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_audit"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_audit"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_audit"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_audit"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_audit"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_audit"} 1
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_checklist"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_checklist"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_checklist"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_checklist"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_checklist"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_checklist"} 2
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_score"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_score"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_score"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_score"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_score"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_score"} 5
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_api_save"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_api_save"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_api_save"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_api_save"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_api_save"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_api_save"} 0
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_template"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_template"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_template"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_template"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_template"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_template"} 1
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_system"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_system"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_system"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_system"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_system"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_system"} 4
# HELP Total Messages Incoming for this client.
# TYPE gnatds_clients_in_msgs_total gauge
gnatds_clients_in_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_compliance"} 0
# HELP Total Messages Outgoing for this client.
# TYPE gnatds_clients_out_msgs_total gauge
gnatds_clients_out_msgs_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_compliance"} 0
# HELP Total Pending Bytes for this client.
# TYPE gnatds_clients_pending_bytes_total gauge
gnatds_clients_pending_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_compliance"} 0
# HELP Total Bytes Incoming for this client.
# TYPE gnatds_clients_in_bytes_total gauge
gnatds_clients_in_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_compliance"} 0
# HELP Total Bytes Outgoing for this client.
# TYPE gnatds_clients_out_bytes_total gauge
gnatds_clients_out_bytes_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_compliance"} 0
# HELP Total Subscriptions for this client.
# TYPE gnatds_clients_subscriptions_total gauge
gnatds_clients_subscriptiosn_total{server_id="http://127.0.0.1:8222",clientname="openrmf_msg_compliance"} 3
```