using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageFile
{
    public partial interface IFileService
    {
        /// <summary>
        /// Backup database
        /// </summary>
        void Backup();

        /// <summary>
        /// Back up files
        /// </summary>
        void BackupFiles();

        /// <summary>
        /// Delete the backup file
        /// </summary>
        /// <param name="fileName">Backup file name</param>
        void DeleteFile(string fileName);

        /// <summary>
        /// Restore database
        /// </summary>
        /// <param name="fileName">Backup file name</param>
        void RestoreBackup(string fileName);

        #region UploadFile

        /// <summary>
        /// 获取当前操作的附件数据
        /// </summary>
        /// <param name="objectid">UploadFile identifier</param>
        /// <param name="taggantid">taggantid</param>
        /// <param name="tableName">tableName</param>
        /// <returns>UploadFile list</returns>
        List<UploadFile> GetUploadFileList(int objectid, Guid taggantid, string tableName);

        /// <summary>
        /// 上传附件数据
        /// </summary>
        /// <param name="uploadFile">UploadFile</param>
        /// <returns></returns>
        UploadFile InsertUploadFile(UploadFile uploadFile);


        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        void UpdateUploadFile(UploadFile uploadFile); 
        /// <summary>
        /// 保存文件列表
        /// </summary>
        /// <param name="objectID">UploadFile identifier</param>
        /// <param name="taggantid">taggantid</param>
        /// <param name="tableName">tableName</param>
        void SaveFileList(int objectID, Guid taggantid, string tableName);

        /// <summary>
        /// 删除附件数据
        /// </summary>
        /// <param name="uploadfileid">UploadFile ID</param>
        void DeleteUploadFile(int uploadfileid);

        /// <summary>
        /// 根据附件数据ID获取附件数据
        /// </summary>
        /// <param name="uploadfileid">UploadFile ID</param>
        /// <returns></returns>
        UploadFile GetUploadFileByUploadFileID(int uploadfileid);

        /// <summary>
        /// 获取附件列表
        /// </summary>
        /// <param name="objectid"></param>
        /// <returns></returns>
        List<UploadFile> GetUploadFileList(int objectid);


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        List<UploadFile> GetUploaFileList();
        #endregion

        string LocalFTPFolderPath { get; }
    }
}
