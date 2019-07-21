using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Payroll.Application.Couchbase;
using Payroll.Application.Couchbase.BucketActions;
using Payroll.Application.Couchbase.Configuration;
using Payroll.Application.Models;

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
//            configuration.Serializer = () => serializer;

            var cluster = new Cluster(configuration);

            services.AddTransient<ICluster>(sp => cluster);

            services.AddTransient(sp => cluster.OpenBucket("payroll"));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }

        public static IServiceCollection AddActions(this IServiceCollection services)
        {
            services.AddTransient<IBucketAction, PrimaryIndexBucketBucketAction>();
            services.AddTransient<IBucketAction, EmployeeIndexBucketBucketAction>();

            return services;
        }
    }
}
