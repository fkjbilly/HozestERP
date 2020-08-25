using Ext.Net;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageProject
{
    public partial class XMLogisticsFeeBranch : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void dataBind()
        {
            //项目数据
            var projectList = XMProjectService.GetXMProjectList();
            Store2.DataSource = projectList;
            Store2.DataBind();

            //物流公司数据
            var logisticsList = CodeService.GetCodeListInfoByCodeTypeID(244);
            Store3.DataSource = logisticsList;
            Store3.DataBind();

            //发货点数据(发货仓)
            var codeList = CodeService.GetCodeListInfoByCodeTypeID(188);
            Store4.DataSource = codeList;
            Store4.DataBind();
        }

        protected void add_Click(object sender, DirectEventArgs e)
        {
            dataBind();
            Window1.Show();
            fromPanel1.Reset();
            btnSave.Hidden = false;
            btnEdit.Hidden = true;
        }

        protected void btnSave_Click(object sender, DirectEventArgs e)
        {
            int projectID = int.Parse(cbProject.Text);
            int LogisticsID = int.Parse(cbLogistics.Text);
            decimal fee = decimal.Parse(numPrice.Text);
            int ProductCategoryID = int.Parse(cbProductCategory.Text);

            BusinessLogic.ManageProject.XMLogisticsFeeBranch entity = XMLogisticsFeeBranchService.getSingle(a => a.ProjectID == projectID && a.LogisticsID == LogisticsID && a.ProductCategoryID == ProductCategoryID);
            if(entity!=null)
            {
                ExtNet.Msg.Alert("提示", "已有相同记录存在").Show();
                return;
            }

            BusinessLogic.ManageProject.XMLogisticsFeeBranch model = new BusinessLogic.ManageProject.XMLogisticsFeeBranch();
            model.ProjectID = projectID;
            model.LogisticsID = LogisticsID;
            model.ProductCategoryID = ProductCategoryID;
            model.Fee = fee;
            model.CreateID= HozestERPContext.Current.User.CustomerID;
            model.CreateDate = DateTime.Now;
            XMLogisticsFeeBranchService.InsertXMLogisticsFeeBranch(model);
        }

        protected void edit_Click(object sender, DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMLogisticsFeeBranchNew> list = Serializer.Deserialize<List<XMLogisticsFeeBranchNew>>(data);
            if (list.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录").Show();
                return;
            }
            else if(list.Count>1)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "只允许单选").Show();
                return;
            }

            dataBind();
            Window1.Show();
            fromPanel1.Reset();

            BusinessLogic.ManageProject.XMLogisticsFeeBranch entity = XMLogisticsFeeBranchService.GetXMLogisticsFeeBranchByID(list[0].ID);
            selectID.Value = list[0].ID;
            cbProject.Value = entity.ProjectID;
            cbLogistics.Value = entity.LogisticsID;
            cbProductCategory.Value = entity.ProductCategoryID;
            numPrice.Value = entity.Fee;
            btnEdit.Hidden = false;
            btnSave.Hidden = true;
        }

        protected void btnEdit_Click(object sender, DirectEventArgs e)
        {
            int ID = int.Parse(selectID.Text);
            BusinessLogic.ManageProject.XMLogisticsFeeBranch entity = XMLogisticsFeeBranchService.GetXMLogisticsFeeBranchByID(ID);
            entity.ProjectID = int.Parse(cbProject.Text);
            entity.LogisticsID = int.Parse(cbLogistics.Text);
            entity.ProductCategoryID = int.Parse(cbProductCategory.Text);
            entity.Fee = decimal.Parse(numPrice.Text);
            XMLogisticsFeeBranchService.UpdateXMLogisticsFeeBranch(entity);
        }

        protected void btnDeleteClick(object sender, DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMLogisticsFeeBranchNew> list = Serializer.Deserialize<List<XMLogisticsFeeBranchNew>>(data);
            if (list.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录").Show();
                return;
            }

            foreach(var item in list)
            {
                XMLogisticsFeeBranchService.DeleteXMLogisticsFeeBranch(item.ID, false);
            }

            XMLogisticsFeeBranchService.SaveChanges();
        }
    }
}