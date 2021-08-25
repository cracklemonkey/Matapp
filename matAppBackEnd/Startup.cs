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
using matAppBackEnd.Models;
using matAppBackEnd.Services;

namespace matAppBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
public string MyAllowSpecificOrigins {get;set;} = "MyAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   

            services.AddCors(options =>
        {  
            options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
            
                builder.WithOrigins("http://localhost:8082")
                .AllowAnyMethod()
                .AllowAnyHeader());
                //.AllowCredentials());
            
                
        });

            
            
             // requires using Microsoft.Extensions.Options
            services.AddDbContext<ListingDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MatAppDB")));
            services.AddDbContext<UserDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MatAppDB")));

            services.AddScoped<ListingService>();
            services.AddScoped<UserService>();
            
            

            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
