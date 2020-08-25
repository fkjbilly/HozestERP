using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.Codes
{
    public partial interface ICodeService
    {
        #region
        /// <summary>
        /// 返回公用代码信息
        /// </summary>
        List<CodeList> GetCodeListAll();
        /// <summary>
        /// 查询公用代码信息
        /// </summary>
        List<CodeList> GetCodeList(int codeID);
        /// <summary>
        /// 根据CodeTypeID获取公用代码信息
        /// </summary>
        /// <param name="CodeID">codeID</param>
        List<CodeList> GetCodeListInfoByCodeTypeID(int codeTypeID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeIDs"></param>
        /// <returns></returns>
        List<CodeList> GetCodeListInfoByCodeIDs(string codeIDs);


        /// <summary>
        /// 根据CodeTypeID、CodeName查询公用代码信息
        /// </summary>
        /// <param name="CodeID">codeID</param>
        List<CodeList> GetCodeListInfoByCodeTypeIDAndCodeName(int codeTypeID, string CodeName);
        /// <summary>
        /// 根据CodeTypeID获取公用代码信息
        /// </summary>
        /// <param name="codeTypeID">codeTypeID</param>
        /// <param name="isDeleted">isDeleted</param>
        /// <returns>List</returns>
        List<CodeList> GetCodeListInfoByCodeTypeID(int codeTypeID, bool isDeleted);

        List<CodeList> GetCodeListInfoByCodeTypeIDWithoutCache(int codeTypeID,bool isDeleted);
        /// <summary>
        /// 根据CodeID获取公用代码信息
        /// </summary>
        /// <param name="CodeID">codeID</param>
        CodeList GetCodeListInfoByCodeID(int codeID);
        /// <summary>
        /// 根据codeTypeID获取公用代码信息
        /// </summary>
        /// <param name="CodeTypeID">codeTypeID</param>
        CodeList GetCodeListByCodeTypeID(int codeTypeID);

        /// <summary>
        /// 增加公用代码信息
        /// </summary>
        /// <param name="CodeList">CodeList</param>
        void InsertCodeList(CodeList codeList);
        /// <summary>
        ///修改公用代码信息
        /// </summary>
        /// <param name="CodeList">CodeList</param>
        void UpdateCodeList(CodeList codeList);
        /// <summary>
        /// 删除公用代码信息
        /// </summary>
        /// <param name="CodeID">codeID</param>
        void DeleteCodeList(int codeID);

        /// <summary>
        /// 根据CodeName获取公用代码信息
        /// </summary>
        /// <param name="CodeName"></param>
        /// <returns></returns>
        //CodeList GetCodeName(string CodeName);


        /// <summary>
        /// 根据代码类型ID和代码编号获取代码列表
        /// </summary>
        /// <param name="codeTypeID"></param>
        /// <param name="CodeNo"></param>
        /// <returns></returns>
        List<CodeList> GetCodeListByCodeTypeIDCodeNo(int codeTypeID, string CodeNo);

        #endregion
    }
}
