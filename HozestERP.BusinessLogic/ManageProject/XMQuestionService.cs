using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Expressions;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;
using HozestERP.BusinessLogic.Installation;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageCustomerService;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMQuestionService : IXMQuestionService
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
        public XMQuestionService(HozestERPObjectContext context)
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
        public XMQuestion GetById(int id)
        {
            if (id == 0) return null;
            var query = from m in _context.XMQuestions
                        where m.ID == id
                        && m.IsEnable == false
                        select m;
            var mModel = query.SingleOrDefault();
            return mModel;
        }

        /// <summary>
        ///  Gets all records
        /// </summary>
        /// <returns>records</returns>
        public IList<XMQuestion> GetAll()
        {
            var query = from m in _context.XMQuestions
                        select m;
            return query.ToList<XMQuestion>();
        }

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="XMQuestion">pXMQuestion</param>
        /// <returns>record</returns>
        public void Insert(XMQuestion pXMQuestion)
        {
            if (pXMQuestion == null)
                throw new ArgumentNullException("pXMQuestion");

            _context.XMQuestions.AddObject(pXMQuestion);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="XMQuestion">pXMQuestion</param>
        /// <returns>record</returns>
        public void Update(XMQuestion pXMQuestion)
        {
            if (pXMQuestion == null)
                throw new ArgumentNullException("pXMQuestion");

            if (!_context.IsAttached(pXMQuestion))
                _context.XMQuestions.Attach(pXMQuestion);

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
                _context.XMQuestions.Attach(mRecord);

            _context.DeleteObject(mRecord);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<XMQuestion> GetQuestions()
        {
            var query = from m in _context.XMQuestions
                        where m.IsEnable == false
                        select m;
            return query.ToList();
        }

        public List<XMQuestion> GetQuestionsListByIDs(List<int> IDs)
        {
            var query = from m in _context.XMQuestions
                        where m.IsEnable == false
                        && IDs.Contains(m.ID)
                        select m;
            return query.ToList();
        }

        public List<XMDataAnalysy> GetQuestionAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> nickcount,
            List<int?> QuestionType, int QuestionLevel)
        {
            if (EndDate != null)
            {
                EndDate = ((DateTime)EndDate).AddDays(1).AddSeconds(-1);
            }
            var query = from p in this._context.XMQuestionDetails
                        join q in this._context.XMQuestions
                        on p.QuestionID equals q.ID
                        where p.IsEnable == false
                        && (PlatformId == -1 || q.PlatformID == PlatformId)
                        && ((NickId == -1 || q.NickID == NickId) || (NickId == -2 && nickcount.Contains(q.NickID)))
                        && ((BeginDate == null && EndDate == null) || (p.CreateTime >= BeginDate && p.CreateTime <= EndDate))
                        && (CustomerId == -1 || ((CustomerId == 0 && p.SrvAfterCustomerID == null) || p.SrvAfterCustomerID == CustomerId))
                        && (QuestionType.Count() == 0 || QuestionType.Contains(p.QuestionTypeID.Value))
                        && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                        orderby p.SrvAfterCustomerID, q.PlatformID, q.NickID, p.CreateTime
                        select new XMDataAnalysy
                        {
                            ID = p.ID,
                            QuestionID = q.ID,
                            PlatformTypeId = q.PlatformID,
                            NickId = q.NickID,
                            CreatorID = p.SrvAfterCustomerID == null ? 0 : p.SrvAfterCustomerID,
                            QuestionType = p.QuestionTypeID,
                            QuestionLevel = p.QuestionLevel == null ? 0 : (int)p.QuestionLevel,
                            Status = (int)p.Status,
                            ResultsId = p.ResultsId == null ? 0 : (int)p.ResultsId,
                            IsReturns = (bool)p.IsReturns,
                            LastModifyTime = p.LastModifyTime,
                            OrdersTime = p.OrdersTime
                        };
            return query.ToList();
        }

        public List<XMDataAnalysy> GetDataAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> nickcount,
            List<int?> QuestionType, int QuestionLevel)
        {
            if (EndDate != null)
            {
                EndDate = ((DateTime)EndDate).AddDays(1).AddSeconds(-1);
            }
            var query = from p in this._context.XMQuestionDetails
                        join q in this._context.XMQuestions
                        on p.QuestionID equals q.ID
                        where p.IsEnable == false
                        && (PlatformId == -1 || q.PlatformID == PlatformId)
                        && ((NickId == -1 || q.NickID == NickId) || (NickId == -2 && nickcount.Contains(q.NickID)))
                        && ((BeginDate == null && EndDate == null) || (p.CreateTime >= BeginDate && p.CreateTime <= EndDate))
                        && (CustomerId == -1 || ((CustomerId == 0 && p.SrvAfterCustomerID == null) || p.SrvAfterCustomerID == CustomerId))
                        && QuestionType.Count() == 0 || QuestionType.Contains(p.QuestionTypeID.Value)
                        && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                        orderby p.SrvAfterCustomerID, q.PlatformID, q.NickID, p.CreateTime
                        select new XMDataAnalysy
                        {
                            ID = p.ID,
                            PlatformTypeId = q.PlatformID,
                            NickId = q.NickID,
                            CreatorID = p.SrvAfterCustomerID == null ? 0 : p.SrvAfterCustomerID,
                            QuestionType = p.QuestionTypeID,
                            QuestionLevel = p.QuestionLevel == null ? 0 : (int)p.QuestionLevel,
                            Status = (int)p.Status,
                            ResultsId = p.ResultsId == null ? 0 : (int)p.ResultsId,
                            IsReturns = (bool)p.IsReturns,
                            LastModifyTime = p.LastModifyTime,
                            OrdersTime = p.OrdersTime
                        };
            return query.ToList();
        }

        public int GetNickCount(List<XMDataAnalysy> Questionlist, int PlatformTypeId, int NickId)
        {
            int count = 0;
            var query = from p in Questionlist
                        where p.PlatformTypeId == PlatformTypeId
                        && p.NickId == NickId
                        select p;
            if (query != null)
            {
                count = query.ToList().Count;
            }
            return count;
        }
        /// <summary>
        /// 获取父节点下问题数量
        /// </summary>
        /// <returns></returns>
        public int GetQuestionCategoryCount(List<XMDataAnalysy> Questionlist, int pCategoryId)
        {
            int count = 0;
            var query = from p in Questionlist
                        where p.ParentQuestionType == pCategoryId
                        select p;
            if (query != null)
            {
                count = query.ToList().Count;
            }
            return count;
        }

        public int GetCompleteCount(List<XMDataAnalysy> Questionlist, int CreatorID, string Type)
        {
            int count = 0;
            if (Type == "Complete")
            {
                int complete = Convert.ToInt32(QuestionStatusEnum.Complete);
                var query = from p in Questionlist
                            where p.CreatorID == CreatorID
                            && p.Status == complete
                            select p;
                count = query.ToList().Count;
            }
            else if (Type == "ReturnCount")
            {
                int resultsId = 0;
                var code = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(201, false);
                if (code != null)
                {
                    foreach (CodeList info in code)
                    {
                        if (info.CodeName == "退货")
                        {
                            resultsId = info.CodeID;
                            break;
                        }
                    }
                }
                var query1 = from p in Questionlist
                             where p.CreatorID == CreatorID
                             && p.ResultsId == resultsId
                             select p;
                if (query1 != null)
                {
                    count = query1.ToList().Count;
                }
            }
            else if (Type == "ReturnTotal")
            {
                var query2 = from p in Questionlist
                             where p.CreatorID == CreatorID
                             && p.IsReturns == true
                             select p;
                if (query2 != null)
                {
                    count = query2.ToList().Count;
                }
            }

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="nick"></param>
        /// <param name="platform"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<XMQuestion> GetQuestionsBySearch(string orderNO = "", string nickID = "", string platform = "", string status = "",
            string afterFullName = "", string beginDate = "", string endDate = "")
        {
            string strSql = @"select a.* from dbo.XM_Question a";
            string strWhere = "";
            if (!string.IsNullOrEmpty(orderNO)) strWhere += " AND a.OrderNO = '" + orderNO + "'";
            if (!string.IsNullOrEmpty(nickID) && !nickID.Equals("-1")) strWhere += " AND a.NickID = '" + nickID + "'";
            if (!string.IsNullOrEmpty(platform) && !platform.Equals("-1")) strWhere += " AND a.PlatformID = '" + platform + "'";
            if (!string.IsNullOrEmpty(status) && !status.Equals("-1")) strWhere += " AND a.[Status] = '" + status + "'";
            if (!string.IsNullOrEmpty(afterFullName))
            {
                strWhere += @" AND exists (
	                                select 1 from dbo.Sys_CustomerInfo b
	                                where a.LastModifyByID = b.CustomerID
	                                AND b.FullName = '" + afterFullName + @"'
                               )";
            }
            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                endDate = endDate + " 23:59:59";
                strWhere += " AND a.CreateTime between '" + beginDate + "' and '" + endDate + @"'";
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " WHERE 1=1 " + strWhere;
            }
            strSql += " ORDER BY a.EmergencyDegree DESC,a.[Status] ASC";

            var res = this._context.ExecuteStoreQuery<XMQuestion>(strSql).ToList();
            return res;
        }



        /// <summary>
        /// 根据订单号查询
        /// </summary>
        /// <param name="orderNO">订单号</param> 
        /// <returns></returns>
        public List<XMQuestion> GetQuestionsByOrderNo(string orderNO)
        {

            var query = from m in _context.XMQuestions
                        where m.OrderNO.Equals(orderNO)
                        && m.IsEnable == false
                        select m;
            return query.ToList();
        }

        /// <summary>
        /// 根绝条件获取订单问题反馈列表
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="nickID">店铺ID</param>
        /// <param name="startTime">订单创建开始日期</param>
        /// <param name="endTime">订单创建结束日期</param>
        /// <param name="platformID">平台ID</param>
        /// <param name="statusID">状态ID</param>
        /// <param name="FullName">姓名</param>NO
        /// <param name="RefundLogisticsNo">退款单号</param> NO
        /// <param name="afterFullName">售后</param>
        /// <param name="questionTypeIDs">问题类型ID</param>
        /// <param name="PrdouctName">产品名称</param>NO
        /// <param name="lastStartDate"></param>
        /// <param name="lastEndDate"></param> 
        /// <param name="TheResults">问题处理结果</param>  
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="Buyer">买家</param>
        /// <returns></returns>
        public PagedList<XMQuestion> XMQuestionSearch(string orderNO, int xMProjectId, string nickID, DateTime? startTime, DateTime? endTime
            , int platformID, int statusID, string FullName, string RefundLogisticsNo, string afterFullName, List<int> questionTypeIDs, string PrdouctName
           , int pageIndex, int pageSize, string sortExpression, string sortDirection, DateTime? lastStartDate, DateTime? lastEndDate, int TheResults, string Buyer, int QuestionLevel)
        {
            if (questionTypeIDs == null)
            {
                questionTypeIDs = new List<int>();
            }
            int?[] nicklist = Array.ConvertAll<string, int?>(nickID.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            //初始化 （所以）
            IQueryable<XMQuestion> query = null;
            //完成 
            List<XMQuestionDetail> xMQuestionDetailOK = new List<XMQuestionDetail>();

            //最后提交时间不为空
            if (lastStartDate.HasValue == true && lastEndDate.HasValue == true)
            {
                //最后提交时间（开始时间）
                //string lastStartDateS = lastStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                //最后提交时间（结束时间）
                string lastEndDateS = lastEndDate.Value.AddDays(1).AddMilliseconds(-30).ToString("yyyy-MM-dd HH:mm:ss");
                //最后提交时间 （结束时间  字符串转DateTime类型）
                DateTime? lastEndDateD = Convert.ToDateTime(lastEndDateS);

                //问题类型 
                string questionTypeNotIDs = "-1";
                if (questionTypeIDs.Count > 0)
                {

                    questionTypeNotIDs = string.Join(",", questionTypeIDs);
                }

                #region 完成
                if (TheResults == 1)
                {
                    //根据问题提交时间查找3天内处理完成的问题集合
                    xMQuestionDetailOK = IoC.Resolve<IXMQuestionDetailService>().GetQuestionDetailsByComplete(lastStartDate.Value.ToString(),
                        lastEndDate.Value.ToString(), afterFullName, questionTypeNotIDs);

                    //取QuestionID
                    List<int> QuestionIDs = xMQuestionDetailOK.Select(q => q.QuestionID).Distinct().ToList();

                    query = from p in this._context.XMQuestions
                            where QuestionIDs.Contains(p.ID)
                            select p;
                }
                #endregion

                #region 未完成
                else if (TheResults == 2)
                {
                    //完成 所以
                    List<XMQuestionDetail> xMQuestionDetailALL = IoC.Resolve<IXMQuestionDetailService>().GetQuestionDetailsBySubmit(lastStartDate.Value.ToString(),
                        lastEndDate.Value.ToString(), afterFullName, questionTypeNotIDs);
                    List<int> IDsAll = xMQuestionDetailALL.Select(q => q.ID).ToList();

                    //根据问题提交时间查找3天内处理完成的问题集合
                    xMQuestionDetailOK = IoC.Resolve<IXMQuestionDetailService>().GetQuestionDetailsByComplete(lastStartDate.Value.ToString(),
                        lastEndDate.Value.ToString(), afterFullName, questionTypeNotIDs);
                    List<int> IDsOK = xMQuestionDetailOK.Select(q => q.ID).ToList();

                    //未完成的 (在所以完成的问题集合 与 3天内处理完成的问题集合,找出未按时间完成的明细数据)
                    List<int> NotIDs = (from i in IDsAll
                                        where !IDsOK.Contains(i)
                                        select i).ToList();

                    //未完成明细 主表ID
                    List<int> QuestionIDs = IoC.Resolve<IXMQuestionDetailService>().getByIds(NotIDs).Select(q => q.QuestionID).ToList();

                    query = from p in this._context.XMQuestions
                            where QuestionIDs.Contains(p.ID)
                            select p;
                }
                #endregion

                #region 所有
                else
                {
                    if (questionTypeIDs.Count != 0)
                    {
                        query = from p in this._context.XMQuestions
                                join b in this._context.XMNicks on p.NickID equals b.nick_id into temp
                                from tt in temp.DefaultIfEmpty()
                                join c in this._context.XMQuestionDetails on p.ID equals c.QuestionID into tD
                                from dd in tD.DefaultIfEmpty()
                                where p.OrderNO.Contains(orderNO)
                                && p.Buyer.Contains(Buyer)
                                && (xMProjectId == -1 || tt.ProjectId == xMProjectId)
                                && (nick_id == -1 || nicklist.Contains(p.NickID))
                                && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                                && (!startTime.HasValue || dd.CreateTime >= startTime)
                                && (!endTime.HasValue || dd.CreateTime <= endTime)
                                && (platformID == -1 || p.PlatformID == platformID)
                                && (statusID == -1 || p.Status == statusID)
                                && (questionTypeIDs.Contains(dd.QuestionTypeID.Value))
                                && (!lastStartDate.HasValue || dd.CreateTime >= lastStartDate)
                                && (!lastEndDate.HasValue || dd.CreateTime <= lastEndDateD)
                                && p.IsEnable == false
                                orderby p.CreateTime descending
                                select p;
                    }
                    else
                    {
                        query = from p in this._context.XMQuestions
                                join b in this._context.XMNicks on p.NickID equals b.nick_id into temp
                                from tt in temp.DefaultIfEmpty()
                                join c in this._context.XMQuestionDetails on p.ID equals c.QuestionID into tD
                                from dd in tD.DefaultIfEmpty()
                                where p.OrderNO.Contains(orderNO)
                                && p.Buyer.Contains(Buyer)
                                && (xMProjectId == -1 || tt.ProjectId == xMProjectId)
                                && (nick_id == -1 || nicklist.Contains(p.NickID))
                                && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                                && (!startTime.HasValue || dd.CreateTime >= startTime)
                                && (!endTime.HasValue || dd.CreateTime <= endTime)
                                && (platformID == -1 || p.PlatformID == platformID)
                                && (statusID == -1 || p.Status == statusID)
                                && (!lastStartDate.HasValue || dd.CreateTime >= lastStartDate)
                                && (!lastEndDate.HasValue || dd.CreateTime <= lastEndDateD)
                                && p.IsEnable == false
                                orderby p.CreateTime descending
                                select p;
                    }

                    if (afterFullName != "")
                    {
                        query = from p in query
                                join c in this._context.CustomerInfoes on p.LastModifyByID equals c.CustomerID
                               into cJon
                                from cInfo in cJon.DefaultIfEmpty()
                                where cInfo.FullName.Contains(afterFullName)
                                select p;
                    }
                }
                #endregion
            }
            else
            {
                if (questionTypeIDs.Count != 0)
                {
                    query = from p in this._context.XMQuestions
                            join b in this._context.XMNicks on p.NickID equals b.nick_id into temp
                            from tt in temp.DefaultIfEmpty()
                            join c in this._context.XMQuestionDetails on p.ID equals c.QuestionID into tD
                            from dd in tD.DefaultIfEmpty()
                            where p.OrderNO.Contains(orderNO)
                                && p.Buyer.Contains(Buyer)
                            && (xMProjectId == -1 || tt.ProjectId == xMProjectId)
                            && (nick_id == -1 || nicklist.Contains(p.NickID))
                            && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                            && (!startTime.HasValue || dd.CreateTime >= startTime)
                            && (!endTime.HasValue || dd.CreateTime <= endTime)
                            && (platformID == -1 || p.PlatformID == platformID)
                            && (statusID == -1 || p.Status == statusID)
                            && (questionTypeIDs.Contains(dd.QuestionTypeID.Value))
                            && (!lastStartDate.HasValue || dd.CreateTime >= lastStartDate)
                            && (!lastEndDate.HasValue || dd.CreateTime <= lastEndDate)
                            && p.IsEnable == false
                            orderby p.CreateTime descending
                            select p;
                }
                else
                {
                    query = from p in this._context.XMQuestions
                            join b in this._context.XMNicks on p.NickID equals b.nick_id into temp
                            from tt in temp.DefaultIfEmpty()
                            join c in this._context.XMQuestionDetails on p.ID equals c.QuestionID into tD
                            from dd in tD.DefaultIfEmpty()
                            where p.OrderNO.Contains(orderNO)
                                && p.Buyer.Contains(Buyer)
                            && (xMProjectId == -1 || tt.ProjectId == xMProjectId)
                            && (nick_id == -1 || nicklist.Contains(p.NickID))
                            && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                            && (!startTime.HasValue || dd.CreateTime >= startTime)
                            && (!endTime.HasValue || dd.CreateTime <= endTime)
                            && (platformID == -1 || p.PlatformID == platformID)
                            && (statusID == -1 || p.Status == statusID)
                            && (!lastStartDate.HasValue || dd.CreateTime >= lastStartDate)
                            && (!lastEndDate.HasValue || dd.CreateTime <= lastEndDate)
                            && p.IsEnable == false
                            orderby p.CreateTime descending
                            select p;
                }

                if (afterFullName != "")
                {
                    query = from p in query
                            join c in this._context.CustomerInfoes on p.LastModifyByID equals c.CustomerID
                            into cJon
                            from cInfo in cJon.DefaultIfEmpty()
                            where cInfo.FullName.Contains(afterFullName)
                            orderby p.CreateTime descending
                            select p;
                }
            }
            return new PagedList<XMQuestion>(query.Distinct().OrderByDescending(p => p.CreateTime.Value).ToList(), pageIndex, pageSize, sortExpression, sortDirection);
        }


        #endregion

        /// <summary>
        /// 根绝条件获取订单问题反馈列表（List）
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="nickID">店铺ID</param>
        /// <param name="startTime">订单创建开始日期</param>
        /// <param name="endTime">订单创建结束日期</param>
        /// <param name="platformID">平台ID</param>
        /// <param name="statusID">状态ID</param>
        /// <param name="afterFullName">售后</param>
        /// <param name="questionTypeIDs">问题类型ID</param> 
        /// <returns></returns> 
        public List<QuestionDetailed_Result> XMQuestionSearchList(string orderNO, int xMProjectId, string nickID, DateTime? startTime, DateTime? endTime
            , int platformID, int statusID, string FullName, string RefundLogisticsNo, string afterFullName, List<int> questionTypeIDs, string PrdouctName
           , DateTime? lastStartDate, DateTime? lastEndDate, int TheResults, string Buyer, int QuestionLevel)
        {
            if (questionTypeIDs == null)
            {
                questionTypeIDs = new List<int>();
            }
            int?[] nicklist = Array.ConvertAll<string, int?>(nickID.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            //初始化 （所以）
            //IQueryable<QuestionDetailed_Result> query = null;
            //完成 
            List<XMQuestionDetail> xMQuestionDetailOK = new List<XMQuestionDetail>();

            var query = from p in _context.XMQuestions
                        join c in this._context.XMQuestionDetails on p.ID equals c.QuestionID into tD
                        from dd in tD.DefaultIfEmpty()
                        join b in this._context.XMNicks on p.NickID equals b.nick_id into temp
                        from tt in temp.DefaultIfEmpty()
                        join e in _context.XMOrderInfoes on p.OrderNO equals e.OrderCode
                        select new QuestionDetailed_Result
                        {
                            ID = p.ID,
                            OrderNO = p.OrderNO,
                            PlatformID = p.PlatformID,
                            NickID = p.NickID,
                            Buyer = p.Buyer,
                            OredrInfoID = e.ID,
                            FullName = e.FullName,
                            Mobile = e.Mobile,
                            Tel = e.Tel,
                            DeliveryAddress = e.DeliveryAddress,
                            OrderPrice = e.OrderPrice,
                            OdIsEnable = e.IsEnable,
                            Status = p.Status,
                            QIsEnable = p.IsEnable,
                            CreateTime = dd.CreateTime,
                            QuestionID = dd.QuestionID,
                            SrvBeforeCustomerID = dd.SrvBeforeCustomerID,
                            SrvAfterCustomerID = dd.SrvAfterCustomerID,
                            ResultMsg = dd.ResultMsg,
                            LastModifyByID = dd.LastModifyByID,
                            LastModifyTime = dd.LastModifyTime,
                            QuestionTypeID = dd.QuestionTypeID,
                            OrdersTime = dd.OrdersTime,
                            IsReturns = dd.IsReturns,
                            Description = dd.Description,
                            ResultsId = dd.ResultsId,
                            QDIsEnable = dd.IsEnable,
                            ProjectId = tt.ProjectId,
                            QuestionLevel = p.QuestionLevel
                        };

            //最后提交时间不为空
            if (lastStartDate.HasValue == true && lastEndDate.HasValue == true)
            {
                //最后提交时间（开始时间）
                //string lastStartDateS = lastStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                //最后提交时间（结束时间）
                string lastEndDateS = lastEndDate.Value.AddDays(1).AddMilliseconds(-30).ToString("yyyy-MM-dd HH:mm:ss");
                //最后提交时间 （结束时间  字符串转DateTime类型）
                DateTime? lastEndDateD = Convert.ToDateTime(lastEndDateS);

                //问题类型 
                string questionTypeNotIDs = "-1";
                if (questionTypeIDs.Count > 0)
                {

                    questionTypeNotIDs = string.Join(",", questionTypeIDs);
                }
                #region 完成
                if (TheResults == 1)
                {
                    //根据问题提交时间查找3天内处理完成的问题集合
                    xMQuestionDetailOK = IoC.Resolve<IXMQuestionDetailService>().GetQuestionDetailsByComplete(lastStartDate.Value.ToString(),
                        lastEndDate.Value.ToString(), afterFullName, questionTypeNotIDs);

                    //取QuestionID
                    List<int> QuestionIDs = new List<int>();  //xMQuestionDetailOK.Select(q => q.QuestionID).Distinct().ToList();

                    foreach (XMQuestionDetail info in xMQuestionDetailOK)
                    {
                        if (!QuestionIDs.Contains(info.QuestionID))
                        {
                            QuestionIDs.Add(info.QuestionID);
                        }
                    }

                    query = from p in query
                            where QuestionIDs.Contains(p.ID)
                            select p;

                }
                #endregion

                #region 未完成
                else if (TheResults == 2)
                {
                    //完成 所以
                    List<XMQuestionDetail> xMQuestionDetailALL = IoC.Resolve<IXMQuestionDetailService>().GetQuestionDetailsBySubmit(lastStartDate.Value.ToString(),
                        lastEndDate.Value.ToString(), afterFullName, questionTypeNotIDs);
                    List<int> IDsAll = new List<int>();         // xMQuestionDetailALL.Select(q => q.ID).ToList();
                    foreach (XMQuestionDetail Info in xMQuestionDetailALL)
                    {
                        IDsAll.Add(Info.ID);
                    }
                    //根据问题提交时间查找3天内处理完成的问题集合
                    xMQuestionDetailOK = IoC.Resolve<IXMQuestionDetailService>().GetQuestionDetailsByComplete(lastStartDate.Value.ToString(),
                        lastEndDate.Value.ToString(), afterFullName, questionTypeNotIDs);
                    List<int> IDsOK = new List<int>();           // xMQuestionDetailOK.Select(q => q.ID).ToList();
                    foreach (XMQuestionDetail q in xMQuestionDetailOK)
                    {
                        IDsOK.Add(q.ID);
                    }
                    //未完成的 (在所以完成的问题集合 与 3天内处理完成的问题集合,找出未按时间完成的明细数据)
                    List<int> NotIDs = (from i in IDsAll
                                        where !IDsOK.Contains(i)
                                        select i).ToList();

                    //未完成明细 主表ID
                    var details = IoC.Resolve<IXMQuestionDetailService>().getByIds(NotIDs);
                    List<int> QuestionIDs = new List<int>();         // IoC.Resolve<IXMQuestionDetailService>().getByIds(NotIDs).Select(q => q.QuestionID).ToList();
                    foreach (XMQuestionDetail q in details)
                    {
                        QuestionIDs.Add(q.QuestionID);
                    }
                    query = from p in query
                            where QuestionIDs.Contains(p.ID)
                            select p;
                }
                #endregion

                #region 所有
                else
                {
                    query = from p in query
                            where p.OrderNO.Contains(orderNO)
                            && p.Buyer.Contains(Buyer)
                            && (xMProjectId == -1 || p.ProjectId == xMProjectId)
                            && (nick_id == -1 || nicklist.Contains(p.NickID))
                            && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                            && (!startTime.HasValue || p.CreateTime >= startTime)
                            && (!endTime.HasValue || p.CreateTime <= endTime)
                            && (platformID == -1 || p.PlatformID == platformID)
                            && (statusID == -1 || p.Status == statusID)
                            && (questionTypeIDs.Count == 0 || questionTypeIDs.Contains(p.QuestionTypeID.Value))
                            && (!lastStartDate.HasValue || p.CreateTime >= lastStartDate)
                            && (!lastEndDate.HasValue || p.CreateTime <= lastEndDateD)
                            && p.QIsEnable == false
                            && p.QDIsEnable == false
                            && p.OdIsEnable == false
                            select new QuestionDetailed_Result
                            {
                                ID = p.ID,
                                OrderNO = p.OrderNO,
                                PlatformID = p.PlatformID,
                                NickID = p.NickID,
                                Buyer = p.Buyer,
                                OredrInfoID = p.OredrInfoID,
                                FullName = p.FullName,
                                Mobile = p.Mobile,
                                Tel = p.Tel,
                                DeliveryAddress = p.DeliveryAddress,
                                OrderPrice = p.OrderPrice,
                                OdIsEnable = p.OdIsEnable,
                                Status = p.Status,
                                QIsEnable = p.QIsEnable,
                                CreateTime = p.CreateTime,
                                QuestionID = p.QuestionID,
                                SrvBeforeCustomerID = p.SrvBeforeCustomerID,
                                SrvAfterCustomerID = p.SrvAfterCustomerID,
                                ResultMsg = p.ResultMsg,
                                LastModifyByID = p.LastModifyByID,
                                LastModifyTime = p.LastModifyTime,
                                QuestionTypeID = p.QuestionTypeID,
                                OrdersTime = p.OrdersTime,
                                IsReturns = p.IsReturns,
                                Description = p.Description,
                                ResultsId = p.ResultsId,
                                QDIsEnable = p.QDIsEnable,
                                ProjectId = p.ProjectId,
                                QuestionLevel = p.QuestionLevel
                            };

                    if (afterFullName != "")
                    {
                        query = from p in query
                                join c in this._context.CustomerInfoes on p.LastModifyByID equals c.CustomerID
                               into cJon
                                from cInfo in cJon.DefaultIfEmpty()
                                where cInfo.FullName.Contains(afterFullName)
                                select p;
                    }

                }
                #endregion
            }
            else
            {
                query = from p in query
                        where p.OrderNO.Contains(orderNO)
                            && p.Buyer.Contains(Buyer)
                        && (xMProjectId == -1 || p.ProjectId == xMProjectId)
                        && (nick_id == -1 || nicklist.Contains(p.NickID))
                        && (QuestionLevel == -1 || p.QuestionLevel == QuestionLevel)
                        && (!startTime.HasValue || p.CreateTime >= startTime)
                        && (!endTime.HasValue || p.CreateTime <= endTime)
                        && (platformID == -1 || p.PlatformID == platformID)
                        && (statusID == -1 || p.Status == statusID)
                        && (questionTypeIDs.Count == 0 || questionTypeIDs.Contains(p.QuestionTypeID.Value))
                        && (!lastStartDate.HasValue || p.CreateTime >= lastStartDate)
                        && (!lastEndDate.HasValue || p.CreateTime <= lastEndDate)
                        && p.QIsEnable == false
                        && p.QDIsEnable == false
                        && p.OdIsEnable == false
                        select new QuestionDetailed_Result
                        {
                            ID = p.ID,
                            OrderNO = p.OrderNO,
                            PlatformID = p.PlatformID,
                            NickID = p.NickID,
                            Buyer = p.Buyer,
                            OredrInfoID = p.OredrInfoID,
                            FullName = p.FullName,
                            Mobile = p.Mobile,
                            Tel = p.Tel,
                            DeliveryAddress = p.DeliveryAddress,
                            OrderPrice = p.OrderPrice,
                            OdIsEnable = p.OdIsEnable,
                            Status = p.Status,
                            QIsEnable = p.QIsEnable,
                            CreateTime = p.CreateTime,
                            QuestionID = p.QuestionID,
                            SrvBeforeCustomerID = p.SrvBeforeCustomerID,
                            SrvAfterCustomerID = p.SrvAfterCustomerID,
                            ResultMsg = p.ResultMsg,
                            LastModifyByID = p.LastModifyByID,
                            LastModifyTime = p.LastModifyTime,
                            QuestionTypeID = p.QuestionTypeID,
                            OrdersTime = p.OrdersTime,
                            IsReturns = p.IsReturns,
                            Description = p.Description,
                            ResultsId = p.ResultsId,
                            QDIsEnable = p.QDIsEnable,
                            ProjectId = p.ProjectId,
                            QuestionLevel = p.QuestionLevel
                        };
                if (afterFullName != "")
                {
                    query = from p in query
                            join c in this._context.CustomerInfoes on p.LastModifyByID equals c.CustomerID
                           into cJon
                            from cInfo in cJon.DefaultIfEmpty()
                            where cInfo.FullName.Contains(afterFullName)
                            select p;
                }
            }
            return query.OrderByDescending(p => p.CreateTime.Value).ToList();
        }

    }
}
