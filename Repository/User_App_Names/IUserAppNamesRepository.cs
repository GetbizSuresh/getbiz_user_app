using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Names
{
    public interface IUserAppNamesRepository
    {
        Response GetALLUserAppNames();
        Response AddUserAppNames(user_app_names user_App_Names);
        Response EditUserAppNames(user_app_names user_App_Names);
    }
}
