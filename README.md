# Payroll

## Prerequisites

1. [Docker][docker]
1. [.NET Core 2.2][netcore]
1. [NodeJS][node]
1. [Visual Studio 2019][vs2019] (*optional*, or another capable IDE to run .NET Core apps)

## Setup
1. Navigate to the couchbase folder
1. To build your Docker Couchbase image, Execute the build script by running ```./build.sh``` in your favorite terminal application
1. Upon a successful build, you're ready to start your Couchbase container by running ```./run.sh```
1. While Couchbase is intializing the cluster (usually takes about 2 minutes), browse to the web[vuesetup] project setup and follow those instructions. You really should run ```npm run serve``` so that your development dev server stays running for you
1. In a new terminal window, navigate to the api folder and get the API up by running ```./run.sh```
1. Open your favorite web browser and navigate to the [application][apphome]!

[docker]: https://www.docker.com/products/docker-desktop
[netcore]: https://dotnet.microsoft.com/download
[node]: https://nodejs.org/en/download/
[vuesetup]: ./web/README.md
[vs2019]: https://visualstudio.microsoft.com/downloads/
[apphome]: http://payroll.localdev.me:51020