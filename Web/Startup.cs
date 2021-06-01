using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using ProjetoCinema.Domain.Model;
using ProjetoCinema.Web.ViewModel;
using System;

namespace Web
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Cookie.HttpOnly = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                        options.LoginPath = "/Account/Login";

                        //TODO Página de acesso negado
                        options.AccessDeniedPath = "/Account/AccessDenied";
                        options.SlidingExpiration = true;
                    });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

           // var config = new AutoMapper.MapperConfiguration(cfg =>
          //  {
               // cfg.CreateMap<FilmeViewModel, Filme>();
               // cfg.CreateMap<Filme, FilmeViewModel>();

            //    cfg.CreateMap<SalaViewModel, Sala>();
           //     cfg.CreateMap<Sala, SalaViewModel>();

             //   cfg.CreateMap<SessaoViewModel, Sessao>();
           //     cfg.CreateMap<Sessao, SessaoViewModel>();

           //     cfg.CreateMap<HomeViewModel, Home>();
          //      cfg.CreateMap<Home, HomeViewModel>();

           //     cfg.CreateMap<NotificacaoViewModel, Notificacao>();
           //     cfg.CreateMap<Notificacao, NotificacaoViewModel>();
          //  });

            //IMapper mapper = config.CreateMapper();
          //  services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
