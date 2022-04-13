using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_names
    {
        [Key]
        public int user_app_names_id { get; set; }
        public int user_app_id { get; set; }
        public string user_app_name { get; set; }
        public string user_app_web_link { get; set; }
        public string user_app_title_bar_name { get; set; }
        public string user_app_icon_name { get; set; }
        public string user_app_icon_image_path { get; set; }
    }
}
