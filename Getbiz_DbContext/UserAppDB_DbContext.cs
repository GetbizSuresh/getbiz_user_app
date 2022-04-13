using getbiz_user_app.Models;
using Microsoft.EntityFrameworkCore;

namespace getbiz_user_app.Getbiz_DbContext
{
    public class UserAppDB_DbContext : DbContext
    {
        public UserAppDB_DbContext(DbContextOptions<UserAppDB_DbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<getbiz_app_launch_screen_display> getbiz_app_launch_screen_display { get; set; }
        public DbSet<user_app_about_demo> user_app_about_demo { get; set; }
        public DbSet<user_app_business_categories> user_app_business_categories { get; set; }
        public DbSet<user_app_business_category_about_demo> user_app_business_category_about_demo { get; set; }
        public DbSet<user_app_categories> user_app_categories { get; set; }
        public DbSet<user_app_countries> user_app_countries { get; set; }
        public DbSet<user_app_country_business_category_location_assignment> user_app_country_business_category_location_assignment { get; set; }
        public DbSet<user_app_master> user_app_master { get; set; }
        public DbSet<user_app_names> user_app_names { get; set; }
        public DbSet<user_apps_audit_trail> user_apps_audit_trail { get; set; }
        public DbSet<user_apps_update_time_stamp> user_apps_update_time_stamp { get; set; }
        public DbSet<user_app_cloud_file_storage_permissions> user_app_cloud_file_storage_permissions { get; set; }
        public DbSet<user_app_additional_data> user_app_additional_data { get; set; }
        public DbSet<business_category_audit_trail> business_category_audit_trail { get; set; }
        public DbSet<country_audit_trail> country_audit_trail { get; set; }
    }
}
