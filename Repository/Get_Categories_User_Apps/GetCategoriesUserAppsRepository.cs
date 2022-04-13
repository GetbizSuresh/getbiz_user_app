using getbiz_user_app.Getbiz_DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.Get_Categories_User_Apps
{
    public class GetCategoriesUserAppsRepository: IGetCategoriesUserAppsRepository
    {

        public readonly UserAppDB_DbContext _DbContext;
        public GetCategoriesUserAppsRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }


        public Response2 GetCategoriesUserAppsByPathOrId(string _Path, string _Id)
        {
            Response2 response = new Response2();
            List<ParentData> lstParnet = new List<ParentData>();
            ParentData objParent = new ParentData();
            try
            {

                if (_Path == null)

                {
                    response.Message = "Enter user App Category Id or Path !!";
                    response.Status = false;
                }

                else
                {
                    var lstData = (from master in _DbContext.user_app_master
                                   join assign in _DbContext.user_app_country_business_category_location_assignment on master.user_app_id
                                   equals assign.user_app_id
                                   join catLoc in _DbContext.user_app_categories on assign.user_app_category_id
                                   equals catLoc.user_app_category_id
                                   
                                   
                                   select new
                                   {
                                       CategoryName = catLoc.user_app_category_name,
                                       user_app_category_name = catLoc.user_app_category_name,
                                       user_app_category_path = catLoc.user_app_category_path,
                                       user_app_category_id = catLoc.user_app_category_id,
                                       user_app_id = master.user_app_id,
                                       user_app_icon_name = master.user_app_icon_name,
                                       user_app_web_image = master.user_app_icon_image,
                                       user_app_full_name = master.user_app_full_name,
                                       user_app_development_status = master.user_app_development_status,
                                       user_app_country_business_category_location_Id = assign.user_app_country_business_category_location_Id,
                                       user_app_title_bar_name = master.user_app_title_bar_name,
                                       user_app_business_category_id = assign.user_app_business_category_id,
                                       user_app_country_id = assign.user_app_country_id,
                                       custom_app_id = assign.custom_app_id,

                                   }).ToList();


                    //Add Category Id and Data into a single List
                    List<ParentData> lstParentData = new();
                    List<ParentData> finalPata = new();

                    ParentData objParentData = new();
                    int _PathLength = _Path.Split(',').Length;
                    List<FilterData1> lstFilterData = new();
                    FilterData1 filterData1 = new FilterData1();

                    if (_PathLength == 1) //if not comma seprated
                    {
                        var objData = lstData.Where(z => z.user_app_category_path == _Path).ToList();
                        for (int i = 0; i < objData.Count; i++)
                        {
                            objParentData.Category_Name = objData[i].CategoryName;

                            if (objData != null && objData[i].user_app_id > 0)
                            {
                                filterData1 = new FilterData1();
                                //lstFilterData = new List<FilterData>();

                                filterData1.user_app_id = objData[i].user_app_id;
                                filterData1.user_app_category_id = objData[i].user_app_category_id;
                                filterData1.user_app_category_path = objData[i].user_app_category_path;
                                filterData1.user_app_category_name = objData[i].user_app_category_name;
                                filterData1.user_app_icon_name = objData[i].user_app_icon_name;
                                filterData1.user_app_web_image = objData[i].user_app_id+"//"+objData[i].user_app_web_image;
                                filterData1.user_app_full_name = objData[i].user_app_full_name;
                                filterData1.user_app_development_status = objData[i].user_app_development_status;
                                filterData1.user_app_country_business_category_location_Id = objData[i].user_app_country_business_category_location_Id;
                                filterData1.user_app_title_bar_name = objData[i].user_app_title_bar_name;
                                filterData1.user_app_business_category_id = objData[i].user_app_business_category_id;
                                filterData1.user_app_country_id = objData[i].user_app_country_id;
                                filterData1.custom_app_id = objData[i].custom_app_id;

                                lstFilterData.Add(filterData1);
                            }
                        }

                        objParentData.filterData1 = lstFilterData;
                        lstParentData.Add(objParentData);
                    }
                    else
                    {
                        for (int j = 0; j < _Path.Split(",").Length; j++)
                        {
                            var objData = lstData.Where(z => z.user_app_category_path == _Path.Split(",")[j]).ToList();
                            lstFilterData = new List<FilterData1>();
                            objParentData = new ParentData();

                            for (int k = 0; k < objData.Count; k++)
                            {
                                objParentData.Category_Name = objData[k].CategoryName;
                                if (objData != null && objData[k].user_app_id > 0)
                                {
                                    filterData1 = new FilterData1
                                    {
                                        user_app_id = objData[k].user_app_id,
                                        user_app_category_id = objData[k].user_app_category_id,
                                        user_app_category_name = objData[k].user_app_category_name,
                                        user_app_category_path = objData[k].user_app_category_path,
                                        user_app_icon_name = objData[k].user_app_icon_name,
                                        user_app_web_image = objData[k].user_app_id+"//"+objData[k].user_app_web_image,
                                        user_app_full_name = objData[k].user_app_full_name,
                                        user_app_development_status = objData[k].user_app_development_status,
                                        user_app_country_business_category_location_Id = objData[k].user_app_country_business_category_location_Id,
                                        user_app_title_bar_name = objData[k].user_app_title_bar_name,
                                        user_app_business_category_id = objData[k].user_app_business_category_id,
                                        user_app_country_id = objData[k].user_app_country_id,
                                        custom_app_id = objData[k].custom_app_id,


                                    };
                                    lstFilterData.Add(filterData1);
                                }
                            }
                            objParentData.filterData1 = lstFilterData;
                            lstParentData.Add(objParentData);
                        }

                    }


                    if (lstParentData.Count() > 0)
                    {
                        response.Data = lstParentData;
                        response.Message = "Data Fetch successfully !!";
                        response.Status = true;
                    }
                    else
                    {
                        response.Data = lstParentData;
                        response.Message = "No Data found!!";
                        response.Status = true;
                    }


                }


                if (_Id == null)

                {
                    response.Message = "Enter user App Category Id or Path !!";
                    response.Status = false;
                }

                else
                {
                    var lstData = (from master in _DbContext.user_app_master
                                   join assign in _DbContext.user_app_country_business_category_location_assignment on master.user_app_id
                                   equals assign.user_app_id
                                   join catLoc in _DbContext.user_app_categories on assign.user_app_category_id
                                   equals catLoc.user_app_category_id

                                   select new
                                   {
                                       CategoryName = catLoc.user_app_category_name,
                                      
                                       user_app_category_name = catLoc.user_app_category_name,
                                       user_app_category_path = catLoc.user_app_category_path,
                                       user_app_category_id = catLoc.user_app_category_id,
                                       user_app_id = master.user_app_id,
                                       user_app_icon_name = master.user_app_icon_name,
                                       user_app_web_image = master.user_app_icon_image,
                                       user_app_full_name = master.user_app_full_name,
                                       user_app_development_status = master.user_app_development_status,
                                       user_app_title_bar_name = master.user_app_title_bar_name,
                                       user_app_country_business_category_location_Id = assign.user_app_country_business_category_location_Id,
                                       user_app_business_category_id = assign.user_app_business_category_id,
                                       user_app_country_id = assign.user_app_country_id,
                                       custom_app_id = assign.custom_app_id,

                                   }).ToList();


                    //Add Category Id and Data into a single List
                    List<ParentData> lstParentData = new();
                    List<ParentData> finalPata = new();

                    ParentData objParentData = new();
                    int _IdLength = _Id.Split(',').Length;
                    List<FilterData1> lstFilterData = new();
                    FilterData1 filterData1 = new FilterData1();

                    if (_IdLength == 1) //if not comma seprated
                    {
                        var objData = lstData.Where(z => z.user_app_category_id == _Id).ToList();
                        for (int i = 0; i < objData.Count; i++)
                        {
                            objParentData.Category_Name = objData[i].CategoryName;

                            if (objData != null && objData[i].user_app_id > 0)
                            {
                                filterData1 = new FilterData1();
                                //lstFilterData = new List<FilterData>();

                                filterData1.user_app_id = objData[i].user_app_id;
                                filterData1.user_app_category_id = objData[i].user_app_category_id;
                                filterData1.user_app_category_name = objData[i].user_app_category_name;
                                filterData1.user_app_category_path = objData[i].user_app_category_path;
                                filterData1.user_app_icon_name = objData[i].user_app_icon_name;
                                filterData1.user_app_web_image = objData[i].user_app_id+"//"+objData[i].user_app_web_image;
                                filterData1.user_app_full_name = objData[i].user_app_full_name;
                                filterData1.user_app_development_status = objData[i].user_app_development_status;
                                filterData1.user_app_title_bar_name = objData[i].user_app_title_bar_name;
                                filterData1.user_app_country_business_category_location_Id = objData[i].user_app_country_business_category_location_Id;
                                filterData1.user_app_business_category_id = objData[i].user_app_business_category_id;
                                filterData1.user_app_country_id = objData[i].user_app_country_id;
                                filterData1.custom_app_id = objData[i].custom_app_id;

                                lstFilterData.Add(filterData1);
                            }
                        }

                        objParentData.filterData1 = lstFilterData;
                        lstParentData.Add(objParentData);
                    }
                    else
                    {
                        for (int j = 0; j < _Id.Split(",").Length; j++)
                        {
                            var objData = lstData.Where(z => z.user_app_category_id == _Id.Split(",")[j]).ToList();
                            lstFilterData = new List<FilterData1>();
                            objParentData = new ParentData();

                            for (int k = 0; k < objData.Count; k++)
                            {
                                objParentData.Category_Name = objData[k].CategoryName;
                                if (objData != null && objData[k].user_app_id > 0)
                                {
                                    filterData1 = new FilterData1
                                    {

                                        user_app_id = objData[k].user_app_id,
                                        user_app_category_id =objData[k].user_app_category_id,
                                        user_app_category_name = objData[k].user_app_category_name,
                                        user_app_category_path = objData[k].user_app_category_path,
                                        user_app_icon_name = objData[k].user_app_icon_name,
                                        user_app_web_image = objData[k].user_app_id+"//"+objData[k].user_app_web_image,
                                        user_app_full_name = objData[k].user_app_full_name,
                                        user_app_development_status = objData[k].user_app_development_status,
                                        user_app_title_bar_name = objData[k].user_app_title_bar_name,
                                        user_app_country_business_category_location_Id = objData[k].user_app_country_business_category_location_Id,
                                        user_app_business_category_id = objData[k].user_app_business_category_id,
                                        user_app_country_id = objData[k].user_app_country_id,
                                        custom_app_id = objData[k].custom_app_id,
                                    };
                                    lstFilterData.Add(filterData1);
                                }
                            }
                            objParentData.filterData1 = lstFilterData;
                            lstParentData.Add(objParentData);
                        }
                    }


                    if (lstParentData.Count() > 0)
                    {
                        response.Data = lstParentData;
                        response.Message = "Data Fetch successfully !!";
                        response.Status = true;
                    }
                    else
                    {
                        response.Data = lstParentData;
                        response.Message = "No Data found!!";
                        response.Status = true;
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




    }
}
