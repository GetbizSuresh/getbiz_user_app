using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.Get_Categories_User_Apps
{
    public interface IGetCategoriesUserAppsRepository
    {
        Response2 GetCategoriesUserAppsByPathOrId(string UserAppCategoryPath, string UserAppCategoryId);
    }
}
