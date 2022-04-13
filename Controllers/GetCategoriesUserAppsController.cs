using getbiz_user_app.Repository.Get_Categories_User_Apps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Controllers
{
    public class GetCategoriesUserAppsController : ControllerBase
    {
        private IGetCategoriesUserAppsRepository GetCategoriesUserAppsRepository;

        public GetCategoriesUserAppsController(IGetCategoriesUserAppsRepository _userAppCommentsSectionRepository)
        {
            GetCategoriesUserAppsRepository = _userAppCommentsSectionRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetCategoriesUserAppsByPathOrId")]
        public IActionResult GetCategoriesUserAppsByPathOrId(string UserAppCategoryPath, string UserAppCategoryId)
        {
            try
            {
                var messages = GetCategoriesUserAppsRepository.GetCategoriesUserAppsByPathOrId(UserAppCategoryPath, UserAppCategoryId);
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
