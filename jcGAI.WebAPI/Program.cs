using jcGAI.WebAPI.Common;
using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Services;

using Microsoft.OpenApi.Models;

namespace jcGAI.WebAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(AppConstants.DbConnectionMongo));
            builder.Services.AddSingleton<MongoDbService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "jcGAI", Description = "Garmin Application Insights"});

                c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

                c.EnableAnnotations();
            });

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.MapControllers();

            app.Run();
        }
    }
}