using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Codes
{
    public partial interface ICodeTypeService
    {
        #region
        /// <summary>
        /// 返回公用代码信息
        /// </summary>
        List<CodeType> GetCodeTypeAll();

        /// <summary>
        /// 返回公用代码信息
        /// </summary>
        List<CodeType> GetCodeTypeByModuleID(int moduleID);


        /// <summary>
        /// 返回公用代码信息
        /// </summary>
        CodeType GetCodeTypeByCodeTypeName(string CodeTypeName);

        /// <summary>
        /// 查询公用代码信息
        /// </summary>
        List<CodeType> GetCodeType(int CodeTypeID);
        /// <summary>
        /// 根据CodeTypeID获取公用代码信息
        /// </summary>
        /// <param name="CodeTypeID">CodeTypeID</param>
        CodeType GetCodeTypeByCodeTypeID(int CodeTypeID);
        /// <summary>
        /// 增加公用代码信息
        /// </summary>
        /// <param name="codeType">CodeType</param>
        void InsertCodeType(CodeType  codeType);
        /// <summary>
        ///修改公用代码信息
        /// </summary>
        /// <param name="codeType">CodeType</param>
        void UpdateCodeType(CodeType codeType);
        /// <summary>
        /// 删除公用代码信息
        /// </summary>
        /// <param name="CodeTypeID">CodeTypeID</param>
        void DeleteCodeType(int CodeTypeID);


        List<CodeType> GetCodeTypeByPlatFormTypeId(string platformtypeid);
        #endregion
    }
}
