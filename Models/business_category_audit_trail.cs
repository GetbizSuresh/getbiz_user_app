using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class business_category_audit_trail
    {
        [Key]
        public int user_app_business_category_audit_trail_Id { get; set; }
        public string user_app_business_category_id { get; set; }
        public string user_app_activity { get; set; }
        public int user_app_activity_by_user_id { get; set; }
        public DateTime user_app_activity_timestamp { get; set; }
    }
}
