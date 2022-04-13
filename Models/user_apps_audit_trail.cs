using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_apps_audit_trail
    {
        [Key]
       public int user_app_audit_trail_Id { get; set; }
        public int user_app_id { get; set; }
        public string user_app_activity { get; set; }
        public int user_app_activity_by_user_id { get; set; }
        public DateTime user_app_activity_timestamp { get; set; }

        //from user_app_master
       // public string user_app_full_name { get; set; }
        


    }


}
