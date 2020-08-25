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
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Codes
{
    public partial class CodeList: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CodeID
        /// </summary>
        public int CodeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeTypeID
        /// </summary>
        public int CodeTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeNO
        /// </summary>
        public string CodeNO { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeName
        /// </summary>
        public string CodeName { get; set; }
    
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
        /// Gets or sets the SCodeType
        /// </summary>
        public virtual CodeType SCodeType { get; set; }

     
        #endregion

    }
}
