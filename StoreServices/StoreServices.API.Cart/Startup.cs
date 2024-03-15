using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreServices.API.Cart.Application;
using StoreServices.API.Cart.Application.Remotes;
using StoreServices.API.Cart.Infrastructure;
using StoreServices.API.Cart.Interfaces;
using System;

namespace StoreServices.API.Cart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddControllers();
            services.AddDbContext<CartContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
            });

            services.AddMediatR(typeof(New.Execute).Assembly);
            services.AddHttpClient("Books", config => 
            {
                config.BaseAddress = new Uri(Configuration["ExternalServices:Books"]);
            });
            services.AddHttpClient("Authors", config =>
            {
                config.BaseAddress = new Uri(Configuration["ExternalServices:Authors"]);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
