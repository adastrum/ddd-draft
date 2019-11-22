using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Xxx.Application.Commands;
using Xxx.Application.Queries;
using Xxx.Domain.Aggregates.Bar;
using Xxx.Domain.Aggregates.Foo;
using Xxx.Domain.Common;
using Xxx.Infrastructure.Queries;
using Xxx.Infrastructure.Repositories;

namespace Xxx.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = _configuration["SqlConnectionString"];

            services.AddDbContext<XxxContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
            });

            services.Scan(scan =>
            {
                scan.FromAssemblyOf<XxxContext>()
                    .AddClasses(classes => classes.AssignableToAny(typeof(IRepository<>), typeof(IQueryService)))
                    .AsImplementedInterfaces();
            });

            services.AddTransient<IDbConnection>(serviceProvider => new SqlConnection(sqlConnectionString));

            services.AddMvc();

            services.AddSwaggerDocument();

            services.AddMediatR(typeof(IQueryService).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvcWithDefaultRoute();
        }
    }
}
