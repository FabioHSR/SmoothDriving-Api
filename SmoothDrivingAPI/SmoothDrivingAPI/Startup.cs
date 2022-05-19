using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SmoothDriving.Infra.Data.Context;
using SmoothDriving.Infra.Data.Repositories;
using SmoothDrivingAPI.Domain.Interfaces;
using MongoDB.Driver;
using SmoothDrivingAPI.Services;

namespace SmoothDrivingAPI
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(_env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //Configuration = builder.Build();
        }

        public IWebHostEnvironment _env { get; }

        public IConfigurationRoot Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();

            //services.Configure<BrokerDataBaseSettings>(Configuration.GetSection("BrokerDataBase"));

            services.AddScoped<IMongoClient, MongoClient>( options => 
            {
                var connectionString = options.GetRequiredService<IConfiguration>()["MongoConnectionString"];
                return new MongoClient(connectionString);
            });

            // services.AddScoped<IMongoClient>(s => new MongoClient("mongodb://helix:H3l1xNG@15.228.222.191:27000/?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&ssl=false"));
            // services.AddScoped(s => new BrokerContext(s.GetRequiredService<IMongoClient>(), "sth_helixiot"));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddApiVersioning(v =>
            {
                v.ReportApiVersions = true;
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmoothDrivingAPI", Version = "v1" });
            });

            services.AddDbContext<APIContext>(options =>
            {
                // if (_env.IsDevelopment())
                    options.UseInMemoryDatabase("InMemoryDb");
            });

            //services.AddDbContext<BrokerContext>(options =>
            //{
            //    // if (_env.IsDevelopment())
            //    options.
            //    options.UseInMemoryDatabase("InMemoryDb");
            //});

            services.AddScoped<DbContext, APIContext>();

            //services.AddScoped<DbContext, BrokerContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleService, VehicleService>();

            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<ITripService, TripService>();

            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IRelatorioService, RelatorioService>();

            services.AddScoped<IBrokerTripRepository, BrokerTripRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, APIContext context)
        {
            // if (env.IsDevelopment())
            // {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmoothDrivingAPI v1"));

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            // }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}