
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-08 13:14:13
** 修改人:
** 修改日期:
** 描 述: 接口实现类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMBusinessDataService : IXMBusinessDataService
    {
        #region Fields
        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;
        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public XMBusinessDataService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMBusinessDataService成员
        /// <summary>
        /// Insert into XMBusinessData
        /// </summary>
        /// <param name="xmbusinessdata">XMBusinessData</param>
        public void InsertXMBusinessData(XMBusinessData xmbusinessdata)
        {
            if (xmbusinessdata == null)
                return;

            if (!this._context.IsAttached(xmbusinessdata))

                this._context.XMBusinessDatas.AddObject(xmbusinessdata);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMBusinessData
        /// </summary>
        /// <param name="xmbusinessdata">XMBusinessData</param>
        public void UpdateXMBusinessData(XMBusinessData xmbusinessdata)
        {
            if (xmbusinessdata == null)
                return;

            if (this._context.IsAttached(xmbusinessdata))
                this._context.XMBusinessDatas.Attach(xmbusinessdata);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMBusinessData list
        /// </summary>
        public List<XMBusinessData> GetXMBusinessDataList()
        {
            var query = from p in this._context.XMBusinessDatas
                        where p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        public List<XMBusinessDataBrief> GetXMBusinessDataListByClientCompany(string ClientCompany)
        {
            var query = from p in this._context.XMBusinessDatas
                        where p.IsEnabled == false
                        && (p.ClientCompany.Contains(ClientCompany) || p.PayPerson.Contains(ClientCompany))
                        select new XMBusinessDataBrief
                        {
                            ContractNumber = p.ContractNumber,
                            ContractAmount = p.ContractAmount,
                            ClientCompany = p.ClientCompany,
                            PayPerson = p.PayPerson
                        };
            return query.ToList();
        }

        public List<XMBusinessData> GetXMBusinessDataDetailListByContractNumber(string ContractNumber, int ID)
        {
            var query = from p in this._context.XMBusinessDatas
                        where p.IsEnabled == false
                        && p.ContractNumber == ContractNumber
                        && (ID == 0 || p.ID != ID)
                        select p;
            return query.ToList();
        }

        public List<XMBusinessData> GetXMBusinessDataListByContractNumber(string ContractNumber)
        {
            var query = from p in this._context.XMBusinessDatas
                        where p.IsEnabled == false
                        && p.ContractNumber == ContractNumber
                        select p;
            return query.ToList();
        }

        #region
        public string GetCustomerName(string CustomerNameIDs)
        {
            string[] arr = CustomerNameIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr != null && arr.Count() > 0)
            {
                string name = "";
                foreach (string Id in arr)
                {
                    int id = int.Parse(Id);
                    var query = from p in this._context.CustomerInfoes
                                where !p.Deleted
                                && p.CustomerID == id
                                select p;
                    if (name == "")
                    {
                        name = query.SingleOrDefault().FullName;
                    }
                    else
                    {
                        name = name + "," + query.SingleOrDefault().FullName;
                    }
                }
                return name;
            }
            else
            {
                return "";
            }
        }

        //public List<string> GetBelongingNameList(int BelongingDepID)
        //{
        //    var query = from p in this._context.XMBusinessDatas
        //                where p.IsEnabled == false
        //                && p.BelongingDepID == BelongingDepID
        //                select p;
        //    string name="";
        //    if (query != null && query.ToList().Count > 0)
        //    {
        //        foreach (XMBusinessData Info in query.ToList())
        //        {
        //            name = name + "," + GetCustomerNameByBusinessDateID(Info.ID);
        //        }
        //    }
        //    List<string> list = name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //    return list;
        //}

        public string GetCustomerNameByBusinessDateID(int BusinessDateID)
        {
            var query = from p in this._context.XMBusinessDataDetails
                        where p.IsEnabled == false
                        && p.BusinessDataID == BusinessDateID
                        select p;
            if (query != null && query.ToList().Count > 0)
            {
                string Name = "";
                List<string> list = new List<string>();
                foreach (XMBusinessDataDetail Info in query.ToList())
                {
                    string[] arr = Info.BelongingName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr != null && arr.Count() > 0)
                    {
                        foreach (string name in arr)
                        {
                            if (list.IndexOf(name) == -1)
                            {
                                list.Add(name);
                            }
                        }
                    }
                }
                foreach (string no in list)
                {
                    if (Name == "")
                    {
                        Name = no;
                    }
                    else
                    {
                        Name = Name + "," + no;
                    }
                }
                return Name;
            }
            else
            {
                return "";
            }
        }
        #endregion

        public bool GetFinancialStatusByBusinessDateID(int BusinessDateID)
        {
            var query = from p in this._context.XMBusinessDataDetails
                        where p.IsEnabled == false
                        && p.BusinessDataID == BusinessDateID
                        select p;
            if (query != null && query.ToList().Count > 0)
            {
                bool status = true;
                foreach (XMBusinessDataDetail Info in query.ToList())
                {
                    if (!(bool)Info.FinancialStatus)
                    {
                        status = false;
                        break;
                    }
                }
                return status;
            }
            else
            {
                return false;
            }
        }

        public List<XMBusinessData> GetXMBusinessDataListByData(string ContractNumber, string ClientCompany, string BelongingPeople, int BelongingDepID)
        {
            var query = from p in this._context.XMBusinessDatas
                        join q in this._context.XMBusinessDataDetails
                        on p.ID equals q.BusinessDataID into detail
                        from Datail in detail.DefaultIfEmpty()
                        where p.IsEnabled == false
                        && p.ContractNumber.Contains(ContractNumber)
                        && p.ClientCompany.Contains(ClientCompany)
                        && (Datail == null || Datail.BelongingName.Contains(BelongingPeople))
                        && p.BelongingDepID == BelongingDepID
                        select p;
            return query.ToList().Distinct().ToList();
        }


        /// <summary>
        /// get to XMBusinessData Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMBusinessData Page List</returns>
        public PagedList<XMBusinessData> SearchXMBusinessData(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMBusinessDatas
                        orderby p.ID
                        select p;
            return new PagedList<XMBusinessData>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMBusinessData by ID
        /// </summary>
        /// <param name="id">XMBusinessData ID</param>
        /// <returns>XMBusinessData</returns>   
        public XMBusinessData GetXMBusinessDataByID(int id)
        {
            var query = from p in this._context.XMBusinessDatas
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMBusinessData by ID
        /// </summary>
        /// <param name="ID">XMBusinessData ID</param>
        public void DeleteXMBusinessData(int id)
        {
            var xmbusinessdata = this.GetXMBusinessDataByID(id);
            if (xmbusinessdata == null)
                return;

            if (!this._context.IsAttached(xmbusinessdata))
                this._context.XMBusinessDatas.Attach(xmbusinessdata);

            this._context.DeleteObject(xmbusinessdata);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMBusinessData by ID
        /// </summary>
        /// <param name="IDs">XMBusinessData ID</param>
        public void BatchDeleteXMBusinessData(List<int> ids)
        {
            var query = from q in _context.XMBusinessDatas
                        where ids.Contains(q.ID)
                        select q;
            var xmbusinessdatas = query.ToList();
            foreach (var item in xmbusinessdatas)
            {
                if (!_context.IsAttached(item))
                    _context.XMBusinessDatas.Attach(item);

                _context.XMBusinessDatas.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
