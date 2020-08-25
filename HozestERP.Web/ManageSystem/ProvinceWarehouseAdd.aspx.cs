using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageSystem
{
    public partial class ProvinceWarehouseAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //仓库
            int WarehouseID = int.Parse(this.ddlWarehouse.SelectedValue.Trim());
            //省
            string ProvinceName = this.txtProvinceName.Text.Trim();

            if (string.IsNullOrEmpty(ProvinceName))
            {
                base.ShowMessage("省/自治区/直辖市必须填写！");
                return;
            }

            var list = base.ProvinceWarehouseService.GetProvinceWarehouseListByParam(-1, ProvinceName);
            if (list.Count > 0)
            {
                if (Id == -1 || (Id != -1 && list.Count > 1) || (Id != -1 && list.Count == 1 && list[0].ID != Id))
                {
                    base.ShowMessage("该省/自治区/直辖市已存在！");
                    return;
                }
            }

            if (Id == -1)//添加
            {
                ProvinceWarehouse Info = new ProvinceWarehouse();
                Info.WarehouseID = WarehouseID;
                Info.ProvinceName = ProvinceName;
                Info.IsEnabled = false;
                Info.CreatorID = HozestERPContext.Current.User.CustomerID;
                Info.CreateTime = DateTime.Now;
                Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                Info.UpdateTime = DateTime.Now;
                base.ProvinceWarehouseService.InsertProvinceWarehouse(Info);
                base.ShowMessage("保存成功！");
            }
            else//编辑
            {
                ProvinceWarehouse Info = base.ProvinceWarehouseService.GetProvinceWarehouseByID(Id);
                if (Info != null)//判断有没有这条数据
                {
                    Info.WarehouseID = WarehouseID;
                    Info.ProvinceName = ProvinceName;
                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateTime = DateTime.Now;
                    base.ProvinceWarehouseService.UpdateProvinceWarehouse(Info);
                    base.ShowMessage("保存成功！");
                }
            }
        }

        public void loadDate()
        {
            if (Id != -1)
            {
                var Info = base.ProvinceWarehouseService.GetProvinceWarehouseByID(Id);
                this.ddlWarehouse.SelectedValue = Info.WarehouseID.ToString();
                this.txtProvinceName.Text = Info.ProvinceName;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public void Face_Init()
        {
            //仓库
            this.ddlWarehouse.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(227, false);
            this.ddlWarehouse.DataSource = codeList;
            this.ddlWarehouse.DataTextField = "CodeName";
            this.ddlWarehouse.DataValueField = "CodeID";
            this.ddlWarehouse.DataBind();
        }

        public void SetTrigger()
        {
        }
    }
}