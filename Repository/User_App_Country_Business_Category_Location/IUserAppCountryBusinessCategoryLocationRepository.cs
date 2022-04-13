using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Country_Business_Category_Location_Assignment
{
    public interface IUserAppCountryBusinessCategoryLocationAssignmentRepository
    {
        Response GetUserAppCountryBusinessCategoryLocationAssignment();
        Response AddUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment user_app_country_business_category_location_assignment_Location);
        Response EditUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment user_app_country_business_category_location_assignment_Location);
    }
}
