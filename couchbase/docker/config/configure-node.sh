#!/bin/bash

set -m

/entrypoint.sh couchbase-server &

apt-get update
apt-get install --yes apt-utils tzdata locales
ln -sf /usr/share/zoneinfo/$HOST_TIMEZONE /etc/localtime
dpkg-reconfigure --frontend noninteractive tzdata

sleep 15

#initialize the cluster
couchbase-cli cluster-init -c 127.0.0.1 --cluster-username admin --cluster-password admin1 --services data,index,query --cluster-ramsize 512  --cluster-index-ramsize 256 --index-storage-setting memopt --cluster-port 8091

#create the payroll bucket
couchbase-cli bucket-create -c 127.0.0.1 --username admin --password admin1 --bucket payroll --bucket-type couchbase --bucket-ramsize 128

fg 1