using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Countries
{
    public interface IUserAppCountriesRepository
    {
        Response GetALLUserAppCountries();
        Response AddUserAppCountries(user_app_countries user_App_Countries);
        Response EditUserAppCountries(user_app_countries user_app_countries);
        Response DeleteUserAppCountries(int UserAppCountryId);
        Response GetALLUserAppCountryAuditTrail();
    }
}
