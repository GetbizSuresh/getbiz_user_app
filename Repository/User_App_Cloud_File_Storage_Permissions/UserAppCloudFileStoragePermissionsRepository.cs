
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Cloud_File_Storage_Permissions
{
    public class UserAppCloudFileStoragePermissionsRepository : IUserAppCloudFileStoragePermissionsRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppCloudFileStoragePermissionsRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppCloudFileStorage(user_app_cloud_file_storage_permissions user_app_cloud_file_storage_permissions)
        {
            Response response = new Response();
            try
            {
                if (user_app_cloud_file_storage_permissions.user_app_id == 0)
                {
                    response.Message = "Enter User App ID !!";
                    response.Status = false;
                }
                else
                {
                    var obj = _DbContext.user_app_cloud_file_storage_permissions.Add(user_app_cloud_file_storage_permissions);
                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;

                    
                }
             
            }
            catch (Exception ex)
            {
                response.Message = "User App ID Already Exist !!";
                response.Status = false;
            }
            return response;
        }

        public Response EditUserAppCloudFileStorage(user_app_cloud_file_storage_permissions user_app_cloud_file_storage_permissions)
        {
            Response response = new Response();
            try
            {
                user_app_cloud_file_storage_permissions _user_app_cloud_file_storage_permissions_Model = new user_app_cloud_file_storage_permissions();
                _user_app_cloud_file_storage_permissions_Model.delete_files = user_app_cloud_file_storage_permissions.delete_files;
                _user_app_cloud_file_storage_permissions_Model.delete_folder = user_app_cloud_file_storage_permissions.delete_folder;
                _user_app_cloud_file_storage_permissions_Model.copy_files = user_app_cloud_file_storage_permissions.copy_files;
                _user_app_cloud_file_storage_permissions_Model.user_app_id = user_app_cloud_file_storage_permissions.user_app_id;
                //_user_app_cloud_file_storage_permissions_Model.user_app_cloud_file_storage_permissions_id = user_app_cloud_file_storage_permissions.user_app_cloud_file_storage_permissions_id;

                _DbContext.Attach(_user_app_cloud_file_storage_permissions_Model);
                
                _DbContext.Entry(_user_app_cloud_file_storage_permissions_Model).Property(p => p.delete_files).IsModified = true;
                _DbContext.Entry(_user_app_cloud_file_storage_permissions_Model).Property(p => p.delete_folder).IsModified = true;
                _DbContext.Entry(_user_app_cloud_file_storage_permissions_Model).Property(p => p.copy_files).IsModified = true;
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

        public Response GetALLUserAppCloudFileStorage()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_cloud_file_storage_permissions
                                 select new
                                 {
                                     user_app_id = master.user_app_id,
                                     delete_files = master.delete_files == true ? "Yes" : "No",
                                     delete_folder = master.delete_folder == true ? "Yes" : "No",
                                     copy_files = master.copy_files == true ? "Yes" : "No",
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

        public Response GetALLUserAppCloudFileStorageById(int user_app_id)
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.user_app_cloud_file_storage_permissions.Where(z => z.user_app_id == user_app_id).ToList();
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
