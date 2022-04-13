using getbiz_user_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Communication
{
    public interface IUserAppCommunicationRepository
    {
        Response GetAllCommunicationData(int user_app_id);
        Response GetAllCommunicationDataById(int communication_ID, int user_app_id);
        Response SaveCommunicationData(user_app_communication user_app_communication);
        Response DeleteCommunicationData(int user_app_id);
        Response DeleteCommunicationDataById(int user_Id, int communication_ID);
        Response UpdateCommunicationData(user_app_communication user_app_communication);


    }
}
