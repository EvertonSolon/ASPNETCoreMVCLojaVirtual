using LojaVirtual.BaseDeDados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LojaVirtual.Repositorios;
using LojaVirtual.Repositorios.Contracts;
using LojaVirtual.Bibliotecas.Sessao;
using LojaVirtual.Bibliotecas.Login;
using LojaVirtual.Bibliotecas.PagedLlist;
using LojaVirtual.Bibliotecas.Email;
using System.Net.Mail;
using System.Net;

namespace LojaVirtual
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public Startup(IHostingEnvironment variavelDeAmbiente)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(variavelDeAmbiente.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{variavelDeAmbiente.EnvironmentName}.json", optional: true)
        //        .AddEnvironmentVariables();
        //    Configuration = builder.Build();

        //    var ambiente
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Old
            /* 
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            */
            #endregion

            //Para obter as configuração do appsettings.
            services.Configure<PagedListConfiguracao>(Configuration.GetSection("XPagedList"));
            services.Configure<EmailConfiguracao>(Configuration.GetSection("Email"));

            //Todas as classes que serão utilizadas pela injeção de dependência deverão ser incluídas nas linhas abaixo.

            //Configuração para que a injeção de dependência funcione na classe Sessao.
            services.AddHttpContextAccessor();

            #region Repository pattern
            //services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IClienteRepository, ClienteRepositorio>();
            services.AddScoped<INewsLetterRepository, NewsLetterRepositorio>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepositorio>();
            services.AddScoped<ICategoriaRepository, CategoriaRepositorio>();

            //Teste 1 
            services.AddScoped(options =>
            {
                var smtp = new SmtpClient
                {
                    Host = Configuration.GetValue<string>("Email:ServerSMTP"),
                    Port = Configuration.GetValue<int>("Email:ServerPort"),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Configuration.GetValue<string>("Email:UserName"),
                                  Configuration.GetValue<string>("Email:Password")),
                    EnableSsl = true
                };

                return smtp;
            });

            services.AddScoped<GerenciarEmail>();

            #endregion

            //#region Início da implementação do estado de sessão para tempdata
            //services.AddDistributedMemoryCache();

            //services.AddSession(options =>
            //{
            //    // Defini o tempo inativo (Idle timeout) da sessão para 10 segundos apenas para facilitar os testes.
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //});
            //#endregion Fim da implementação do estado de sessão para tempdata

            #region Configuração da Sessão para cookies
            services.AddMemoryCache();
            services.AddSession(options =>
            {
            });

            services.AddScoped<Sessao>();//Permite que a classe Sessao seja utilizado em qualquer parte da LojaVirtual.
            services.AddScoped<LoginCliente>();
            services.AddScoped<LoginColaborador>();

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //TODO: REFATORAR
            //var connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtual;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(connection));

            //POR ESTE
            services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LojaVirtualContext")));
            //FONTE: https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-3.0&tabs=visual-studio
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles(); //Carrega o site com os arquivos no wwwroot. Como movi os arquivos para pasta paginas, a aplicação não irá mais encontrar os arquivos para serem exibidos na página inicial.
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
