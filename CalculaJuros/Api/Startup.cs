using Api.Interface;
using Api.Model;
using Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Api
{
    /// <summary>
    /// Classe responsável para configurar inicialização da aplicação
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor da classe de 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Interface de configuração
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configuração dos services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Criando a injeção de dependência do service
            services.AddScoped<ICalculaJurosService, CalculaJurosService>();

            //Cria um única instancia das configurações da aplicação
            var config = new ConfiguracaoDaAplicacao();
            Configuration.Bind("ConfiguracaoDaAplicacao", config);
            services.AddSingleton(config);

            //Preparando o Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info
                {
                    Version = "v1.0",
                    Title = "API - Calculadora de Juros",
                    Description = "API em Asp .Net Core 2.2 que realiza cálculo de juros",
                    Contact = new Contact
                    {
                        Name = "Wellington Alves da Silva",
                        Email = "wellington.alvesdasilva@hotmail.com",
                        Url = "https://github.com/wellingtonalvesdasilva"
                    }
                });

                //Obtendo o diretório e depois o nome do arquivo .xml de comentários
                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");
                c.IncludeXmlComments(xmlDocumentPath);
            });
        }


        /// <summary>
        /// Configurar a aplicação
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //Preparando o Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "API de Cálculo de Juros v1.0");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
