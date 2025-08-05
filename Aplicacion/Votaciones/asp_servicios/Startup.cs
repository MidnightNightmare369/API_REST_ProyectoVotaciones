using asp_servicios.Controllers;
using libr_aplicaciones.Implementaciones;
using libr_aplicaciones.Interfaces;
using libr_repositorios;
using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x =>
            {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x =>
            {
                x.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            // Repositorios
            services.AddScoped<IConexion, Conexion>();

            // Aplicaciones
            services.AddScoped<IVotersApp, VotersApp>();
            services.AddScoped<ICandidatesApp, CandidatesApp>();
            services.AddScoped<IVotesApp, VotesApp>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddScoped<VotersController, VotersController>();
            services.AddScoped<CandidatesController, CandidatesController>();
            services.AddScoped<VotesController, VotesController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors();
        }

    }
}
