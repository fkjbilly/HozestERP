using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Media;

namespace HozestERP.Web.Modules
{
    public partial class UpdateImageControl : BaseAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lbtnUpImage.OnClientClick = "return ShowSelectSingleProductDetail('" + CommonHelper.GetStoreLocation() + "Modules/UpdateImage.aspx');";
                Picture defaultpicture = PictureService.GetPictureById(this.PictureID);
                this.SelectPicture = defaultpicture;
            }
        }

        public int PictureID
        {
            get
            {
                int pictureID = 0;
                try
                {
                    int.TryParse(Session["UpdateImageControlPictureID"].ToString(), out pictureID);
                }
                catch
                {
                }
                return pictureID;
            }
            set
            {
                Session["UpdateImageControlPictureID"] = value.ToString();
            }
        }

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
                if (value != null)
                {
                    this.imgProduct.ImageUrl = this.PictureService.GetPictureUrl(value.PictureID, 100);
                }
            }
        }

        public string Value
        {
            get
            {
                return this.hidValue.Value.Trim();
            }
            set
            {
                this.hidValue.Value = value;
            }
        }


        public Unit Width
        {
            get
            {
                return imgProduct.Width;
            }
            set
            {
                imgProduct.Width = value;
            }
        }

        public Unit Height
        {
            get
            {
                return imgProduct.Height;
            }
            set
            {
                imgProduct.Height = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return imgProduct.Enabled;
            }
            set
            {
                imgProduct.Enabled = value;
            }
        }

        public delegate void SelectedPictureEventHandler(object sender, SelectedPictureEventArgs e);

        public event SelectedPictureEventHandler SelectPictureEvent;
        
        protected void lbtnUpImage_Click(object sender, EventArgs e)
        {
            if (SelectPicture == null)
            {
                return;
            }
            this.imgProduct.ImageUrl = this.PictureService.GetPictureUrl(this.SelectPicture.PictureID, 100);
            if (this.SelectPictureEvent != null)
            {
                this.SelectPictureEvent(sender, new SelectedPictureEventArgs() { SelectPicture = this.SelectPicture });
            }
        }

        protected void lbtnRemove_Click(object sender, EventArgs e)
        {
            Picture defaultpicture = PictureService.GetPictureById(this.PictureID);
            this.SelectPicture = defaultpicture;
        }
    }

    public partial class SelectedPictureEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the Picture
        /// </summary>
        public Picture SelectPicture { get; set; }
    }
}