using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Cloud_File_Storage_Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Controllers
{
  
    [ApiController]
    public class UserAppCloudFileStoragePermissionsController : ControllerBase
    {
        private IUserAppCloudFileStoragePermissionsRepository userAppCloudFileStoragePermissionsRepository;
        public UserAppCloudFileStoragePermissionsController(IUserAppCloudFileStoragePermissionsRepository _userAppCloudFileStoragePermissionsRepository)
        {
            userAppCloudFileStoragePermissionsRepository = _userAppCloudFileStoragePermissionsRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppCloudFileStorage")]
        public IActionResult AddUserAppCloudFileStorage(user_app_cloud_file_storage_permissions user_app_cloud_file_storage_permissions)
        {
            try
            {
                var messages = userAppCloudFileStoragePermissionsRepository.AddUserAppCloudFileStorage(user_app_cloud_file_storage_permissions);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/EditUserAppCloudFileStorage")]
        public IActionResult EditUserAppCloudFileStorage(user_app_cloud_file_storage_permissions user_app_cloud_file_storage_permissions)
        {
            try
            {
                var messages = userAppCloudFileStoragePermissionsRepository.EditUserAppCloudFileStorage(user_app_cloud_file_storage_permissions);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetALLUserAppCloudFileStorage")]
        public IActionResult GetALLUserAppCloudFileStorage()
        {
            try
            {
                var messages = userAppCloudFileStoragePermissionsRepository.GetALLUserAppCloudFileStorage();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetALLUserAppCloudFileStorageById")]
        public IActionResult GetALLUserAppCloudFileStorageById(int user_app_id)
        {
            try
            {
                var messages = userAppCloudFileStoragePermissionsRepository.GetALLUserAppCloudFileStorageById(user_app_id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
