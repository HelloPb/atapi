﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace atapi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ROR Online - v1 API Specification",
                    Description = "Describes the list of API's used for ROR Online project",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "ROR Online API", Email = "atapi@outlook.com", Url = "https://atapiap.azurewebsites.net" }
                });

                c.SwaggerDoc("v2", new Info
                {
                    Version = "v2",
                    Title = "ROR Online - v2 API Specification",
                    Description = "Describes the list of API's used for ROR Online project",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "ROR Online API", Email = "atapi@outlook.com", Url = "https://atapiap.azurewebsites.net" }
                });
            });

            services.AddCors(o => o.AddPolicy("CORS_GLOBAL", builder =>
            {
                builder.WithOrigins("*").AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CORS_GLOBAL");
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ROR Online - v1 API Specification");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "ROR Online - v2 API Specification");
            });
        }
    }
}
