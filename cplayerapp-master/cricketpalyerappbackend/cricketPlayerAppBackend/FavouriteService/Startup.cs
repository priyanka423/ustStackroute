using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavouriteService.Models;
using FavouriteService.Repository;
using FavouriteService.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FavouriteService
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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddMvc();
            //Implement token validation logic
            ValidateToken(Configuration, services);

            //register all dependencies here
            // services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<FavouriteContext>();
            services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            services.AddScoped<IFavouriteService, Service.FavouriteService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Favourite API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            /* services.AddCors();*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            /*app.UseCors(options =>
options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();*/
            // app.UseMvc();
            app.UseCors("AllowAll");
            //app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Favourite API");
            });
            /* app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());*/
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            /*app.UseCors(builder =>
                         builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
                );*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        //Implementation of ValidateToken method
        #region private void ValidateToken(IConfiguration configuration, IServiceCollection services)
        private void ValidateToken(IConfiguration configuration, IServiceCollection services)
        {
            var securityTokenParameters = configuration.GetSection("SecurityTokenParameters");
            var securityKey = securityTokenParameters["securitykey"];
            var keyBytes = Encoding.ASCII.GetBytes(securityKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = securityTokenParameters["Iss"],
                ValidateAudience = true,
                ValidAudience = securityTokenParameters["Aud"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => o.TokenValidationParameters = tokenValidationParameters);
        }

        #endregion
    }
}
