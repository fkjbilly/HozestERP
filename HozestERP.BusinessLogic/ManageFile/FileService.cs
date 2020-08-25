using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using System.IO;
using System.Web;

using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Installation;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageFile
{
    /// <summary>
    /// FileService
    /// </summary>
    public partial class FileService : IFileService
    {

        #region Fields

        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;

        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public FileService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPStaticCache();
        }

        #endregion

        /// <summary>
        /// Backup database
        /// </summary>
        public void Backup()
        {
            string path = IoC.Resolve<ISettingManager>().GetSettingValue("Maintenance.BackupPath").Trim();
            if (String.IsNullOrEmpty(path))
                path = string.Format("{0}{1}", HttpContext.Current.Request.PhysicalApplicationPath, "Upload\\backups\\");

            string fileName = string.Format(
                "{0}database_{1}_{2}.bak",
                path,
                DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"),
                CommonHelper.GenerateRandomDigitCode(4));

            InstallerHelper.Backup(fileName);
        }

        /// <summary>
        /// Back up files
        /// </summary>
        public void BackupFiles()
        {
            string fileName = string.Format("{0}Upload\\backups\\files_{1}_{2}.zip", HttpContext.Current.Request.PhysicalApplicationPath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
            using (ZipFile zipFile = new ZipFile())
            {
                zipFile.AddDirectory(this.LocalFTPFolderPath);
                zipFile.Save(fileName);
            }
        }

        /// <summary>
        /// Delete the backup file
        /// </summary>
        /// <param name="fileName">Backup file name</param>
        public void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        /// <summary>
        /// Restore database
        /// </summary>
        /// <param name="fileName">Backup file name</param>
        public void RestoreBackup(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return;

            if (File.Exists(fileName))
            {
                switch (Path.GetExtension(fileName).ToLowerInvariant())
                {
                    case ".zip":
                        if (Path.GetFileName(fileName).StartsWith("images"))
                        {
                            using (ZipFile zipFile = new ZipFile(fileName))
                            {
                                zipFile.ExtractAll(this.LocalFTPFolderPath, ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                        break;
                    case ".bak":
                        InstallerHelper.RestoreBackup(fileName);
                        break;
                }
            }
            else
            {
                throw new CRMException("File doesn't exist");
            }
        }


        #region UploadFile

        /// <summary>
        /// 获取当前操作的附件数据
        /// </summary>
        /// <param name="objectid">UploadFile identifier</param>
        /// <param name="taggantid">taggantid</param>
        /// <param name="tableName">tableName</param>
        /// <returns>UploadFile list</returns>
        public List<UploadFile> GetUploadFileList(int objectid, Guid taggantid, string tableName)
        {
            return this._context.GetUploadFileList(objectid, taggantid, tableName).ToList();
        }

        /// <summary>
        /// 上传附件数据
        /// </summary>
        /// <param name="uploadFile">UploadFile</param>
        /// <returns></returns>
        public UploadFile InsertUploadFile(UploadFile uploadFile)
        {
            if (uploadFile == null)
                throw new ArgumentNullException("uploadFile");

            _context.UploadFiles.AddObject(uploadFile);
            _context.SaveChanges();

            return uploadFile;
        }

        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        public void UpdateUploadFile(UploadFile uploadFile)
        {
            if (uploadFile == null)
                return;

            if (this._context.IsAttached(uploadFile))
                this._context.UploadFiles.Attach(uploadFile);

            this._context.SaveChanges();
        }




        /// <summary>
        /// 保存文件列表
        /// </summary>
        /// <param name="objectID">UploadFile identifier</param>
        /// <param name="taggantid">taggantid</param>
        /// <param name="tableName">tableName</param>
        public void SaveFileList(int objectID, Guid taggantid, string tableName)
        {
            this._context.UploadFileList(objectID, taggantid, tableName);
        }

        /// <summary>
        /// 删除附件数据
        /// </summary>
        /// <param name="uploadfileid">UploadFile ID</param>
        public void DeleteUploadFile(int uploadfileid)
        {
            if (uploadfileid == 0)
                return;
            var uploadfile = GetUploadFileByUploadFileID(uploadfileid);
            if (uploadfile == null)
                return;
            if (File.Exists(HttpContext.Current.Server.MapPath("~") + "Upload\\" + uploadfile.Url))
                File.Delete(HttpContext.Current.Server.MapPath("~") + "Upload\\" + uploadfile.Url);
            if (!_context.IsAttached(uploadfile))
                _context.UploadFiles.Attach(uploadfile);

            _context.DeleteObject(uploadfile);
            _context.SaveChanges();
        }

        /// <summary>
        /// 根据附件数据ID获取附件数据
        /// </summary>
        /// <param name="uploadfileid">UploadFile ID</param>
        /// <returns></returns>
        public UploadFile GetUploadFileByUploadFileID(int uploadfileid)
        {
            if (uploadfileid == 0)
                return null;

            var query = from p in _context.UploadFiles
                        where p.UploadFileID == uploadfileid
                        select p;
            var uploadfile = query.SingleOrDefault();

            return uploadfile;
        }

        /// <summary>
        /// 获取附件列表
        /// </summary>
        /// <param name="objectid"></param>
        /// <returns></returns>
        public List<UploadFile> GetUploadFileList(int objectid)
        {
            var query = from p in _context.UploadFiles
                        where p.ObjectID == objectid
                        select p;

            return query.ToList();
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<UploadFile> GetUploaFileList() {
             
            var query = from p in _context.UploadFiles
                        orderby p.ObjectID ascending
                        select p;

            return query.ToList();        
        }

        #endregion

        /// <summary>
        /// Gets the local image path
        /// </summary>
        public string LocalFTPFolderPath
        {
            get
            {
                string path = HttpContext.Current.Request.PhysicalApplicationPath + "Upload";
                return path;
            }
        }
    }
}
