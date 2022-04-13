using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_business_categories
    {
        [Key]
        public string user_app_business_category_id { get; set; }
        public string user_app_business_category_path { get; set; }
        public string user_app_business_category_name { get; set; }
    }
}
