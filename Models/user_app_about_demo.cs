using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_about_demo
    {

        // public int user_app_demo_id { get; set; }
        [Key]
        public int user_app_id { get; set; }
        public string user_app_demo_video_path { get; set; }
        public string user_app_timestamp_title { get; set; }
        public string user_app_timestamp_description { get; set; }
        public string user_app_attachments_path { get; set; }

    }
}
