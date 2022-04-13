
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Country_Business_Category_Location_Assignment
{
    public class UserAppCountryBusinessCategoryLocationAssignmentRepository : IUserAppCountryBusinessCategoryLocationAssignmentRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppCountryBusinessCategoryLocationAssignmentRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment user_app_country_business_category_location_assignment_Model)
        {
            Response response = new Response();
            try
            {
                if (user_app_country_business_category_location_assignment_Model.user_app_country_business_category_location_Id == 0)
                    
                {
                    response.Data = (from master in _DbContext.user_app_country_business_category_location_assignment
                                     select new
                                     {
                                         country_business_category_location_Id = master.user_app_country_business_category_location_Id,
                                         country_id = master.user_app_country_id,
                                         Idb = master.user_app_business_category_id,
                                         Idc = master.user_app_category_id,
                                         user_app_id = master.user_app_id,
                                         custom_app_id = 0,
                                         Category_location = Convert.ToDecimal(master.user_app_category_location),
                                     }).ToList();
                    var obj = _DbContext.user_app_country_business_category_location_assignment.Add(user_app_country_business_category_location_assignment_Model);
                    _DbContext.SaveChanges();

                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditUserAppCountryBusinessCategoryLocationAssignment(user_app_country_business_category_location_assignment user_App_Country_Business_Category_Location_Assignment)
        {
            Response response = new Response();
            try
            {
                user_app_country_business_category_location_assignment _user_app_country_business_category_location_assignment_Model = new user_app_country_business_category_location_assignment();

                _user_app_country_business_category_location_assignment_Model.user_app_country_business_category_location_Id = user_App_Country_Business_Category_Location_Assignment.user_app_country_business_category_location_Id;
                _user_app_country_business_category_location_assignment_Model.user_app_country_id = user_App_Country_Business_Category_Location_Assignment.user_app_country_id;
                _user_app_country_business_category_location_assignment_Model.user_app_business_category_id = user_App_Country_Business_Category_Location_Assignment.user_app_business_category_id;
                _user_app_country_business_category_location_assignment_Model.user_app_category_id = user_App_Country_Business_Category_Location_Assignment.user_app_category_id;
                _user_app_country_business_category_location_assignment_Model.user_app_id = user_App_Country_Business_Category_Location_Assignment.user_app_id;
                _user_app_country_business_category_location_assignment_Model.user_app_category_location = user_App_Country_Business_Category_Location_Assignment.user_app_category_location;

               _DbContext.Attach(_user_app_country_business_category_location_assignment_Model);
                _DbContext.Entry(_user_app_country_business_category_location_assignment_Model).Property(p => p.user_app_country_id).IsModified = true;
                _DbContext.Entry(_user_app_country_business_category_location_assignment_Model).Property(p => p.user_app_business_category_id).IsModified = true;
                _DbContext.Entry(_user_app_country_business_category_location_assignment_Model).Property(p => p.user_app_category_id).IsModified = true;
                _DbContext.Entry(_user_app_country_business_category_location_assignment_Model).Property(p => p.user_app_id).IsModified = true;
                _DbContext.Entry(_user_app_country_business_category_location_assignment_Model).Property(p => p.user_app_category_location).IsModified = true;
                _DbContext.SaveChanges();
                 
                response.Message = "Data updated successfully !!";
                response.Status = true;
            }
            catch (Exception)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetUserAppCountryBusinessCategoryLocationAssignment()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_country_business_category_location_assignment
                                 select new
                                 {
                                     country_business_category_location_Id = master.user_app_country_business_category_location_Id,
                                     country_id = master.user_app_country_id,
                                     user_app_business_category_id = master.user_app_business_category_id,
                                     user_app_category_id = master.user_app_category_id,
                                     user_app_id = master.user_app_id,
                                     Category_location = Convert.ToDecimal(master.user_app_category_location),
                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }
    }
}
