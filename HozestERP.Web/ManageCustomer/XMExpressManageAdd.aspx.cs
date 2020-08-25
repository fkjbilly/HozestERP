using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageProject;
using JdSdk.Domain;

namespace HozestERP.Web.ManageCustomer
{
    public partial class XMExpressManageAdd : BaseAdministrationPage, IEditPage
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

                if (Id != 0)
                {
                    var Info = base.XMExpressManagementService.GetXMExpressManagementByID(Id);
                    if (Info != null)
                    {
                        //快递公司
                        if (Info.ExpressID != null&&Copy!=1)
                        {
                            List<XMCompanyCustom> xMCompanyCustomList = new List<XMCompanyCustom>();
                            this.ddlExpress.Items.Clear();
                            var xMCompanyCustom = base.XMCompanyCustomService.GetXMCompanyCustomByLogisticId(Info.ExpressID.ToString());
                            if (xMCompanyCustom != null)
                            {
                                xMCompanyCustomList.Add(xMCompanyCustom);
                            }
                            this.ddlExpress.DataSource = xMCompanyCustomList;
                            this.ddlExpress.DataTextField = "LogisticsName";
                            this.ddlExpress.DataValueField = "LogisticsId";
                            this.ddlExpress.DataBind();
                        }

                        if(Copy==1)
                        {
                            var InfoEntity = base.CustomerInfoService.GetCustomerInfoByID(HozestERPContext.Current.User.CustomerID);
                            if (InfoEntity != null)
                            {
                                this.txtSender.Text = InfoEntity.FullName;
                            }

                            var Department = base.CustomerService.GetDepartmentByCustomerID(HozestERPContext.Current.User.CustomerID);
                            if (Department != null)
                            {
                                this.ddlDepartment.SelectedValue = GetDepartmentID(Department.DepartmentID).ToString();
                            }
                        }
                        else
                        {
                            this.txtCourierNumber.Text = Info.CourierNumber == null ? "" : Info.CourierNumber;
                            this.ddlDepartment.SelectedValue = Info.DepartmentID.ToString();
                            this.txtSender.Text = Info.SenderName;
                            this.txtGoods.Text = Info.Goods == null ? "" : Info.Goods;
                            this.txtRemarks.Text = Info.Remarks == null ? "" : Info.Remarks;
                        }
                        this.txtReceivingName.Text = Info.ReceivingName;
                        this.txtReceivingCompany.Text = Info.ReceivingCompany;
                        this.txtReceivingTel.Text = Info.ReceivingTel;
                        this.txtAddress.Text = Info.Address;
                        this.txtPrice.Text = Info.Price == null ? "" : Info.Price.ToString();

                        province = Info.Province == null ? "" : Info.Province;
                        city = Info.City == null ? "" : Info.City;
                        county = Info.County == null ? "" : Info.County;
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

                        EditJurisdiction(Info);
                    }
                }
                else
                {
                    var Info = base.CustomerInfoService.GetCustomerInfoByID(HozestERPContext.Current.User.CustomerID);
                    if (Info != null)
                    {
                        this.txtSender.Text = Info.FullName;
                    }

                    var Department = base.CustomerService.GetDepartmentByCustomerID(HozestERPContext.Current.User.CustomerID);
                    if (Department != null)
                    {
                        this.ddlDepartment.SelectedValue = GetDepartmentID(Department.DepartmentID).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 编辑权限
        /// </summary>
        public void EditJurisdiction(XMExpressManagement Info)
        {
            if (!string.IsNullOrEmpty(Info.CourierNumber))
            {
                this.ddlExpress.Enabled = false;
                this.txtReceivingName.ReadOnly = true;
                this.txtReceivingCompany.ReadOnly = true;
                this.txtReceivingTel.ReadOnly = true;
                this.ddlProvince.Enabled = false;
                this.ddlCity.Enabled = false;
                this.ddlCounty.Enabled = false;
                this.txtAddress.ReadOnly = true;
                this.txtGoods.ReadOnly = true;
            }

            if (Jurisdiction != 1)
            {
                if (Info.CreateID != HozestERPContext.Current.User.CustomerID)
                {
                    this.btnSave.Visible = false;
                }
            }
            else
            {
                this.txtPrice.ReadOnly = false;
            }
        }

        public int GetDepartmentID(int DepartmentID)
        {
            var Department = base.EnterpriseService.GetDepartmentById(DepartmentID);
            if (Department != null)
            {
                if (Department.ParentID != 0)
                {
                    return GetDepartmentID((int)Department.ParentID);
                }
                else
                {
                    return Department.DepartmentID;
                }
            }
            return -1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal a = 0;
            string ExpressID = this.ddlExpress.SelectedValue;
            int DepartmentID = int.Parse(this.ddlDepartment.SelectedValue);
            string ReceivingName = this.txtReceivingName.Text.Trim();
            string ReceivingCompany = this.txtReceivingCompany.Text.Trim();
            string ReceivingTel = this.txtReceivingTel.Text.Trim();
            string Address = this.txtAddress.Text.Trim();
            string Price = this.txtPrice.Text.Trim();
            string Goods = this.txtGoods.Text.Trim();
            string Remarks = this.txtRemarks.Text.Trim();
            string Province = this.ddlProvince.SelectedValue.Trim();
            string City = this.ddlCity.SelectedValue.Trim();
            string County = this.ddlCounty.SelectedValue.Trim();

            //if (ExpressID == -1)
            //{
            //    base.ShowMessage("请选择快递公司！");
            //    return;
            //}
            if (DepartmentID == -1)
            {
                base.ShowMessage("该账号没有所属的部门！");
                return;
            }
            if (ReceivingName == "")
            {
                base.ShowMessage("请填写收件人姓名！");
                return;
            }
            if (ReceivingTel == "")
            {
                base.ShowMessage("请填写收件人电话！");
                return;
            }
            if (ReceivingTel.Length > 15)
            {
                base.ShowMessage("收件人电话位数太长，请修改！");
                return;
            }
            if (this.ddlCity.SelectedItem == null || this.ddlCounty.SelectedItem == null || this.ddlProvince.SelectedItem.Text == ""
                || this.ddlCity.SelectedItem.Text == "" || this.ddlCounty.SelectedItem.Text == "")
            {
                base.ShowMessage("请填写收件人省市区！");
                return;
            }
            if (Address == "")
            {
                base.ShowMessage("请填写收件人地址！");
                return;
            }
            if (Price != "")
            {
                if (!decimal.TryParse(Price, out a))
                {
                    base.ShowMessage("价格必须为数字！");
                    return;
                }
            }

            if (Id != 0&&Copy!=1)
            {
                var Info = base.XMExpressManagementService.GetXMExpressManagementByID(Id);
                if (Info != null)
                {
                    if (ExpressID != "")
                    {
                        Info.ExpressID = int.Parse(ExpressID);
                    }

                    Info.ReceivingName = ReceivingName;
                    Info.ReceivingCompany = ReceivingCompany;
                    Info.ReceivingTel = ReceivingTel;
                    if (Price != "")
                    {
                        Info.Price = decimal.Parse(Price);
                    }
                    Info.Remarks = Remarks;
                    Info.Goods = Goods;
                }
                if (Province != "-1")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(Province);
                    Info.Province = this.ddlProvince.SelectedItem.Text.Trim();

                    if (City != "-2" && City != "-3" && City != "-4")
                    {
                        Info.Province += info.CityType;
                    }
                }
                if (City == "-2" || City == "-3" || City == "-4")
                {
                    Info.City = Info.Province;
                    if (City == "-3" || City == "-4")
                    {
                        Info.City += "市";
                    }
                }
                else if (City != "-1" && City != "-2" && City != "-3" && City != "-4" && City != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(City);
                    Info.City = this.ddlCity.SelectedItem.Text.Trim() + info.CityType;
                }

                if (County != "-1" && County != "")
                {
                    var info = base.AreaCodeService.GetAreaByNumberID(County);
                    Info.County = this.ddlCounty.SelectedItem.Text.Trim() + info.CityType;
                }
                Info.Address = Address;
                Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = DateTime.Now;
                base.XMExpressManagementService.UpdateXMExpressManagement(Info);
            }
            else
            {
                XMExpressManagement Info = new XMExpressManagement();
                if (ExpressID != "")
                {
                    Info.ExpressID = int.Parse(ExpressID);
                }

                Info.CourierNumber = "";
                Info.DepartmentID = DepartmentID;
                Info.SendDate = DateTime.Now;
                Info.ReceivingName = ReceivingName;
                Info.ReceivingCompany = ReceivingCompany;
                Info.ReceivingTel = ReceivingTel;
                Info.Province = this.ddlProvince.SelectedItem.Text;
                Info.City = this.ddlCity.SelectedItem.Text;
                Info.County = this.ddlCounty.SelectedItem.Text;
                Info.Address = Address;
                Info.Remarks = Remarks;
                Info.PrintCount = 0;
                Info.Goods = Goods;
                Info.IsEnable = false;
                Info.SenderID = Info.CreateID = Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                Info.CreateDate = Info.UpdateDate = DateTime.Now;
                base.XMExpressManagementService.InsertXMExpressManagement(Info);
            }
            base.ShowMessage("保存成功！");
        }

        public void Face_Init()
        {
            //部门绑定
            this.ddlDepartment.Items.Clear();
            var DepartmentList = base.EnterpriseService.GetDepartmentByParentID(3, 0);
            this.ddlDepartment.DataSource = DepartmentList;
            this.ddlDepartment.DataTextField = "DepName";
            this.ddlDepartment.DataValueField = "DepartmentID";
            this.ddlDepartment.DataBind();
            this.ddlDepartment.Items.Insert(0, new ListItem("---所有---", "-1"));

            //快递绑定
            //this.ddlExpress.Items.Clear();
            //var xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();
            //this.ddlExpress.DataSource = xMCompanyCustomList;
            //this.ddlExpress.DataTextField = "LogisticsName";
            //this.ddlExpress.DataValueField = "LogisticsId";
            //this.ddlExpress.DataBind();
            //this.ddlExpress.SelectedValue = "470";
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
            //else if (ProvinceName == "香港" || ProvinceName == "澳门" || ProvinceName == "台湾")
            else if (ProvinceName == "澳门" || ProvinceName == "台湾")
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
                return int.Parse(Request.Params["Id"]);
            }
        }

        public int Jurisdiction
        {
            get
            {
                return int.Parse(Request.Params["Jurisdiction"]);
            }
        }

        public int Copy
        {
            get
            {
                return int.Parse(Request.Params["Copy"]);
            }
        }
    }
}