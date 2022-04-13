    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class getbiz_app_launch_screen_display
    {
        [Key]
        public int user_app_launch_screen_location{ get; set; }
        public int user_app_id { get; set; }
        public string user_app_launch_screen_mobile_image_path { get; set; }
        public string user_app_launch_screen_desktop_image_path { get; set; }
        public string user_app_launch_screen_text1 { get; set; }
        public string user_app_launch_screen_text2 { get; set; }
        public string user_app_launch_screen_text3 { get; set; }
    }
}
