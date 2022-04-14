using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyApp.Infrastructure.Context;

namespace MyApp.IOC
{
    public static class DependencyInjectionJWT
    {
            public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services, IConfiguration configuration)
            {
                //informar o tipo de authentication
                //definir modelo de desafio de authentication
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            //habilitar a authentication JWT usando o esquema e desafio definidos 
            //validar o token
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    //valores, que eu defini no appsettings
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    
                    //TEMPO DE VIDA EXTRA PARA O TOKEN SETADO PARA 0
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;


        }
    }
}
