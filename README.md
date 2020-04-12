# NATS Client Metrics
This is something to run inside Docker or Kubernetes (k8s) to gather client specific connection metrics for NATS. 
It will show the server and the client connected and for each, print out the Prometheus based metrics strings 
along with the help information. 

I purposely did this with a /metrics web API in .NET Core 2.2 without the heavy running of the Metrics middleware. I 
only needed this data so did the minimal listing required just for this reason. This I did for my OpenRMF application
so I could see which client was the busiest, had the most messages, most bytes, per client and not just the server as 
a whole. 

It is a WIP still and needs massaging to error nicely, do asynchronous work, add tests. But this is a good start IMO.

## Build
```
make build
```

## Make a Docker images
```
make docker
```

## Run in Docker or Kubernetes
There is a URL below that is in the NATSMETRICSURL environment variable to launch with this. The default is localhost which 
in Docker/K8s world means "itself" which won't work. Make sure you update the URL environment variable to match the metrics
endpoint.

```
"NATSMETRICSURL" : "http://127.0.0.1:8222",
```