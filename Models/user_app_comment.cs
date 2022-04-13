using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Models
{
    public class user_app_comment
    {
        [Key]
        public int comment_id { get; set; }
        public int user_Id { get; set; }
        public string comment_timestamp { get; set; }
        public string comment_text { get; set; }
        public int is_the_comment_private { get; set; }
        public string comment_reply { get; set; }
        public int comment_reply_by_user_id { get; set; }
    }
}
