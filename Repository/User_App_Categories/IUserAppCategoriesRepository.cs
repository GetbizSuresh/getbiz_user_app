using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Categories
{
    public interface IUserAppCategoriesRepository
    {
        Response GetALLUserAppCategories();
        Response AddUserAppCategories(user_app_categories user_app_categories);
        Response AddUserAppCategoryUser(user_app_categories_parent1 user_app_categories_parent1);
        Response EditUserAppCategories(user_app_categories user_app_categories);
        Response DeleteUserCategory(string UserCategoryId);
        Response ReAssignUserApps(user_app_categories_parent1 user_app_categories_parent1);
        Response ReAssignAppsDeleteUserId(user_app_categories_parent1 user_app_categories_parent1);
    }
}
