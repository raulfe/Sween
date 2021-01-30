using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sween.Core.CustomEntities;
using Sween.Core.Interfaces;
using Sween.Core.Services;
using Sween.Infrastructure.Data;
using Sween.Infrastructure.Filters;
using Sween.Infrastructure.Interfaces;
using Sween.Infrastructure.Repositorios;
using Sween.Infrastructure.Services;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Sween.API
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }   ).ConfigureApiBehaviorOptions(options => { //options.SuppressModelStateInvalidFilter = true; 
            });
            
            services.AddDbContext<SweenContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Sween")));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISecurityRepository, SecurityRepository>();
            services.AddTransient<IMessagesRepository, MessagesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider => { var acceso = provider.GetRequiredService<IHttpContextAccessor>(); var request = acceso.HttpContext.Request; var absoluteUri = string.Concat(request.Scheme, "://",request.Host.ToUriComponent()); return new UriService(absoluteUri); });
            services.AddSwaggerGen(doc => { doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Sween API", Version = "v1" }); var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); doc.IncludeXmlComments(xmlPath); });
            services.AddAuthentication(options => { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; }).AddJwtBearer(options => { options.TokenValidationParameters = new TokenValidationParameters { ValidateIssuer = true, ValidateAudience = true, ValidateLifetime = true, ValidateIssuerSigningKey = true, ValidIssuer = Configuration["Authentication:Issuer"],ValidAudience=Configuration["Authentication:Audience"],IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))}; });
            services.AddMvc(option => { option.Filters.Add<ValidationFilter>(); }).AddFluentValidation(options => { options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Sween API");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
