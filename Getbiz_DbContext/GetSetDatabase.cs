using getbiz_user_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace getbiz_user_app.Getbiz_DbContext
{
    public class GetSetDatabase
    {
        string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=userappdb;Allow User Variables=true";
        public Response CreateCommentTableDyanmically(int comment_id, int user_Id, string comment_timestamp,
              string comment_text, int is_the_comment_private, string comment_reply, int comment_reply_by_user_id,string Counter)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[8];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_comment_timestamp", MySqlDbType.VarChar);
                param[0].Value = comment_timestamp;

                param[1] = new MySqlParameter("p_userId", MySqlDbType.Int32);
                param[1].Value = user_Id;

                param[2] = new MySqlParameter("p_commentText", MySqlDbType.VarChar);
                param[2].Value = comment_text;

                param[3] = new MySqlParameter("p_comment_reply_by_user_id", MySqlDbType.Int32);
                param[3].Value = comment_reply_by_user_id;

                param[4] = new MySqlParameter("p_commentReply", MySqlDbType.VarChar);
                param[4].Value = comment_reply;

                param[5] = new MySqlParameter("p_is_the_comment_private", MySqlDbType.VarChar);
                param[5].Value = is_the_comment_private;

                param[6] = new MySqlParameter("p_Counter", MySqlDbType.VarChar);
                param[6].Value = Counter;

                param[7] = new MySqlParameter("p_commentId", MySqlDbType.Int32);
                param[7].Value = comment_id;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCommentTableDyanmically", param);
            }
            catch (Exception ex)
            {

            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GetAll
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "GetAll")
                    {
                        List<user_app_comment> lst_comment_For_User = new List<user_app_comment>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            user_app_comment user_app_comment = new user_app_comment();
                            user_app_comment.comment_id = Convert.ToInt32(ds.Tables[0].Rows[i]["comment_id"]);
                            user_app_comment.user_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["user_id"]);
                            user_app_comment.comment_timestamp = Convert.ToString(ds.Tables[0].Rows[i]["comment_timestamp"]);
                            user_app_comment.comment_text = Convert.ToString(ds.Tables[0].Rows[i]["comment_text"]);
                            user_app_comment.is_the_comment_private = Convert.ToInt32(ds.Tables[0].Rows[i]["is_the_comment_private"]);
                            user_app_comment.comment_reply = Convert.ToString(ds.Tables[0].Rows[i]["comment_reply"]);
                            user_app_comment.comment_reply_by_user_id = Convert.ToInt32(ds.Tables[0].Rows[i]["comment_reply_by_user_id"]);

                            lst_comment_For_User.Add(user_app_comment);
                        }
                        response.Data = lst_comment_For_User;

                        response.Message = "Comments data fetched successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }
            }
            return response;
        }

        //Coummication Section

        public Response CreateUserAppCommunicationTableDyanmically(int user_app_id, int p_communication_id, string p_communication_timestamp,
            string p_communication_text, string Counter)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[5];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_user_Id", MySqlDbType.Int32);
                param[0].Value = user_app_id;

                param[1] = new MySqlParameter("p_communication_id", MySqlDbType.Int32);
                param[1].Value = p_communication_id;

                param[2] = new MySqlParameter("p_communication_timestamp", MySqlDbType.VarChar);
                param[2].Value = p_communication_timestamp;

                param[3] = new MySqlParameter("p_communication_text", MySqlDbType.VarChar);
                param[3].Value = p_communication_text;

                param[4] = new MySqlParameter("p_Counter", MySqlDbType.VarChar);
                param[4].Value = Counter;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateUserAppCommunicationTableDyanmically", param);
            }
            catch (Exception ex)
            {

            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GetAll
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "GetAll")
                    {
                        List<user_app_communication> lst_user_app_communication = new List<user_app_communication>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            user_app_communication _user_app_communication = new user_app_communication();
                            _user_app_communication.communication_id = Convert.ToInt32(ds.Tables[0].Rows[i]["communication_id"]);
                            _user_app_communication.user_id = Convert.ToInt32(ds.Tables[0].Rows[i]["user_id"]);
                            _user_app_communication.communication_timestamp = Convert.ToString(ds.Tables[0].Rows[i]["communication_timestamp"]);
                            _user_app_communication.communication_text = Convert.ToString(ds.Tables[0].Rows[i]["communication_text"]);
                            lst_user_app_communication.Add(_user_app_communication);
                        }
                        response.Data = lst_user_app_communication;
                        response.Message = "Communication data fetched successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }
            }
            return response;
        }




        public DataSet GetCustomAppData()
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[0];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetCustomAppdata", param);
               
            }
            
            catch (Exception ex)
            {
                response.Data = ex.Message;
                response.Message = "";
                response.Status = false;
                return ds;
            }

          
            return ds;
        }





        public DataSet GetUserAppCustomAppdata()
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[0];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetUserAppCustomAppdata", param);
            }
            catch (Exception ex)
            {
                response.Data = ex.Message;
                response.Message = "";
                response.Status = false;
                return ds;
            }


            return ds;
        }



        public DataSet GetUserAppCustomAppCategoryId(string Categoryid)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[1];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_Categoryid", MySqlDbType.JSON);
                param[0].Value = Categoryid;
                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetUserAppCustomAppCategoryid", param);
            }
            catch (Exception ex)
            {
                response.Data = ex.Message;
                response.Message = "";
                response.Status = false;
                return ds;
            }


            return ds;
        }








    }
}
