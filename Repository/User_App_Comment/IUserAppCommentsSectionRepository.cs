using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Comment
{
    public interface IUserAppCommentsSectionRepository
    {
        Response GetAllComments(int user_Id);
        Response SaveComments(user_app_comment user_app_comment);
        Response DeleteComment(int user_Id);
        Response DeleteCommentById(int comment_id, int user_Id);
        Response SavePublicPrivateComment(int user_Id, int is_the_comment_private);
        Response UpdateComments(user_app_comment user_app_comment);
    }
}
