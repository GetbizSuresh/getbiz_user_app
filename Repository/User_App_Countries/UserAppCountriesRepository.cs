
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.User_App_Countries
{
    public class UserAppCountriesRepository : IUserAppCountriesRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        public UserAppCountriesRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppCountries(user_app_countries user_App_Countries_Model)
        {
        Response response = new Response();
        try
        {
            if (user_App_Countries_Model.user_app_country_id == 0)
            {
                var obj = _DbContext.user_app_countries.Add(user_App_Countries_Model);
                _DbContext.SaveChanges();


                    country_audit_trail _Country_Audit_Trail = new country_audit_trail();
                    _Country_Audit_Trail.user_app_country_id = user_App_Countries_Model.user_app_country_id;
                    _Country_Audit_Trail.user_app_activity = "Added";
                    _Country_Audit_Trail.user_app_activity_by_user_id = _Country_Audit_Trail.user_app_activity_by_user_id;
                    _Country_Audit_Trail.user_app_activity_timestamp = DateTime.UtcNow;

                    _DbContext.Add(_Country_Audit_Trail);

                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                response.Status = true;
            }
        }
        catch (Exception ex)
        {
            response.Message = "Data Saved to failed !!";
            response.Status = false;
        }
        return response;
        }

        public Response EditUserAppCountries(user_app_countries user_App_Countries)
        {
            Response response = new Response();
            try
            {
                user_app_countries _user_app_countries_Model = new user_app_countries
                {
                    user_app_country_id = user_App_Countries.user_app_country_id,
                    user_app_country_path = user_App_Countries.user_app_country_path,
                    user_app_country_name = user_App_Countries.user_app_country_name
                };

                _DbContext.Attach(_user_app_countries_Model);
                _DbContext.Entry(_user_app_countries_Model).Property(p => p.user_app_country_path).IsModified = true;
                _DbContext.Entry(_user_app_countries_Model).Property(p => p.user_app_country_name).IsModified = true;
                _DbContext.SaveChanges();

                country_audit_trail _Country_Audit_Trail = new country_audit_trail();
                _Country_Audit_Trail.user_app_country_id = _user_app_countries_Model.user_app_country_id;
                _Country_Audit_Trail.user_app_activity = "Edited";
                _Country_Audit_Trail.user_app_activity_by_user_id = _Country_Audit_Trail.user_app_activity_by_user_id;
                _Country_Audit_Trail.user_app_activity_timestamp = DateTime.UtcNow;

                _DbContext.Add(_Country_Audit_Trail);
                _DbContext.SaveChanges();


                response.Message = "Data updated successfully !!";
                response.Status = true;
            }
            catch (Exception)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetALLUserAppCountries()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_app_countries
                                 select new
                                 {
                                     Country_Id = master.user_app_country_id,
                                     Country_Path = master.user_app_country_path,
                                     Country_Name = master.user_app_country_name,
                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response DeleteUserAppCountries(int UserAppCountryId)
        {
            Response response = new Response();
            try
            {
                var user_app_country_id =_DbContext.user_app_countries.Where(m => m.user_app_country_id == UserAppCountryId).FirstOrDefault();
                _DbContext.user_app_countries.Remove(user_app_country_id);
                _DbContext.SaveChanges();

                //var country_audit_trail = _DbContext.country_audit_trail.Where(c => c.user_app_country_id == UserAppCountryId).FirstOrDefault();
                //_DbContext.country_audit_trail.Remove(country_audit_trail);
                //_DbContext.SaveChanges();

                country_audit_trail _Country_Audit_Trail = new country_audit_trail();
                _Country_Audit_Trail.user_app_country_id = user_app_country_id.user_app_country_id;
                _Country_Audit_Trail.user_app_activity = "Deleted";
                _Country_Audit_Trail.user_app_activity_by_user_id = _Country_Audit_Trail.user_app_activity_by_user_id;
                _Country_Audit_Trail.user_app_activity_timestamp = DateTime.UtcNow;

                _DbContext.Add(_Country_Audit_Trail);
                _DbContext.SaveChanges();

                response.Message = "Data Deleted successfully !!";
                response.Status = true;

            }
            catch (Exception ex)
            {
                response.Message = "Data Delete failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetALLUserAppCountryAuditTrail()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.country_audit_trail
                                 join assign in _DbContext.user_app_countries on master.user_app_country_id
                                  equals assign.user_app_country_id

                                 select new
                                 {
                                     // User_App_Audit_Trail_Id = master.user_app_audit_trail_Id,
                                     user_app_country_id = master.user_app_country_id,
                                     User_App_Activity = master.user_app_activity,
                                     User_App_Activity_By_User_Id = master.user_app_activity_by_user_id,
                                     User_App_Activity_Time_Stamp = master.user_app_activity_timestamp,
                                     user_app_country_name = assign.user_app_country_name,
                                     //User_App_Full_Name = assign.user_app_full_name,


                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }


    }
}
