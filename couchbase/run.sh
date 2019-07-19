#!/bin/bash
#remove any running containers
docker rm $(docker stop $(docker ps -a -q --filter="name=couchbase-server"))

docker run --restart=always --name=couchbase-server -d \
-p 8091-8094:8091-8094  -p 11207:11207 -p 11210-11211:11210-11211 -p 18091-18093:18091-18093 \
-e HOST_TIMEZONE=America/New_York \
couchbase-local