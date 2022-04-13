using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_user_app
{
    public class Response2
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }
    public class ParentData
    {
        public string Category_Name { get; set; }
       // public List<FilterData> filterData { get; set; }
        public List<FilterData1> filterData1 { get; set; }
        //public List<FilterData3> filterData3 { get; set; }
    }

    public class ParentData2
    {
        public string Category_Name { get; set; }
        public List<FilterData> filterData { get; set; }
        
    }

    public class FilterData
    {
        public string Path { get; set; }

        public int user_app_id { get; set; }
        public string user_app_icon_name { get; set; }
        public string user_app_web_image { get; set; }
        public string user_app_full_name { get; set; }
        public string user_app_title_bar_name { get; set; }
        public bool user_app_development_status { get; set; }
        public int user_app_country_id { get; set; }
        public string user_app_category_id { get; set; }
        public string user_app_business_category_id { get; set; }

        //public string user_app_name { get; set; }
        //public string user_app_title_bar_name { get; set; }

    }

    public class FilterData1
    {
        public string user_app_category_id { get; set; }
        public string user_app_category_path { get; set; }
        public string user_app_category_name { get; set; }
        public int user_app_id { get; set; }
        public string user_app_icon_name { get; set; }
        public string user_app_web_image { get; set; }
        public string user_app_full_name { get; set; }
        public string user_app_title_bar_name { get; set; }
        public bool user_app_development_status { get; set; }
        //public string user_app_name { get; set; }
        //public string user_app_title_bar_name { get; set; }
        public int user_app_country_business_category_location_Id { get; set; }
        public int user_app_country_id { get; set; }
        public string user_app_business_category_id { get; set; }
        public int custom_app_id {get; set;}
    }

    public class ParentData1
    {
        
        public List<FilterData2> filterData2 { get; set; }
        
    }

    public class FilterData2
    {
        public string user_app_category_id { get; set; }

        public int user_app_id { get; set; }
        public int user_app_category_location { get; set; }

        [Key]
        public int user_apps_and_categories_assignment_id { get; set; }
    }

    public class ParentData3
    {
        public string Category_Name { get; set; }
        // public List<FilterData> filterData { get; set; }
        //public List<FilterData1> filterData1 { get; set; }
        public List<FilterData3> filterData3 { get; set; }
    }
    public class FilterData3
    {
        public string user_app_business_category_id { get; set; }
        public string user_app_business_category_path { get; set; }
        public string user_app_business_category_name { get; set; }
        public int user_app_id { get; set; }
        public string user_app_icon_name { get; set; }
        public string user_app_web_image { get; set; }
        public string user_app_full_name { get; set; }
        public string user_app_title_bar_name { get; set; }
        public bool user_app_development_status { get; set; }
        //public string user_app_name { get; set; }
        //public string user_app_title_bar_name { get; set; }
        public int user_app_country_business_category_location_Id { get; set; }
        public int user_app_country_id { get; set; }
        public string user_app_category_id { get; set; }
    }

}
