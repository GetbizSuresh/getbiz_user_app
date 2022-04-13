using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_master
    {
        [Key]

        public int user_app_id { get; set; }
        public string user_app_icon_name { get; set; }
        public string user_app_title_bar_name { get; set; }
        public string user_app_full_name { get; set; }
        public string user_app_icon_image { get; set; }
        public bool user_app_development_status { get; set; }
       
       
    }

    public class user_app_master_Fetchdata
    {
        [Key]

        public int user_app_id { get; set; }
        public string user_app_icon_name { get; set; }
        public string user_app_title_bar_name { get; set; }
        public string user_app_full_name { get; set; }
        public string user_app_icon_image { get; set; }
        public IFormFile userapp_upload_image { get; set; }
        public bool user_app_development_status { get; set; }


    }


    public class getster_categoryname
    {
        public string user_app_category_name { get; set; }

        public List<getster_category_json> data { get; set; }
    }


    public class getster_category_json
    {
        public string custom_app_id { get; set; }
        public string custom_app_icon_name { get; set; }
        public string custom_app_icon_image { get; set; }
        public string custom_app_full_name { get; set; }

        public string custom_app_title_bar_name { get; set; }
        public bool custom_app_development_status { get; set; }

        //public string custom_app_title_bar_name { get; set; }
        //public string custom_app_development_status { get; set; }

    }




    public class getster_categoryusercustomapp
    {
        public string user_app_category_name { get; set; }

        public List<getster_usercustom_json> data { get; set; }
    }


    public class getster_usercustom_json
    {
        public string custom_app_id { get; set; }
        public string custom_app_icon_name { get; set; }
        public string custom_app_icon_image { get; set; }
        public string custom_app_full_name { get; set; }

        public string custom_app_title_bar_name { get; set; }
        
        public Boolean custom_app_development_status { get; set; }

        public string user_app_id { get; set; }
        public string user_app_icon_name { get; set; }
        public string user_app_title_bar_name { get; set; }
        public string user_app_full_name { get; set; }
        public string user_app_icon_image { get; set; }
        public Boolean user_app_development_status { get; set; }


        //public string custom_app_title_bar_name { get; set; }
        //public string custom_app_development_status { get; set; }

    }

    public class getsterUserAppCustomAppCategoryId
    {
        public List<Categoryids> Categoryid { get; set; }
    }

    public class Categoryids
    {
        public string Categoryid { get; set; }
    }


}
