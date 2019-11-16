using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Xxx.Application.Commands;
using Xxx.Domain.Aggregates.Bar;
using Xxx.Domain.Aggregates.Foo;
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

            var barQueryHandler = new BarQueryHandler(sqlConnectionString);
            services.AddSingleton(barQueryHandler);

            services.AddScoped<IFooRepository, FooRepository>();
            services.AddScoped<IBarRepository, BarRepository>();

            services.AddMvc();

            services.AddSwaggerDocument();

            services.AddMediatR(typeof(CreateBarCommand).GetTypeInfo().Assembly);
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
