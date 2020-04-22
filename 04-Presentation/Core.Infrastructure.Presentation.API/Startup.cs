using System;
using AutoMapper;
using Core.Infrastructure.Domain.Aggregate.User;
using Core.Infrastructure.Domain.Context.Context;
using Core.Infrastructure.Presentation.API.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Presentation.API
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
            //Configuring API's
            services.ConfigureAuthentication(Configuration);
            services.AddMvc().AddFluentValidation();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            //Configure Third Parties
            services.ConfigureLogger(Configuration);
            services.ConfigureCors();
            services.ConfigureMySqlContext(Configuration);
            services.ConfigureUnitOfWork();
            services.ConfigureSwagger();
            //services.AddAutoMapper();
            services.AddAutoMapper(typeof(Startup));
            services.ConfigureApplicationService();
            services.ConfigureAttributes();
            services.ConfigureDomainService();
            services.ConfigureFluentValidation();
            services.ConfigureRedisCache();
            //Mapping.ConfigureMapping();
            //services.Configure<PasswordHasherOptions>(options =>
            //    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            //);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, InfrastructureContext context)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            // ===== Use Authentication ======
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            //app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/CoreInfrastructure/swagger.json", "CoreInfrastructure"); });
            //app.UseIdentity();
            // Runs matching. An endpoint is selected and set on the HttpContext if a match is found.
            app.UseRouting();
            // Executes the endpoint that was selected by routing.
            app.UseEndpoints(endpoints =>
            {
                // Mapping of endpoints goes here:
                endpoints.MapControllers();
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        "default",
            //        "api/{controller}/{action}");
            //    //defaults: new { controller = "RefType" });
            //    //routes.MapRoute(
            //    //    name: "LogsId",
            //    //    template: "api/[controller]/ID/{id}",
            //    //    defaults: new { controller = "BXLogs", action = "GetById" });

            //    //routes.MapRoute(
            //    //    name: "LogsAPI",
            //    //    template: "api/[controller]/API/{apiname}",
            //    //    defaults: new { controller = "BXLogs", action = "GetByAPI" });
            //});
        }
    }
}