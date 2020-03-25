using AM.API.Helpers;
using AM.API.Services.Assets;
using AM.API.Services.Categories;
using AM.API.Services.Manufacturers;
using AM.API.Services.Models;
using AM.API.Services.Processors;
using AM.API.Services.Sizes;
using AM.API.Services.Suppliers;
using AM.API.Services.Users;
using AM.API.Validators;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace AM.API
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

            services.AddDbContext<DataContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidateModelStateFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAutoMapper();

            // START: Configure DI for application services
            #region Manufacturer
            services.AddScoped<IManufacturerService, ManufacturerService>();
            #endregion

            #region Category
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion

            #region Model
            services.AddScoped<IModelService, ModelService>();
            #endregion

            #region Size
            services.AddScoped<IHardDiskSizeService, HardDiskSizeService>();
            services.AddScoped<IMemorySizeService, MemorySizeService>();
            services.AddScoped<IVideoCardSizeService, VideoCardSizeService>();
            #endregion

            #region Supplier
            services.AddScoped<ISupplierService, SupplierService>();
            #endregion

            #region Processor
            services.AddScoped<IProcessorService, ProcessorService>();
            #endregion

            #region Asset
            services.AddScoped<IAssetService, AssetService>();
            #endregion

            #region User
            services.AddScoped<IUserService, UserService>();
            #endregion
            //  END

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Info { Title = "Assets Management API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Configure JWT Authentication
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Assets Management API");
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
