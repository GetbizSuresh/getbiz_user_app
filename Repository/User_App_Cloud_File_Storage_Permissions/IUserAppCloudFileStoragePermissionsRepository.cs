using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Cloud_File_Storage_Permissions
{
    public interface IUserAppCloudFileStoragePermissionsRepository 
    {
        Response GetALLUserAppCloudFileStorage();
        Response GetALLUserAppCloudFileStorageById(int user_app_id);
        Response AddUserAppCloudFileStorage(user_app_cloud_file_storage_permissions user_app_cloud_file_storage_permissions);
        Response EditUserAppCloudFileStorage(user_app_cloud_file_storage_permissions user_app_cloud_file_storage_permissions);
    }
}
