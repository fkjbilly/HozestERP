
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-04-25 17:06:07
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMWareHouses : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the CityId
        /// </summary>
        public string CityId { get; set; }
        /// <summary>
        /// Gets or sets the ParentID
        /// </summary>
        public Nullable<int> ParentID { get; set; }

        /// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the isEnable
        /// </summary>
        public Nullable<bool> isEnable { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        #endregion
        #region Custom Properties
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickId != null && this.NickId > 0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 仓库所属城市
        /// </summary>
        public string CityName
        {
            get
            {
                string cityName = "";
                string ProvinceId = "";
                if (CityId != "" && CityId.Length >= 6)
                {
                    ProvinceId = CityId.Substring(0, 6);
                }
                var Province = IoC.Resolve<IXMWareHousesService>().GetProvinceByProvinceId(ProvinceId);
                if (Province != null && (Province.City == "北京" || Province.City == "上海" || Province.City == "重庆" || Province.City == "天津"))
                {
                    cityName = Province.City;
                }
                else
                {
                    if (CityId != "" && CityId.Length == 9)         //城市
                    {
                        var info = IoC.Resolve<IXMWareHousesService>().GetCityInfoByCityId(CityId, 3);
                        if (info != null)
                        {
                            cityName = info.City;
                        }
                    }
                    if (CityId != "" && CityId.Length == 12)     //县区
                    {
                        var info = IoC.Resolve<IXMWareHousesService>().GetCityInfoByCityId(CityId, 4);
                        if (info != null)
                        {
                            cityName = info.City;
                        }
                    }
                }
                return cityName;
            }
        }

        #endregion
    }
}
