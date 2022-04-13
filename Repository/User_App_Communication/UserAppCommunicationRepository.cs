
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Communication
{
    public class UserAppCommunicationRepository: IUserAppCommunicationRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppCommunicationRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response DeleteCommunicationData(int user_app_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateUserAppCommunicationTableDyanmically(user_app_id, 0, "","", "Delete");
                response.Status = true;
                response.Message = "Data Deleted Successfully !!";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error Occured ! while  deleting the data !!";
            }
            return response;
        }

        public Response DeleteCommunicationDataById(int communication_id, int user_Id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateUserAppCommunicationTableDyanmically(communication_id, user_Id, "","", "DeleteById");
                response.Status = true;
                response.Message = "Data Deleted Successfully !!";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error Occured ! while  deleting the data !!";
            }
            return response;
        }

        public Response GetAllCommunicationData(int user_app_Id)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateUserAppCommunicationTableDyanmically(user_app_Id, 0, "","", "GetAll");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error occured fetching the data !!";
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

        public Response GetAllCommunicationDataById(int communication_ID, int user_app_Id)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateUserAppCommunicationTableDyanmically(user_app_Id, communication_ID, "","", "GetByID");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error occured ! white fething the data";
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

        public Response SaveCommunicationData(user_app_communication user_app_communication)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateUserAppCommunicationTableDyanmically(
                    user_app_communication.user_id,
                    0, user_app_communication.communication_timestamp,
                    user_app_communication.communication_text,
                    "Insert");
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error occured ! white saving the data";
            }
            return response;
        }

        public Response UpdateCommunicationData(user_app_communication user_app_communication)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateUserAppCommunicationTableDyanmically(user_app_communication.user_id,
                    user_app_communication.communication_id, user_app_communication.communication_timestamp,
                    user_app_communication.communication_text,
                    "EditCommunication");
                response.Status = result.Status;
                response.Message = result.Message;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error, while updating the data !!";
            }
            return response;
        }
    }
}
