using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using SmartReferralApiCore2.EFHelpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Mvc;

namespace SmartReferralApiCore2
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
            //Hookup the EF DbContext to the database connection string name
            //which is in the appsettings.json file
            services.AddDbContext<SmartReferralContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

                    
            //Add CORS for cross browser ability 
            services.AddCors(options => options.AddPolicy("", p => p.AllowAnyOrigin()
                                                               .AllowAnyMethod()
                                                                .AllowAnyHeader()));

            //Add MVC 
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "SmartReferralApiCore2",
                    Version = "v1",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Brian Quinn", Email = "", Url = "https://twitter.com/bofcarbon1" },
                    License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                });
            });           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

        }
    }
}
