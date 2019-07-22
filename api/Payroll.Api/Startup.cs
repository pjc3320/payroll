using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Payroll.Application.Couchbase.BucketActions;
using Payroll.Application.Extensions;

namespace Payroll.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddMediatR(typeof(Application.GetEmployees.GetEmployeesHandler));
            services.AddCouchbase();
            services.AddRepositories();
            services.AddActions();

            var actions = services.BuildServiceProvider().GetServices<IBucketAction>().ToList();

            actions.ForEach(a => a.Execute());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
