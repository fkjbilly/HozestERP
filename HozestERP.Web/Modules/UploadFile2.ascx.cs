using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;

namespace HozestERP.Web.Modules
{
    public partial class UploadFile2 : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindRepeater();

                
            }
        }

        public void BindRepeater()
        {
            var uploadfiles = base.FileService.GetUploadFileList(this.ObjectID, this.TaggantID, this.TableName);
            this.rpFiles.DataSource = uploadfiles;
            this.rpFiles.DataBind();
        }

        protected void rpFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("DetailDelete"))
            {
              
            }
        }

        public Guid TaggantID
        {
            get
            {
                try
                {
                    return new Guid(ViewState["UploadFileTaggantID"].ToString());
                }
                catch
                {
                    return Guid.NewGuid();
                }
            }
            set
            {
                ViewState["UploadFileTaggantID"] = value.ToString();
            }
        }

        public int ObjectID
        {
            get
            {
                try
                {
                    return int.Parse(ViewState["UploadFileObjectID"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                ViewState["UploadFileObjectID"] = value.ToString();
            }
        }

        public string TableName
        {
            get
            {
                try
                {
                    return ViewState["UploadFileTableName"].ToString();
                }
                catch
                {
                    return string.Empty ;
                }
            }
            set
            {
                ViewState["UploadFileTableName"] = value.ToString();
            }
        }

        public bool ReadOnly
        {
            get
            {
                try
                {
                    return bool.Parse(ViewState["UploadFileReadOnly"].ToString());
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                ViewState["UploadFileReadOnly"] = value.ToString();
            }
        }

        public void SaveUpdateFile(int objectid)
        {
            base.FileService.SaveFileList(objectid, this.TaggantID, this.TableName);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindRepeater();
        }
    }
}