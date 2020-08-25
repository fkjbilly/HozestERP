using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial interface IXMQuestionDetailService
    {
        /// <summary>
        /// Get a record by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>record</returns>
        XMQuestionDetail GetById(int id);

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        List<XMQuestionDetail> getByIds(List<int> IDs);

        /// <summary>
        ///  Gets all records
        /// </summary>
        /// <returns>records</returns>
        IList<XMQuestionDetail> GetAll();

        /// <summary>
        /// Insert a new record
        /// </summary>
        /// <param name="XMQuestionDetail">pXMQuestionDetail</param>
        /// <returns>record</returns>
        void Insert(XMQuestionDetail pXMQuestionDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="XMQuestionDetail">pXMQuestionDetail</param>
        /// <returns>record</returns>
        void Update(XMQuestionDetail pXMQuestionDetail);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 获取问题明细
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        List<XMQuestionDetail> GetQuestionDetails(int questionID);

        /// <summary>
        /// 查询问题类型子节点数据列表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="cId"></param>
        /// <returns></returns>
        List<XMQuestionDetail> GetQuestionDetailsByParm(int xMProjectId, string xMNickId, DateTime? BeginDate, DateTime? EndDate, int cId);

        /// <summary>
        /// 根据父节点下子节点类型集合查询数据
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="QuestionType"></param>
        /// <returns></returns>
        List<XMQuestionDetail> GetQuestionDetailByCategoryIDs(int xMProjectId, string xMNickId, DateTime? BeginDate, DateTime? EndDate, List<int?> QuestionType);
        /// <summary>
        /// 根据问题提交时间获取问题集合
        /// </summary>
        /// <param name="beginDate">完成率开始时间</param>
        /// <param name="endDate">完成率结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <param name="strQuestiongType">问题类型</param>
        /// <returns></returns>
        List<XMQuestionDetail> GetQuestionDetailsBySubmit(string beginDate, string endDate, string afterFullName, string strQuestiongType);

        /// <summary>
        /// 根据问题提交时间查找3天内处理完成的问题集合
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <param name="strQuestiongType">问题类型</param>
        /// <returns></returns>
        List<XMQuestionDetail> GetQuestionDetailsByComplete(string beginDate, string endDate, string afterFullName, string strQuestiongType);

        /// <summary>
        /// 根据问题提交时间获取是退货集合
        /// </summary>
        /// <param name="beginDate">完成率开始时间</param>
        /// <param name="endDate">完成率结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <returns></returns>
        List<XMQuestionDetail> GetQuestionDetailsByIsReturnsTrue(string beginDate, string endDate, string afterFullName);

        /// <summary>
        /// 根据问题提交时间查找处理结果是退货（实际退货）
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="afterFullName">售后</param>
        /// <returns></returns>
        List<XMQuestionDetail> GetQuestionDetailsByResultsCount(string beginDate, string endDate, string afterFullName);

        /// <summary>
        /// 移交客服
        /// </summary>
        /// <param name="QuestionIDs"></param>
        /// <param name="LastModifyByID"></param>
        /// <returns></returns>
        int UpdateGetQuestionDetailsByQuestionID(int QuestionID, int LastModifyByID);//, string LastModifyTime);

        /// <summary>
        /// Batch delete BatchDeleteXMQuestionDetails by QuestionID
        /// </summary>
        /// <param name="QuestionID">BatchDeleteXMQuestionDetails QuestionID</param>
        void BatchDeleteXMQuestionDetails(int questionID);
    }
}
