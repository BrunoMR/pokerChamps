using System.Net.Mime;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Poker.Api.Extensions;
using System.Text.Json.Serialization;
using System.Xml;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Bson.IO;

namespace Poker.Api
{
    public class Startup
    {
        public readonly IConfiguration _configuration;
        private IWebHostEnvironment _environment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            
            // Normal AddLogging
            services.AddLogging();

            // Additional code to register the ILogger as a ILogger<T> where T is the Startup class
            services.AddSingleton(typeof(ILogger), typeof(Logger<Startup>));

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(o => o.ReportApiVersions = true);

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: "_enableCors",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
            });

            services.AddHttpContextAccessor();

            services.AddDependencies();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}