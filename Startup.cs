
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Repository.Get_All_Master;
using getbiz_user_app.Repository.Get_Business_Categories_User_Apps;
using getbiz_user_app.Repository.Get_Categories_User_Apps;
using getbiz_user_app.Repository.Getbiz_App_Launch_Screen_Display;
using getbiz_user_app.Repository.User_App_About_Demo;
using getbiz_user_app.Repository.User_App_Additional_Data;
using getbiz_user_app.Repository.User_App_Business_Categories;
using getbiz_user_app.Repository.User_App_Business_Category_About_Demo;
using getbiz_user_app.Repository.User_App_Categories;
using getbiz_user_app.Repository.User_App_Cloud_File_Storage_Permissions;
using getbiz_user_app.Repository.User_App_Comment;
using getbiz_user_app.Repository.User_App_Communication;
using getbiz_user_app.Repository.User_App_Countries;
using getbiz_user_app.Repository.User_App_Country_Business_Category_Location_Assignment;
using getbiz_user_app.Repository.User_App_Master;
using getbiz_user_app.Repository.User_App_Names;
using getbiz_user_app.Repository.User_Apps_Audit_Trail;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace getbiz_user_app
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

            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<UserAppDB_DbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddControllers().AddNewtonsoftJson();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "getbiz_user_app", Version = "v1" });
            });


            services.AddScoped<IGetbizAppLaunchScreenDisplayRepository, GetbizAppLaunchScreenDisplayRepository>();
            services.AddScoped<IUserAppAboutDemoRepository, UserAppAboutDemoRepository>();
            services.AddScoped<IUserAppBusinessCategoriesRepository, UserAppBusinessCategoriesRepository>();
            services.AddScoped<IUserAppBusinessCategoryAboutDemoRepository, UserAppBusinessCategoryAboutDemoRepository>();
            services.AddScoped<IUserAppCategoriesRepository, UserAppCategoriesRepository>();
            services.AddScoped<IUserAppCountriesRepository, UserAppCountriesRepository>();
            services.AddScoped<IUserAppCountryBusinessCategoryLocationAssignmentRepository, UserAppCountryBusinessCategoryLocationAssignmentRepository>();
            services.AddScoped<IUserAppMasterRepository, UserAppMasterRepository>();
            services.AddScoped<IUserAppNamesRepository, UserAppNamesRepository>();
            services.AddScoped<IUserAppsAuditTrailRepository, UserAppsAuditTrailRepository>();
            services.AddScoped<IUserAppCommentsSectionRepository, UserAppCommentsSectionRepository>();
            services.AddScoped<IUserAppCloudFileStoragePermissionsRepository, UserAppCloudFileStoragePermissionsRepository>();
            services.AddScoped<IUserAppAdditionalDataRepository, UserAppAdditionalDataRepository>();
            services.AddScoped<IUserAppCommunicationRepository, UserAppCommunicationRepository>();
            services.AddScoped<IGetCategoriesUserAppsRepository, GetCategoriesUserAppsRepository>();
            services.AddScoped<IGetAllMasterUserAppsRepository, GetAllMasterUserAppsRepository>();
            services.AddScoped<IGetBusinessCategoriesUserAppsRepository, GetBusinessCategoriesUserAppsRepository>();

            services.AddCors(option => option.AddPolicy("getbiz_user_app", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "getbiz_user_app v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true)
              .AllowCredentials());


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
