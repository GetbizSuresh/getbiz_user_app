

using getbiz_user_app.Getbiz_DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class CommanCode
    {
        public readonly UserAppDB_DbContext _DbContext;
        public CommanCode(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response CommanUpdateStatus(int userAppId, bool publishKey, string methodName)
        {
            Response response = new Response();
            try
            {
                user_apps_update_time_stamp _user_apps_update_time_stamp = new user_apps_update_time_stamp();
                user_apps_audit_trail _user_apps_audit_trail = new user_apps_audit_trail();
                user_app_master _user_app_master = new user_app_master();


                #region Update Field user_app_development_status in  user_app_master Table
                //0 means Publish and 1 means Unpublish

                if (methodName == "Single_Update_Status")
                {
                    var getData = _DbContext.user_app_master.Where(z => z.user_app_id == userAppId).FirstOrDefault();
                    getData.user_app_id = userAppId;
                    getData.user_app_development_status = publishKey;
                    _DbContext.user_app_master.Attach(getData).Property(x => x.user_app_development_status).IsModified = true;
                    _DbContext.Entry(getData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                #endregion


                #region user_App_Audit_Trail Update Section
                var getAuditTrial = _DbContext.user_apps_audit_trail.Where(z => z.user_app_id == userAppId).FirstOrDefault();

                if (getAuditTrial != null)
                {
                    // 0 = true = Publish // 1= false = unUblish
                    // 0 being false and 1 being true
                    getAuditTrial.user_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                    getAuditTrial.user_app_activity_by_user_id = 1; //Current UserId
                    getAuditTrial.user_app_activity_timestamp = DateTime.UtcNow;
                    getAuditTrial.user_app_id = userAppId;

                    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity).IsModified = true;
                    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity_by_user_id).IsModified = true;
                    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity_timestamp).IsModified = true;
                    //_DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_id).IsModified = true;
                    _DbContext.Entry(getAuditTrial).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }

                else  //entry New
                {
                    _user_apps_audit_trail.user_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                    _user_apps_audit_trail.user_app_activity_by_user_id = 1; //Current UserId
                    _user_apps_audit_trail.user_app_activity_timestamp = DateTime.UtcNow;
                    _user_apps_audit_trail.user_app_id = userAppId;
                    var obj = _DbContext.user_apps_audit_trail.Add(_user_apps_audit_trail);
                    _DbContext.SaveChanges();
                }

                #endregion

                #region Update user_app_update_status
                var getStatusData = _DbContext.user_apps_update_time_stamp.Where(z => z.user_app_id == userAppId).FirstOrDefault();
                if (getStatusData != null) //entry updated
                {
                    getStatusData.user_app_id = userAppId;
                    getStatusData.user_app_update_time_stamp = DateTime.Now;
                    _DbContext.user_apps_update_time_stamp.Attach(getStatusData).Property(x => x.user_app_update_time_stamp).IsModified = true;
                    _DbContext.Entry(getStatusData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                else  //entry New
                {
                    _user_apps_update_time_stamp.user_app_update_time_stamp = DateTime.Now;
                    _user_apps_update_time_stamp.user_app_id = userAppId;
                    var obj = _DbContext.user_apps_update_time_stamp.Add(_user_apps_update_time_stamp);
                    _DbContext.SaveChanges();
                }
                #endregion

                response.Status = true;
                response.Message = "Data updated Successfully";
            }
            catch (Exception ex)
            {

                response.Status = false;
                response.Message = "Data updated failed..";
            }
            return response;
        }
    }
}
