﻿using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Couchbase.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Payroll.Application.Couchbase.BucketActions;
using Payroll.Application.Couchbase.Configuration;

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

            var configuration = new ClientConfiguration(clientDefinition);
            configuration.SetAuthenticator(authenticator);
            configuration.Serializer = () =>
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                return new DefaultSerializer(jsonSerializerSettings, jsonSerializerSettings);
            };
            
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
