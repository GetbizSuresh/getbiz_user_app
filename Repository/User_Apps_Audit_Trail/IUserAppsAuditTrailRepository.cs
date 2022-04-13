using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_Apps_Audit_Trail
{
    public interface IUserAppsAuditTrailRepository
    {
        Response GetALLUserAppsAuditTrail();
        //Response AddUserAppsAuditTrail(user_apps_audit_trail user_Apps_Audit_Trail);
        //Response EditUserAppsAuditTrail(user_apps_audit_trail user_Apps_Audit_Trail);
    }
}
