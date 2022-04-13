using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Business_Category_About_Demo
{
    public interface IUserAppBusinessCategoryAboutDemoRepository
    {
        Response GetALLUserAppAboutDemoCategories();
        Response AddUserAppAboutDemoCategories(user_app_business_category_about_demo user_app_business_category_about_demo);
        Response EditUserAppAboutDemoCategories(user_app_business_category_about_demo user_app_business_category_about_demo);
        Response GetUserAppAboutDemoCategoriesById(string GetDemoCategoriesById);
    }
}
