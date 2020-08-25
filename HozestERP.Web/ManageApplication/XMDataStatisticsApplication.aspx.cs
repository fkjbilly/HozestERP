using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageApplication
{
    public partial class XMDataStatisticsApplication : BaseAdministrationPage, ISearchPage
    {
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            
        }

        public void Face_Init()
        {

        }

        private void LoadData()
        {
            //平台类型动态数据绑定
            this.ddlPlatformEXT.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            StorePlatform.DataSource = codeList;
            StorePlatform.DataBind();

            this.ddlNickEXT.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            SoreNick.DataSource = NickList;
            SoreNick.DataBind();
        }

        public void SetTrigger()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            var ddlPlatform = ddlPlatformEXT.Value == null ? -1 : int.Parse(ddlPlatformEXT.Value.ToString());//平台
            var nickid = ddlNickEXT.Value == null ? -1 : int.Parse(ddlNickEXT.Value.ToString());//店铺
            var timetype = timetypeEXT.Value==null ? 1 : int.Parse(timetypeEXT.Value.ToString());//时间类型
            var ApplicaType = ApplicaTypeEXT.Value == null ? -1 : int.Parse(ApplicaTypeEXT.Value.ToString());//申请类型
            var txtBeginDate = this.txtBegin.Value.Trim();//开始时间
            var txtEndDate = this.txtEnd.Value.Trim();//结束时间

            if (string.IsNullOrEmpty(txtBeginDate))
            {
                var ti = DateTime.Now.AddDays(-7);
                var ti2 = DateTime.Now;
                this.txtBegin.Value = DateTime.Parse(ti.Year + "-" + ti.Month + "-" + ti.Day).ToString("yyyy-MM-dd");
                this.txtEnd.Value = DateTime.Parse(ti2.Year + "-" + ti2.Month + "-" + ti2.Day).ToString("yyyy-MM-dd");
                txtBeginDate = DateTime.Parse(ti.Year + "-" + ti.Month + "-" + ti.Day).ToString("yyyy-MM-dd");
                txtEndDate = ti2.ToString("yyyy-MM-dd");
            }
            else
            {
                this.txtBegin.Value = txtBeginDate;
                txtEndDate = Convert.ToDateTime(txtEnd.Value).AddDays(+1).AddSeconds(-1).ToString("yyyy-MM-dd");
            }

            var listHuan = XMApplicationService.GetXMApplicationReportData(ddlPlatform, nickid, timetype, ApplicaType, Convert.ToDateTime(txtBeginDate), Convert.ToDateTime(txtEndDate), 1);//换货
            var listTui = XMApplicationService.GetXMApplicationReportData(ddlPlatform, nickid, timetype, ApplicaType, Convert.ToDateTime(txtBeginDate), Convert.ToDateTime(txtEndDate), 2);//退货

            StoreHuan.DataSource = listHuan;
            StoreHuan.DataBind();

            StoreTui.DataSource = listTui;
            StoreTui.DataBind();

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), System.DateTime.Now.Ticks.ToString(), "dataBindHuan('" + ddlPlatform + "','" + nickid + "','" + timetype + "','" + ApplicaType + "','" + txtBeginDate + "','" + txtEndDate + "')", true);//ajax
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
            BindGrid();
        }
    }
}