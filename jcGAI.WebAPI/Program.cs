using jcGAI.WebAPI.Common;
using jcGAI.WebAPI.Objects.Config;
using jcGAI.WebAPI.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace jcGAI.WebAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton(builder.Configuration.GetSection(AppConstants.DbConnectionMongo).Get<MongoDbConfig>());
  
            builder.Services.AddSingleton<MongoDbService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "jcGAI", Description = "Garmin Application Insights" });

                c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

                c.EnableAnnotations();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authentication",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = AppConstants.JWT_Issuer,
                    ValidAudience = AppConstants.JWT_Audience,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConstants.JWT_Secret))
                };
            });

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}