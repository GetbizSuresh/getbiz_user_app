
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Comment
{
    public class UserAppCommentsSectionRepository : IUserAppCommentsSectionRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppCommentsSectionRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response DeleteComment(int user_Id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(0, user_Id, "", "" ,0, "", 0, "Delete");
                response.Status = true;
                response.Message = "Comment Deleted Successfully";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Failed to Deleted comment!!";
            }
            return response;
        }

        public Response DeleteCommentById(int comment_id, int user_Id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(comment_id, user_Id, "", "", 0, "",0, "DeleteById");
                response.Status = true;
                response.Message = "Comment Deleted Successfully";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Failed to Deleted comment!!";
            }
            return response;
        }

        public Response GetAllComments(int user_Id)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateCommentTableDyanmically(0, user_Id,
                    "", "", 0, "",0, "GetAll");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Failed to fetchd data!!";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response SaveComments(user_app_comment user_app_comment)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCommentTableDyanmically(0, user_app_comment.user_Id,
                user_app_comment.comment_timestamp, user_app_comment.comment_text, user_app_comment.is_the_comment_private,
                user_app_comment.comment_reply, user_app_comment.comment_reply_by_user_id, "Insert");
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While saving data";
            }
            return response;
        }

        public Response SavePublicPrivateComment(int user_Id, int is_the_comment_private)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(0, user_Id, "", "", is_the_comment_private, "",0, "PublicPrivateCommentUpdate");
                response.Status = true;
                response.Message = "Data updated successfully";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Data updated failed!!";
            }
            return response;
        }

        public Response UpdateComments(user_app_comment user_app_comment)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCommentTableDyanmically(user_app_comment.comment_id, user_app_comment.user_Id,
                user_app_comment.comment_timestamp, user_app_comment.comment_text, user_app_comment.is_the_comment_private,
                user_app_comment.comment_reply,user_app_comment.comment_reply_by_user_id, "EditComment");
                response.Status = result.Status;
                response.Message = result.Message;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Failed to updated the data";
            }
            return response;
        }
    }
}
