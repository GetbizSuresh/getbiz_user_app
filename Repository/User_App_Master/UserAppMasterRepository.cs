
using getbiz_user_app.Getbiz_DbContext;
using getbiz_user_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace getbiz_user_app.Repository.User_App_Master
{

    public class UserAppMasterRepository : IUserAppMasterRepository
    {
        public readonly UserAppDB_DbContext _DbContext;
        CommanCode _commanCode = null;

        private IConfiguration _configuration;
        public UserAppMasterRepository(UserAppDB_DbContext DbContext,IConfiguration configuration)
        {
            _DbContext = DbContext;
            _commanCode = new CommanCode(DbContext);
            _configuration = configuration;
        }


        public Response AddUserAppData(user_app_master_Fetchdata user_App_Master_Model)
        {
            Response response = new Response();
            
            try
            {
                if (user_App_Master_Model.user_app_id == 0)
                {
                    user_app_master obj_Fetchdata = new user_app_master();
                    obj_Fetchdata.user_app_id = user_App_Master_Model.user_app_id;
                    obj_Fetchdata.user_app_icon_name = user_App_Master_Model.user_app_icon_name;
                    obj_Fetchdata.user_app_title_bar_name = user_App_Master_Model.user_app_title_bar_name;
                    obj_Fetchdata.user_app_full_name = user_App_Master_Model.user_app_full_name;
                    obj_Fetchdata.user_app_icon_image = user_App_Master_Model.user_app_icon_image;
                    obj_Fetchdata.user_app_development_status = user_App_Master_Model.user_app_development_status;

                    var obj = _DbContext.user_app_master.Add(obj_Fetchdata);
                    _DbContext.SaveChanges();
                    int getuserid = _DbContext.user_app_master.Max(u => u.user_app_id);

                    saveImage(convertImage(user_App_Master_Model.userapp_upload_image), user_App_Master_Model.user_app_icon_image, getuserid);



                    user_apps_audit_trail _User_Apps_Audit_Trail = new user_apps_audit_trail();
                    _User_Apps_Audit_Trail.user_app_id = obj_Fetchdata.user_app_id;
                    _User_Apps_Audit_Trail.user_app_activity = "Added";
                    _User_Apps_Audit_Trail.user_app_activity_by_user_id = _User_Apps_Audit_Trail.user_app_activity_by_user_id;
                    _User_Apps_Audit_Trail.user_app_activity_timestamp = DateTime.UtcNow;

                    _DbContext.user_apps_audit_trail.Add(_User_Apps_Audit_Trail);
                    _DbContext.SaveChanges();
                 
                    response.Message = "Data Saved successfully !!";
                    response.Data = obj_Fetchdata;
                    response.Status = true;

                   
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response EditUserAppData(user_app_master_Fetchdata user_App_Master_Model)
        {
            Response response = new Response();
            try
            {
                user_app_master _user_App_Master_Model = new user_app_master();
                _user_App_Master_Model.user_app_development_status = user_App_Master_Model.user_app_development_status;
                _user_App_Master_Model.user_app_icon_image = user_App_Master_Model.user_app_icon_image;
                _user_App_Master_Model.user_app_icon_name = user_App_Master_Model.user_app_icon_name;
                _user_App_Master_Model.user_app_full_name = user_App_Master_Model.user_app_full_name;
                _user_App_Master_Model.user_app_title_bar_name = user_App_Master_Model.user_app_title_bar_name;
                _user_App_Master_Model.user_app_id = user_App_Master_Model.user_app_id;

                _DbContext.Attach(_user_App_Master_Model);
                _DbContext.Entry(_user_App_Master_Model).Property(p => p.user_app_development_status).IsModified = true;
                _DbContext.Entry(_user_App_Master_Model).Property(p => p.user_app_icon_image).IsModified = true;
                _DbContext.Entry(_user_App_Master_Model).Property(p => p.user_app_icon_name).IsModified = true;
                _DbContext.Entry(_user_App_Master_Model).Property(p => p.user_app_full_name).IsModified = true;
                _DbContext.Entry(_user_App_Master_Model).Property(p => p.user_app_title_bar_name).IsModified = true;
                saveImage(convertImage(user_App_Master_Model.userapp_upload_image), user_App_Master_Model.user_app_icon_image, user_App_Master_Model.user_app_id);

                user_apps_audit_trail _User_Apps_Audit_Trail = new user_apps_audit_trail();
                _User_Apps_Audit_Trail.user_app_id = _user_App_Master_Model.user_app_id;
                _User_Apps_Audit_Trail.user_app_activity = "Edited";
                _User_Apps_Audit_Trail.user_app_activity_by_user_id = _User_Apps_Audit_Trail.user_app_activity_by_user_id;
                _User_Apps_Audit_Trail.user_app_activity_timestamp = DateTime.UtcNow;

                _DbContext.user_apps_audit_trail.Add(_User_Apps_Audit_Trail);
                //_DbContext.SaveChanges();
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

        public Response2 GetUserAppData()
        {
            Response2 response = new Response2();
            List<ParentData2> lstParnet = new List<ParentData2>();
            ParentData2 objParent = new ParentData2();


            var query2 = (
            from CAT in _DbContext.user_app_categories
            from AST in _DbContext.user_app_country_business_category_location_assignment
            .Where(mapping => mapping.user_app_category_id == CAT.user_app_category_id)
            .DefaultIfEmpty() // <== makes join left join
            from groups in _DbContext.user_app_master
            .Where(groupe => groupe.user_app_id == AST.user_app_id)
            .DefaultIfEmpty() // <== makes join left join
            select new
            {
                Category_Name = CAT.user_app_category_name,
                user_app_id = AST.user_app_id
            });

            try
            {
                if (query2 == null)
                {

                    var q = query2.ToList();
                    var lstCategory = q.GroupBy(z => z.Category_Name).ToList();

                    var lstData = (from master in _DbContext.user_app_master
                                   join assign in _DbContext.user_app_country_business_category_location_assignment on master.user_app_id
                                   equals assign.user_app_id
                                   join catLoc in _DbContext.user_app_categories on assign.user_app_category_id
                                   equals catLoc.user_app_category_id
                                   
                                   //join assign1 in _DbContext.user_app_names on master.user_app_id
                                   //equals assign1.user_app_id

                                   select new
                                   {
                                       user_app_id = master.user_app_id,
                                       CategoryName = catLoc.user_app_category_name,
                                       Path = catLoc.user_app_category_path,
                                       user_app_icon_name = master.user_app_icon_name,
                                       user_app_web_image = master.user_app_icon_image,
                                       user_app_full_name = master.user_app_full_name,
                                       user_app_title_bar_name = master.user_app_title_bar_name,
                                       user_app_development_status = master.user_app_development_status,
                                       user_app_category_id = assign.user_app_category_id,
                                       user_app_country_id = assign.user_app_country_id,
                                       user_app_business_category_id = assign.user_app_business_category_id,
                                       //user_app_name = assign1.user_app_name,
                                       //user_app_title_bar_name = assign1.user_app_title_bar_name,
                                   }).ToList();

                    List<FilterData> lstFilterData = new List<FilterData>();
                    FilterData fDataobj = new FilterData();
                    for (int i = 0; i < lstCategory.Count; i++)
                    {
                        objParent = new ParentData2();
                        var list = lstData.Where(z => z.CategoryName == lstCategory[i].Key).ToList();

                        if (list.Count > 0)
                        {
                            objParent.Category_Name = lstCategory[i].Key;
                            lstFilterData = new List<FilterData>();
                            foreach (var master in list)
                            {
                                fDataobj = new FilterData();
                                fDataobj.Path = master.Path;
                                
                                fDataobj.user_app_id = master.user_app_id;
                                fDataobj.user_app_icon_name = master.user_app_icon_name;
                                fDataobj.user_app_web_image = master.user_app_id + "//" + master.user_app_web_image;
                                fDataobj.user_app_full_name = master.user_app_full_name;
                                fDataobj.user_app_development_status = master.user_app_development_status;
                                //fDataobj.user_app_name = master.user_app_name;
                                fDataobj.user_app_title_bar_name = master.user_app_title_bar_name;
                                
                                
                                
                                fDataobj.user_app_category_id = master.user_app_category_id;
                                fDataobj.user_app_country_id = master.user_app_country_id;
                                fDataobj.user_app_business_category_id = master.user_app_business_category_id;




                                lstFilterData.Add(fDataobj);
                            }
                            objParent.filterData = lstFilterData;
                            lstParnet.Add(objParent);
                        }
                    }
                    response.Data = lstParnet;
                    response.Message = "Data Fetch successfully !!";
                    response.Status = true;
                }
                else
                {
                    var query = (
                          from CAT in _DbContext.user_app_categories
                          from AST in _DbContext.user_app_country_business_category_location_assignment
                              //.Where(mapping => mapping.Id == CAT.Id)
                              //.DefaultIfEmpty() // <== makes join left join
                          from groups in _DbContext.user_app_master
                          .Where(groupe => groupe.user_app_id == AST.user_app_id)
                          .DefaultIfEmpty() // <== makes join left join
                          select new
                          {
                              Category_Name = CAT.user_app_category_name,
                              user_app_id = AST.user_app_id == null
                          });

                    try
                    {
                        var q = query.ToList();
                        var lstCategory = q.GroupBy(z => z.Category_Name).ToList();

                        var lstData = (from master in _DbContext.user_app_master
                                       join assign in _DbContext.user_app_country_business_category_location_assignment on master.user_app_id
                                       equals assign.user_app_id
                                       join catLoc in _DbContext.user_app_categories on assign.user_app_category_id
                                       equals catLoc.user_app_category_id
                                       //join assign1 in _DbContext.user_app_names on master.user_app_id
                                       //equals assign1.user_app_id

                                       select new
                                       {
                                           user_app_id = master.user_app_id,
                                           CategoryName = catLoc.user_app_category_name,
                                           Path = catLoc.user_app_category_path,
                                           user_app_icon_name = master.user_app_icon_name,
                                           user_app_web_image =master.user_app_icon_image,
                                           user_app_full_name = master.user_app_full_name,
                                           user_app_title_bar_name = master.user_app_title_bar_name,
                                           user_app_development_status = master.user_app_development_status,
                                           user_app_category_id = assign.user_app_category_id,
                                           user_app_country_id = assign.user_app_country_id,
                                           user_app_business_category_id = assign.user_app_business_category_id,
                                           //user_app_name = assign1.user_app_name,
                                           //user_app_title_bar_name = assign1.user_app_title_bar_name,
                                       }).ToList();

                        List<FilterData> lstFilterData = new List<FilterData>();
                        FilterData fDataobj = new FilterData();
                        for (int i = 0; i < lstCategory.Count; i++)
                        {
                            objParent = new ParentData2();
                            var list = lstData.Where(z => z.CategoryName == lstCategory[i].Key).ToList();

                            if (list.Count > 0)
                            {
                                objParent.Category_Name = lstCategory[i].Key;
                                lstFilterData = new List<FilterData>();
                                foreach (var master in list)
                                {
                                    fDataobj = new FilterData();
                                    fDataobj.Path = master.Path;

                                    fDataobj.user_app_id = master.user_app_id;
                                    fDataobj.user_app_icon_name = master.user_app_icon_name;
                                    fDataobj.user_app_web_image = master.user_app_id + "//" + master.user_app_web_image;
                                    fDataobj.user_app_full_name = master.user_app_full_name;
                                    fDataobj.user_app_development_status = master.user_app_development_status;
                                   // fDataobj.user_app_name = master.user_app_name;
                                    fDataobj.user_app_title_bar_name = master.user_app_title_bar_name;

                                    fDataobj.user_app_category_id = master.user_app_category_id;
                                    fDataobj.user_app_country_id = master.user_app_country_id;
                                    fDataobj.user_app_business_category_id = master.user_app_business_category_id;


                                    lstFilterData.Add(fDataobj);
                                }
                                objParent.filterData = lstFilterData;
                                lstParnet.Add(objParent);
                            }
                        }
                        response.Data = lstParnet;
                        response.Message = "Data Fetch successfully !!";
                        response.Status = true;


                    }
                    catch (Exception ex)
                    {
                        response.Message = "Error, while fetching the data !!";
                        response.Status = false;
                    }
                }
            }


            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }


            return response;
        }
        public Response GetCustomAppData()
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    DataSet dset = new DataSet();
                    dset = getSetDatabase.GetCustomAppData();
                    List<getster_categoryname> objlistparent = new List<getster_categoryname>();
                    getster_categoryname objparentdata = new getster_categoryname();

                    List<getster_category_json> objlistchild = new List<getster_category_json>();
                    getster_category_json objchilddata = new getster_category_json();


                    for (int i = 0; i < dset.Tables[1].Rows.Count; i++)
                    {
                        objparentdata = new getster_categoryname();
                        objparentdata.user_app_category_name = dset.Tables[1].Rows[i][2].ToString();
                        string categoryid = dset.Tables[1].Rows[i][0].ToString();
                        //DataTable Store = dset.Tables[1];

                        //var dataRow = Store.AsEnumerable().Where(x => x.Field<string>("getster_app_category_id") == categoryid).ToList();

                        //if (dataRow.Count > 0)
                        //{
                        objlistchild = new List<getster_category_json>();

                        for (int j = 0; j < dset.Tables[0].Rows.Count; j++)
                        {
                            string check = "0";

                            string customappid = dset.Tables[0].Rows[j][0].ToString();

                            if (categoryid == (dset.Tables[0].Rows[j][1].ToString()))
                            {
                    
                                for (int jj = 0; jj < dset.Tables[2].Rows.Count; jj++)
                                {
                                    objchilddata = new getster_category_json();
                                    if (customappid == (dset.Tables[2].Rows[jj][0].ToString()))
                                    {
                                        check = "1";
                                        objchilddata.custom_app_id = dset.Tables[2].Rows[jj][0].ToString();
                                        objchilddata.custom_app_icon_name= dset.Tables[2].Rows[jj][1].ToString();
                                        objchilddata.custom_app_icon_image = dset.Tables[2].Rows[jj][0].ToString()+"//"+dset.Tables[2].Rows[jj][2].ToString();
                                        objchilddata.custom_app_full_name = dset.Tables[2].Rows[jj][3].ToString();

                                        objchilddata.custom_app_title_bar_name = dset.Tables[2].Rows[jj][4].ToString();
                                        objchilddata.custom_app_development_status = bool.Parse(dset.Tables[2].Rows[jj][5].ToString());
                                    }
                                    if (check == "1")
                                    {
                                        check = "0";
                                        objlistchild.Add(objchilddata);
                                    }


                                }


                            }


                     

                        }
                        //  }


                        objparentdata.data = objlistchild;

                        objlistparent.Add(objparentdata);

                    }

                    response.Data = objlistparent;
                    response.Status = true;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = ex.Message;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response GetUserAppDataById(int GetUserAppDataById)
        {
            Response response = new Response();
            try
            {
                List<user_app_master> myList = new List<user_app_master>();

                myList = _DbContext.user_app_master.Where(u => u.user_app_id == GetUserAppDataById).ToList();

                if (myList.Count != 0)
                {
                    string imagepath = GetUserAppDataById + "//" + myList[0].user_app_icon_image;
                    myList[0].user_app_icon_image = imagepath;
                    response.Data = myList;
                    response.Message = "Data Fetch Successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Data = myList;
                    response.Message = "Data not found Kindly Check..!!";
                    response.Status = true;
                }

           
            }
            catch (Exception)
            {
                response.Message = "Data updation failed !!";
                response.Status = false;
            }
            return response;
        }




        public Response UpdateUserAppDevelopmentStatus(int UserId,bool publishKey)
        {
            return CommanUpdateStatus(UserId, publishKey, "Single_Update_Status");
        }

        public Response CommanUpdateStatus(int UserId, bool publishKey, string methodName)
        {
            Response response = new Response();
            try
            {
                user_apps_update_time_stamp user_Apps_Update_Time_Stamp = new user_apps_update_time_stamp();
                user_apps_audit_trail user_Apps_Audit_Trail = new user_apps_audit_trail();
                user_app_master user_App_Master = new user_app_master();


                #region Update Field user_app_development_status in  user_app_master Table
                //0 means Publish and 1 means Unpublish

                if (methodName == "Single_Update_Status")
                {
                    var getData = _DbContext.user_app_master.Where(z => z.user_app_id == UserId).FirstOrDefault();
                    getData.user_app_id = UserId;
                    getData.user_app_development_status = publishKey;
                    _DbContext.user_app_master.Attach(getData).Property(x => x.user_app_development_status).IsModified = true;
                    _DbContext.Entry(getData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                #endregion


                #region user_Apps_Audit_Trail Update Section
                var getAuditTrial = _DbContext.user_apps_audit_trail.Where(z => z.user_app_id == UserId).FirstOrDefault();

                if (UserId == 0)
                {
                    // 0 = true = Publish // 1= false = unPublish
                    // 0 being false and 1 being true

                    getAuditTrial.user_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                    getAuditTrial.user_app_activity_by_user_id = UserId; //Current UserId
                    getAuditTrial.user_app_activity_timestamp = DateTime.UtcNow;
                    getAuditTrial.user_app_id = UserId;

                    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity).IsModified = true;
                    _DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_activity_by_user_id).IsModified = true;
                    //_DbContext.user_apps_audit_trail.Attach(getAuditTrial).Property(x => x.user_app_id).IsModified = true;
                    _DbContext.Entry(getAuditTrial).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }

                else  //entry New
                {
                    user_Apps_Audit_Trail.user_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                    user_Apps_Audit_Trail.user_app_activity_by_user_id = UserId; //Current UserId
                    user_Apps_Audit_Trail.user_app_activity_timestamp = DateTime.UtcNow;
                    user_Apps_Audit_Trail.user_app_id = UserId;
                    var obj = _DbContext.user_apps_audit_trail.Add(user_Apps_Audit_Trail);
                    _DbContext.SaveChanges();
                }


                #endregion

                #region Update user_apps_update_time_stamp
                var getStatusData = _DbContext.user_apps_update_time_stamp.Where(z => z.user_app_id == UserId).FirstOrDefault();
                if (getStatusData != null) //entry updated
                {
                    getStatusData.user_app_id = UserId;
                    getStatusData.user_app_update_time_stamp = DateTime.UtcNow;
                    _DbContext.user_apps_update_time_stamp.Attach(getStatusData).Property(x => x.user_app_update_time_stamp).IsModified = true;
                    _DbContext.Entry(getStatusData).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                }
                else  //entry New
                {
                    user_Apps_Update_Time_Stamp.user_app_update_time_stamp = DateTime.UtcNow;
                    user_Apps_Update_Time_Stamp.user_app_id = UserId;
                    var obj = _DbContext.user_apps_update_time_stamp.Add(user_Apps_Update_Time_Stamp);
                    _DbContext.SaveChanges();
                }


                #endregion

                response.Status = true;
                response.Message = "Data updated Successfully";
            }
            catch (Exception ex)
            {

                response.Status = false;
                response.Message = "Data updated failed..";
            }
            return response;
        }



        public Response GetUserAppCustomAppdata()
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    DataSet dset = new DataSet();
                    dset = getSetDatabase.GetUserAppCustomAppdata();
                    List<getster_categoryusercustomapp> objlistparent = new List<getster_categoryusercustomapp>();
                    getster_categoryusercustomapp objparentdata = new getster_categoryusercustomapp();

                    List<getster_usercustom_json> objlistchild = new List<getster_usercustom_json>();
                    getster_usercustom_json objchilddata = new getster_usercustom_json();


                    for (int i = 0; i < dset.Tables[1].Rows.Count; i++)
                    {
                        objparentdata = new getster_categoryusercustomapp();
                        objparentdata.user_app_category_name = dset.Tables[1].Rows[i][2].ToString();
                        string categoryid = dset.Tables[1].Rows[i][0].ToString();
                        //DataTable Store = dset.Tables[1];

                        //var dataRow = Store.AsEnumerable().Where(x => x.Field<string>("getster_app_category_id") == categoryid).ToList();

                        //if (dataRow.Count > 0)
                        //{
                        objlistchild = new List<getster_usercustom_json>();

                        for (int j = 0; j < dset.Tables[0].Rows.Count; j++)
                        {
                            string check = "0";

                            string customappid = dset.Tables[0].Rows[j][0].ToString();
                            string userappid = dset.Tables[0].Rows[j][1].ToString();

                          
                                if (categoryid == (dset.Tables[0].Rows[j][2].ToString()))
                                {
                                if (customappid != "0")
                                {
                                    for (int jj = 0; jj < dset.Tables[2].Rows.Count; jj++)
                                    {
                                        objchilddata = new getster_usercustom_json();
                                        if (customappid == (dset.Tables[2].Rows[jj][0].ToString()))
                                        {
                                            check = "1";
                                            objchilddata.custom_app_id = dset.Tables[2].Rows[jj][0].ToString();
                                            objchilddata.custom_app_icon_name = dset.Tables[2].Rows[jj][1].ToString();
                                            objchilddata.custom_app_icon_image = dset.Tables[2].Rows[jj][0].ToString()+"//"+dset.Tables[2].Rows[jj][2].ToString();
                                            objchilddata.custom_app_full_name = dset.Tables[2].Rows[jj][3].ToString();

                                            objchilddata.custom_app_title_bar_name = dset.Tables[2].Rows[jj][4].ToString();
                                            objchilddata.custom_app_development_status = bool.Parse(dset.Tables[2].Rows[jj][5].ToString());
                                        }
                                        if (check == "1")
                                        {
                                            check = "0";
                                            objlistchild.Add(objchilddata);
                                        }


                                    }
                                }

                                if (!string.IsNullOrEmpty(userappid))
                                {
                                    for (int k = 0; k < dset.Tables[3].Rows.Count; k++)
                                    {
                                        objchilddata = new getster_usercustom_json();
                                        if (userappid == (dset.Tables[3].Rows[k][0].ToString()))
                                        {
                                            check = "1";
                                            objchilddata.user_app_id = dset.Tables[3].Rows[k][0].ToString();
                                            objchilddata.user_app_icon_name = dset.Tables[3].Rows[k][1].ToString();
                                            objchilddata.user_app_title_bar_name = dset.Tables[3].Rows[k][2].ToString();
                                            objchilddata.user_app_icon_image = dset.Tables[3].Rows[k][0].ToString()+"//"+dset.Tables[3].Rows[k][3].ToString();
                                            objchilddata.user_app_full_name = dset.Tables[3].Rows[k][4].ToString();
                                            objchilddata.user_app_development_status = bool.Parse(dset.Tables[3].Rows[k][5].ToString());
                                        }
                                        if (check == "1")
                                        {
                                            check = "0";
                                            objlistchild.Add(objchilddata);
                                        }


                                    }
                                }
                                 


                                }
                          
                          




                        }
                        //  }


                        objparentdata.data = objlistchild;

                        objlistparent.Add(objparentdata);

                    }

                    response.Data = objlistparent;
                    response.Status = true;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = ex.Message;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response GetUserAppCustomAppCategoryId(string Categoryid)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    DataSet dset = new DataSet();
                    dset = getSetDatabase.GetUserAppCustomAppCategoryId(Categoryid);
                    List<getster_categoryusercustomapp> objlistparent = new List<getster_categoryusercustomapp>();
                    getster_categoryusercustomapp objparentdata = new getster_categoryusercustomapp();

                    List<getster_usercustom_json> objlistchild = new List<getster_usercustom_json>();
                    getster_usercustom_json objchilddata = new getster_usercustom_json();


                    for (int i = 0; i < dset.Tables[1].Rows.Count; i++)
                    {
                        objparentdata = new getster_categoryusercustomapp();
                        objparentdata.user_app_category_name = dset.Tables[1].Rows[i][2].ToString();
                        string categoryid = dset.Tables[1].Rows[i][0].ToString();
                        //DataTable Store = dset.Tables[1];

                        //var dataRow = Store.AsEnumerable().Where(x => x.Field<string>("getster_app_category_id") == categoryid).ToList();

                        //if (dataRow.Count > 0)
                        //{
                        objlistchild = new List<getster_usercustom_json>();

                        for (int j = 0; j < dset.Tables[0].Rows.Count; j++)
                        {
                            string check = "0";

                            string customappid = dset.Tables[0].Rows[j][0].ToString();
                            string userappid = dset.Tables[0].Rows[j][1].ToString();


                            if (categoryid == (dset.Tables[0].Rows[j][2].ToString()))
                            {
                                if (customappid != "0")
                                {
                                    for (int jj = 0; jj < dset.Tables[2].Rows.Count; jj++)
                                    {
                                        objchilddata = new getster_usercustom_json();
                                        if (customappid == (dset.Tables[2].Rows[jj][0].ToString()))
                                        {
                                            check = "1";
                                            objchilddata.custom_app_id = dset.Tables[2].Rows[jj][0].ToString();
                                            objchilddata.custom_app_icon_name = dset.Tables[2].Rows[jj][1].ToString();
                                            objchilddata.custom_app_icon_image = dset.Tables[2].Rows[jj][0].ToString()+"//"+dset.Tables[2].Rows[jj][2].ToString();
                                            objchilddata.custom_app_full_name = dset.Tables[2].Rows[jj][3].ToString();

                                            objchilddata.custom_app_title_bar_name = dset.Tables[2].Rows[jj][4].ToString();
                                            objchilddata.custom_app_development_status = Convert.ToBoolean(dset.Tables[2].Rows[jj][5].ToString());
                                        }
                                        if (check == "1")
                                        {
                                            check = "0";
                                            objlistchild.Add(objchilddata);
                                        }


                                    }
                                }

                                if (!string.IsNullOrEmpty(userappid))
                                {
                                    for (int k = 0; k < dset.Tables[3].Rows.Count; k++)
                                    {
                                        objchilddata = new getster_usercustom_json();
                                        if (userappid == (dset.Tables[3].Rows[k][0].ToString()))
                                        {
                                            check = "1";
                                            objchilddata.user_app_id = dset.Tables[3].Rows[k][0].ToString();
                                            objchilddata.user_app_icon_name = dset.Tables[3].Rows[k][1].ToString();
                                            objchilddata.user_app_title_bar_name = dset.Tables[3].Rows[k][2].ToString();
                                            objchilddata.user_app_icon_image = dset.Tables[3].Rows[k][0].ToString()+"//"+dset.Tables[3].Rows[k][3].ToString();
                                            objchilddata.user_app_full_name = dset.Tables[3].Rows[k][4].ToString();
                                            objchilddata.user_app_development_status = Convert.ToBoolean(dset.Tables[3].Rows[k][5].ToString());
                                            

                                        }
                                        if (check == "1")
                                        {
                                            check = "0";
                                            objlistchild.Add(objchilddata);
                                        }


                                    }
                                }



                            }






                        }
                        //  }

                        objparentdata.data = objlistchild;

                        objlistparent.Add(objparentdata);

                    }

                    response.Data = objlistparent;
                    response.Status = true;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = ex.Message;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }


        protected string saveImage(byte[] image, string name,int userid)
        {
            string uniqueFileName = name;
            string LiveServerpath = _configuration.GetSection("LiveUserapp").Value;
            string pathname = LiveServerpath + userid;
            bool exists = System.IO.Directory.Exists(pathname);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(pathname);
            }
               
            using (MemoryStream mem = new MemoryStream(image))
            {
                using (var yourImage = Image.FromStream(mem))
                {
                    var filepath = pathname +"\\"+ uniqueFileName;
                    yourImage.Save(filepath, ImageFormat.Png);
                }
            }
            return uniqueFileName;
        }

        protected static byte[] convertImage(IFormFile imgToResize)
        {
            using (var ms = new MemoryStream())
            {
                imgToResize.CopyTo(ms);
                var fileBytes = ms.ToArray();
                ms.Dispose();
                return (byte[])fileBytes;
            }
        }












    }
}
