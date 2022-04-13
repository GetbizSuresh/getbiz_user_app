using getbiz_user_app.Models;

namespace getbiz_user_app.Repository.User_App_Additional_Data
{
    public interface IUserAppAdditionalDataRepository
    {
        Response GetALLUserAppAdditionalData();
        Response GetALLUserAppAdditionalDataById(int user_app_id);
        Response AddUserAppAdditionalData(user_app_additional_data user_app_additional_data);
        Response EditUserAppAdditionalData(user_app_additional_data user_app_additional_data);
        
    }
}
