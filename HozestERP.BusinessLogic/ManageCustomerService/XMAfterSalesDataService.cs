
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-07-01 15:43:27
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
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMAfterSalesDataService: IXMAfterSalesDataService
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
    	public XMAfterSalesDataService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMAfterSalesDataService成员
        /// <summary>
        /// Insert into XMAfterSalesData
        /// </summary>
        /// <param name="xmaftersalesdata">XMAfterSalesData</param>
    	public void InsertXMAfterSalesData(XMAfterSalesData xmaftersalesdata)
    	{	
            if (xmaftersalesdata == null)
                return;
    
            if (!this._context.IsAttached(xmaftersalesdata))
    			
                this._context.XMAfterSalesDatas.AddObject(xmaftersalesdata);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMAfterSalesData
        /// </summary>
        /// <param name="xmaftersalesdata">XMAfterSalesData</param>
        public void UpdateXMAfterSalesData(XMAfterSalesData xmaftersalesdata)
        {
            if (xmaftersalesdata == null)
                return;
    
            if (this._context.IsAttached(xmaftersalesdata))
                this._context.XMAfterSalesDatas.Attach(xmaftersalesdata);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMAfterSalesData list
        /// </summary>
        public List<XMAfterSalesData> GetXMAfterSalesDataList()
        {		
            var query = from p in this._context.XMAfterSalesDatas
                        select p;
            return query.ToList();
        }

        //public List<QuestionDetailed_Result> GetXMAfterSalesDataByDemandReturn(DateTime begin, DateTime end, int CustomerID, string ReturnID)
        //{
        //    int type = 1;//需求退货客户
        //    int ResultsId = 0;
        //    if (!string.IsNullOrEmpty(ReturnID))
        //    {
        //        type = 0;//实际退货
        //        ResultsId = int.Parse(ReturnID);
        //    }
        //    var query = from p in this._context.XMQuestionDetails
        //                join question in this._context.XMQuestions
        //                on p.QuestionID equals question.ID
        //                join codelist in this._context.CodeLists
        //                on p.QuestionTypeID equals codelist.CodeID into CodeList
        //                from Code in CodeList
        //                where p.SrvAfterCustomerID == CustomerID
        //                && p.Status == 2
        //                && p.LastModifyTime > begin
        //                && p.LastModifyTime < end
        //                && p.IsReturns == true
        //                && (Code.CodeName != "催货" && Code.CodeName != "常规活动收货后赠品及返现")
        //                && Code.Deleted == false
        //                && p.IsEnable == false
        //                && question.IsEnable ==false
        //                && (type > 0 || p.ResultsId == ResultsId)
        //                orderby p.QuestionID ascending, p.CreateTime ascending
        //                select new QuestionDetailed_Result
        //                {
        //                    ID=question.ID,
        //                    OrderNO = question.OrderNO,
        //                    PlatformID = question.PlatformID,
        //                    NickID = question.NickID,
        //                    Buyer = question.Buyer,
        //                    QuestionTypeID = p.QuestionTypeID,
        //                    IsReturns = p.IsReturns,
        //                    SrvAfterCustomerID = p.SrvBeforeCustomerID,
        //                    ResultsId =p.ResultsId,
        //                    Status = p.Status,
        //                    CreateTime = p.CreateTime
        //                };
        //    List<QuestionDetailed_Result> List = new List<QuestionDetailed_Result>();
        //    if (query != null && query.Count()>0)
        //    {
        //        IEnumerable<IGrouping<int, QuestionDetailed_Result>> list = query.GroupBy(x => x.ID);
        //        foreach (IGrouping<int, QuestionDetailed_Result> info in list)
        //        {
        //            List<QuestionDetailed_Result> sl = info.ToList<QuestionDetailed_Result>();//分组后的集合
        //            int no=0;
        //            foreach (QuestionDetailed_Result item in sl)
        //            {
        //                if (no == 0)
        //                {
        //                    List.Add(item);
        //                    no++;
        //                    continue;
        //                }
        //                bool have = false;
        //                foreach (QuestionDetailed_Result it in sl)
        //                {
        //                    if (item.ID == it.ID && item.QuestionTypeID == it.QuestionTypeID && item!=it)
        //                    { 
        //                        if((DateTime)item.CreateTime >= (DateTime)it.CreateTime)
        //                        {
        //                            if ((DateTime)item.CreateTime < ((DateTime)it.CreateTime).AddHours(48))
        //                            {
        //                                have = true;
        //                                break;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (((DateTime)item.CreateTime).AddHours(48) >= (DateTime)it.CreateTime)
        //                            {
        //                                have = true;
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //                if (!have)
        //                {
        //                    List.Add(item);
        //                }
        //            }
        //        }
        //    }
        //    return List;
        //}

        public List<QuestionDetailed_Result> GetXMAfterSalesDataByPersonalWorkload(DateTime begin, DateTime end, int CustomerID)
        {
            var query = from p in this._context.XMQuestionDetails
                        join question in this._context.XMQuestions
                        on p.QuestionID equals question.ID
                        join codelist in this._context.CodeLists
                        on p.QuestionTypeID equals codelist.CodeID into CodeList
                        from Code in CodeList
                        where p.SrvAfterCustomerID == CustomerID
                        && p.Status == 2
                        && p.LastModifyTime > begin
                        && p.LastModifyTime < end
                        //&& p.IsReturns == true
                        && (Code.CodeName != "催货" && Code.CodeName != "常规活动收货后赠品及返现")
                        && Code.Deleted == false
                        && p.IsEnable == false
                        && question.IsEnable == false
                        orderby p.QuestionID ascending, p.CreateTime ascending
                        select new QuestionDetailed_Result
                        {
                            ID = question.ID,
                            OrderNO = question.OrderNO,
                            PlatformID = question.PlatformID,
                            NickID = question.NickID,
                            Buyer = question.Buyer,
                            QuestionTypeID = p.QuestionTypeID,
                            IsReturns = p.IsReturns,
                            SrvAfterCustomerID = p.SrvBeforeCustomerID,
                            ResultsId = p.ResultsId,
                            Status = p.Status,
                            CreateTime = p.CreateTime
                        };
            List<QuestionDetailed_Result> List = new List<QuestionDetailed_Result>();
            if (query != null && query.Count() > 0)
            {
                IEnumerable<IGrouping<int, QuestionDetailed_Result>> list = query.GroupBy(x => x.ID);
                foreach (IGrouping<int, QuestionDetailed_Result> info in list)
                {
                    List<QuestionDetailed_Result> sl = info.ToList<QuestionDetailed_Result>();//分组后的集合
                    int no = 0;
                    foreach (QuestionDetailed_Result item in sl)
                    {
                        if (no == 0)
                        {
                            List.Add(item);
                            no++;
                            continue;
                        }
                        bool have = false;
                        foreach (QuestionDetailed_Result it in sl)
                        {
                            if (item.QuestionID == it.QuestionID && item.QuestionTypeID == it.QuestionTypeID)
                            {
                                if ((DateTime)item.CreateTime >= (DateTime)it.CreateTime)
                                {
                                    if ((DateTime)item.CreateTime < ((DateTime)it.CreateTime).AddHours(48))
                                    {
                                        have = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (((DateTime)item.CreateTime).AddHours(48) >= (DateTime)it.CreateTime)
                                    {
                                        have = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!have)
                        {
                            List.Add(item);
                        }
                    }
                }
            }
            return List;
        }

        public XMAfterSalesData GetXMAfterSalesDataInfoByMonth(string date, int CustomerID)
        {
            var query = from p in this._context.XMAfterSalesDatas
                        where p.Month == date
                        && p.CustomerID == CustomerID
                        select p;
            return query.SingleOrDefault();
        }

        public List<XMAfterSalesData> GetXMAfterSalesDataListByMonth(string date)
        {
            var query = from p in this._context.XMAfterSalesDatas
                        where p.Month == date
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMAfterSalesData Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAfterSalesData Page List</returns>
        public PagedList<XMAfterSalesData> SearchXMAfterSalesData(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAfterSalesDatas
                        orderby p.ID
                        select p;
            return new PagedList<XMAfterSalesData>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMAfterSalesData by ID
        /// </summary>
        /// <param name="id">XMAfterSalesData ID</param>
        /// <returns>XMAfterSalesData</returns>   
        public XMAfterSalesData GetXMAfterSalesDataByID(int id)
        {
            var query = from p in this._context.XMAfterSalesDatas
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMAfterSalesData by ID
        /// </summary>
        /// <param name="ID">XMAfterSalesData ID</param>
        public void DeleteXMAfterSalesData(int id)
        {
            var xmaftersalesdata = this.GetXMAfterSalesDataByID(id);
            if (xmaftersalesdata == null)
                return;
    
            if (!this._context.IsAttached(xmaftersalesdata))
                this._context.XMAfterSalesDatas.Attach(xmaftersalesdata);
    
            this._context.DeleteObject(xmaftersalesdata);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMAfterSalesData by ID
        /// </summary>
        /// <param name="IDs">XMAfterSalesData ID</param>
        public void BatchDeleteXMAfterSalesData(List<int> ids)
        {
    	   var query = from q in _context.XMAfterSalesDatas
                    where ids.Contains(q.ID)
                    select q;
            var xmaftersalesdatas = query.ToList();
            foreach (var item in xmaftersalesdatas)
            {
                if (!_context.IsAttached(item))
                    _context.XMAfterSalesDatas.Attach(item);  
    
                _context.XMAfterSalesDatas.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
