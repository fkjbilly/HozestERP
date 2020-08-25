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
    public partial class LogisticsAgingAdd : BaseAdministrationPage, IEditPage
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
            //string Line = this.txtLine.Text.Trim();
            string DepartureProvince = this.txtDepartureProvince.Text.Trim();
            string DepartureCity = this.txtDepartureCity.Text.Trim();
            string Pathway = this.txtPathway.Text.Trim();
            string PathwayDate = this.txtPathwayDate.Text.Trim();
            string DestinationProvince = this.txtDestinationProvince.Text.Trim();
            string DestinationCity = this.txtDestinationCity.Text.Trim();
            string DestinationDate = this.txtDestinationDate.Text.Trim();
            bool IsSouth = this.ddlIsSouth.SelectedValue == "1" ? true : false;
            string Line = DepartureProvince + "-" + DestinationProvince;

            int ToInt = 0;
            if ((Pathway != "" && int.TryParse(PathwayDate, out ToInt) == false) || int.TryParse(DestinationDate, out ToInt) == false)
            {
                base.ShowMessage("预计到达时间必须为整数！");
                return;
            }

            if (DepartureProvince == "" || DepartureCity == "" || DestinationProvince == ""
                || DestinationCity == "" || DestinationDate == "")
            {
                base.ShowMessage("数据不能为空，请先填写数据！");
                return;
            }

            List<LogisticsAging> list = new List<LogisticsAging>();
            list = base.LogisticsAgingService.GetLogisticsAgingListByParam(DepartureCity, DestinationCity, "-1");

            if (list != null && list.Count > 0)
            {
                if (Id == -1 || (Id != -1 && list[0].ID != Id))
                {
                    base.ShowMessage("该始发城市，该目的城市的物流时效记录已存在，请前去修改！");
                    return;
                }
            }

            if (Id == -1)//添加
            {
                LogisticsAging Info = new LogisticsAging();
                Info.Line = Line;
                Info.DepartureProvince = DepartureProvince;
                Info.DepartureCity = DepartureCity;
                if (Pathway != "")
                {
                    Info.Pathway = Pathway;
                    Info.PathwayDate = int.Parse(PathwayDate);
                }
                else
                {
                    Info.Pathway = "";
                    Info.PathwayDate = null;
                }
                Info.DestinationProvince = DestinationProvince;
                Info.DestinationCity = DestinationCity;
                Info.DestinationDate = int.Parse(DestinationDate);
                Info.IsSouth = IsSouth;
                Info.IsEnabled = false;
                Info.CreatorID = HozestERPContext.Current.User.CustomerID;
                Info.CreateTime = DateTime.Now;
                Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                Info.UpdateTime = DateTime.Now;
                base.LogisticsAgingService.InsertLogisticsAging(Info);
                base.ShowMessage("保存成功！");
            }
            else//编辑
            {
                LogisticsAging Info = base.LogisticsAgingService.GetLogisticsAgingByID(Id);
                if (Info != null)//判断有没有这条数据
                {
                    Info.Line = Line;
                    Info.DepartureProvince = DepartureProvince;
                    Info.DepartureCity = DepartureCity;
                    if (Pathway != "")
                    {
                        Info.Pathway = Pathway;
                        Info.PathwayDate = int.Parse(PathwayDate);
                    }
                    else
                    {
                        Info.Pathway = "";
                        Info.PathwayDate = null;
                    }
                    Info.DestinationProvince = DestinationProvince;
                    Info.DestinationCity = DestinationCity;
                    Info.DestinationDate = int.Parse(DestinationDate);
                    Info.IsSouth = IsSouth;
                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateTime = DateTime.Now;
                    base.LogisticsAgingService.UpdateLogisticsAging(Info);
                    base.ShowMessage("保存成功！");
                }
            }
        }

        public void loadDate()
        {
            if (Id != -1)
            {
                var Info = base.LogisticsAgingService.GetLogisticsAgingByID(Id);
                this.txtDepartureProvince.Text = Info.DepartureProvince;
                this.txtDepartureCity.Text = Info.DepartureCity;
                this.txtPathway.Text = Info.Pathway;
                this.txtPathwayDate.Text = Info.PathwayDate.ToString();
                this.txtDestinationProvince.Text = Info.DestinationProvince;
                this.txtDestinationCity.Text = Info.DestinationCity;
                this.txtDestinationDate.Text = Info.DestinationDate.ToString();
                this.ddlIsSouth.SelectedValue = Info.IsSouth == true ? "1" : "0";
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
        }

        public void SetTrigger()
        {
        }
    }
}