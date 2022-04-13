using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_cloud_file_storage_permissions
    {
        [Key]
        
        public int user_app_id { get; set; }
        public bool delete_folder { get; set; }
        public bool delete_files { get; set; }
        public bool copy_files { get; set; }

        
        //0 for by Default NO
        //1 for Yes
         
    }
}
