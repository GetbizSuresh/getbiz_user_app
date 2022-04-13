using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_additional_data
    {

        // public int user_app_additional_data_id { get; set; }
        [Key]
        public int user_app_id { get; set; }
        public bool can_this_user_app_be_blocked_by_app_administrator { get; set; }
        public bool can_this_app_be_displayed_in_customerbizapp_launch_screen { get; set; }
        public bool does_this_app_have_configuration_data_specific_to_this_app { get; set; }
        public bool appsuitable_displayed_launchscreen_freeaccess_unregistered_users { get; set; }

    }
}
