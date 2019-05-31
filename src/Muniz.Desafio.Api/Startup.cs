using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Muniz.Desafio.Crosscutting.IoC;
using SimpleInjector;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Muniz.Desafio.Api
{
    public class Startup
    {
        private Container container = new Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope.
                options.AddAspNetCore()
                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    .AddControllerActivation()
                    
                    .AddViewComponentActivation();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Desafio Radix",
                        Version = "v1",
                        Description = "API Rest para registrar e analisar as informações dos sensores"
                       
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            CustomDependecyResolver.Resolve(container);
            container.Verify();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Desafio Radix");
            });
           
        }
    }
}
