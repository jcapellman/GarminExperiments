using jcGAI.WebAPI.Common;
using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Services;

namespace jcGAI.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MongoDBConfig>(builder.Configuration.GetSection(AppConstants.DB_CONNECTION_MONGO));
            builder.Services.AddSingleton<MongoDBService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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