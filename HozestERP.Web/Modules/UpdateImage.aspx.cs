using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Web.Controls;

using HozestERP.BusinessLogic.Media;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.Modules
{
    public partial class UpdateImage : BaseAdministrationPage, IEditPage
    {

        public Picture SelectPicture
        {
            get
            {
                try
                {
                    return (Session["SelectPicture"] as Picture);
                }
                catch
                {
                }
                return new Picture();
            }
            set
            {
                Session["SelectPicture"] = value;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ShowPicture();
            }
        }

        private void ShowPicture()
        {
            string pictureUrl = string.Empty;
            int pictureSize = this.SettingManager.GetSettingValueInteger("Media.ProductPicture.PictureSize", 200);

            //新增,选择过图片了.则显示当前选择的图片
            if (this.SelectPicture != null)
            {
                pictureUrl = this.PictureService.GetPictureUrl(this.SelectPicture.PictureID, pictureSize, false);
            }
            else
            {
                pictureUrl = this.PictureService.GetDefaultPictureUrl(PictureTypeEnum.Avatar, pictureSize);
            }
            this.imgShow.ImageUrl = pictureUrl;

        }

        private void UploadImage()
        {
            var pictureFile = fileUpload.PostedFile;
            if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
            {
                //大小
                int maxProductPicture = this.SettingManager.GetSettingValueInteger("Media.Customer.AvatarMaxSizeBytes", 20000);
                if (pictureFile.ContentLength > maxProductPicture)
                    throw new CRMException(string.Format("Maximum product size is {0} bytes", maxProductPicture));

                //格式
                string type = pictureFile.ContentType;
                if (type == "image/gif" || type == "image/jpg" || type == "image/png" || type == "image/jpeg" || type == "image/x-png" || type == "image/bmp" || type == "image/pjpeg")
                {
                    byte[] pictureBinary = pictureFile.GetPictureBits();
                    Picture upPicture = this.PictureService.InsertPicture(pictureBinary, pictureFile.ContentType, true);
                    if (upPicture != null)
                    {
                        //显示图片
                        int pictureSize = this.SettingManager.GetSettingValueInteger("Media.Customer.AvatarSize", 200);
                        this.imgShow.ImageUrl = this.PictureService.GetPictureUrl(upPicture.PictureID, pictureSize, false);
                        this.SelectPicture = upPicture;
                    }
                }
                else
                {
                    throw new CRMException(string.Format("格式不正确."));
                }
            }


        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            this.SelectPicture = null;
            this.ShowPicture();
        }

        protected void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                UploadImage();
            }
            catch(Exception err)
            {
                base.ProcessException(err);
            }
        }

        #region public void JsWrite(string paramAction)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsWrite(string paramAction)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "JS", paramAction, true);
        }
        #endregion

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("图片上传");
        }

        public void SetTrigger()
        {
        }

        #endregion
    }
}