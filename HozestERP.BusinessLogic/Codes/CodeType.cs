/******************************************************************
** Copyright (c) 2008 -2012 
** ������:������
** ��������:2011-02-11
** �޸���: ������
** �޸�����: 2011-02-11
** �� ��: ������ 2011-02-11 �������ͷ��ע��
** �� ��:1.0
**----------------------------------------------------------------------------
******************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace HozestERP.BusinessLogic.Codes
{
    public partial class CodeType : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the CodeTypeID
        /// </summary>
        public int CodeTypeID { get; set; }

        /// <summary>
        /// Gets or sets the CodeTypeCode
        /// </summary>
        public string CodeTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the Module ID
        /// </summary>
        public int ModuleID { get; set; }

        /// <summary>
        /// Gets or sets the CodeTypeName
        /// </summary>
        public string CodeTypeName { get; set; }

        /// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the SCodeList list
        /// </summary>
        public virtual ICollection<CodeList> SCodeLists { get; set; }

        #endregion
    }
}
