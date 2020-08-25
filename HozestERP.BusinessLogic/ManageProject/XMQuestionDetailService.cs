using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;
using HozestERP.BusinessLogic.Installation;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMQuestionDetailService : IXMQuestionDetailService
    {
        #region Properties

        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Object context</param>
        public XMQuestionDetailService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPStaticCache();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get a record by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>record</returns>
        public XMQuestionDetail GetById(int id)
        {
            if (id == 0) return null;
            var query = from m in _context.XMQuestionDetails
                        where m.ID == id
                        && m.IsEnable == false
                        select m;
            var mModel = query.SingleOrDefault();
            return mModel;
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public List<XMQuestionDetail> getByIds(List<int> IDs)
        {

            var query = from m in _context.XMQuestionDetails
                        where IDs.Contains(m.ID)
                        select m;
            return query.ToList<XMQuestionDetail>();

        }

        /// <summary>
        ///  Gets all records
        /// </summary>
        /// <returns>records</returns>
        public IList<XMQuestionDetail> GetAll()
        {
            var query = from m in _context.XMQuestionDetails
                        select m;
            return query.ToList<XMQuestionDetail>();
        }

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="XMQuestionDetail">pXMQuestionDetail</param>
        /// <returns>record</returns>
        public void Insert(XMQuestionDetail pXMQuestionDetail)
        {
            if (pXMQuestionDetail == null)
                throw new ArgumentNullException("pXMQuestionDetail");

            _context.XMQuestionDetails.AddObject(pXMQuestionDetail);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="XMQuestionDetail">pXMQuestionDetail</param>
        /// <returns>record</returns>
        public void Update(XMQuestionDetail pXMQuestionDetail)
        {
            if (pXMQuestionDetail == null)
                throw new ArgumentNullException("pXMQuestionDetail");

            if (!_context.IsAttached(pXMQuestionDetail))
                _context.XMQuestionDetails.Attach(pXMQuestionDetail);

            _context.SaveChanges();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var mRecord = GetById(id);
            if (mRecord == null) return;

            if (!_context.IsAttached(mRecord))
                _context.XMQuestionDetails.Attach(mRecord);

            _context.DeleteObject(mRecord);
            _context.SaveChanges();
        }

        /// <summary>
        /// 得到问题列表
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public List<XMQuestionDetail> GetQuestionDetails(int questionID)
        {
            if (questionID == 0)
                return new List<XMQuestionDetail>();
            var query = from m in _context.XMQuestionDetails
                        where m.QuestionID.Equals(questionID)
                        && m.IsEnable == false
                        select m;
            return query.ToList();
        }

        /// <summary>
        /// 根据问题提交时间获取问题集合
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <param name="strQuestiongType">问题类型</param>
        /// <returns></returns>
        public List<XMQuestionDetail> GetQuestionDetailsBySubmit(string beginDate, string endDate, string afterFullName, string strQuestiongType)
        {
            string strSql = @"select * from dbo.XM_QuestionDetail a";
            string strWhere = "";
            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                beginDate = DateTime.Parse(beginDate).Date.ToString("yyyy-MM-dd HH:mm:ss");
                endDate = DateTime.Parse(endDate).AddDays(1).AddMilliseconds(-30).ToString("yyyy-MM-dd HH:mm:ss");
                strWhere += @" AND a.CreateTime is not null
                               AND a.OrdersTime is not null
                               AND a.QuestionTypeID  in (" + strQuestiongType + @") 
                               AND a.CreateTime between '" + beginDate + "' and '" + endDate + "'";
            }
            if (!string.IsNullOrEmpty(afterFullName))
            {
                strWhere += @" AND exists (
	                            select 1 from dbo.Sys_CustomerInfo b
	                            where a.SrvAfterCustomerID = b.CustomerID
	                            AND b.FullName = '" + afterFullName + @"'
                            )";
            }

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " WHERE 1=1" + strWhere;
            }
            strSql += " ORDER BY a.ID";
            return this._context.ExecuteStoreQuery<XMQuestionDetail>(strSql).ToList();
        }
        /// <summary>
        /// 根据问题提交时间查找3天内处理完成的问题集合
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <param name="strQuestiongType">问题类型</param>
        /// <returns></returns>
        public List<XMQuestionDetail> GetQuestionDetailsByComplete(string beginDate, string endDate, string afterFullName, string strQuestiongType)
        {

            //--创单时间 如是星期五：需在创单时间加3天
            //--创单时间 如是星期六：需在创单时间加2天
            //--创单时间 如是星期日：需在创单时间加1天
            string strSql = @"select  [ID]
							  ,c.[QuestionID] ,c.[SrvBeforeCustomerID] ,c.[SrvAfterCustomerID] ,c.[Description]
							  ,c.[ResultMsg] ,c.[Status] ,c.CreateTimeOld  as CreateTime,c.[CreateByID] ,c.[LastModifyTime]
							  ,c.[LastModifyByID] ,c.[QuestionTypeID] ,c.OrdersTimeNow as OrdersTime
							  ,c.[IsEnable] ,c.[IsReturns] ,c.[ResultsId] 
							  from (  
							  select aNow.* from (
                              select [ID]  ,[QuestionID] ,[SrvBeforeCustomerID] ,[SrvAfterCustomerID]
							  ,[Description]  ,[ResultMsg] ,[Status]  ,[CreateByID]
							  ,[LastModifyTime] ,[LastModifyByID] ,[QuestionTypeID] ,[IsEnable]
							  ,[IsReturns] ,[ResultsId]  ,[CreateTime] as  CreateTimeOld, 
                             case when DATENAME(weekday,a.CreateTime) ='Friday' then DATEADD(d,3,a.CreateTime) 
                             when DATENAME(weekday,a.CreateTime) ='Saturday' then DATEADD(d,2,a.CreateTime) 
                             when DATENAME(weekday,a.CreateTime) ='Sunday' then DATEADD(d,1,a.CreateTime) 
                             else DATEADD(d,0,a.CreateTime)  end as  CreateTimeNow 
                             ,[OrdersTime] as OrdersTimeNow
                             from dbo.XM_QuestionDetail a 
                             ) aNow ";
            string strWhere = "";
            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                beginDate = DateTime.Parse(beginDate).Date.ToString("yyyy-MM-dd HH:mm:ss");
                endDate = DateTime.Parse(endDate).AddDays(1).AddMilliseconds(-30).ToString("yyyy-MM-dd HH:mm:ss");
                strWhere += @" AND aNow.CreateTimeOld is not null
                               AND aNow.LastModifyTime is not null
                               AND aNow.CreateTimeOld between '" + beginDate + "' and '" + endDate + @"'
                               AND aNow.QuestionTypeID  in (" + strQuestiongType + @") 
                               AND datediff(hour, aNow.CreateTimeNow ,aNow.OrdersTimeNow) < 24";
            }
            if (!string.IsNullOrEmpty(afterFullName))
            {
                strWhere += @" AND exists (
	                            select 1 from dbo.Sys_CustomerInfo b
	                            where aNow.SrvAfterCustomerID = b.CustomerID
	                            AND b.FullName = '" + afterFullName + @"' )";
            }

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " WHERE 1=1 " + strWhere;
            }
            strSql += " ) as c";
            return this._context.ExecuteStoreQuery<XMQuestionDetail>(strSql).ToList();
        }

        /// <summary>
        /// 查询问题类型子节点数据列表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="cId"></param>
        /// <returns></returns>
        public List<XMQuestionDetail> GetQuestionDetailsByParm(int xMProjectId, string xMNickId, DateTime? BeginDate, DateTime? EndDate, int cId)
        {
            if (EndDate != null)
            {
                EndDate = ((DateTime)EndDate).AddDays(1).AddSeconds(-1);
            }
            int?[] nicklist = Array.ConvertAll<string, int?>(xMNickId.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            var query = from p in this._context.XMQuestionDetails
                        join c in this._context.XMQuestions on p.QuestionID equals c.ID into tD
                        from dd in tD.DefaultIfEmpty()
                        join b in this._context.XMNicks on dd.NickID equals b.nick_id into temp
                        from tt in temp.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (xMProjectId == -1 || tt.ProjectId == xMProjectId)
                        && (nick_id == -1 || nicklist.Contains(dd.NickID))
                        && p.CreateTime >= BeginDate && p.CreateTime <= EndDate
                        && p.QuestionTypeID == cId
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 统计问题类型查询列表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="QuestionType"></param>
        /// <returns></returns>
        public List<XMQuestionDetail> GetQuestionDetailByCategoryIDs(int xMProjectId, string xMNickId, DateTime? BeginDate, DateTime? EndDate,
           List<int?> QuestionType)
        {
            if (EndDate != null)
            {
                EndDate = ((DateTime)EndDate).AddDays(1).AddSeconds(-1);
            }
            int?[] nicklist = Array.ConvertAll<string, int?>(xMNickId.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            var query = from p in this._context.XMQuestionDetails
                        join c in this._context.XMQuestions on p.QuestionID equals c.ID into tD
                        from dd in tD.DefaultIfEmpty()
                        join b in this._context.XMNicks on dd.NickID equals b.nick_id into temp
                        from tt in temp.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (xMProjectId == -1 || tt.ProjectId == xMProjectId)
                        && (nick_id == -1 || nicklist.Contains(dd.NickID))
                        && p.CreateTime >= BeginDate && p.CreateTime <= EndDate
                        && QuestionType.Contains(p.QuestionTypeID.Value)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据问题提交时间获取是退货集合
        /// </summary>
        /// <param name="beginDate">完成率开始时间</param>
        /// <param name="endDate">完成率结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <returns></returns>
        public List<XMQuestionDetail> GetQuestionDetailsByIsReturnsTrue(string beginDate, string endDate, string afterFullName)
        {

            string strSql = @"select * from dbo.XM_QuestionDetail a";
            string strWhere = "";
            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                beginDate = DateTime.Parse(beginDate).Date.ToString("yyyy-MM-dd HH:mm:ss");
                endDate = DateTime.Parse(endDate).AddDays(1).AddMilliseconds(-30).ToString("yyyy-MM-dd HH:mm:ss");
                strWhere += @"  AND a.IsReturns=1
                               AND a.CreateTime is not null
                               AND a.OrdersTime is not null 
                               AND a.CreateTime between '" + beginDate + "' and '" + endDate + "'";
            }
            if (!string.IsNullOrEmpty(afterFullName))
            {
                strWhere += @" AND exists (
	                            select 1 from dbo.Sys_CustomerInfo b
	                            where a.SrvAfterCustomerID = b.CustomerID
	                            AND b.FullName = '" + afterFullName + @"'
                            )";
            }

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " WHERE 1=1" + strWhere;
            }
            strSql += " ORDER BY a.ID";
            return this._context.ExecuteStoreQuery<XMQuestionDetail>(strSql).ToList();
        }

        /// <summary>
        /// 根据问题提交时间查找处理结果是退货（实际退货）
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <returns></returns>
        public List<XMQuestionDetail> GetQuestionDetailsByResultsCount(string beginDate, string endDate, string afterFullName)
        {

            string strSql = @"select * from dbo.XM_QuestionDetail a";
            string strWhere = "";
            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                beginDate = DateTime.Parse(beginDate).Date.ToString("yyyy-MM-dd HH:mm:ss");
                endDate = DateTime.Parse(endDate).AddDays(1).AddMilliseconds(-30).ToString("yyyy-MM-dd HH:mm:ss");
                strWhere += @"  AND a.CreateTime is not null
                               AND a.OrdersTime is not null 
                               AND a.CreateTime between '" + beginDate + "' and '" + endDate + "' and exists(  select 1 from Sys_CodeList c  where a.ResultsId=c.CodeID and c.CodeNO='Returns')";
            }
            if (!string.IsNullOrEmpty(afterFullName))
            {
                strWhere += @" AND exists (
	                            select 1 from dbo.Sys_CustomerInfo b
	                            where a.SrvAfterCustomerID = b.CustomerID
	                            AND b.FullName = '" + afterFullName + @"'
                            )";
            }

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " WHERE 1=1" + strWhere;
            }
            strSql += " ORDER BY a.ID";
            return this._context.ExecuteStoreQuery<XMQuestionDetail>(strSql).ToList();

        }

        /// <summary>
        /// 移交客服
        /// </summary>
        /// <param name="QuestionIDs"></param>
        /// <param name="LastModifyByID"></param>
        /// <returns></returns>
        public int UpdateGetQuestionDetailsByQuestionID(int QuestionID, int LastModifyByID)//, string LastModifyTime)
        {

            string strSql = @"UPDATE XM_QuestionDetail set SrvAfterCustomerID=" + LastModifyByID + " ,LastModifyByID=" + LastModifyByID + "  WHERE  QuestionID =" + QuestionID;


            return SqlDataHelper.ExcuteBySql(strSql);
        }

        /// <summary>
        /// Batch delete BatchDeleteXMQuestionDetails by QuestionID
        /// </summary>
        /// <param name="QuestionID">BatchDeleteXMQuestionDetails QuestionID</param>
        public void BatchDeleteXMQuestionDetails(int questionID)
        {
            var query = from q in _context.XMQuestionDetails
                        where q.QuestionID == questionID
                        select q;
            var question = query.ToList();
            foreach (var item in question)
            {
                if (!_context.IsAttached(item))
                    _context.XMQuestionDetails.Attach(item);

                _context.XMQuestionDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }
        #endregion
    }
}
