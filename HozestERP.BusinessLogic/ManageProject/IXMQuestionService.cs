using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMQuestionService
    {
        /// <summary>
        /// Get a record by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>record</returns>
        XMQuestion GetById(int id);

        /// <summary>
        ///  Gets all records
        /// </summary>
        /// <returns>records</returns>
        IList<XMQuestion> GetAll();

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="XMQuestion">pXMQuestion</param>
        /// <returns>record</returns>
        void Insert(XMQuestion pXMQuestion);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="XMQuestion">pXMQuestion</param>
        /// <returns>record</returns>
        void Update(XMQuestion pXMQuestion);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 根据推广组获取策略列表
        /// </summary>
        /// <returns></returns>
        List<XMQuestion> GetQuestions();

        /// <summary>
        /// 根据推广组获取策略列表
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="nick"></param>
        /// <param name="platform"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        List<XMQuestion> GetQuestionsBySearch(string orderNO = "", string nick = "", string platform = "", string status = "",
             string afterFullName = "", string beginDate = "", string endDate = "");

        List<XMDataAnalysy> GetDataAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> a, List<int?> QuestionType, int QuestionLevel);

        /// <summary>
        /// 查询父节点下总的记录数
        /// </summary>
        /// <param name="Questionlist"></param>
        /// <param name="pCategoryID"></param>
        /// <returns></returns>
        int GetQuestionCategoryCount(List<XMDataAnalysy> Questionlist, int pCategoryID);

        /// <summary>
        /// 根据问题类型进行统计
        /// </summary>
        /// <param name="PlatformId"></param>
        /// <param name="NickId"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="CustomerId"></param>
        /// <param name="a"></param>
        /// <param name="QuestionType"></param>
        /// <param name="QuestionLevel"></param>
        /// <returns></returns>
        List<XMDataAnalysy> GetQuestionAnalysisList(int PlatformId, int NickId, DateTime? BeginDate, DateTime? EndDate, int CustomerId, List<int?> a, List<int?> QuestionType, int QuestionLevel);
        int GetNickCount(List<XMDataAnalysy> Questionlist, int PlatformTypeId, int NickId);
        int GetCompleteCount(List<XMDataAnalysy> Questionlist, int CreatorID, string Type);
        List<XMQuestion> GetQuestionsListByIDs(List<int> IDs);

        /// <summary>
        /// 根据订单号查询
        /// </summary>
        /// <param name="orderNO">订单号</param> 
        /// <returns></returns>
        List<XMQuestion> GetQuestionsByOrderNo(string orderNO);

        /// <summary>
        /// 根绝条件获取订单问题反馈列表
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="nickID">店铺ID</param>
        /// <param name="startTime">订单创建开始日期</param>
        /// <param name="endTime">订单创建结束日期</param>
        /// <param name="platformID">平台ID</param>
        /// <param name="statusID">状态ID</param>
        /// <param name="afterFullName">售后</param>
        /// <param name="questionTypeIDs">问题类型ID</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="Buyer">买家</param>
        /// <returns></returns>
        PagedList<XMQuestion> XMQuestionSearch(string orderNO, int xMProjectId, string nickID, DateTime? startTime, DateTime? endTime
            , int platformID, int statusID, string FullName, string RefundLogisticsNo, string afterFullName, List<int> questionTypeIDs, string PrdouctName
           , int pageIndex, int pageSize, string sortExpression, string sortDirection, DateTime? lastStartDate, DateTime? lastEndDate, int TheResults, string Buyer, int QuestionLevel);


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
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        List<QuestionDetailed_Result> XMQuestionSearchList(string orderNO, int xMProjectId, string nickID, DateTime? startTime, DateTime? endTime
            , int platformID, int statusID, string FullName, string RefundLogisticsNo, string afterFullName, List<int> questionTypeIDs, string PrdouctName
           , DateTime? lastStartDate, DateTime? lastEndDate, int TheResults, string Buyer, int QuestionLevel);
    }
}
