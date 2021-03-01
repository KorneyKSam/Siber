using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sibers.DbStuff;
using Sibers.DbStuff.Models;
using Sibers.DbStuff.Repository;
using Sibers.Models;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Sibers
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
            var connectionString = @"Server=NOONE\SQLEXPRESS;Database=DBSibers;Trusted_Connection=True;";
            services.AddDbContext<DBSibersContext>(option => option.UseSqlServer(connectionString));
            RegistrationMapper(services);            
            RegistrationRepository(services);
            services.AddControllersWithViews();
        }

        private void RegistrationMapper(IServiceCollection services)
        {
            var configurationExpression = new MapperConfigurationExpression();

            configurationExpression.CreateMap<User, SignUpViewModel>();
            configurationExpression.CreateMap<SignUpViewModel, User>();

            configurationExpression.CreateMap<CustomerCompany, CustomerCompanyViewModel>();
            configurationExpression.CreateMap<CustomerCompanyViewModel, CustomerCompany>();

            configurationExpression.CreateMap<ExecutingCompany, ExecutingCompanyViewModel>();
            configurationExpression.CreateMap<ExecutingCompanyViewModel, ExecutingCompany>();

            configurationExpression.CreateMap<Employee, EmployeeViewModel>();
            configurationExpression.CreateMap<EmployeeViewModel, Employee>();


            configurationExpression.CreateMap<Project, ProjectViewModel>();
            configurationExpression.CreateMap<ProjectViewModel, Project>();

            configurationExpression.CreateMap<Project, ProjectInfoViewModel>();
            configurationExpression.CreateMap<ProjectInfoViewModel, Project>();

            var mapperConfiguration = new MapperConfiguration(configurationExpression);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(s => mapper);
        }

        public void RegistrationRepository(IServiceCollection services)
        {
            services.AddScoped<UserRepository>(serviceProvider => new UserRepository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<CustomerCompanyRepository>(serviceProvider => new CustomerCompanyRepository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<EmployeeRepository>(serviceProvider => new EmployeeRepository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<ProjectRepository>(serviceProvider => new ProjectRepository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<ExecutingCompanyRepository>(serviceProvider => new ExecutingCompanyRepository(serviceProvider.GetService<DBSibersContext>()));
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
