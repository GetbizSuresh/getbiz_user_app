using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.Getbiz_App_Launch_Screen_Display
{
    public interface IGetbizAppLaunchScreenDisplayRepository
    {
        Response GetALLGetbizAppLaunchScreenDisplay();
        Response GetALLGetbizAppLaunchScreenDisplayById(int user_app_id);
        Response AddGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display getbiz_app_launch_screen_display);
        Response EditGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display getbiz_app_launch_screen_display);
    }
}
