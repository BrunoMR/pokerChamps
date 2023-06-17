using Poker.Api.Extensions;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Poker.Api.Shared;

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
            services.AddAutoMapper(typeof(Startup));
            
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

            services.Configure<JsonOptions>(op =>
            {
                op.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
            });

            services.AddHttpContextAccessor();
            
            services.AddSingleton<IMongoClient>(x =>
            {
                // Configure the MongoDB connection settings
                var settings = MongoClientSettings.FromConnectionString(_configuration["PKC_ConnectionStringMongoDb"]);

                // Optionally, configure other settings such as read preferences, write concerns, etc.

                // Create a new MongoClient instance
                var client = new MongoClient(settings);

                return client;
            });
            
            // Configure the IClientSessionHandle
            services.AddScoped<IClientSessionHandle>(x =>
            {
                var client = x.GetRequiredService<IMongoClient>();

                // Start a new session
                var session = client.StartSession();

                return session;
            });

            services.AddDependencies();
            services.AddAutoMappers();
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
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}