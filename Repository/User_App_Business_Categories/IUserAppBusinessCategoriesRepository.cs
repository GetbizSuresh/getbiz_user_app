using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Business_Categories
{
    public interface IUserAppBusinessCategoriesRepository
    {
        Response GetALLUserAppBusinessCategories();
        Response AddUserAppBusinessCategories(user_app_business_categories user_app_business_categories);
        Response EditUserAppBusinessCategories(user_app_business_categories user_app_business_categories);
        Response DeleteUserAppBusinessCategory(string UserAppBusinessCategoryId);
        Response ReAssignUserAppsBusinessCategory(user_app_categories_parent1 user_app_categories_parent1);
        Response ReAssignUserAppsBusinessCategoryDeleteUserId(user_app_categories_parent1 user_app_categories_parent1);
        Response GetALLUserAppsBusinessCategoryAuditTrail();
    }
}
