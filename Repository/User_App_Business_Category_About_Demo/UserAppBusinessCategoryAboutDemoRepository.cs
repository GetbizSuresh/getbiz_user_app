
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Business_Category_About_Demo
{
    public class UserAppBusinessCategoryAboutDemoRepository : IUserAppBusinessCategoryAboutDemoRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppBusinessCategoryAboutDemoRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppAboutDemoCategories(user_app_business_category_about_demo user_app_business_category_about_demo)
        {
            Response response = new Response();
            try
            {
                //if (user_app_business_category_about_demo.Id == null)
                //{
                  //  user_app_business_category_about_demo.user_app_business_category_description_timestamp = DateTime.UtcNow;
                    var obj = _DbContext.user_app_business_category_about_demo.Add(user_app_business_category_about_demo);
                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                //}
            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditUserAppAboutDemoCategories(user_app_business_category_about_demo user_app_business_category_about_demo)
        {
            Response response = new Response();
            try
            {
                user_app_business_category_about_demo _user_app_business_category_about_demo_Model = new user_app_business_category_about_demo();
               // _user_app_business_category_about_demo_Model.user_app_business_category_about_demo_id = user_app_business_category_about_demo.user_app_business_category_about_demo_id;
                _user_app_business_category_about_demo_Model.user_app_business_category_id = user_app_business_category_about_demo.user_app_business_category_id;
                _user_app_business_category_about_demo_Model.user_app_business_category_demo_video_path = user_app_business_category_about_demo.user_app_business_category_demo_video_path;
                _user_app_business_category_about_demo_Model.user_app_business_category_description_timestamp = user_app_business_category_about_demo.user_app_business_category_description_timestamp;

                _DbContext.Attach(_user_app_business_category_about_demo_Model);
               // _DbContext.Entry(_user_app_business_category_about_demo_Model).Property(p => p.user_app_business_category_id).IsModified = true;
                _DbContext.Entry(_user_app_business_category_about_demo_Model).Property(p => p.user_app_business_category_demo_video_path).IsModified = true;
                _DbContext.Entry(_user_app_business_category_about_demo_Model).Property(p => p.user_app_business_category_description_timestamp).IsModified = true;

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

        public Response GetALLUserAppAboutDemoCategories()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_business_category_about_demo
                                 select new
                                 {
                                     //Business_Category_About_Demo_Id = master.user_app_business_category_about_demo_id,
                                     user_app_business_category_id = master.user_app_business_category_id,
                                     Business_Category_Demo_Video_Path = master.user_app_business_category_demo_video_path,
                                     Business_Category_Description_Time_Stamp = master.user_app_business_category_description_timestamp,
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

        public Response GetUserAppAboutDemoCategoriesById(string GetDemoCategoriesById)
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.user_app_business_category_about_demo.Where(z => z.user_app_business_category_id == GetDemoCategoriesById).ToList();
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
