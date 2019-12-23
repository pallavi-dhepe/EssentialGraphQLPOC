using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DashboardBackend.DataAccess.Contracts;
using DashboardBackend.DataAccess.Repositories;
using DashboardBackend.Database;
using DashboardBackend.Queries;
using DashboardBackend.Schemas;
using DashboardBackend.Types;
using DashboardBackend.BL.Services;
using DashboardBackend.BL.Interfaces;

namespace DashboardBackend
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();

            services.AddDbContext<DashboardDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DashboardDBConnection"]));
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ProjectQuery>();
            services.AddSingleton<ProjectType>();
            services.AddSingleton<PersonType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new DashboardDBContextSchema(new FuncDependencyResolver(type => sp.GetService(type))));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
