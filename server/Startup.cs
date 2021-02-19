using System.Text.Json.Serialization;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Migrations;
using Repositories;
using Repositories.Interfaces;

namespace Server
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
                  builder =>
                  {
                builder.WithOrigins("http://localhost", "http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
              });
      });

      services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "stalks", Version = "v1" });
      });

      services.AddFluentMigratorCore()
          .ConfigureRunner(rb => rb
              // Add Postgres support to FluentMigrator
              .AddPostgres()
              // Set the connection string
              .WithGlobalConnectionString(DbConfiguration.PG_CONNECTION)
              // Define the assembly containing the migrations
              .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
          // TODO make this read from some config
          // .Configure<RunnerOptions>(cfg => { cfg.Profile = "Development"; })
          // Enable logging to console in the FluentMigrator way
          .AddLogging(lb => lb.AddFluentMigratorConsole());

      services.AddSingleton<IVillagerRepository, VillagerRepository>();
      services.AddSingleton<IIslandRepository, IslandRepository>();
      services.AddSingleton<ITransactionRepository, TransactionRepository>();
      services.AddSingleton<IStalkRepository, StalkRepository>();
      services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "stalks v1"));
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
