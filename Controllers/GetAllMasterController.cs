
using getbiz_user_app.Repository.Get_All_Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Controllers
{
    public class GetAllMasterController : ControllerBase
    {
        private IGetAllMasterUserAppsRepository getAllMasterUserAppsRepository;

        public GetAllMasterController(IGetAllMasterUserAppsRepository _getAllMasterUserAppsRepository)
        {
            getAllMasterUserAppsRepository = _getAllMasterUserAppsRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllMasterUserApp")]
        public IActionResult GetAllMasterUserApp()
        {
            try
            {
                var messages = getAllMasterUserAppsRepository.GetAllMasterUserApp();
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
