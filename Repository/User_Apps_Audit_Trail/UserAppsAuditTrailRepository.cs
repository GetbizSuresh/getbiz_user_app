
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;
using getbiz_user_app.Repository.User_App_Names;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_Apps_Audit_Trail
{
    public class UserAppsAuditTrailRepository : IUserAppsAuditTrailRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppsAuditTrailRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response GetALLUserAppsAuditTrail()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_apps_audit_trail
                                 join assign in _DbContext.user_app_master on master.user_app_id
                                   equals assign.user_app_id
                                 

                                 select new
                                 {
                                    // User_App_Audit_Trail_Id = master.user_app_audit_trail_Id,
                                     User_App_Id = master.user_app_id,
                                     User_App_Activity = master.user_app_activity,
                                     User_App_Activity_By_User_Id = master.user_app_activity_by_user_id,
                                     User_App_Activity_Time_Stamp = master.user_app_activity_timestamp,
                                     User_App_Full_Name = assign.user_app_full_name,


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
