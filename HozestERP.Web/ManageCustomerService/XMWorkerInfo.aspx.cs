using Ext.Net;
using HozestERP.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMWorkerInfo : BaseAdministrationPage, ISearchPage
    {
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
           
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
                DataLoad();
                BindGrid();
            }
        }

        private void DataLoad()
        {
            var provinceList = AreaCodeService.GetAreaCodeByRank(2);
            provinceStore.DataSource = provinceList;
            provinceStore.DataBind();
        }

        private void BindGrid()
        {
            string name = txtUserName.Text.Trim();
            string province = txtProvince.Text.Trim();
            string city = txtCity.Text.Trim();
            string region = txtRegion.Text.Trim();
            var list = XMWorkerInfoService.GetXMWorkerInfoList(name, province, city, region);
            StoreWorker.DataSource = list;
            StoreWorker.DataBind();
        }

        protected void Data_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            BindGrid();
        }

        protected void btnSave_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string fullName = txtName.Text.Trim();
            string tel = txtTel.Text.Trim();
            string level = txtLevel.Text.Trim();
            string PayMethod = txtPayMethod.Text.Trim();
            string InstallationType = txtInstallationType.Text.Trim();
            string province = "";
            foreach (var item in cbProvince.SelectedItems)
            {
                province = province + item.Text+",";
            }
            if(!string.IsNullOrEmpty(province))
            {
                province = province.Substring(0, province.Length - 1);
            }
            string city = "";
            foreach (var item in cbCity.SelectedItems)
            {
                city = city + item.Text+",";
            }
            if (!string.IsNullOrEmpty(city))
            {
                city = city.Substring(0, city.Length - 1);
            }
            string regin = "";
            foreach (var item in cbRegion.SelectedItems)
            {
                regin = regin + item.Text+",";
            }
            if (!string.IsNullOrEmpty(regin))
            {
                regin = regin.Substring(0, regin.Length - 1);
            }

            BusinessLogic.ManageCustomerService.XMWorkerInfo entity = XMWorkerInfoService.getSingle(a => a.Tel == tel);
            if(entity!=null)
            {
                ExtNet.Msg.Alert("提示", "用户信息已存在！").Show();
                return;
            }

            BusinessLogic.ManageCustomerService.XMWorkerInfo model = new BusinessLogic.ManageCustomerService.XMWorkerInfo();
            model.FullName = fullName;
            model.Tel = tel;
            model.LevelType = level;
            model.PayMethod = PayMethod;
            model.InstallationType = InstallationType;
            model.Province = province;
            model.City = city;
            model.Regin = regin;
            model.IsEnable = false;
            model.CreateID = HozestERPContext.Current.User.CustomerID;
            model.CreateTime = DateTime.Now;
            model.UpdateID= HozestERPContext.Current.User.CustomerID;
            model.UpdateTime= DateTime.Now;

            XMWorkerInfoService.InsertXMWorkerInfo(model);


        }

        protected void btnEdit_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            string fullName = txtName.Text.Trim();
            string tel = txtTel.Text.Trim();
            string level = txtLevel.Text.Trim();
            string PayMethod = txtPayMethod.Text.Trim();
            string InstallationType = txtInstallationType.Text.Trim();
            string province = "";
            foreach (var item in cbProvince.SelectedItems)
            {
                province = province + item.Text + ",";
            }
            if (!string.IsNullOrEmpty(province))
            {
                province = province.Substring(0, province.Length - 1);
            }
            string city = "";
            foreach (var item in cbCity.SelectedItems)
            {
                city = city + item.Text + ",";
            }
            if (!string.IsNullOrEmpty(city))
            {
                city = city.Substring(0, city.Length - 1);
            }
            string regin = "";
            foreach (var item in cbRegion.SelectedItems)
            {
                regin = regin + item.Text + ",";
            }
            if (!string.IsNullOrEmpty(regin))
            {
                regin = regin.Substring(0, regin.Length - 1);
            }

            BusinessLogic.ManageCustomerService.XMWorkerInfo entity = XMWorkerInfoService.getSingle(a => a.ID== ID);
            if(entity==null)
            {
                ExtNet.Msg.Alert("提示", "记录不存在！").Show();
                return;
            }

            entity.FullName = fullName;
            entity.Tel = tel;
            entity.LevelType = level;
            entity.PayMethod = PayMethod;
            entity.InstallationType = InstallationType;
            entity.Province = province;
            entity.City = city;
            entity.Regin = regin;
            entity.CreateID = HozestERPContext.Current.User.CustomerID;
            entity.CreateTime = DateTime.Now;
            entity.UpdateID = HozestERPContext.Current.User.CustomerID;
            entity.UpdateTime = DateTime.Now;

            XMWorkerInfoService.UpdateXMWorkerInfo(entity);
        }

        protected void province_Select(object sender, Ext.Net.DirectEventArgs e)
        {
            List<BusinessLogic.Codes.AreaCode> list = new List<BusinessLogic.Codes.AreaCode>();
            var pros = cbProvince.SelectedItems;
            //城市数据
            foreach(var item in pros)
            {
                var cityList = AreaCodeService.GetAreaCodeByCity(3, "/"+ item.Text+"/");
                list.AddRange(cityList);
            }

            cityStore.DataSource = list;
            cityStore.DataBind();

            cbCity.Clear();
            cbRegion.Clear();
        }

        protected void city_Select(object sender, Ext.Net.DirectEventArgs e)
        {
            List<BusinessLogic.Codes.AreaCode> list = new List<BusinessLogic.Codes.AreaCode>();
            var citys = cbCity.SelectedItems;

            //地区数据
            foreach(var item in citys)
            {
                var reginList = AreaCodeService.GetAreaCodeByCity(4, "/"+item.Text+"/");
                list.AddRange(reginList);
            }
            regionStore.DataSource = list;
            regionStore.DataBind();

            cbRegion.Clear();
        }

        protected void formLoad_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<BusinessLogic.ManageCustomerService.XMWorkerInfo> list = Serializer.Deserialize<List<BusinessLogic.ManageCustomerService.XMWorkerInfo>>(data);
            if (list.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "请选择一条数据").Show();
            }

            Window1.Show();
            fromPanel1.Reset();
            txtID.Text = list[0].ID.ToString();
            txtName.Text = list[0].FullName.ToString();
            txtTel.Text = list[0].Tel.ToString();
            txtLevel.Text = list[0].LevelType.ToString();
            txtPayMethod.Text = list[0].PayMethod.ToString();
            string[] Provinces = list[0].Province.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            cbProvince.SetValue(Provinces);
            province_Select(sender, e);
            cbCity.SetValue(list[0].City.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            city_Select(sender, e);
            cbRegion.SetValue(list[0].Regin.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        }

        protected void deleteInfo_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<BusinessLogic.ManageCustomerService.XMWorkerInfo> list = Serializer.Deserialize<List<BusinessLogic.ManageCustomerService.XMWorkerInfo>>(data);
            if (list.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "请选择一条数据").Show();
            }

            int ID = list[0].ID;

            BusinessLogic.ManageCustomerService.XMWorkerInfo entity = XMWorkerInfoService.getSingle(a => a.ID == ID);
            if (entity == null)
            {
                ExtNet.Msg.Alert("提示", "记录不存在！").Show();
                return;
            }

            entity.IsEnable = true;

            XMWorkerInfoService.UpdateXMWorkerInfo(entity);
        }
    }
}