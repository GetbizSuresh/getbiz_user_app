using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_country_business_category_location_assignment
    {
        [Key]
        public int user_app_country_business_category_location_Id { get; set; }
        public int user_app_country_id { get; set; }
        public string user_app_business_category_id { get; set; }
        public string user_app_category_id { get; set; }//update
        public int user_app_id { get; set; }
        public int custom_app_id { get; set; } //update
        public int user_app_category_location { get; set; } //update
    }
}
