using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Filters;
using ProyectoBCP_API.Jwt;
using ProyectoBCP_API.Jwt.Provider;
using ProyectoBCP_API.Jwt.Provider.Impl;
using ProyectoBCP_API.Jwt.Session;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Service.Impl;
using Remi.Api.Filters;

namespace ProyectoBCP_API
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
            services.AddControllers(options =>
            {
                options.Filters.Add(new CustomExceptionFilterAttribute());
            });
            services.AddCors(options => options.AddDefaultPolicy(
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            //builder => builder.WithOrigins("")
            ));
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<JwtSettings>(Configuration.GetSection("JWT"))
                .AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);

            //Services
            services.AddScoped<ITokenProvider, JwTokenProvider>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<IChapterAreaLeaderServices, ChapterAreaLeaderService>();
            services.AddScoped<IChapterLeaderService, ChapterLeaderService>();
            services.AddScoped<ITribeService, TribeService>();
            services.AddScoped<ISquadService, SquadService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolService, RolService>();


            //Session
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPrincipal, DefaultPrincipal>();
            services.AddScoped<IUserSession, UserSession>();

            //Filters
            services.AddScoped<IsAuthenticatedAttribute>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ISubMenuService, SubMenuService>(); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyectoBCP_API", Version = "v1" });
            });
            services.AddControllersWithViews().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoBCP_API v1"));
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
