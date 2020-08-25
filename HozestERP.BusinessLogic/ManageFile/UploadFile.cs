/******************************************************************
** Copyright (c) 2008 -2012 ���ڻ���
** ������:������
** ��������:2012-03-21
** �޸���: ������
** �޸�����: 2012-03-21
** �� ��: ������ 2012-03-21 ���� ������
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

namespace HozestERP.BusinessLogic.ManageFile
{
    public partial class UploadFile: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the UploadFileID
        /// </summary>
        public int UploadFileID { get; set; }
    
    	/// <summary>
        /// Gets or sets the TaggantID
        /// </summary>
        public System.Guid TaggantID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ObjectID
        /// </summary>
        public int ObjectID { get; set; }

        /// <summary>
        /// Gets or sets the TableName
        /// </summary>
        public string TableName { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Url
        /// </summary>
        public string Url { get; set; }
    
    	/// <summary>
        /// Gets or sets the Created
        /// </summary>
        public System.DateTime Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public int CreatorID { get; set; }

        #endregion
    }
}
