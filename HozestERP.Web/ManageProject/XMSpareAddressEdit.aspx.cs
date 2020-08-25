using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using JdSdk.Domain;

namespace HozestERP.Web.ManageProject
{
    public partial class XMSpareAddressEdit : BaseAdministrationPage, IEditPage
    {
        public string province = "";
        public string city = "";
        public string county = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定省
                this.ddlProvince.Items.Clear();
                var ProvinceList = base.AreaCodeService.GetAreaCode("001");
                this.ddlProvince.DataSource = ProvinceList;
                this.ddlProvince.DataTextField = "City";
                this.ddlProvince.DataValueField = "NumberID";
                this.ddlProvince.DataBind();
                this.ddlProvince.Items.Insert(0, new ListItem("其它", "-1"));

                var Exist = base.XMSpareAddressService.GetXMSpareAddressByParm(Id, TypeID);
                if (Exist != null)
                {
                    province = Exist.Province == null ? "" : Exist.Province;
                    city = Exist.City == null ? "" : Exist.City;
                    county = Exist.County == null ? "" : Exist.County;
                    this.txtAppointDeliveryTime.Value = Exist.AppointDeliveryTime.ToString();
                    this.txtFullName.Text = Exist.FullName;
                    this.txtMobile.Text = Exist.Mobile;
                    this.txtTel.Text = Exist.Tel;
                    this.txtDeliveryAddress.Text = Exist.DeliveryAddress;

                    if (province != "")
                    {
                        bool ProvinceMatch = false;
                        foreach (var Province in ProvinceList)
                        {
                            if (Province.City.Substring(0, 2) == province.Substring(0, 2))
                            {
                                ProvinceMatch = true;
                                this.ddlProvince.SelectedValue = Province.NumberID;
                                break;
                            }
                        }
                        if (!ProvinceMatch)
                        {
                            this.ddlProvince.SelectedValue = "-1";
                        }
                        ddlProvince_Changed(sender, e);
                    }

                    string area = "";
                    if (this.ddlProvince.SelectedValue != "-1")
                    {
                        area += Exist.Province;
                    }
                    if (this.ddlCity.SelectedValue != "-1")
                    {
                        area += Exist.City;
                    }
                    if (this.ddlCounty.SelectedValue != "-1")
                    {
                        area += Exist.County;
                    }

                    if (area.Length > 0)
                    {
                        this.txtDeliveryAddress.Text = this.txtDeliveryAddress.Text.Replace(area, "");
                    }
                    else
                    {
                        this.ddlProvince.SelectedValue = "-1";
                        ddlProvince_Changed(sender, e);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string area = "";
            DateTime date = DateTime.Now;
            string AppointDeliveryTime = this.txtAppointDeliveryTime.Value.Trim();
            string FullName = this.txtFullName.Text.Trim();
            string Mobile = this.txtMobile.Text.Trim();
            string Tel = this.txtTel.Text.Trim();
            string DeliveryAddress = this.txtDeliveryAddress.Text.Trim();

            if (FullName == "" || Mobile == "" || DeliveryAddress == "" || this.ddlProvince.SelectedItem.Text == "" || this.ddlCity.SelectedItem == null || this.ddlCounty.SelectedItem == null)
            {
                base.ShowMessage("数据不能为空！");
                return;
            }

            var Exist = base.XMSpareAddressService.GetXMSpareAddressByParm(Id, TypeID);
            if (Exist != null)
            {
                if (DateTime.TryParse(AppointDeliveryTime, out date))
                {
                    Exist.AppointDeliveryTime = DateTime.Parse(AppointDeliveryTime);
                }
                Exist.FullName = FullName;
                Exist.Mobile = Mobile;
                Exist.Tel = Tel;

                if (this.ddlProvince.SelectedValue != "-1")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlProvince.SelectedValue);
                    Exist.Province = this.ddlProvince.SelectedItem.Text.Trim();

                    if (this.ddlCity.SelectedValue != "-2" && this.ddlCity.SelectedValue != "-3" && this.ddlCity.SelectedValue != "-4")
                    {
                        Exist.Province += info.CityType;
                    }
                    area += Exist.Province;
                }

                if (this.ddlCity.SelectedValue == "-2" || this.ddlCity.SelectedValue == "-3" || this.ddlCity.SelectedValue == "-4")
                {
                    Exist.City = Exist.Province;
                    if (this.ddlCity.SelectedValue == "-3" || this.ddlCity.SelectedValue == "-4")
                    {
                        Exist.City += "市";
                    }
                    area += Exist.City;
                }
                else if (this.ddlCity.SelectedValue != "-1" && this.ddlCity.SelectedValue != "-2" && this.ddlCity.SelectedValue != "-3" && this.ddlCity.SelectedValue != "-4" && this.ddlCity.SelectedValue != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlCity.SelectedValue);
                    Exist.City = this.ddlCity.SelectedItem.Text.Trim() + info.CityType;
                    area += Exist.City;
                }

                if (this.ddlCounty.SelectedValue != "-1" && this.ddlCounty.SelectedValue != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlCounty.SelectedValue);
                    Exist.County = this.ddlCounty.SelectedItem.Text.Trim() + info.CityType;
                    area += Exist.County;
                }
                Exist.DeliveryAddress = area + DeliveryAddress;
                Exist.UpdateID = HozestERPContext.Current.User.CustomerID;
                Exist.UpdateDate = DateTime.Now;
                base.XMSpareAddressService.UpdateXMSpareAddress(Exist);
            }
            else
            {
                XMSpareAddress Info = new XMSpareAddress();
                Info.OtherID = Id;
                Info.TypeID = TypeID;
                if (DateTime.TryParse(AppointDeliveryTime, out date))
                {
                    Info.AppointDeliveryTime = DateTime.Parse(AppointDeliveryTime);
                }
                Info.FullName = FullName;
                Info.Mobile = Mobile;
                Info.Tel = Tel;

                if (this.ddlProvince.SelectedValue != "-1")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlProvince.SelectedValue);
                    Info.Province = this.ddlProvince.SelectedItem.Text.Trim();

                    if (this.ddlCity.SelectedValue != "-2" && this.ddlCity.SelectedValue != "-3" && this.ddlCity.SelectedValue != "-4")
                    {
                        Info.Province += info.CityType;
                    }
                    area += Info.Province;
                }

                if (this.ddlCity.SelectedValue == "-2" || this.ddlCity.SelectedValue == "-3" || this.ddlCity.SelectedValue == "-4")
                {
                    Info.City = Info.Province;
                    if (this.ddlCity.SelectedValue == "-3" || this.ddlCity.SelectedValue == "-4")
                    {
                        Info.City += "市";
                    }
                    area += Info.City;
                }
                else if (this.ddlCity.SelectedValue != "-1" && this.ddlCity.SelectedValue != "-2" && this.ddlCity.SelectedValue != "-3" && this.ddlCity.SelectedValue != "-4" && this.ddlCity.SelectedValue != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlCity.SelectedValue);
                    Info.City = this.ddlCity.SelectedItem.Text.Trim() + info.CityType;
                    area += Info.City;
                }

                if (this.ddlCounty.SelectedValue != "-1" && this.ddlCounty.SelectedValue != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlCounty.SelectedValue);
                    Info.County = this.ddlCounty.SelectedItem.Text.Trim() + info.CityType;
                    area += Info.County;
                }
                Info.DeliveryAddress = area + DeliveryAddress;
                Info.IsEnable = false;
                Info.CreateID = HozestERPContext.Current.User.CustomerID;
                Info.CreateDate = DateTime.Now;
                Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMSpareAddressService.InsertXMSpareAddress(Info);
            }

            base.ShowMessage("保存成功！");
        }

        #region IEditPage 成员

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        protected void ddlProvince_Changed(Object sender, EventArgs e)
        {
            this.ddlCity.Items.Clear();

            string Province = this.ddlProvince.SelectedValue.Trim();
            string ProvinceName = this.ddlProvince.SelectedItem.Text.Trim();
            if (Province == "-1")
            {
                this.ddlCounty.Items.Clear();
                return;
            }
            else if (ProvinceName == "香港" || ProvinceName == "澳门" || ProvinceName == "台湾")
            {
                this.ddlCity.Items.Insert(0, new ListItem("港澳台", "-2"));
                this.ddlCounty.Items.Clear();
                return;
            }
            else if (ProvinceName == "天津" || ProvinceName == "重庆" || ProvinceName == "上海")
            {
                this.ddlCity.Items.Insert(0, new ListItem("直辖市", "-3"));
            }
            else if (ProvinceName == "北京")
            {
                this.ddlCity.Items.Insert(0, new ListItem("直辖市", "-4"));
            }
            else
            {
                var CityList = base.AreaCodeService.GetAreaCode(Province);
                this.ddlCity.DataSource = CityList;
                this.ddlCity.DataTextField = "City";
                this.ddlCity.DataValueField = "NumberID";
                this.ddlCity.DataBind();
                this.ddlCity.Items.Insert(0, new ListItem("其它", "-1"));

                if (city != "")
                {
                    bool CityMatch = false;
                    foreach (var City in CityList)
                    {
                        if (City.City.Substring(0, 2) == city.Substring(0, 2))
                        {
                            CityMatch = true;
                            this.ddlCity.SelectedValue = City.NumberID;
                            break;
                        }
                    }
                    if (!CityMatch)
                    {
                        this.ddlCity.SelectedValue = "-1";
                        return;
                    }
                }
            }

            ddlCity_Changed(sender, e);
        }

        protected void ddlCity_Changed(Object sender, EventArgs e)
        {
            List<AreaCode> CountyList = new List<AreaCode>();
            string City = this.ddlCity.SelectedValue.Trim();

            if (City == "-3")//直辖市
            {
                string Province = this.ddlProvince.SelectedValue.Trim();
                CountyList = base.AreaCodeService.GetAreaCode(4, Province);
            }
            else if (City == "-4")//北京
            {
                string Province = this.ddlProvince.SelectedValue.Trim();
                CountyList = base.AreaCodeService.GetAreaCode(3, Province);
            }
            else
            {
                CountyList = base.AreaCodeService.GetAreaCode(City);
            }

            this.ddlCounty.Items.Clear();
            this.ddlCounty.DataSource = CountyList;
            this.ddlCounty.DataTextField = "City";
            this.ddlCounty.DataValueField = "NumberID";
            this.ddlCounty.DataBind();
            this.ddlCounty.Items.Insert(0, new ListItem("其它", "-1"));

            if (county != "")
            {
                bool CountyMatch = false;
                foreach (var County in CountyList)
                {
                    if (County.City.Substring(0, 2) == county.Substring(0, 2))
                    {
                        CountyMatch = true;
                        this.ddlCounty.SelectedValue = County.NumberID;
                        break;
                    }
                    else if (City == "-3" || City == "-4")
                    {
                        if (city != "" && County.City.Substring(0, 2) == city.Substring(0, 2))
                        {
                            CountyMatch = true;
                            this.ddlCounty.SelectedValue = County.NumberID;
                            break;
                        }
                    }
                }
                if (!CountyMatch)
                {
                    this.ddlCounty.SelectedValue = "-1";
                    return;
                }
            }
        }

        public int Id
        {
            get
            {
                return  CommonHelper.QueryStringInt("Id");
            }
        }

        public int TypeID
        {
            get
            {
                return CommonHelper.QueryStringInt("TypeID");
            }
        }

        #endregion
    }
}