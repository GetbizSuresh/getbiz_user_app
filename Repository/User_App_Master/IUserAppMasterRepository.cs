using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Master
{
    public interface IUserAppMasterRepository
    {
        //Response GetUserAppData();
        Response2 GetUserAppData();
        Response AddUserAppData(user_app_master_Fetchdata user_App_Master_Model);
        Response EditUserAppData(user_app_master_Fetchdata user_App_Master_Model);
        Response GetUserAppDataById(int GetUserAppDataById);

        Response UpdateUserAppDevelopmentStatus(int UserAppId, bool developmentStatus);

        Response GetCustomAppData();
        Response GetUserAppCustomAppdata();

        Response GetUserAppCustomAppCategoryId(string Categoryid);

    }
}
