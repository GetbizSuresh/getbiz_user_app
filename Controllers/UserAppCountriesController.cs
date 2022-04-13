using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Countries;
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
    public class UserAppCountriesController : ControllerBase
    {
        private IUserAppCountriesRepository userAppCountriesRepository;
        public UserAppCountriesController(IUserAppCountriesRepository _userAppCountriesRepository)
        {
            userAppCountriesRepository = _userAppCountriesRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppCountries")]
        public IActionResult AddUserAppCountries(user_app_countries user_app_countries_Model)
        {
            try
            {
                var messages = userAppCountriesRepository.AddUserAppCountries(user_app_countries_Model);
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
        [Route("api/EditUserAppCountries")]
        public IActionResult EditUserAppCountries(user_app_countries user_app_countries_Model)
        {
            try
            {
                var messages = userAppCountriesRepository.EditUserAppCountries(user_app_countries_Model);
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
        [Route("api/GetALLUserAppCountries")]
        public IActionResult GetALLUserAppCountries()
        {
            try
            {
                var messages = userAppCountriesRepository.GetALLUserAppCountries();
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
        [Route("api/DeleteUserAppCountries")]
        public IActionResult DeleteUserAppCountries(int UserAppCountryId)
        {
            try
            {
                var messages = userAppCountriesRepository.DeleteUserAppCountries(UserAppCountryId);
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
        [Route("api/GetALLUserAppCountryAuditTrail")]
        public IActionResult GetALLUserAppCountryAuditTrail()
        {
            try
            {
                var messages = userAppCountriesRepository.GetALLUserAppCountryAuditTrail();
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
 
