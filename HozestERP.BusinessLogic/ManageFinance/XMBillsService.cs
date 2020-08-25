
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2018-12-13 09:24:36
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMBillsService: IXMBillsService
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
    	public XMBillsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMBillsService成员
        /// <summary>
        /// Insert into XMBills
        /// </summary>
        /// <param name="xmbills">XMBills</param>
    	public void InsertXMBills(XMBills xmbills)
    	{	
            if (xmbills == null)
                return;
    
            if (!this._context.IsAttached(xmbills))
    			
                this._context.XMBills.AddObject(xmbills);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMBills
        /// </summary>
        /// <param name="xmbills">XMBills</param>
        public void UpdateXMBills(XMBills xmbills)
        {
            if (xmbills == null)
                return;
    
            if (this._context.IsAttached(xmbills))
                this._context.XMBills.Attach(xmbills);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMBills list
        /// </summary>
        public List<XMBills> GetXMBillsList()
        {		
            var query = from p in this._context.XMBills
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMBills Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMBills Page List</returns>
        public PagedList<XMBills> SearchXMBills(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMBills
                        orderby p.BillID
                        select p;
            return new PagedList<XMBills>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMBills by BillID
        /// </summary>
        /// <param name="billid">XMBills BillID</param>
        /// <returns>XMBills</returns>   
        public XMBills GetXMBillsByBillID(int billid)
        {
            var query = from p in this._context.XMBills
                        where p.BillID.Equals(billid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMBills by BillID
        /// </summary>
        /// <param name="BillID">XMBills BillID</param>
        public void DeleteXMBills(int billid)
        {
            var xmbills = this.GetXMBillsByBillID(billid);
            if (xmbills == null)
                return;
    
            if (!this._context.IsAttached(xmbills))
                this._context.XMBills.Attach(xmbills);
    
            this._context.DeleteObject(xmbills);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMBills by BillID
        /// </summary>
        /// <param name="BillIDs">XMBills BillID</param>
        public void BatchDeleteXMBills(List<int> billids)
        {
    	   var query = from q in _context.XMBills
                    where billids.Contains(q.BillID)
                    select q;
            var xmbillss = query.ToList();
            foreach (var item in xmbillss)
            {
                if (!_context.IsAttached(item))
                    _context.XMBills.Attach(item);  
    
                _context.XMBills.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// 订单信息(根据创单时间查询)
        /// </summary>
        /// <param name="SuppliersID">供应商ID </param>
        /// <param name="VerificationStatus">核销状态 </param>
        /// <param name="DeliveryId">发货单ID</param>
        /// <param name="PlatformMerchantCode">商品编码</param>
        /// <param name="CreateDateEBegin">创单开始时间</param>
        /// <param name="CreateDateEnd">创单结束时间</param>
        /// <returns></returns>
        public List<XMBills> GetXMBillsListSearch(string SuppliersID, string VerificationStatus, string DeliveryId, string PlatformMerchantCode, DateTime CreateDateEBegin, DateTime CreateDateEnd)
        {
            //未发货查找类型
            string sqlWhere = " where 1 = 1";
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(SuppliersID) && int.Parse(SuppliersID) >= 0)
                sb.Append(" AND SuppliersID = '" + SuppliersID + "'");
            if (!string.IsNullOrWhiteSpace(VerificationStatus))
                sb.Append(" AND VerificationStatus = '" + VerificationStatus + "'");
            if (!string.IsNullOrWhiteSpace(DeliveryId))
                sb.Append(" AND DeliveryNumber like '%" + DeliveryId + "%'");
            if (!string.IsNullOrWhiteSpace(PlatformMerchantCode))
                sb.Append(" AND PlatformMerchantCode like '%" + PlatformMerchantCode + "%'");

            sb.Append(" AND CreateDate >= '" + CreateDateEBegin + "' AND CreateDate < '" + CreateDateEnd + "'");
            
            string sql = " select * from XM_Bills" + sqlWhere + sb.ToString() + "order by BillID";
          
            var queryTrue = this._context.ExecuteStoreQuery<XMBills>(sql);

            return queryTrue.ToList();
        }

        /// <summary>
        /// Insert into List<XMBills>
        /// </summary>
        /// <param name="xmbills">XMBills</param>
        public void InsertXMBills(List<XMBills> xmbills)
        {
            if (xmbills.Count == 0)
                return;
            try
            {
                foreach (var elem in xmbills)
                {
                    if (!this._context.IsAttached(elem))
                        this._context.XMBills.AddObject(elem);
                }
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update into XMBills
        /// </summary>
        /// <param name="xmbills">XMBills</param>
        public void UpdateXMBills(List<XMBills> xmbills, Dictionary<string, string> Dic)
        {
            if (xmbills.Count == 0)
                return;
            try
            {
                foreach (var elem in xmbills)
                {
                    if (this._context.IsAttached(elem))
                        this._context.XMBills.Attach(elem);
                }
                UpdateXMDelivery(Dic);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get to XMBills list
        /// <param name="billsIdList">List<BillID></param>
        /// </summary>
        public List<XMBills> GetXMBillsList(List<int> billsIdList)
        {
            var query = from p in this._context.XMBills
                        where billsIdList.Contains(p.BillID)
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// update into XMDeliveryDetails
        /// <param name="dic">存储发货单号和账单核销状态的字典</param>
        /// </summary>
        public void UpdateXMDelivery(Dictionary<string, string> dic)
        {
            var deliveryNumberList = new List<string>();

            foreach (var elem in dic)
            {
                deliveryNumberList.Add(elem.Key.Split(',')[0]);
            }

            var deliveryQuery = from p in this._context.XMDeliveries
                                where deliveryNumberList.Contains(p.DeliveryNumber)
                                select p;//找出所有相关的发货单信息

            var deliverArray = deliveryQuery.ToArray();

            var deliverIdList = deliverArray.Select(m => (int?)m.Id).ToList();//获得所有的发货单号

            var query = from p in this._context.XMDeliveryDetails//得到对应的发货单详细信息的数据
                               join q in _context.XMDeliveries
                               on p.DeliveryId equals q.Id
                               where deliverIdList.Contains(p.DeliveryId)
                               select new { 
                                   p.Id,
                                   p.DeliveryId,
                                   q.DeliveryNumber,
                                   p.PlatformMerchantCode
                               };

            var array = query.Distinct().ToArray();
            var statusDic = new Dictionary<int, string>();
            var deliverDetailsIds = new List<int>();
            foreach (var elem in array)//将发货单详细ID和状态一一对应
            {
                var key = elem.DeliveryNumber + "," + elem.PlatformMerchantCode;
                if (dic.Keys.Contains(key))
                    statusDic.Add(elem.Id,dic[key]);
                deliverDetailsIds.Add(elem.Id);
            }

            var detailsQuery = from p in this._context.XMDeliveryDetails//得到对应的发货单详细信息的数据
                               where deliverDetailsIds.Contains(p.Id)
                               select p;

            var detailsArray = detailsQuery.ToArray();
            var updateDetailsList = new List<ManageProject.XMDeliveryDetails>();
            foreach (var elem in detailsArray)//修改发货单详细中的状态
            {
                if (statusDic.Keys.Contains(elem.Id))
                {
                    elem.VerificationStatus = statusDic[elem.Id];
                    updateDetailsList.Add(elem);//将修改过的发货单详细信息存储
                }
            }
            foreach (var elem in updateDetailsList)
            {
                if (this._context.IsAttached(elem))
                    this._context.XMDeliveryDetails.Attach(elem);
            }
            var deliverTotal = detailsArray.GroupBy(m => m.DeliveryId).Select(m => new
            {
                DeliveryId = m.Key,
                VerificationStatusList = m.Select(s => s.VerificationStatus)
            }).ToArray();
            var deliverTotalDic = new Dictionary<int?, string>();
            foreach (var elem in deliverTotal)
            {
                var st = elem.VerificationStatusList.Where(m => m != Convert.ToString((int)status.全部核销)).Count();
                if (st == 0)//全部核销
                {
                    deliverTotalDic.Add(elem.DeliveryId, Convert.ToString((int)status.全部核销));
                }
                else 
                {
                    st = elem.VerificationStatusList.Where(m => m != Convert.ToString((int)status.异常) && !string.IsNullOrWhiteSpace(m) && m != Convert.ToString((int)status.未核销)).Count();
                    if (st != 0)//存在核销异常的详细单
                        deliverTotalDic.Add(elem.DeliveryId, Convert.ToString((int)status.部分核销));
                    else 
                        deliverTotalDic.Add(elem.DeliveryId, Convert.ToString((int)status.未核销));
                }
            }

            foreach (var elem in deliverArray)
            {
                if (deliverTotalDic.Keys.Contains(elem.Id))
                    elem.VerificationStatus = deliverTotalDic[elem.Id];
                if (this._context.IsAttached(elem))
                    this._context.XMDeliveries.Attach(elem);
            }
            //this._context.SaveChanges();
        }
        /// <summary>
        /// 返回核销状态的text
        /// </summary>
        /// <param name="VerificationStatus"></param>
        /// <returns></returns>
        public string ReturnStatusText(string VerificationStatus)
        {
            var codeEntity = _context.CodeLists.Where(m => m.CodeTypeID == 247 && m.CodeNO == VerificationStatus).SingleOrDefault();
            if (codeEntity == null)
                return "无此核销状态";
            return codeEntity.CodeName;
        }
        /// <summary>
        /// 返回供应商名称text
        /// </summary>
        /// <param name="VerificationStatus"></param>
        /// <returns></returns>
        public string ReturnSuppliersName(int SuppliersId)
        {
            var suppliersEntity = _context.XMSuppliers.Where(m => m.Id == SuppliersId).SingleOrDefault();
            if (suppliersEntity == null)
                return "无此供应商";
            return suppliersEntity.SupplierName;
        }

       

    }
}
