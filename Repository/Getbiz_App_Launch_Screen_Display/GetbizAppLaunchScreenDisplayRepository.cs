
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.Getbiz_App_Launch_Screen_Display
{
    public class GetbizAppLaunchScreenDisplayRepository : IGetbizAppLaunchScreenDisplayRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public GetbizAppLaunchScreenDisplayRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display getbiz_app_launch_screen_display)
        {
            Response response = new Response();
            try
            {
                if (getbiz_app_launch_screen_display.user_app_launch_screen_location==0)
                {
                    var obj = _DbContext.getbiz_app_launch_screen_display.Add(getbiz_app_launch_screen_display);
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

        public Response EditGetbizAppLaunchScreenDisplay(getbiz_app_launch_screen_display getbiz_app_launch_screen_display)
        {
            Response response = new Response();
            try
            {
                getbiz_app_launch_screen_display _getbiz_app_launch_screen_display = new getbiz_app_launch_screen_display();
                _getbiz_app_launch_screen_display.user_app_id = getbiz_app_launch_screen_display.user_app_id;
                _getbiz_app_launch_screen_display.user_app_launch_screen_location = getbiz_app_launch_screen_display.user_app_launch_screen_location;
                _getbiz_app_launch_screen_display.user_app_launch_screen_mobile_image_path = getbiz_app_launch_screen_display.user_app_launch_screen_mobile_image_path;
                _getbiz_app_launch_screen_display.user_app_launch_screen_desktop_image_path = getbiz_app_launch_screen_display.user_app_launch_screen_desktop_image_path;
                _getbiz_app_launch_screen_display.user_app_launch_screen_text1 = getbiz_app_launch_screen_display.user_app_launch_screen_text1;
                _getbiz_app_launch_screen_display.user_app_launch_screen_text2 = getbiz_app_launch_screen_display.user_app_launch_screen_text2;
                _getbiz_app_launch_screen_display.user_app_launch_screen_text3 = getbiz_app_launch_screen_display.user_app_launch_screen_text3;

                _DbContext.Attach(_getbiz_app_launch_screen_display);
                _DbContext.Entry(_getbiz_app_launch_screen_display).Property(p => p.user_app_id).IsModified = true;
                _DbContext.Entry(_getbiz_app_launch_screen_display).Property(p => p.user_app_launch_screen_mobile_image_path).IsModified = true;
                _DbContext.Entry(_getbiz_app_launch_screen_display).Property(p => p.user_app_launch_screen_desktop_image_path).IsModified = true;
                _DbContext.Entry(_getbiz_app_launch_screen_display).Property(p => p.user_app_launch_screen_text1).IsModified = true;
                _DbContext.Entry(_getbiz_app_launch_screen_display).Property(p => p.user_app_launch_screen_text2).IsModified = true;
                _DbContext.Entry(_getbiz_app_launch_screen_display).Property(p => p.user_app_launch_screen_text3).IsModified = true;
                _DbContext.SaveChanges();
                 
                response.Message = "Data updated successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetALLGetbizAppLaunchScreenDisplay()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.getbiz_app_launch_screen_display
                                 select new
                                 {
                                     Launch_Screen_Location = master.user_app_launch_screen_location,
                                     User_Id = master.user_app_id,
                                     Launch_Screen_Mobile_Image_Path = master.user_app_launch_screen_mobile_image_path,
                                     Launch_Screen_Desktop_Image_Path = master.user_app_launch_screen_desktop_image_path,
                                     Launch_Screen_Text1 = master.user_app_launch_screen_text1,
                                     Launch_Screen_Text2 = master.user_app_launch_screen_text2,
                                     Launch_Screen_Text3 = master.user_app_launch_screen_text3,
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

        public Response GetALLGetbizAppLaunchScreenDisplayById(int user_app_id)
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.getbiz_app_launch_screen_display.Where(z => z.user_app_id == user_app_id).ToList();
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
    }
}
