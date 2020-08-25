using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using System.Web.UI.HtmlControls;

namespace HozestERP.Web.ManageProject
{
    public partial class XMNickSetAdvertingField : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdvertingField();
            }
        }

        protected void Page_init(object sender, EventArgs e)
        {
            InitSelectedCheckbox();
        }

        //初始化已选中的复选框
        private void InitSelectedCheckbox()
        {
            if (this.NickId != 0)
            {
                var advertingField = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(this.NickId);
                if (advertingField != null && advertingField.Fields != null)
                {
                    hdfIDs.Value = advertingField.Fields;
                }
            }
        }

        /// <summary>
        /// 绑定广告费下明细字段
        /// </summary>
        private void BindAdvertingField()
        {
            var advertingField = base.XMAdvertingFieldService.GetXMAdvertingFieldList();
            this.rptAdvertingField.DataSource = advertingField;
            this.rptAdvertingField.DataBind();
        }

        protected int i = 1;

        protected void rptAdvertingField_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //动态控制repeater显示行数
            if (i % 16 == 0 && i > 0)
            {
                e.Item.Controls.Add(new LiteralControl("</tr><tr>"));
            }
            i++;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Session["isEdit"] = 1;
            //选中字段ID字符串(以，隔开)
            string IDs = hdfSelectAllID.Value;
            if (string.IsNullOrEmpty(IDs))
            {
                base.ShowMessage("请选择字段！");
                return;
            }
            if (!string.IsNullOrEmpty(IDs) && this.NickId != 0)
            {
                var advertingIncludeField = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(this.NickId);
                //新增
                if (advertingIncludeField == null)
                {
                    XMNickIncludeAdveringField info = new XMNickIncludeAdveringField();
                    info.NickId = this.NickId;
                    info.Fields = IDs;
                    info.CreateDate = DateTime.Now;
                    info.CreateID = HozestERPContext.Current.User.CustomerID;
                    info.UpdateDate = DateTime.Now;
                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMNickIncludeAdveringFieldService.InsertXMNickIncludeAdveringField(info);
                }
                else
                {
                    advertingIncludeField.Fields = IDs;
                    advertingIncludeField.UpdateID = HozestERPContext.Current.User.CustomerID;
                    advertingIncludeField.UpdateDate = DateTime.Now;
                    base.XMNickIncludeAdveringFieldService.UpdateXMNickIncludeAdveringField(advertingIncludeField);
                }
                base.ShowMessage("操作成功！");
            }
            BindAdvertingField();
            InitSelectedCheckbox();
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int NickId
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime
        {
            get { return CommonHelper.QueryString("StartTime"); }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime
        {
            get { return CommonHelper.QueryString("EndTime"); }
        }
    }
}