using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.BusinessLogic.Codes;

namespace HozestERP.Web.ManageSystem
{
    public partial class AreaCode : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnPublished.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitle("区域查询");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.Master.BindData<HozestERP.BusinessLogic.Codes.AreaCode>(this.grdAreaCode
                , base.AreaCodeService.GetAreaCodeByParentID(this.txtConent.Text.Trim(), paramPageIndex, paramPageSize));
        }

        //public void BindGrid()
        //{
        //    this.BindGrid(1, this.Master.PageSize);
        //}
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void btnPublished_Click(object sender, EventArgs e)
        {
            string xmlids = string.Empty;
            string noxmlids = string.Empty;
            for (int i = 0; i < this.grdAreaCode.Rows.Count; i++)
            {
                CheckBox myChk = (CheckBox)this.grdAreaCode.Rows[i].Cells[0].FindControl("chkSelected");
                if (myChk != null)
                {
                    if (myChk.Checked)
                    {
                        xmlids += this.grdAreaCode.DataKeys[i].Value.ToString() + ",";
                    }
                    else
                    {
                        noxmlids += this.grdAreaCode.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            base.AreaCodeService.MarkAreasBatchPublished(xmlids.TrimEnd(','), noxmlids.TrimEnd(','));
            base.ShowMessage("设置成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
    }
}