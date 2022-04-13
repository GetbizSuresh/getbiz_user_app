using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.Get_Business_Categories_User_Apps
{
    public interface IGetBusinessCategoriesUserAppsRepository
    {
        Response2 GetBusinessCategoriesUserAppsByPathOrId(string UserAppBusinessCategoryPath, string UserAppBusinessCategoryId);

    }
}
