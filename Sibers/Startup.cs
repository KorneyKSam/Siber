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
using Sibers.Models.Authorization;
using Sibers.Models.CustomerCompany;
using Sibers.Models.Employee;
using Sibers.Models.ExecutingCompany;
using Sibers.Models.Project;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Sibers
{
    public class Startup
    {
        public const string AuthMethod = "CookieAuth";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = @"Server=NOONE\SQLEXPRESS;Database=DBSibers;Trusted_Connection=True;";
            services.AddDbContext<DBSibersContext>(option => option.UseSqlServer(connectionString));

            services.AddAuthentication(AuthMethod).AddCookie(AuthMethod, config =>
            {
                config.Cookie.Name = "User.Sibers";
                config.LoginPath = "/Authorization/SignIn";
                config.AccessDeniedPath = "/Account/AccessDenied";
            });

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

            var mapperConfiguration = new MapperConfiguration(configurationExpression);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(s => mapper);
        }

        public void RegistrationRepository(IServiceCollection services)
        {
            services.AddScoped<User_Repository>(serviceProvider => new User_Repository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<Customer_Company_Repository>(serviceProvider => new Customer_Company_Repository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped(serviceProvider => new DbStuff.Repository.Employee_Project_Repository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<Employee_Repository>(serviceProvider => new Employee_Repository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<Project_Repository>(serviceProvider => new Project_Repository(serviceProvider.GetService<DBSibersContext>()));
            services.AddScoped<Executing_Company_Repository>(serviceProvider => new Executing_Company_Repository(serviceProvider.GetService<DBSibersContext>()));
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
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
