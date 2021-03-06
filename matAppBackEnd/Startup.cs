using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SpaServices.Extensions;
using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Azure.Storage.Blobs;

namespace matAppBackEnd
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
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
                //.AllowCredentials());
        });

            
            
             // requires using Microsoft.Extensions.Options
            services.AddDbContext<MatAppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MatAppDB")));
            services.AddScoped(x => new BlobServiceClient(Configuration.GetConnectionString("MatAppBlob")));

            services.AddScoped<ListingService>();
            services.AddScoped<AllergieService>();
            services.AddScoped<FoodTypeService>();
            services.AddScoped<ListingAllergieService>();
            services.AddScoped<ListingFoodTypeService>();
            services.AddScoped<OrderListingService>();
             services.AddScoped<OrderedListingService>();
          
            services.AddScoped<ImageService>();

         
            
            

            services.AddControllers();

            services.AddSpaStaticFiles(c=>
            {

                c.RootPath="../matapp/dist";
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            app.UseSpaStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSpa(config=>
            {
                config.Options.SourcePath="../matapp";
                if(env.IsDevelopment())
                {
                    config.UseProxyToSpaDevelopmentServer("http://localhost:8080/");
                }
            });
        }
    }
}
