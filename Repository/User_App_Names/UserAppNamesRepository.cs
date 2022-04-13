
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Names
{
    public class UserAppNamesRepository : IUserAppNamesRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppNamesRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppNames(user_app_names user_App_Names_Model)
        {
            Response response = new Response();
            try
            {
                if (user_App_Names_Model.user_app_names_id == 0)
                {
                    var obj = _DbContext.user_app_names.Add(user_App_Names_Model);
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

        public Response EditUserAppNames(user_app_names user_App_Names)
        {
            Response response = new Response();
            try
            {
                user_app_names _user_app_names_Model = new user_app_names();
                _user_app_names_Model.user_app_id = user_App_Names.user_app_id;
                _user_app_names_Model.user_app_names_id = user_App_Names.user_app_names_id;
                _user_app_names_Model.user_app_name = user_App_Names.user_app_name;
                _user_app_names_Model.user_app_web_link = user_App_Names.user_app_web_link;
                _user_app_names_Model.user_app_title_bar_name = user_App_Names.user_app_title_bar_name;
                _user_app_names_Model.user_app_icon_name = user_App_Names.user_app_icon_name;
                _user_app_names_Model.user_app_icon_image_path = user_App_Names.user_app_icon_image_path;

                _DbContext.Attach(_user_app_names_Model);
                _DbContext.Entry(_user_app_names_Model).Property(p => p.user_app_id).IsModified = true;
                _DbContext.Entry(_user_app_names_Model).Property(p => p.user_app_name).IsModified = true;
                _DbContext.Entry(_user_app_names_Model).Property(p => p.user_app_web_link).IsModified = true;
                _DbContext.Entry(_user_app_names_Model).Property(p => p.user_app_title_bar_name).IsModified = true;
                _DbContext.Entry(_user_app_names_Model).Property(p => p.user_app_icon_name).IsModified = true;
                _DbContext.Entry(_user_app_names_Model).Property(p => p.user_app_icon_image_path).IsModified = true;
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

        public Response GetALLUserAppNames()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_names
                                 select new
                                 {
                                     User_App_Id = master.user_app_id,
                                     User_App_Name = master.user_app_name,
                                     User_App_Web_Link = master.user_app_web_link,
                                     User_App_Title_Bar_Name = master.user_app_title_bar_name,
                                     User_App_Icon_Name = master.user_app_icon_name,
                                     User_App_Icon_Image_Path = master.user_app_icon_image_path,
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
