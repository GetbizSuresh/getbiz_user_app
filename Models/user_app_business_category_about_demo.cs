using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_business_category_about_demo
    {
        [Key]
       // public int user_app_business_category_about_demo_id { get; set; }
        public string user_app_business_category_id { get; set; }
        public string user_app_business_category_demo_video_path { get; set; }
        public string user_app_business_category_description_timestamp { get; set; }
    }
}
