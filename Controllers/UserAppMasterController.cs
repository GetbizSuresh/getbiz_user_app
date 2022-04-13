using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Controllers
{
    [ApiController]
    public class UserAppMasterController : ControllerBase
    {
        private IUserAppMasterRepository userAppMasterRepository;
        public UserAppMasterController(IUserAppMasterRepository _userAppMasterRepository)
        {
            userAppMasterRepository = _userAppMasterRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppData")]
        public IActionResult AddUserAppData([FromForm] user_app_master_Fetchdata user_App_Master_Model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
                if (!string.IsNullOrEmpty(user_App_Master_Model.userapp_upload_image.FileName))
                {
                    string getimagename = user_App_Master_Model.userapp_upload_image.FileName;

               
                    user_App_Master_Model.user_app_icon_image = getimagename;
                    var messages = userAppMasterRepository.AddUserAppData(user_App_Master_Model);
                    if (messages == null)
                    {
                        return NotFound();
                    }
                    return Ok(messages);
                }
                else
                {
                    return Ok("Image not found Kindly Upload Image.....!");
                }

              
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/EditUserAppData")]
        public IActionResult EditUserAppData([FromForm] user_app_master_Fetchdata user_App_Master_Model)
        {
            try
            {
                string getimagename = user_App_Master_Model.userapp_upload_image.FileName;
                user_App_Master_Model.user_app_icon_image = getimagename;
                var messages = userAppMasterRepository.EditUserAppData(user_App_Master_Model);
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
        [Route("api/GetUserAppData")]
        public IActionResult GetUserAppData()
        {
            try
            {


                var messages = userAppMasterRepository.GetUserAppData();
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
        [Route("api/GetUserAppDataById")]
        public IActionResult GetUserAppDataById(int GetUserAppDataById)
        {
            try
            {
                var messages = userAppMasterRepository.GetUserAppDataById(GetUserAppDataById);
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

        [HttpPost]
        [Route("api/UpdateUserAppDevelopmentStatus")]
        public IActionResult UpdateUserAppDevelopmentStatus(int userAppId, bool publishKey)
        {
            try
            {
                var messages = userAppMasterRepository.UpdateUserAppDevelopmentStatus(userAppId, publishKey);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetCustomAppData")]
        public IActionResult GetCustomAppData()
        {
            try
            {
                var messages = userAppMasterRepository.GetCustomAppData();
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
        [Route("api/GetUserAppCustomAppdata")]
        public IActionResult GetUserAppCustomAppdata()
        {
            try
            {
                var messages = userAppMasterRepository.GetUserAppCustomAppdata();
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
        [Route("api/GetUserAppCustomAppCategoryId")]
        public IActionResult GetUserAppCustomAppCategoryId(getsterUserAppCustomAppCategoryId objCategoryid)
        {
            try
            {
                string categoryid = JsonConvert.SerializeObject(objCategoryid.Categoryid);
                var messages = userAppMasterRepository.GetUserAppCustomAppCategoryId(categoryid);
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



        protected string saveImage(byte[] image, string name)
        {
            string uniqueFileName = name;
            string pathname = "D:\\Lokesh\\getbiz_user_app-main\\getbiz_user_app-main\\Userapp_Icon\\";
            using (MemoryStream mem = new MemoryStream(image))
            {
                using (var yourImage = Image.FromStream(mem))
                {
                    var filepath = pathname+ "Userapp_Icon"+ $@"\{uniqueFileName}";
                    yourImage.Save(filepath, ImageFormat.Png);
                }
            }
            return uniqueFileName;
        }

        protected static byte[] convertImage(IFormFile imgToResize)
        {
            using (var ms = new MemoryStream())
            {
                imgToResize.CopyTo(ms);
                var fileBytes = ms.ToArray();
                ms.Dispose();
                return (byte[])fileBytes;
            }
        }





    }
}
