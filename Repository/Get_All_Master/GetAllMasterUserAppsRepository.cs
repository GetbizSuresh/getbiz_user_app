using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.Get_All_Master
{
    public class GetAllMasterUserAppsRepository: IGetAllMasterUserAppsRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public GetAllMasterUserAppsRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response GetAllMasterUserApp()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_master
                                 select new
                                 {
                                     user_app_id = master.user_app_id,
                                     user_app_icon_name = master.user_app_icon_name,
                                     user_app_title_bar_name = master.user_app_title_bar_name,
                                     user_app_icon_image = master.user_app_id+"\\"+master.user_app_icon_image,
                                     user_app_full_name = master.user_app_full_name,
                                     user_app_development_status = master.user_app_development_status,
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
