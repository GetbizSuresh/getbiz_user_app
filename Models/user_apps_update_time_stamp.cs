using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_apps_update_time_stamp
    {
        [Key]
        public int user_app_id { get; set; }
        public DateTime user_app_update_time_stamp { get; set; }
    }
}
