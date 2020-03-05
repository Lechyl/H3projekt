using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ORM.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using LongigantenAPI.Helpers;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace LongigantenAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(configuration => {
                configuration.ReturnHttpNotAcceptable = true;
            })
            //configure to use Json.net for patch methods
            .AddNewtonsoftJson( setupAction => {
                setupAction.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            })
            //Configure to use XML and Return http not acceptable
            .AddXmlDataContractSerializerFormatters()

            //Configure Default Validation Error message for client.
            .ConfigureApiBehaviorOptions(setupAction => {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = "https://localhost:5000/modelvalidationproblem",
                        Title = "One or more model validation errors occurred.",
                        Status = StatusCodes.Status422UnprocessableEntity,
                        Detail = "See the errors property for details.",
                        Instance = context.HttpContext.Request.Path
                    };

                    problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);
                    //Return as Error 422 UnprocessableEntityObjectResult
                    return new UnprocessableEntityObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });

            //add cache headers
            services.AddResponseCaching();

            //allow cross site origin
            services.AddCors();
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            //Mapping between ORM models to/and MVC Models on Current Domain/This system
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Add the service ORM to the project
            services.AddScoped <IORM>(x => new ORM_MSSQL("localhost", "LongGigantenLogin", "1234", "LongigantenDB",appSettings.Secret));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Development and production mode switch
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Exception handler for Client, return 500 with custom message
                app.UseExceptionHandler(appbuilder =>
                {
                    appbuilder.Run(async context => {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    
                    });
                });
            }

              

            //Using Routing
            app.UseRouting();

            app.UseCors(
            options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            //use cache headers
            app.UseResponseCaching();

            //use Authentica´tion and Authorization for JWT.
            app.UseAuthentication();
            app.UseAuthorization();


            //Route to/from Controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
