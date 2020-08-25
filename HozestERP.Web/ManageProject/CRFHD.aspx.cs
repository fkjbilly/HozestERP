using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Web.auth;

namespace HozestERP.Web.ManageProject
{
    public partial class CRFHD : BaseAdministrationPage
    {
        #region 定义变量
        public string OrderCode
        {
            get { return ViewState["OrderCode"].ToString(); }
            set { ViewState["OrderCode"] = value; }
        }

        public string ids
        {
            get { return ViewState["ids"].ToString(); }
            set { ViewState["ids"] = value; }
        }



        public string PrintTypeId
        {
            get { return ViewState["PrintTypeId"].ToString(); }
            set { ViewState["PrintTypeId"] = value; }
        }


        public string kdgs
        {
            get { return ViewState["kdgs"].ToString(); }
            set { ViewState["kdgs"] = value; }
        }
        #endregion

        private ReportDocument myReport;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ConfigureCrystalReports();
                if (Request.QueryString["ids"] != null && Request.QueryString["ids"].ToString() != "")
                {
                    ids = Request.QueryString["ids"].ToString();
                }
                //订单列表
                List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();

                if (ids != "")
                {
                    int[] sts = new int[ids.Split(',').Length];
                    for (int i = 0; i < ids.Split(',').Length; i++)
                    {
                        string Id = ids.Split(',')[i];
                        sts[i] = int.Parse(Id);
                    }

                    orderInfoList = base.XMOrderInfoService.GetXMOrderInfoList(sts);//订单信息
                    if (orderInfoList.Count > 0) 
                    {
                        FHDataSet myFHDataSet = new FHDataSet();
                        FHDataSet.FHDOrderinfoDataTable myFHDOrderinfo = new FHDataSet.FHDOrderinfoDataTable();
                        FHDataSet.FHDOrderinfoDeDataTable myFHDOrderinfoDe = new FHDataSet.FHDOrderinfoDeDataTable();
                        for (int j = 0; j < orderInfoList.Count; j++) 
                        {

                        }
                    }
                }


                //定义ReportDocument对象，装载Crystalreport1.rpt
                myReport = new ReportDocument();
                string reportPath = Server.MapPath("../Reapoting/FHD.rpt");
                myReport.Load(reportPath);
                //把模板对象赋给报表前端呈现控件CrystalReportViewerl
                CrystalReportViewer1.ReportSource = myReport;
                
            }
        }
    }
}