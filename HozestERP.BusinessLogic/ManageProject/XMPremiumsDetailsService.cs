
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-02-10 09:55:50
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
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMPremiumsDetailsService : IXMPremiumsDetailsService
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
        public XMPremiumsDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPremiumsDetailsService成员
        /// <summary>
        /// Insert into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
        public void InsertXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails)
        {
            if (xmpremiumsdetails == null)
                return;

            if (!this._context.IsAttached(xmpremiumsdetails))

                this._context.XMPremiumsDetails.AddObject(xmpremiumsdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Insert into XMPremiumsDetails
        /// </summary>
        /// <param name="ProductlId">厂家编码Id</param>
        /// <param name="PlatformMerchantCode">商品编码</param>
        /// <param name="PrdouctName">商品名称</param>
        /// <param name="FactoryPrice">价格</param>
        /// <param name="ProductNum">数量</param>
        public int InsertXMPremiumsDetails(int PremiumsId, int ProductlId, string PlatformMerchantCode, string PrdouctName, decimal FactoryPrice, int ProductNum)
        {
            int inst = 0;
            int Shipper = 0;
            List<XMPremiumsDetails> CBAList = GetXMPremiumsDetailsListByPremiumsId(PremiumsId);

            var XMPList = CBAList.Where(p => p.PlatformMerchantCode.Equals(PlatformMerchantCode)).ToList();
            int UserId = 0;
            if (HozestERPContext.Current.User != null)
            {
                UserId = HozestERPContext.Current.User.CustomerID;

            }
            else
            {
                string UserName = "admin";
                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                if (customer.Count > 0)
                {
                    UserId = customer[0].CustomerID;
                }
            }

            var ShipperList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(226);
            if (ShipperList.Count > 0)
            {
                Shipper = ShipperList[0].CodeID;
            }
            var Product = IoC.Resolve<IXMProductService>().GetXMProductById(ProductlId);
            if (Product != null)
            {
                Shipper = (int)Product.Shipper;
            }

            if (XMPList.Count > 0)
            {
                XMPremiumsDetails premiumsDetails = new XMPremiumsDetails();
                premiumsDetails = XMPList[0];
                premiumsDetails.ProductDetaislId = ProductlId;
                premiumsDetails.PlatformMerchantCode = PlatformMerchantCode;
                premiumsDetails.PrdouctName = PrdouctName;
                premiumsDetails.FactoryPrice = FactoryPrice;
                premiumsDetails.ProductNum = ProductNum;
                premiumsDetails.Shipper = Shipper;
                premiumsDetails.UpdateID = UserId;//HozestERPContext.Current.User.CustomerID;
                premiumsDetails.UpdateDate = DateTime.Now;
                UpdateXMPremiumsDetails(premiumsDetails);
                inst = 1;
            }
            else
            {
                XMPremiumsDetails premiumsDetails = new XMPremiumsDetails();
                premiumsDetails.PremiumsId = PremiumsId;
                premiumsDetails.ProductDetaislId = ProductlId;
                premiumsDetails.PlatformMerchantCode = PlatformMerchantCode;
                premiumsDetails.PrdouctName = PrdouctName;
                premiumsDetails.FactoryPrice = FactoryPrice;
                premiumsDetails.ProductNum = ProductNum;
                premiumsDetails.Shipper = Shipper;
                premiumsDetails.IsEnable = false;
                premiumsDetails.CreateID = UserId;// HozestERPContext.Current.User.CustomerID;
                premiumsDetails.CreateDate = DateTime.Now;
                premiumsDetails.UpdateID = UserId;// HozestERPContext.Current.User.CustomerID;
                premiumsDetails.UpdateDate = DateTime.Now;
                InsertXMPremiumsDetails(premiumsDetails);
                inst = 1;
            }
            return inst;
        }

        /// <summary>
        /// Update into XMPremiumsDetails
        /// </summary>
        /// <param name="xmpremiumsdetails">XMPremiumsDetails</param>
        public void UpdateXMPremiumsDetails(XMPremiumsDetails xmpremiumsdetails)
        {
            if (xmpremiumsdetails == null)
                return;

            if (this._context.IsAttached(xmpremiumsdetails))
                this._context.XMPremiumsDetails.Attach(xmpremiumsdetails);

            this._context.SaveChanges();
        }

        public List<XMPremiumsDetails> GetXMPremiumsDetailsListByCustomerID(int CustomerID)
        {
            DateTime begin = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/01");
            DateTime end = DateTime.Now;
            var query = from d in _context.XMPremiumsDetails
                        join q in this._context.XMPremiums
                        on d.PremiumsId equals q.Id
                        where q.IsEnable == false
                        && d.IsEnable == false
                        && d.CreateID == CustomerID
                        && d.CreateDate >= begin
                        && d.CreateDate <= end
                        select d;
            return query.ToList();
        }

        /// <summary>
        /// get to XMPremiumsDetails list
        /// </summary>
        public List<XMPremiumsDetails> GetXMPremiumsDetailsList()
        {
            var query = from p in this._context.XMPremiumsDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }



        /// <summary>
        /// 根据赠品申请Id查询赠品明细
        /// </summary>
        /// <param name="PremiumsId">赠品申请Id</param>
        /// <returns></returns>
        public List<XMPremiumsDetails> GetXMPremiumsDetailsListByPremiumsId(int PremiumsId)
        {

            var query = from p in this._context.XMPremiumsDetails
                        where p.PremiumsId == PremiumsId 
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据赠品申请Id、明细商品编码 查询赠品明细
        /// </summary>
        /// <param name="PremiumsId">赠品申请Id</param>
        /// <param name="PlatformMerchantCode">商品编码集合</param>
        /// <returns></returns>
        public List<XMPremiumsDetails> GetXMPremiumsDetailsListByPremiumsId(int PremiumsId, List<string> PlatformMerchantCode)
        {


            var query = from p in this._context.XMPremiumsDetails
                        where p.PremiumsId == PremiumsId
                        && PlatformMerchantCode.Contains(p.PlatformMerchantCode)
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// 根据赠品申请Id查询赠品明细（根据商品编码统计数量）
        /// </summary>
        /// <param name="PremiumsId">赠品申请Id</param>
        /// <returns></returns>
        public List<XMPremiumsDetailsMapping> GetXMPremiumsDetailsListByPremiumsIdList(List<int> PremiumsIdList)
        {
            var query = from p in this._context.XMPremiumsDetails
                        where PremiumsIdList.Contains(p.PremiumsId.Value)
                        && p.IsEnable == false
                        group p by new
                        {
                            PlatformMerchantCode = p.PlatformMerchantCode
                        } into g
                        select new XMPremiumsDetailsMapping
                        {
                            PlatformMerchantCode = g.Key.PlatformMerchantCode,
                            SumProductNum = g.Sum(p => p.ProductNum)
                        };

            return new List<XMPremiumsDetailsMapping>(query);
        }


        /// <summary>
        /// get to XMPremiumsDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPremiumsDetails Page List</returns>
        public PagedList<XMPremiumsDetails> SearchXMPremiumsDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPremiumsDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMPremiumsDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMPremiumsDetails by Id
        /// </summary>
        /// <param name="id">XMPremiumsDetails Id</param>
        /// <returns>XMPremiumsDetails</returns>   
        public XMPremiumsDetails GetXMPremiumsDetailsById(int id)
        {
            var query = from p in this._context.XMPremiumsDetails
                        where p.Id.Equals(id)
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Id">XMPremiumsDetails Id</param>
        public void DeleteXMPremiumsDetails(int id)
        {
            var xmpremiumsdetails = this.GetXMPremiumsDetailsById(id);
            if (xmpremiumsdetails == null)
                return;

            if (!this._context.IsAttached(xmpremiumsdetails))
                this._context.XMPremiumsDetails.Attach(xmpremiumsdetails);

            this._context.DeleteObject(xmpremiumsdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPremiumsDetails by Id
        /// </summary>
        /// <param name="Ids">XMPremiumsDetails Id</param>
        public void BatchDeleteXMPremiumsDetails(List<int> ids)
        {
            var query = from q in _context.XMPremiumsDetails
                        where ids.Contains(q.Id)
                        && q.IsEnable == false
                        select q;
            var xmpremiumsdetailss = query.ToList();
            foreach (var item in xmpremiumsdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPremiumsDetails.Attach(item);

                _context.XMPremiumsDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
