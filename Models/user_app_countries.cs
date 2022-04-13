using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_countries
    {
        [Key]
        public int user_app_country_id { get; set; }
        public string user_app_country_path { get; set; }
        public string user_app_country_name { get; set; }
    }
}
