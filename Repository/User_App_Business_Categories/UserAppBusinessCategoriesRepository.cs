
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Business_Categories
{
    public class UserAppBusinessCategoriesRepository : IUserAppBusinessCategoriesRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppBusinessCategoriesRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppBusinessCategories(user_app_business_categories user_app_business_categories)
        {
            Response response = new Response();
            try
            {
                
                  var obj = _DbContext.user_app_business_categories.Add(user_app_business_categories);
                  _DbContext.SaveChanges();


                business_category_audit_trail _user_app_business_category_audit_trail = new business_category_audit_trail();
                _user_app_business_category_audit_trail.user_app_business_category_id = user_app_business_categories.user_app_business_category_id;
                _user_app_business_category_audit_trail.user_app_activity = "Added";
                _user_app_business_category_audit_trail.user_app_activity_by_user_id = _user_app_business_category_audit_trail.user_app_activity_by_user_id;
                _user_app_business_category_audit_trail.user_app_activity_timestamp = DateTime.UtcNow;

                _DbContext.Add(_user_app_business_category_audit_trail);
                _DbContext.SaveChanges();   



                response.Message = "Data Saved successfully !!";
                    response.Status = true;
                
            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditUserAppBusinessCategories(user_app_business_categories user_app_business_categories)
        {
            Response response = new Response();
            try
            {
                user_app_business_categories _user_app_business_categories_Model = new user_app_business_categories();
                _user_app_business_categories_Model.user_app_business_category_id = user_app_business_categories.user_app_business_category_id;
                _user_app_business_categories_Model.user_app_business_category_path = user_app_business_categories.user_app_business_category_path;
                _user_app_business_categories_Model.user_app_business_category_name = user_app_business_categories.user_app_business_category_name;

                _DbContext.Attach(_user_app_business_categories_Model);
                _DbContext.Entry(_user_app_business_categories_Model).Property(p => p.user_app_business_category_path).IsModified = true;
                _DbContext.Entry(_user_app_business_categories_Model).Property(p => p.user_app_business_category_name).IsModified = true;

                business_category_audit_trail _user_app_business_category_audit_trail = new business_category_audit_trail();
                _user_app_business_category_audit_trail.user_app_business_category_id = user_app_business_categories.user_app_business_category_id;
                _user_app_business_category_audit_trail.user_app_activity = "Edited";
                _user_app_business_category_audit_trail.user_app_activity_by_user_id = _user_app_business_category_audit_trail.user_app_activity_by_user_id;
                _user_app_business_category_audit_trail.user_app_activity_timestamp = DateTime.UtcNow;

                _DbContext.Add(_user_app_business_category_audit_trail);

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

        public Response GetALLUserAppBusinessCategories()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_business_categories
                                 select new
                                 {
                                     user_app_business_category_id = master.user_app_business_category_id,
                                     user_app_business_category_path = master.user_app_business_category_path,
                                     user_app_business_category_name = master.user_app_business_category_name,
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


        public Response DeleteUserAppBusinessCategory(string UserAppBusinessCategoryId )
        {
            Response response = new Response();
            
            try
            {
               // List<user_app_country_business_category_location_assignment> _uac = new List<user_app_country_business_category_location_assignment>().ToList();
                
               var _uac = _DbContext.user_app_country_business_category_location_assignment.Where(l => l.user_app_business_category_id == l.user_app_business_category_id).FirstOrDefault();
               
                _uac.user_app_category_id.ToList();
                
                if (UserAppBusinessCategoryId == _uac.user_app_business_category_id) 
                {
                        response.Message = "User App Business Category already Exist !!";
                        response.Status = true;
                }
                else
                {
                    var user_app_business_category = _DbContext.user_app_business_categories.Where(z => z.user_app_business_category_id == Convert.ToString(UserAppBusinessCategoryId)).FirstOrDefault();
                    _DbContext.user_app_business_categories.Remove(user_app_business_category);
                    _DbContext.SaveChanges();

                    business_category_audit_trail _user_app_business_category_audit_trail = new business_category_audit_trail();
                    _user_app_business_category_audit_trail.user_app_business_category_id = user_app_business_category.user_app_business_category_id;   
                    _user_app_business_category_audit_trail.user_app_activity = "Deleted";
                    _user_app_business_category_audit_trail.user_app_activity_by_user_id = _user_app_business_category_audit_trail.user_app_activity_by_user_id;
                    _user_app_business_category_audit_trail.user_app_activity_timestamp = DateTime.UtcNow;
                    _DbContext.Add(_user_app_business_category_audit_trail);

                    _DbContext.SaveChanges();

                    //response.Message = "User Business Category Deleted successfully !!";
                    //response.Status = true;


                    response.Message = "User Business Category Deleted successfully !!";
                    response.Status = true;

                }



                //var business_category_about_demo = _DbContext.user_app_business_category_about_demo.Where(d => d.user_app_business_category_id == UserAppBusinessCategoryId).FirstOrDefault();
                //_DbContext.user_app_business_category_about_demo.Remove(business_category_about_demo);


                //var business_category_audit_trail = _DbContext.business_category_audit_trail.Where(m => m.user_app_business_category_id == UserAppBusinessCategoryId).FirstOrDefault();
                //_DbContext.business_category_audit_trail.Remove(business_category_audit_trail);

               
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }


        public Response ReAssignUserAppsBusinessCategory(user_app_categories_parent1 user_app_categories_parent1)
        {
            Response response = new Response();

            var getData = _DbContext.user_app_country_business_category_location_assignment.Where(z => z.user_app_id == user_app_categories_parent1.user_app_id
                && z.user_app_business_category_id == user_app_categories_parent1.user_app_business_category_id).FirstOrDefault();


            if (getData == null)
            {
                user_app_country_business_category_location_assignment user_App_Country_Business_Category_Location_Assignment = new user_app_country_business_category_location_assignment
                {
                    user_app_business_category_id = user_app_categories_parent1.user_app_business_category_id,
                    user_app_id = user_app_categories_parent1.user_app_id,
                    user_app_category_location = (int)user_app_categories_parent1.user_app_category_location,
                    user_app_category_id = user_app_categories_parent1.user_app_category_id,
                    user_app_country_id = (int)user_app_categories_parent1.user_app_country_id
                   
                };

                _DbContext.Attach(user_App_Country_Business_Category_Location_Assignment);
                _DbContext.Entry(user_App_Country_Business_Category_Location_Assignment).Property(p => p.user_app_id);
                _DbContext.Entry(user_App_Country_Business_Category_Location_Assignment).Property(p => p.user_app_category_location);
                _DbContext.Entry(user_App_Country_Business_Category_Location_Assignment).State = EntityState.Added;

                _DbContext.SaveChanges();
                response.Status = true;
                response.Message = "Apps Assigned Successfully..";
            }
            else
            {
                response.Status = false;
                response.Message = "User App Id already Exist !!";
            }
            //catch (Exception ex)
            //{
            //    response.Status = false;
            //    response.Message = "Error occured while assigning the apps..";
            //}

            return response;
        }


        public Response ReAssignUserAppsBusinessCategoryDeleteUserId(user_app_categories_parent1 user_app_categories_parent1)
        {
            Response response = new Response();
            try
            {
                var getData = _DbContext.user_app_country_business_category_location_assignment.Where(z => z.user_app_id == user_app_categories_parent1.user_app_id
                && z.user_app_business_category_id == user_app_categories_parent1.user_app_business_category_id).FirstOrDefault();
                _DbContext.user_app_country_business_category_location_assignment.Remove(getData);
                _DbContext.SaveChanges();
                response.Message = "User Id Category Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }


        public Response GetALLUserAppsBusinessCategoryAuditTrail()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.business_category_audit_trail
                                 join assign in _DbContext.user_app_business_categories on master.user_app_business_category_id
                                  equals assign.user_app_business_category_id


                                 select new
                                 {
                                     // User_App_Audit_Trail_Id = master.user_app_audit_trail_Id,
                                     user_app_business_category_id = master.user_app_business_category_id,
                                     User_App_Activity = master.user_app_activity,
                                     User_App_Activity_By_User_Id = master.user_app_activity_by_user_id,
                                     User_App_Activity_Time_Stamp = master.user_app_activity_timestamp,
                                     user_app_business_category_name = assign.user_app_business_category_name,
                                     //User_App_Full_Name = assign.user_app_full_name,


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
