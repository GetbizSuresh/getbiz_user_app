using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_communication
    {

        [Key]
        public int communication_id { get; set; }
        public string communication_timestamp { get; set; }
        public int user_id { get; set; }
        public string communication_text { get; set; }

    }
}
