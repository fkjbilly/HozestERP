using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.Modules
{
    public partial class UploadFileSeeControl : BaseAdministrationUserControl
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
                    return string.Empty;
                }
            }
            set
            {
                ViewState["UploadFileTableName"] = value.ToString();
            }
        }
    }
}