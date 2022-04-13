
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Categories
{
    public class UserAppCategoriesRepository : IUserAppCategoriesRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppCategoriesRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppCategories(user_app_categories user_app_categories)
        {
            Response response = new Response();
            try
            {
                    var obj = _DbContext.user_app_categories.Add(user_app_categories);
                    _DbContext.SaveChanges();

                    response.Message = "Data Saved successfully !!";
                    response.Status = true;

            }
            catch (Exception ex)
            {
                response.Message = "Category Id Alreday Exist and Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response AddUserAppCategoryUser(user_app_categories_parent1 user_app_categories_parent1)
        {
            Response response = new Response();
            try
            {
                var getData = _DbContext.user_app_country_business_category_location_assignment.Where(z => z.user_app_id == user_app_categories_parent1.user_app_id
                && z.user_app_category_id == user_app_categories_parent1.user_app_category_id).FirstOrDefault();


                if (getData == null)
                {
                    user_app_country_business_category_location_assignment user_Apps_And_Categories_Location_Assignment = new user_app_country_business_category_location_assignment
                    {
                        user_app_category_id = user_app_categories_parent1.user_app_category_id,
                        user_app_country_id = user_app_categories_parent1.user_app_country_id,
                        user_app_id = user_app_categories_parent1.user_app_id,
                        custom_app_id = user_app_categories_parent1.custom_app_id,
                        user_app_business_category_id = user_app_categories_parent1.user_app_business_category_id,
                        user_app_category_location = (int)user_app_categories_parent1.user_app_category_location
                    };

                    _DbContext.Attach(user_Apps_And_Categories_Location_Assignment);
                    _DbContext.Entry(user_Apps_And_Categories_Location_Assignment).Property(p => p.user_app_id);
                    _DbContext.Entry(user_Apps_And_Categories_Location_Assignment).Property(p => p.user_app_category_location);
                    _DbContext.Entry(user_Apps_And_Categories_Location_Assignment).State = EntityState.Added;

                    _DbContext.SaveChanges();

                    response.Status = true;
                    response.Message = "Data updated Successfully";
                }
                else
                {
                    response.Status = false;
                    response.Message = "user App Id already Exist !!";
                }

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Data updated failed..";
            }
            return response;
        }




        public Response EditUserAppCategories(user_app_categories user_app_categories)
        {
            Response response = new Response();
            try
            {
                user_app_categories _user_app_categories_Model = new user_app_categories();
                _user_app_categories_Model.user_app_category_id = user_app_categories.user_app_category_id;
                _user_app_categories_Model.user_app_category_path = user_app_categories.user_app_category_path;
                _user_app_categories_Model.user_app_category_name = user_app_categories.user_app_category_name;

                _DbContext.Attach(_user_app_categories_Model);
                _DbContext.Entry(_user_app_categories_Model).Property(p => p.user_app_category_path).IsModified = true;
                _DbContext.Entry(_user_app_categories_Model).Property(p => p.user_app_category_name).IsModified = true;
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

        public Response GetALLUserAppCategories()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_categories
                                 select new
                                 {
                                     user_app_category_id = master.user_app_category_id,
                                     user_app_category_path = master.user_app_category_path,
                                     user_app_category_name = master.user_app_category_name,
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


        public Response DeleteUserCategory(string UserCategoryId)
        {
            Response response = new Response();
            try
            {
                var user_app_category = _DbContext.user_app_categories.Where(z => z.user_app_category_id == Convert.ToString(UserCategoryId)).FirstOrDefault();
                _DbContext.user_app_categories.Remove(user_app_category);
                _DbContext.SaveChanges();
                response.Message = "User Category Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }


        public Response ReAssignUserApps(user_app_categories_parent1 user_app_categories_parent1)
        {
            Response response = new Response();
            
            var getData = _DbContext.user_app_country_business_category_location_assignment.Where(z => z.user_app_id == user_app_categories_parent1.user_app_id
                && z.user_app_category_id == user_app_categories_parent1.user_app_category_id).FirstOrDefault();


            if (getData == null)
            {
                user_app_country_business_category_location_assignment user_App_Country_Business_Category_Location_Assignment = new user_app_country_business_category_location_assignment
                {
                    user_app_category_id = user_app_categories_parent1.user_app_category_id,
                    user_app_id = user_app_categories_parent1.user_app_id,
                    user_app_category_location = (int)user_app_categories_parent1.user_app_category_location,
                    user_app_country_id = (int)user_app_categories_parent1.user_app_country_id,
                    user_app_business_category_id = user_app_categories_parent1.user_app_business_category_id
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

        public Response ReAssignAppsDeleteUserId(user_app_categories_parent1 user_app_categories_parent1)
        {
            Response response = new Response();
            try
            {
                var getData = _DbContext.user_app_country_business_category_location_assignment.Where(z => z.user_app_id == user_app_categories_parent1.user_app_id
                && z.user_app_category_id == user_app_categories_parent1.user_app_category_id).FirstOrDefault();
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


    }
}
