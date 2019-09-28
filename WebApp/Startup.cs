﻿using AutoMapper;
using Business;
using Business.Interface;
using Core.Architecture;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelData.Context;
using ModelData.Model;
using ModelData.Model.ViewModel;
using Repository;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<TaskContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Configura a injeção de dependência
            services.AddScoped<IGenericRepository<Tarefa>, TaskRepository>();
            services.AddScoped<ITaskBusiness, TaskBusiness>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Configurando o mapeamento de modelo de dados para view model ou vice-versa
            var configuracaoMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<TarefaViewModel, Tarefa>();
                config.CreateMap<Tarefa, TarefaViewModel>();
            });
            IMapper mapper = configuracaoMapper.CreateMapper();
            services.AddSingleton(mapper);
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
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}