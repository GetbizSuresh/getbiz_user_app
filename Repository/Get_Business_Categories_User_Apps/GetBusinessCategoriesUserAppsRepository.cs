using getbiz_user_app.Getbiz_DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_user_app.Repository.Get_Business_Categories_User_Apps
{
    public class GetBusinessCategoriesUserAppsRepository: IGetBusinessCategoriesUserAppsRepository
    {
        public readonly UserAppDB_DbContext _DbContext;

        public GetBusinessCategoriesUserAppsRepository(UserAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response2 GetBusinessCategoriesUserAppsByPathOrId(string _Path, string _Id)
        {
            Response2 response = new Response2();
            List<ParentData3> lstParnet = new List<ParentData3>();
            ParentData3 objParent = new ParentData3();

            try
            {

                if (_Path == null)

                {
                    response.Message = "Enter user App Business Category Id or Path !!";
                    response.Status = false;
                }

                else
                {
                    var lstData = (from master in _DbContext.user_app_master
                                   join assign in _DbContext.user_app_country_business_category_location_assignment on master.user_app_id
                                   equals assign.user_app_id
                                   join catLoc in _DbContext.user_app_business_categories on assign.user_app_business_category_id
                                   equals catLoc.user_app_business_category_id
                                   join catLoc1 in _DbContext.user_app_categories on assign.user_app_category_id
                                   equals catLoc1.user_app_category_id


                                   select new
                                   {
                                       CategoryName = catLoc.user_app_business_category_name,
                                       user_app_business_category_id = catLoc.user_app_business_category_id,
                                       user_app_business_category_name = catLoc.user_app_business_category_name,
                                       user_app_business_category_path = catLoc.user_app_business_category_path,
                                       user_app_category_id = catLoc1.user_app_category_id,
                                       user_app_id = master.user_app_id,
                                       user_app_icon_name = master.user_app_icon_name,
                                       user_app_web_image = master.user_app_icon_image,
                                       user_app_full_name = master.user_app_full_name,
                                       user_app_development_status = master.user_app_development_status,
                                       user_app_country_business_category_location_Id = assign.user_app_country_business_category_location_Id,
                                       user_app_title_bar_name = master.user_app_title_bar_name,
                                       //user_app_business_category_id = assign.user_app_business_category_id,
                                       user_app_country_id = assign.user_app_country_id,

                                   }).ToList();


                    //Add Category Id and Data into a single List
                    List<ParentData3> lstParentData = new();
                    List<ParentData3> finalPata = new();

                    ParentData3 objParentData = new();
                    int _PathLength = _Path.Split(',').Length;
                    List<FilterData3> lstFilterData = new();
                    FilterData3 filterData3 = new FilterData3();

                    if (_PathLength == 1) //if not comma seprated
                    {
                        var objData = lstData.Where(z => z.user_app_business_category_path == _Path).ToList();
                        for (int i = 0; i < objData.Count; i++)
                        {
                            objParentData.Category_Name = objData[i].CategoryName;

                            if (objData != null && objData[i].user_app_id > 0)
                            {
                                filterData3 = new FilterData3();
                                //lstFilterData = new List<FilterData>();

                                filterData3.user_app_id = objData[i].user_app_id;
                                filterData3.user_app_business_category_id = objData[i].user_app_business_category_id;
                                filterData3.user_app_business_category_path = objData[i].user_app_business_category_path;
                                filterData3.user_app_business_category_name = objData[i].user_app_business_category_name;
                                filterData3.user_app_icon_name = objData[i].user_app_icon_name;
                                filterData3.user_app_web_image = objData[i].user_app_web_image;
                                filterData3.user_app_full_name = objData[i].user_app_full_name;
                                filterData3.user_app_development_status = objData[i].user_app_development_status;
                                filterData3.user_app_country_business_category_location_Id = objData[i].user_app_country_business_category_location_Id;
                                filterData3.user_app_title_bar_name = objData[i].user_app_title_bar_name;
                               // filterData3.user_app_business_category_id = objData[i].user_app_business_category_id;
                                filterData3.user_app_country_id = objData[i].user_app_country_id;
                                filterData3.user_app_category_id = objData[i].user_app_category_id;




                                lstFilterData.Add(filterData3);
                            }
                        }

                        objParentData.filterData3 = lstFilterData;
                        lstParentData.Add(objParentData);
                    }
                    else
                    {
                        for (int j = 0; j < _Path.Split(",").Length; j++)
                        {
                            var objData = lstData.Where(z => z.user_app_business_category_path == _Path.Split(",")[j]).ToList();
                            lstFilterData = new List<FilterData3>();
                            objParentData = new ParentData3();

                            for (int k = 0; k < objData.Count; k++)
                            {
                                objParentData.Category_Name = objData[k].CategoryName;
                                if (objData != null && objData[k].user_app_id > 0)
                                {
                                    filterData3 = new FilterData3
                                    {
                                        user_app_id = objData[k].user_app_id,
                                        user_app_business_category_id = objData[k].user_app_business_category_id,
                                        user_app_business_category_name = objData[k].user_app_business_category_name,
                                        user_app_business_category_path = objData[k].user_app_business_category_path,
                                        user_app_icon_name = objData[k].user_app_icon_name,
                                        user_app_web_image = objData[k].user_app_web_image,
                                        user_app_full_name = objData[k].user_app_full_name,
                                        user_app_development_status = objData[k].user_app_development_status,
                                        user_app_country_business_category_location_Id = objData[k].user_app_country_business_category_location_Id,
                                        user_app_title_bar_name = objData[k].user_app_title_bar_name,
                                        //user_app_business_category_id = objData[k].user_app_business_category_id,
                                        user_app_country_id = objData[k].user_app_country_id,
                                        user_app_category_id = objData[k].user_app_category_id,


                                    };
                                    lstFilterData.Add(filterData3);
                                }
                            }
                            objParentData.filterData3 = lstFilterData;
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
                    response.Message = "Enter user App Business Category Id or Path !!";
                    response.Status = false;
                }

                else
                {
                    var lstData = (from master in _DbContext.user_app_master
                                   join assign in _DbContext.user_app_country_business_category_location_assignment on master.user_app_id
                                   equals assign.user_app_id
                                   join catLoc in _DbContext.user_app_business_categories on assign.user_app_business_category_id
                                   equals catLoc.user_app_business_category_id
                                   join catLoc1 in _DbContext.user_app_categories on assign.user_app_category_id
                                   equals catLoc1.user_app_category_id

                                   select new
                                   {

                                       CategoryName = catLoc.user_app_business_category_name,
                                       user_app_business_category_id = catLoc.user_app_business_category_id,
                                       user_app_business_category_name = catLoc.user_app_business_category_name,
                                       user_app_business_category_path = catLoc.user_app_business_category_path,
                                       user_app_category_id = catLoc1.user_app_category_id,
                                       user_app_id = master.user_app_id,
                                       user_app_icon_name = master.user_app_icon_name,
                                       user_app_web_image = master.user_app_icon_image,
                                       user_app_full_name = master.user_app_full_name,
                                       user_app_development_status = master.user_app_development_status,
                                       user_app_country_business_category_location_Id = assign.user_app_country_business_category_location_Id,
                                       user_app_title_bar_name = master.user_app_title_bar_name,
                                       //user_app_business_category_id = assign.user_app_business_category_id,
                                       user_app_country_id = assign.user_app_country_id,

                                   }).ToList();


                    //Add Category Id and Data into a single List
                    List<ParentData3> lstParentData = new();
                    List<ParentData3> finalPata = new();

                    ParentData3 objParentData = new();
                    int _IdLength = _Id.Split(',').Length;
                    List<FilterData3> lstFilterData = new();
                    FilterData3 filterData3 = new FilterData3();

                    if (_IdLength == 1) //if not comma seprated
                    {
                        var objData = lstData.Where(z => z.user_app_business_category_id == _Id).ToList();
                        for (int i = 0; i < objData.Count; i++)
                        {
                            objParentData.Category_Name = objData[i].CategoryName;

                            if (objData != null && objData[i].user_app_id > 0)
                            {
                                filterData3 = new FilterData3();
                                //lstFilterData = new List<FilterData>();

                                filterData3 = new FilterData3();
                                //lstFilterData = new List<FilterData>();

                                filterData3.user_app_id = objData[i].user_app_id;
                                filterData3.user_app_business_category_id = objData[i].user_app_business_category_id;
                                filterData3.user_app_business_category_path = objData[i].user_app_business_category_path;
                                filterData3.user_app_business_category_name = objData[i].user_app_business_category_name;
                                filterData3.user_app_icon_name = objData[i].user_app_icon_name;
                                filterData3.user_app_web_image = objData[i].user_app_web_image;
                                filterData3.user_app_full_name = objData[i].user_app_full_name;
                                filterData3.user_app_development_status = objData[i].user_app_development_status;
                                filterData3.user_app_country_business_category_location_Id = objData[i].user_app_country_business_category_location_Id;
                                filterData3.user_app_title_bar_name = objData[i].user_app_title_bar_name;
                                // filterData3.user_app_business_category_id = objData[i].user_app_business_category_id;
                                filterData3.user_app_country_id = objData[i].user_app_country_id;
                                filterData3.user_app_category_id = objData[i].user_app_category_id;


                                lstFilterData.Add(filterData3);
                            }
                        }

                        objParentData.filterData3 = lstFilterData;
                        lstParentData.Add(objParentData);
                    }
                    else
                    {
                        for (int j = 0; j < _Id.Split(",").Length; j++)
                        {
                            var objData = lstData.Where(z => z.user_app_business_category_id == _Id.Split(",")[j]).ToList();
                            lstFilterData = new List<FilterData3>();
                            objParentData = new ParentData3();

                            for (int k = 0; k < objData.Count; k++)
                            {
                                objParentData.Category_Name = objData[k].CategoryName;
                                if (objData != null && objData[k].user_app_id > 0)
                                {
                                    filterData3 = new FilterData3
                                    {

                                        user_app_id = objData[k].user_app_id,
                                        user_app_business_category_id = objData[k].user_app_business_category_id,
                                        user_app_business_category_name = objData[k].user_app_business_category_name,
                                        user_app_business_category_path = objData[k].user_app_business_category_path,
                                        user_app_icon_name = objData[k].user_app_icon_name,
                                        user_app_web_image = objData[k].user_app_web_image,
                                        user_app_full_name = objData[k].user_app_full_name,
                                        user_app_development_status = objData[k].user_app_development_status,
                                        user_app_country_business_category_location_Id = objData[k].user_app_country_business_category_location_Id,
                                        user_app_title_bar_name = objData[k].user_app_title_bar_name,
                                        //user_app_business_category_id = objData[k].user_app_business_category_id,
                                        user_app_country_id = objData[k].user_app_country_id,
                                        user_app_category_id = objData[k].user_app_category_id,
                                    };
                                    lstFilterData.Add(filterData3);
                                }
                            }
                            objParentData.filterData3 = lstFilterData;
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
