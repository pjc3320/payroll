using System;
using System.Collections.Generic;
using AutoMapper;
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
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var serializer = new DefaultSerializer(serializerSettings, serializerSettings);

            configuration.Serializer = () => serializer;
            var cluster = new Cluster(configuration);

            services.AddTransient<ICluster>(sp => cluster);

            services.AddTransient(sp => cluster.OpenBucket("payroll"));
            services.AddSingleton<ITypeSerializer>(new DefaultSerializer(serializerSettings, serializerSettings));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDependentRepository, DependentRepository>();

            return services;
        }

        public static IServiceCollection AddActions(this IServiceCollection services)
        {
            services.AddTransient<IBucketAction, PrimaryIndexBucketBucketAction>();
            services.AddTransient<IBucketAction, EmployeeIndexBucketBucketAction>();
            services.AddTransient<IBucketAction, EmployeeSeedBucketAction>();

            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMapperProfile));

            return services;
        }
    }
}
