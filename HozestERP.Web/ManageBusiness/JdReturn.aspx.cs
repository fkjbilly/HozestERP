using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageBusiness
{
    public partial class JdReturn : BaseAdministrationPage, ISearchPage
    {
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

        }

        private void LoadData()
        {
            //var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(230, false);
            //ReturnTypeStore.DataSource = codeList;
            //ReturnTypeStore.DataBind();

            var projectList = base.XMProjectService.GetXMProjectList();
            ProjectStore.DataSource = projectList;
            ProjectStore.DataBind();

        }

        protected void Project_Select(object sender, Ext.Net.DirectEventArgs e)
        {
            //CbNick.Items.Clear();
            CbNick.Clear();

            var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(CbProject.Value));
            NickStore.DataSource = nickList;
            NickStore.DataBind();
        }

        public void Face_Init()
        {
            
        }

        public void SetTrigger()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtBegin.Value = DateTime.Now.ToString("yyyy-MM") + "-01";
                this.txtEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
                LoadData();
                BindGrid();
            }
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            LoadData();
            BindGrid();
        }

        protected void BindGrid()
        {
            string NickIDs = "";
            //开始日期
            string Begin = this.txtBegin.Value.Trim(); 
            //结束日期
            string End = this.txtEnd.Value.Trim();
            int xMProjectId = Convert.ToInt32(this.CbProject.Value);
            int NickId = Convert.ToInt32(this.CbNick.Value);
            if(NickId==0)
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), xMProjectId);
                foreach(var item in nickList)
                {
                    NickIDs = NickIDs + item.nick_id+",";
                }
                if(NickIDs.Length>0)
                {
                    NickIDs = NickIDs.Substring(0, NickIDs.Length - 1);
                }
            }
            else
            {
                NickIDs = CbNick.Value.ToString();
            }

            var list = XMJDSaleRejectedService.GetXMJDSaleReportData(Begin, End, NickIDs);
            store1.DataSource = list;
            store1.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "JdReturn", "dataBind('" + Begin + "','" + End + "','" + NickIDs + "')", true);//ajax
        }
    }
}