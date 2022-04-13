using getbiz_user_app.Repository.Get_Business_Categories_User_Apps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Controllers
{
    public class GetBusinessCategoriesUserAppsController : Controller
    {
        private IGetBusinessCategoriesUserAppsRepository GetBusinessCategoriesUserAppsRepository;

        public GetBusinessCategoriesUserAppsController(IGetBusinessCategoriesUserAppsRepository _getBusinessCategoriesUserAppsRepository)
        {
            GetBusinessCategoriesUserAppsRepository = _getBusinessCategoriesUserAppsRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetBusinessCategoriesUserAppsByPathOrId")]
        public IActionResult GetBusinessCategoriesUserAppsByPathOrId(string UserAppBusinessCategoryPath, string UserAppBusinessCategoryId)
        {
            try
            {
                var messages = GetBusinessCategoriesUserAppsRepository.GetBusinessCategoriesUserAppsByPathOrId(UserAppBusinessCategoryPath, UserAppBusinessCategoryId);
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
