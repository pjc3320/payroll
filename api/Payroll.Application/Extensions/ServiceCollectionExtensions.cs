using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Payroll.Data.Configuration;

namespace Payroll.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddCouchbase(this IServiceCollection services)
        {

            var clientDefinition = new CouchbaseClientDefinition
            {
                Username = CouchbaseOptions.Username,
                Password = CouchbaseOptions.Password,
                Servers = new List<Uri>
                {
                    new Uri(CouchbaseOptions.Host)
                },
            };

            var authenticator = new PasswordAuthenticator(CouchbaseOptions.Username, CouchbaseOptions.Password);
            var serializer = new JsonSerializerSettings();

            var configuration = new ClientConfiguration(clientDefinition);
            configuration.SetAuthenticator(authenticator);

            var cluster = new Cluster(configuration);

            services.AddTransient<ICluster>(c => cluster);

            services.AddTransient(b => cluster.OpenBucket("payroll"));
            return services;
        }
    }
}
