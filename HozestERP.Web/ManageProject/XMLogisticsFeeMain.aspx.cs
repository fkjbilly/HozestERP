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
    public partial class XMLogisticsFeeMain : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {

            }
        }

        private void data_Bind()
        {
            //项目数据
            var projectList = XMProjectService.GetXMProjectList();
            Store2.DataSource = projectList;
            Store2.DataBind();

            //发货点数据(发货仓)
            var codeList = CodeService.GetCodeListInfoByCodeTypeID(227);
            Store3.DataSource = codeList;
            Store3.DataBind();

            //省份数据
            var provinceList = AreaCodeService.GetAreaCodeByRank(2);
            Store4.DataSource = provinceList;
            Store4.DataBind();

            //物流公司数据
            var logisticsList = CodeService.GetCodeListInfoByCodeTypeID(243);
            Store7.DataSource = logisticsList;
            Store7.DataBind();
        }

        protected void add_Click(object sender, DirectEventArgs e)
        {
            data_Bind();
            Window1.Show();
            fromPanel1.Reset();
            btnSave.Hidden = false;
            btnEdit.Hidden = true;
        }

        protected void edit_Click(object sender, DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMLogisticsFeeMainNew> list= Serializer.Deserialize<List<XMLogisticsFeeMainNew>>(data);
            if (list.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录").Show();
                return;
            }
            else if (list.Count > 1)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "只允许单选").Show();
                return;
            }

            data_Bind();
            Window1.Show();
            fromPanel1.Reset();

            BusinessLogic.ManageProject.XMLogisticsFeeMain entity = XMLogisticsFeeMainService.GetXMLogisticsFeeMainByID(list[0].ID);
            selectID.Value = list[0].ID;
            cbProject.Value = entity.ProjectID;
            cbWarehouse.Value = entity.WareHouseID;
            cbProvince.Value = entity.Province;
            cbCity.Value = entity.City;
            cbArea.Value = entity.Area;
            cbLogistics.Value = entity.LogisticsID;
            numPrice.Value = entity.Fee;
            btnEdit.Hidden = false;
            btnSave.Hidden = true;
        }

        protected void province_Select(object sender, DirectEventArgs e)
        {
            string province = cbProvince.Text;
            //城市数据
            var cityList = AreaCodeService.GetAreaCodeByCity(3, province);
            Store5.DataSource = cityList;
            Store5.DataBind();

            cbCity.Clear();
            cbArea.Clear();
        }

        protected void city_Select(object sender, DirectEventArgs e)
        {
            string city = cbCity.Text;
            string province = cbProvince.Text;
            //地区数据
            var areaList = AreaCodeService.GetAreaCodeByCity(4, province+"/"+ city);
            Store6.DataSource = areaList;
            Store6.DataBind();

            cbArea.Clear();
        }

        protected void btnSave_Click(object sender, DirectEventArgs e)
        {
            int projectID = int.Parse(cbProject.Text);
            int WarehouseID = int.Parse(cbWarehouse.Text);
            string Province = cbProvince.Text;
            string City = cbCity.Text;
            string Area = cbArea.Text;
            int LogisticsID = int.Parse(cbLogistics.Text);
            decimal fee = decimal.Parse(numPrice.Text);

            BusinessLogic.ManageProject.XMLogisticsFeeMain entity = XMLogisticsFeeMainService.getSingle(a => a.ProjectID == projectID && a.WareHouseID == WarehouseID &&
                 a.Province == Province && a.City == City && a.Area == Area && a.LogisticsID == LogisticsID);
            if(entity!=null)
            {
                ExtNet.Msg.Alert("提示", "已有相同记录存在").Show();
                return;
            }

            BusinessLogic.ManageProject.XMLogisticsFeeMain model = new BusinessLogic.ManageProject.XMLogisticsFeeMain();
            model.ProjectID = projectID;
            model.WareHouseID = WarehouseID;
            model.Province = Province;
            model.City = City;
            model.Area = Area;
            model.LogisticsID = LogisticsID;
            model.Fee = fee;
            model.CreateID = HozestERPContext.Current.User.CustomerID;
            model.CreateDate = DateTime.Now;

            XMLogisticsFeeMainService.InsertXMLogisticsFeeMain(model,true);
        }

        protected void btnEdit_Click(object sender, DirectEventArgs e)
        {
            int ID = int.Parse(selectID.Text);
            BusinessLogic.ManageProject.XMLogisticsFeeMain entity = XMLogisticsFeeMainService.GetXMLogisticsFeeMainByID(ID);
            entity.ProjectID = int.Parse(cbProject.Text);
            entity.WareHouseID = int.Parse(cbWarehouse.Text);
            entity.Province = cbProvince.Text;
            entity.City = cbCity.Text;
            entity.Area = cbArea.Text;
            entity.LogisticsID = int.Parse(cbLogistics.Text);
            entity.Fee = decimal.Parse(numPrice.Text);
            XMLogisticsFeeMainService.UpdateXMLogisticsFeeMain(entity);
        }

        protected void btnDeleteClick(object sender, DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<XMLogisticsFeeMainNew> list = Serializer.Deserialize<List<XMLogisticsFeeMainNew>>(data);
            if (list.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录").Show();
                return;
            }

            foreach(var item in list)
            {
                XMLogisticsFeeMainService.DeleteXMLogisticsFeeMain(item.ID, false);
            }

            XMLogisticsFeeMainService.saveChanges();
        }
    }
}