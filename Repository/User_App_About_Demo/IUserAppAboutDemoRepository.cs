using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_About_Demo
{
    public interface IUserAppAboutDemoRepository
    {
        Response GetALLUserAppAboutDemo();
        Response AddUserAppAboutDemo(user_app_about_demo user_app_about_demo);
        Response EditUserAppAboutDemo(user_app_about_demo user_app_about_demo);
        Response DeleteuserAppAboutDemo(user_app_about_demo user_app_about_demo);
        Response GetUserAppAboutDemoById(int user_app_id);
    }
}
