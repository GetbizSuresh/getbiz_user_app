
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_About_Demo
{
    public class UserAppAboutDemoRepository : IUserAppAboutDemoRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppAboutDemoRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppAboutDemo(user_app_about_demo _user_app_about_demo)
        {
            Response response = new Response();
            try
            {
                if (_user_app_about_demo.user_app_id == 0)
                {
                    response.Message = "Enter User App Id";
                    response.Status = false;
                        
                }
                else 
                {
                    _DbContext.user_app_about_demo.Add(_user_app_about_demo);
                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;

                }

            }
            catch (Exception ex)
            {
                response.Message = "User App Id already Exist or Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditUserAppAboutDemo(user_app_about_demo user_app_about_demo)
        {
            Response response = new Response();
            try
            {
                user_app_about_demo _user_app_about_demo_Model = new user_app_about_demo();
                //_user_app_about_demo_Model.user_app_demo_id = user_app_about_demo.user_app_demo_id;
                _user_app_about_demo_Model.user_app_id = user_app_about_demo.user_app_id;
                _user_app_about_demo_Model.user_app_demo_video_path = user_app_about_demo.user_app_demo_video_path;
                _user_app_about_demo_Model.user_app_timestamp_title = user_app_about_demo.user_app_timestamp_title;
                _user_app_about_demo_Model.user_app_timestamp_description = user_app_about_demo.user_app_timestamp_description;
                _user_app_about_demo_Model.user_app_attachments_path = user_app_about_demo.user_app_attachments_path;
                //_user_app_about_demo_Model.user_app_communication = user_app_about_demo.user_app_communication;

                _DbContext.Attach(_user_app_about_demo_Model);
                //_DbContext.Entry(_user_app_about_demo_Model).Property(p => p.user_app_id).IsModified = true;
                _DbContext.Entry(_user_app_about_demo_Model).Property(p => p.user_app_demo_video_path).IsModified = true;
                _DbContext.Entry(_user_app_about_demo_Model).Property(p => p.user_app_timestamp_title).IsModified = true;
                _DbContext.Entry(_user_app_about_demo_Model).Property(p => p.user_app_timestamp_description).IsModified = true;
                _DbContext.Entry(_user_app_about_demo_Model).Property(p => p.user_app_attachments_path).IsModified = true;
               // _DbContext.Entry(_user_app_about_demo_Model).Property(p => p.user_app_communication).IsModified = true;
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

        public Response GetALLUserAppAboutDemo()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_about_demo
                                 select new
                                 {
                                     User_Id = master.user_app_id,
                                     Video_Path = master.user_app_demo_video_path,
                                     user_app_time_stamp_title = master.user_app_timestamp_title,
                                     Description_Time_Stamp = master.user_app_timestamp_description,
                                     Development_Status = master.user_app_attachments_path,
                                     //Communication = master.user_app_communication,
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


        public Response GetUserAppAboutDemoById(int user_app_id)
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.user_app_about_demo.Where(z => z.user_app_id == user_app_id).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Fetching  the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response DeleteuserAppAboutDemo(user_app_about_demo user_app_about_demo)
        {
            Response response = new Response();
            try
            {
                var user_app_category_and_location = _DbContext.user_app_about_demo.Where(z =>
                z.user_app_id == user_app_about_demo.user_app_id).FirstOrDefault();
                _DbContext.user_app_about_demo.Remove(user_app_category_and_location);
                _DbContext.SaveChanges();
                response.Message = "Data Deleted successfully !!";
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
