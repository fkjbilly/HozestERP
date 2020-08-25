using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageProject;
using JdSdk.Domain;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderUpdateConsignee : BaseAdministrationPage, IEditPage
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

                var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                if (OrderInfo != null)
                {
                    province = OrderInfo.Province == null ? "" : OrderInfo.Province;
                    city = OrderInfo.City == null ? "" : OrderInfo.City;
                    county = OrderInfo.County == null ? "" : OrderInfo.County;
                    this.txtAppointDeliveryTime.Value = OrderInfo.AppointDeliveryTime.ToString();
                    this.txtFullName.Text = OrderInfo.FullName;
                    this.txtMobile.Text = OrderInfo.Mobile;
                    this.txtTel.Text = OrderInfo.Tel;
                    this.txtDeliveryAddress.Text = OrderInfo.DeliveryAddress;
                    //this.txtDeliveryAddressSpare.Text = OrderInfo.DeliveryAddressSpare;

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
                        area += OrderInfo.Province;
                    }
                    if (this.ddlCity.SelectedValue != "-1")
                    {
                        area += OrderInfo.City;
                    }
                    if (this.ddlCounty.SelectedValue != "-1")
                    {
                        area += OrderInfo.County;
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
            //string DeliveryAddressSpare = this.txtDeliveryAddressSpare.Text.Trim();
            var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
            if (OrderInfo != null)
            {
                XMOrderInfo record = GetXMOrderInfoValue(OrderInfo);
                if (DateTime.TryParse(AppointDeliveryTime, out date))
                {
                    OrderInfo.AppointDeliveryTime = DateTime.Parse(AppointDeliveryTime);
                }
                else if (string.IsNullOrEmpty(AppointDeliveryTime))
                {
                    OrderInfo.AppointDeliveryTime = null;
                }

                OrderInfo.FullName = FullName;
                OrderInfo.Mobile = Mobile;
                OrderInfo.Tel = Tel;
                //OrderInfo.DeliveryAddressSpare = DeliveryAddressSpare;

                if (this.ddlProvince.SelectedValue != "-1")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlProvince.SelectedValue);
                    OrderInfo.Province = this.ddlProvince.SelectedItem.Text.Trim();

                    if (this.ddlCity.SelectedValue != "-2" && this.ddlCity.SelectedValue != "-3" && this.ddlCity.SelectedValue != "-4")
                    {
                        OrderInfo.Province += info.CityType;
                    }
                    area += OrderInfo.Province;
                }

                if (this.ddlCity.SelectedValue == "-2" || this.ddlCity.SelectedValue == "-3" || this.ddlCity.SelectedValue == "-4")
                {
                    OrderInfo.City = OrderInfo.Province;
                    if (this.ddlCity.SelectedValue == "-3" || this.ddlCity.SelectedValue == "-4")
                    {
                        OrderInfo.City += "市";
                    }
                    area += OrderInfo.City;
                }
                else if (this.ddlCity.SelectedValue != "-1" && this.ddlCity.SelectedValue != "-2" && this.ddlCity.SelectedValue != "-3" && this.ddlCity.SelectedValue != "-4" && this.ddlCity.SelectedValue != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlCity.SelectedValue);
                    OrderInfo.City = this.ddlCity.SelectedItem.Text.Trim() + info.CityType;
                    area += OrderInfo.City;
                }

                if (this.ddlCounty.SelectedValue != "-1" && this.ddlCounty.SelectedValue != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(this.ddlCounty.SelectedValue);
                    OrderInfo.County = this.ddlCounty.SelectedItem.Text.Trim() + info.CityType;
                    area += OrderInfo.County;
                }
                OrderInfo.DeliveryAddress = area + DeliveryAddress;
                OrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                OrderInfo.UpdateDate = DateTime.Now;

                GetOrderInfoDifference(record, OrderInfo);
                base.XMOrderInfoService.UpdateXMOrderInfo(OrderInfo);

                base.ShowMessage("保存成功！");
            }
        }

        public XMOrderInfo GetXMOrderInfoValue(XMOrderInfo OrderInfo)
        {
            XMOrderInfo a = new XMOrderInfo();
            a.AppointDeliveryTime = OrderInfo.AppointDeliveryTime;
            a.FullName = OrderInfo.FullName;
            a.Mobile = OrderInfo.Mobile;
            a.Tel = OrderInfo.Tel;
            a.DeliveryAddressSpare = OrderInfo.DeliveryAddressSpare;
            a.Province = OrderInfo.Province;
            a.City = OrderInfo.City;
            a.County = OrderInfo.County;
            a.DeliveryAddress = OrderInfo.DeliveryAddress;
            return a;
        }

        public void GetOrderInfoDifference(XMOrderInfo info, XMOrderInfo Info)
        {
            if (info.AppointDeliveryTime != Info.AppointDeliveryTime)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-预约发货时间", info.AppointDeliveryTime.ToString(), Info.AppointDeliveryTime.ToString());
            }
            if (info.FullName != Info.FullName)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-姓名", info.FullName, Info.FullName);
            }
            if (info.Mobile != Info.Mobile)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-手机", info.Mobile, Info.Mobile);
            }
            if (info.Tel != Info.Tel)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-电话", info.Tel, Info.Tel);
            }
            if (info.DeliveryAddressSpare != Info.DeliveryAddressSpare)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-备用地址", info.DeliveryAddressSpare, Info.DeliveryAddressSpare);
            }
            if (info.Province != Info.Province)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-省", info.Province, Info.Province);
            }
            if (info.City != Info.City)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-市", info.City, Info.City);
            }
            if (info.County != Info.County)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-县", info.County, Info.County);
            }
            if (info.DeliveryAddress != Info.DeliveryAddress)
            {
                AddXMOrderInfoOperatingRecord("修改收货人信息-地址", info.DeliveryAddress, Info.DeliveryAddress);
            }
        }

        public void AddXMOrderInfoOperatingRecord(string PropertyName, string OldValue, string NewValue)
        {
            XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
            var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
            if (OrderInfo != null)
            {
                record.OrderInfoId = OrderInfo.ID;
                record.PropertyName = PropertyName;
                record.OldValue = OldValue;
                record.NewValue = NewValue;
                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                record.UpdateTime = DateTime.Now;
                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
            }
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

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode
        {
            get
            {
                return Request.Params["OrderCode"];
            }
        }

        #endregion
    }
}