
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-08-10 10:40:39
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMJDSaleRejectedService : IXMJDSaleRejectedService
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
        public XMJDSaleRejectedService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMJDSaleRejectedService成员
        /// <summary>
        /// Insert into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
        public void InsertXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected)
        {
            if (xmjdsalerejected == null)
                return;

            if (!this._context.IsAttached(xmjdsalerejected))

                this._context.XMJDSaleRejecteds.AddObject(xmjdsalerejected);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
        public void UpdateXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected)
        {
            if (xmjdsalerejected == null)
                return;

            if (this._context.IsAttached(xmjdsalerejected))
                this._context.XMJDSaleRejecteds.Attach(xmjdsalerejected);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMJDSaleRejected list
        /// </summary>
        public List<XMJDSaleRejected> GetXMJDSaleRejectedList()
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }

        public List<XMJDSaleRejected> GetXMJDSaleRejectedListOtherProject(DateTime begin, DateTime end)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.IsEnable == false
                        && p.NickId == 29//京东喜临门自营

                        && p.BizDt >= begin
                        && p.BizDt < end
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rejectedCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="returnCategoryID"></param>
        /// <param name="projectId"></param>
        /// <param name="nickids"></param>
        /// <param name="nickids2"></param>
        /// <param name="jdIsConfirm"></param>
        /// <param name="xbIsConfirm"></param>
        /// <param name="xlmIsConfirm"></param>
        /// <returns></returns>
        public List<XMJDSaleRejected> GetXMJDSaleRejectedListByParm(string rejectedCode, string begin, string end, string jdbegin, string jdend, string xlmbegin, string xlmend, int returnCategoryID, int projectId, string nickids, string nickids2, int FactoryID, int jdIsConfirm, int xbIsConfirm, int xlmIsConfirm, string paramNote,string PrepareCode)
        {
            int?[] nickIdlist = Array.ConvertAll<string, int?>(nickids.Split(','), delegate (string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nickIdlist.Count() > 0 && nickIdlist[0] != -1)
            {
                nick_id = int.Parse(nickIdlist[0].ToString());
            }
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }

            DateTime jdBeginTime= DateTime.Now;
            DateTime jdEndTime = DateTime.Now;
            if (jdbegin != "" && jdend != "")
            {
                jdBeginTime = DateTime.Parse(jdbegin);
                jdEndTime = DateTime.Parse(jdend);
            }

            DateTime xlmBeginTime = DateTime.Now;
            DateTime xlmEndTime = DateTime.Now;
            if (xlmbegin != "" && xlmend != "")
            {
                xlmBeginTime = DateTime.Parse(xlmbegin);
                xlmEndTime = DateTime.Parse(xlmend);
            }

            int?[] nickIdlist2 = Array.ConvertAll<string, int?>(nickids2.Split(','), delegate (string s) { return int.Parse(s); });
            bool jdIsConfrimed = jdIsConfirm == 0 ? false : true;
            bool xbIsConfirmed = xbIsConfirm == 0 ? false : true;
            bool xlmIsConfirmed = xlmIsConfirm == 0 ? false : true;
            var query = from p in this._context.XMJDSaleRejecteds
                        join t in this._context.XMNicks
                        on p.NickId equals t.nick_id
                        where p.IsEnable == false
                        && (rejectedCode == "" || p.Ref.Contains(rejectedCode))
                        && (PrepareCode == "" || p.PrepareRef.Contains(PrepareCode))
                        && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                        && (returnCategoryID == -1 || p.ReturnCategoryID == returnCategoryID)
                        && (projectId == -1 || t.ProjectId == projectId)
                        && (nick_id == -1 || nickIdlist.Contains(t.nick_id))
                        && (FactoryID == -1||p.FactoryID== FactoryID)
                        && nickIdlist2.Contains(t.nick_id)
                        && p.Note.Contains(paramNote)
                        select p;

            query = from p in query
                    join d in this._context.XMJDSaleRejectedProductDetails on p.Id equals d.JDRejectedID
                     into XMJDSaleRejectedProductDetails
                    from d in XMJDSaleRejectedProductDetails.DefaultIfEmpty()
                    where d.IsEnable == false
                   && (jdIsConfirm == -1 || d.JDIsConfirm == jdIsConfrimed)
                   && (xbIsConfirm == -1 || d.XBIsConfirm == xbIsConfirmed)
                   && (xlmIsConfirm == -1 || d.XLMIsConfirm == xlmIsConfirmed)
                   && ((jdbegin == "" && jdend == "") || (d.JDConfirmDate >= jdBeginTime && d.JDConfirmDate < jdEndTime))
                   && ((xlmbegin == "" && xlmend == "") || (d.XLMConfirmDate >= xlmBeginTime && d.XLMConfirmDate < xlmEndTime))
                    select p;
            query = query.Distinct().OrderByDescending(x => x.CreateDate);
            return query.ToList();
        }

        public List<XMJDSaleReport> GetXMJDSaleReportData(string begin, string end,string nickid)
        {
            int?[] nickIdlist=new int?[] { };

            if(!string.IsNullOrEmpty(nickid))
            {
                nickIdlist=Array.ConvertAll<string, int?>(nickid.Split(','), delegate (string s) { return int.Parse(s); });
            }

            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (!string.IsNullOrEmpty(begin) && !string.IsNullOrEmpty(end))
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }

            var query = from p in this._context.XMJDSaleRejecteds
                        join m in _context.CodeLists on p.ReturnCategoryID equals m.CodeID
                        where p.IsEnable == false && p.CreateDate>= purBeginTime && p.CreateDate<= purEndTime
                        && nickIdlist.Contains(p.NickId)
                        group p by new { p.ReturnCategoryID, m.CodeName } into g
                        select new XMJDSaleReport
                        {
                            ReturnCategoryID=(int)g.Key.ReturnCategoryID,
                            ReturnType = g.Key.CodeName,
                            Cost = 0,
                            ReturnMoney = g.Sum(a => (decimal)a.ReturnMoney),
                            Num = g.Count(),
                            CountProportion=""
                        };

            List<XMJDSaleReport> list = query.ToList();

            int AllCount = list.Sum(a => a.Num);

            foreach (var item in list)
            {
                var query1 = from p in this._context.XMJDSaleRejecteds
                             join m in _context.XMJDSaleRejectedProductDetails on p.Id equals m.JDRejectedID into temp
                             from pm in temp.DefaultIfEmpty()
                             join o in _context.XMProductDetails on pm.ProductId equals o.ProductId into temp2
                             from po in temp2.DefaultIfEmpty()
                             where p.ReturnCategoryID == item.ReturnCategoryID && p.IsEnable == false && po.PlatformTypeId == 537
                             && p.CreateDate >= purBeginTime && p.CreateDate <= purEndTime && nickIdlist.Contains(p.NickId)
                             select new
                             {
                                 po.Costprice,
                                 pm.RejectionCount
                             };
                var cost = query1.Sum(a => a.Costprice*a.RejectionCount);
                item.Cost = cost == null ? 0 : (decimal)cost;
                item.CountProportion = Math.Round(Math.Round(decimal.Parse(item.Num.ToString()) / AllCount, 4) * 100, 2) + "%";
            }

            return list;
        }

        /// <summary>
        /// get to XMJDSaleRejected Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDSaleRejected Page List</returns>
        public PagedList<XMJDSaleRejected> SearchXMJDSaleRejected(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMJDSaleRejected>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMJDSaleRejected by Id
        /// </summary>
        /// <param name="id">XMJDSaleRejected Id</param>
        /// <returns>XMJDSaleRejected</returns>   
        public XMJDSaleRejected GetXMJDSaleRejectedById(int id)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleRejectCode"></param>
        /// <returns></returns>
        public List<XMJDSaleRejected> GetXMJDSaleRejectedBySaleRejectCode(string saleRejectCode)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.IsEnable == false && p.Ref == saleRejectCode
                        select p;
            return query.ToList();
        }

        public XMJDSaleRejected GetXMJDSaleRejectedByRefAndReturnCategoryID(string Ref, int ReturnCategoryID)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.IsEnable == false && p.Ref == Ref && p.ReturnCategoryID == ReturnCategoryID
                        select p;
            return query.SingleOrDefault();
        }

        public XMJDSaleRejected GetXMJDSaleRejectedByRef(string Ref)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.IsEnable == false && p.Ref == Ref
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Id">XMJDSaleRejected Id</param>
        public void DeleteXMJDSaleRejected(int id)
        {
            var xmjdsalerejected = this.GetXMJDSaleRejectedById(id);
            if (xmjdsalerejected == null)
                return;

            if (!this._context.IsAttached(xmjdsalerejected))
                this._context.XMJDSaleRejecteds.Attach(xmjdsalerejected);

            this._context.DeleteObject(xmjdsalerejected);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Ids">XMJDSaleRejected Id</param>
        public void BatchDeleteXMJDSaleRejected(List<int> ids)
        {
            var query = from q in _context.XMJDSaleRejecteds
                        where ids.Contains(q.Id)
                        select q;
            var xmjdsalerejecteds = query.ToList();
            foreach (var item in xmjdsalerejecteds)
            {
                if (!_context.IsAttached(item))
                    _context.XMJDSaleRejecteds.Attach(item);

                _context.XMJDSaleRejecteds.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<XMJDSaleRejectedExport> Export(List<XMJDSaleRejected> list)
        {
            var query = from m in list
                        //关联退货单详细表
                        join n in _context.XMJDSaleRejectedProductDetails on m.Id equals n.JDRejectedID into temp
                        from p in temp.DefaultIfEmpty()
                        where p.IsEnable == false
                        //关联商品表
                        join a in _context.XMProducts on p.ProductId equals a.Id into temp1
                        from b in temp1.DefaultIfEmpty()
                        where b.IsEnable==false
                        //关联店铺表
                        join c in _context.XMNicks on m.NickId equals c.nick_id into temp2
                        from d in temp2.DefaultIfEmpty()
                        join e in _context.XMProjects on d.ProjectId equals e.Id into temp3
                        from f in temp3.DefaultIfEmpty()
                        select new XMJDSaleRejectedExport
                        {
                            Ref=m.Ref,
                            ProjectName=string.IsNullOrEmpty(f.ProjectName)?"": f.ProjectName,
                            NickName =string.IsNullOrEmpty(m.NickName)?"": m.NickName,
                            Time=m.UpdateDate,
                            ReturnCategoryName=m.ReturnCategoryName,
                            Note=m.Note,
                            PlatformMerchantCode=p.PlatformMerchantCode,
                            ProductName=b.ProductName,
                            Specifications=b.Specifications,
                            RejectionCount=p.RejectionCount,
                            RejectionPrice=p.RejectionPrice,
                            RejectionMoney=p.RejectionMoney,
                            JDIsConfirm=p.JDIsConfirm,
                            XBIsConfirm=p.XBIsConfirm,
                            XLMIsConfirm=p.XLMIsConfirm,
                        };

            return query.ToList();
        }

        #endregion
    }
}
