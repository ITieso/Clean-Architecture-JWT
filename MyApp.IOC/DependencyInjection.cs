using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.IService.ICategoryService;
using MyApp.Application.IService.IProductService;
using MyApp.Application.Service.CategoryService;
using MyApp.Application.Service.ProductService;
using MyApp.Domain.Account;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Context;
using MyApp.Infrastructure.Identity;
using MyApp.Infrastructure.Repository;

namespace MyApp.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<IdentityUser, IdentityRole>().
            AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //quando usuario nao tiver acesso a algo, ele será redirecionado para a tela de login da aplicação
            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");


      
            Assembly assemblyApplication = AppDomain.CurrentDomain.Load("MyApp.Application");
            services.AddMediatR(assemblyApplication);
            return services;
        }   
    }
}
