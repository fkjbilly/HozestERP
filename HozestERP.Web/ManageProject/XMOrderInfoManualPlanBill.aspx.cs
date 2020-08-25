using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.Enterprises;
using Top.Api.Domain;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoManualPlanBill : BaseAdministrationPage, IEditPage
    {
        public string ManufacturersCodeRecord = "";
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMXLMInventory> XLMInventoryList = new List<XMXLMInventory>();
        public List<int> InventoryList = new List<int>();

        //同一个用户多个订单的备份
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> SpareDeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMOrderInfoProductDetails> SpareOrderInfoProductList = new List<XMOrderInfoProductDetails>();
        public List<XMXLMInventory> SpareXLMInventoryList = new List<XMXLMInventory>();
        public List<XMOrderInfoOperatingRecord> SpareRecordList = new List<XMOrderInfoOperatingRecord>();
        public bool MultipleUpdate;//同一个用户多个订单是否更新


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SaveOrderInfoIDs"] != null)
                {
                    List<int> Ids = new List<int>();
                    string msg = "";
                    string[] DeliveryStatue = { "WAIT_SELLER_SEND_GOODS", "DS_WAIT_SELLER_DELIVERY", "WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT",
                                  "STATUS_10", "ORDER_TRUNED_TO_DO", "以接受", "10","已付款" };

                    string[] IDs = (string[])Session["SaveOrderInfoIDs"];
                    if (IDs.Count() > 0)
                    {
                        foreach (var ID in IDs)
                        {
                            Ids.Add(int.Parse(ID));
                        }
                    }
                    else
                    {
                        base.ShowMessage("你没有选择任何记录！");
                        return;
                    }

                    var list = base.XMOrderInfoService.GetXMOrderInfoListByIds(Ids);
                    if (list != null && list.Count > 0)
                    {
                        var ProjectCount = list.Select(x => x.ProjectId).Distinct().ToList();
                        if (ProjectCount.Count > 1)
                        {
                            base.ShowMessage("所选订单必须属于同一个项目！");
                            return;
                        }

                        foreach (var info in list)
                        {
                            //审单排单合并取消判断
                            #region
                            //if (info.IsAudit == null || (bool)!info.IsAudit)
                            //{
                            //    msg += "订单号：" + info.OrderCode + "，未审核，不能排单！<br/>";
                            //    continue;
                            //}
                            //if (info.XM_OrderInfoProductDetails.Where(x => x.IsAudit == true).ToList().Count == 0)
                            //{
                            //    msg += "订单号：" + info.OrderCode + "，的所有产品都未审核，不能排单！<br/>";
                            //    continue;
                            //}
                            #endregion

                            //if (!(bool)info.FinancialAudit)
                            //{
                            //    msg += "订单号：" + info.OrderCode + "，财务审核还未通过，不能排单！<br/>";
                            //    continue;
                            //}
                            if (!(bool)info.IsOurOrder)
                            {
                                msg += "订单号：" + info.OrderCode + "，不是本公司订单，不能排单！<br/>";
                                continue;
                            }
                            //if (!DeliveryStatue.Contains(info.OrderStatus))
                            //{
                            //    msg += "订单号：" + info.OrderCode + "，不是待发货状态，不能排单！<br/>";
                            //    continue;
                            //}
                            if (info.XM_OrderInfoProductDetails.Where(x => x.IsSingleRow != true).ToList().Count == 0)
                            {
                                msg += "订单号：" + info.OrderCode + "，的所有产品都已排单，不能排单！<br/>";
                                continue;
                            }
                        }

                        if (msg != "")
                        {
                            base.ShowMessage(msg);
                            return;
                        }
                        else
                        {
                            //if (ProjectCount[0] == 2)//喜临门排单出库仓库绑定
                            //{
                            //    var WareList = base.CodeService.GetCodeListInfoByCodeTypeID(227);
                            //    this.ddlWareHourses.Items.Clear();
                            //    this.ddlWareHourses.DataSource = WareList;
                            //    this.ddlWareHourses.DataTextField = "CodeName";
                            //    this.ddlWareHourses.DataValueField = "CodeID";
                            //    this.ddlWareHourses.DataBind();
                            //}
                            //else //其他项目排单仓库绑定
                            //{
                            //    int projectID = Convert.ToInt32(ProjectCount[0]);
                            //    if (Convert.ToInt16(ProjectCount[0]) != -1)
                            //    {
                            //        var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(projectID);
                            //        this.ddlWareHourses.Items.Clear();
                            //        this.ddlWareHourses.DataSource = wareHouses;
                            //        this.ddlWareHourses.DataTextField = "Name";
                            //        this.ddlWareHourses.DataValueField = "Id";
                            //        this.ddlWareHourses.DataBind();
                            //    }
                            //}
                            BindddXMProject(ProjectCount[0]);
                            this.ddXMProject.SelectedValue = list[0].ProjectId.ToString();
                        }
                    }
                }

                else if (Session["SaveApplicationIds"] != null)
                {
                    List<int> Ids = new List<int>();
                    string msg = "";
                    string[] IDs = (string[])Session["SaveApplicationIds"];
                    if (IDs.Count() > 0)
                    {
                        foreach (var ID in IDs)
                        {
                            Ids.Add(int.Parse(ID));
                        }
                    }
                    else
                    {
                        base.ShowMessage("你没有选择任何记录！");
                        return;
                    }

                    var list = base.XMApplicationService.GetXMApplicationListByIds(Ids);

                    if (list != null && list.Count > 0)
                    {
                        var ProjectCount = list.Select(x => x.ProjectId).Distinct().ToList();
                        if (ProjectCount.Count > 1)
                        {
                            base.ShowMessage("所选退换货单必须属于同一个项目！");
                            return;
                        }

                        foreach (var info in list)
                        {
                            if (info.SupervisorStatus == null || (bool)!info.SupervisorStatus)
                            {
                                msg += "退换货单：" + info.OrderCode + "，未审核，不能排单！<br/>";
                                continue;
                            }
                            if (info.IsSingleRow != null )
                            {
                                if ((bool)info.IsSingleRow)
                                {
                                    msg += "退换货单：" + info.OrderCode + "，已排单，不能排单！<br/>";
                                    continue;
                                }
                            }
                        }

                        if (msg != "")
                        {
                            base.ShowMessage(msg);
                            return;
                        }

                        else
                        {
                            //if (ProjectCount[0] == 2)//喜临门排单出库仓库绑定
                            //{
                            //    var WareList = base.CodeService.GetCodeListInfoByCodeTypeID(227);
                            //    this.ddlWareHourses.Items.Clear();
                            //    this.ddlWareHourses.DataSource = WareList;
                            //    this.ddlWareHourses.DataTextField = "CodeName";
                            //    this.ddlWareHourses.DataValueField = "CodeID";
                            //    this.ddlWareHourses.DataBind();
                            //}
                            //else //其他项目排单仓库绑定
                            //{
                            //    int projectID = Convert.ToInt32(ProjectCount[0]);
                            //    if (Convert.ToInt16(ProjectCount[0]) != -1)
                            //    {
                            //        var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(projectID);
                            //        this.ddlWareHourses.Items.Clear();
                            //        this.ddlWareHourses.DataSource = wareHouses;
                            //        this.ddlWareHourses.DataTextField = "Name";
                            //        this.ddlWareHourses.DataValueField = "Id";
                            //        this.ddlWareHourses.DataBind();
                            //    }
                            //}
                            BindddXMProject(ProjectCount[0]);
                        }
                    }
                }
                else 
                {
                    base.ShowMessage("你没有选择任何记录！");
                }
            }
        }


        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                if (this.ddXMProject.SelectedValue.ToString().Trim() != "")
                {
                    var projectID = int.Parse(this.ddXMProject.SelectedValue.ToString().Trim());

                    BindWareHouses(projectID);
                }
            }
        }

        private void BindWareHouses(int projectID) 
        {
            if (projectID == 2)//喜临门排单出库仓库绑定
            {
                var WareList = base.CodeService.GetCodeListInfoByCodeTypeID(227);
                this.ddlWareHourses.Items.Clear();
                this.ddlWareHourses.DataSource = WareList;
                this.ddlWareHourses.DataTextField = "CodeName";
                this.ddlWareHourses.DataValueField = "CodeID";
                this.ddlWareHourses.DataBind();
            }
            else //其他项目排单仓库绑定
            {
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.SelectedValue;
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < this.ddXMProject.Items.Count; i++)
                    {
                        if (this.ddXMProject.Items[i].Value != "-1")
                            paramprojectIDs = paramprojectIDs + this.ddXMProject.Items[i].Value + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                ddlWareHourses.DataSource = wareHouses;
                ddlWareHourses.DataTextField = "Name";
                ddlWareHourses.DataValueField = "Id";
                ddlWareHourses.DataBind();
                this.ddlWareHourses.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlWareHourses.Items[0].Selected = true;
            }
        }

        //项目数据绑定
        private void BindddXMProject(int projectID)
        {
            #region 项目名称绑定
            string projectids = "-1,";
            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));

                //默认根据项目列表绑定仓库下拉框
                for (int i = 0; i < projectList.Count; i++)
                {
                    projectids = projectids + projectList[i].Id + ",";
                }
                if (projectids.Length > 0)
                {
                    projectids = projectids.Substring(0, projectids.Length - 1);
                }
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    //默认根据项目列表绑定仓库下拉框
                    for (int i = 0; i < projectList.ToList().Count; i++)
                    {
                        projectids = projectids + projectList.ToList()[i].Id + ",";
                    }
                    if (projectids.Length > 0)
                    {
                        projectids = projectids.Substring(0, projectids.Length - 1);
                    }

                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                    this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "99"));
                }
            }

            BindWareHouses(projectID);
            #endregion
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region 线上订单管理排单保存
                if (Session["SaveOrderInfoIDs"] != null)
                {
                    string msg = "";
                    List<int> Ids = new List<int>();
                    string WareHourses = this.ddlWareHourses.SelectedValue;
                    if (Session["SaveOrderInfoIDs"] != null)
                    {
                        string[] IDs = (string[])Session["SaveOrderInfoIDs"];
                        if (IDs.Count() > 0)
                        {
                            foreach (var ID in IDs)
                            {
                                Ids.Add(int.Parse(ID));
                            }
                        }
                    }

                    if (WareHourses == "-1" || WareHourses == "")
                    {
                        base.ShowMessage("请先选择发库仓库！");
                        return;
                    }

                    var list = base.XMOrderInfoService.GetXMOrderInfoListByIds(Ids);

                    string errOrder = string.Empty;
                    if(chkCodeContain.Checked)
                    {
                        foreach(var item in list)
                        {
                            int count = item.XM_OrderInfoProductDetails.Where(a => a.Manufacturers== "10601139" && (a.IsEnable==false||a.IsEnable==null)&&(a.IsSingleRow==false||a.IsSingleRow==null)).Count();
                            if(count>0)
                            {
                                List<XMOrderInfo> list_OrderInfo = XMOrderInfoService.GetXMOrderInfoListByFullNameAndPlatformMerchantCode(item.FullName,new string[] { "10117847", "10117846", "10117845", "10117844", "10117843", "10117842", "10117841" });//指定商品
                                if(list_OrderInfo.Count<=0)
                                {
                                    errOrder = errOrder + item.OrderCode + ",";
                                }
                            }
                        }
                        if(!string.IsNullOrEmpty(errOrder))
                        {
                            base.ShowMessage("订单："+ errOrder.Substring(0, errOrder.Length-1)+"不允许排单，找不到与礼包对应的商品订单");
                            return;
                        }
                    }

                    if (list != null && list.Count > 0)
                    {
                        var Group = list.GroupBy(x => x.Mobile).ToList();
                        foreach (var group in Group)
                        {
                            bool Multiple = false;//一个用户多个订单
                            if (group.Count() == 1)
                            {
                                XMOrderInfo Info = (group.ToList<XMOrderInfo>())[0];
                                msg = MethodAllIsAudit(Info.ID, chkCodeContain.Checked);//审单功能
                                if (msg == "操作成功")
                                {
                                    msg = "";
                                }
                                msg = XMOrderInfoGroup(Info, list, msg, Multiple, int.Parse(WareHourses), chkCodeContain.Checked);

                                if ((group.ToList<XMOrderInfo>())[0].ProjectId != 2 && msg == "")
                                {
                                    //CreateSaleDelivery(DeliveryList[0].Id, Info.ID);//生成销售出库单
                                }
                            }
                            else if (group.Count() > 1)
                            {
                                Multiple = true;
                                SpareDeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                                SpareOrderInfoProductList = new List<XMOrderInfoProductDetails>();
                                SpareXLMInventoryList = new List<XMXLMInventory>();
                                SpareRecordList = new List<XMOrderInfoOperatingRecord>();
                                MultipleUpdate = true;

                                List<XMOrderInfo> InfoList = group.ToList<XMOrderInfo>();
                                foreach (XMOrderInfo Info in InfoList)
                                {
                                    msg = MethodAllIsAudit(Info.ID, chkCodeContain.Checked);//审单功能
                                    if (msg == "操作成功")
                                    {
                                        msg = "";
                                    }
                                    msg = XMOrderInfoGroup(Info, list, msg, Multiple, int.Parse(WareHourses), chkCodeContain.Checked);
                                }
                                if (MultipleUpdate)
                                {
                                    #region 同一用户多个订单
                                    foreach (var item in SpareDeliveryList)
                                    {
                                        base.XMDeliveryService.InsertXMDelivery(item);
                                    }
                                    foreach (var item in SpareOrderInfoProductList)
                                    {
                                        item.IsSingleRow = true;
                                        item.UpdateDate = DateTime.Now;
                                        item.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(item);
                                    }
                                    foreach (var item in SpareRecordList)
                                    {
                                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(item);
                                    }
                                    if ((group.ToList<XMOrderInfo>())[0].ProjectId != 2)
                                    {
                                        //CreateSaleDelivery(SpareDeliveryList[0].Id, (group.ToList<XMOrderInfo>())[0].ID);//生成销售出库单
                                    }
                                    #endregion
                                }
                                else
                                {
                                    foreach (var item in SpareXLMInventoryList)
                                    {
                                        var info = base.XMXLMInventoryService.GetXMXLMInventoryByID(item.ID);
                                        if (info != null)
                                        {
                                            info.Inventory += item.Inventory;
                                            base.XMXLMInventoryService.UpdateXMXLMInventory(item);
                                        }
                                    }
                                }
                            }
                        }

                        if (msg != "")
                        {
                            base.ShowMessage(msg);
                            return;
                        }
                        else
                        {
                            Session.Remove("SaveOrderInfoIDs");
                            base.ShowMessage("排单成功！");
                        }
                    }
                }
                #endregion

                #region 退换货管理手动批量排单保存
                else if (Session["SaveApplicationIds"] != null) 
                {
                    List<int> Ids = new List<int>();
                    string msg = "";
                    string[] IDs = (string[])Session["SaveApplicationIds"];
                    if (IDs.Count() > 0)
                    {
                        foreach (var ID in IDs)
                        {
                            Ids.Add(int.Parse(ID));
                        }
                    }
                    else
                    {
                        base.ShowMessage("你没有选择任何记录！");
                        return;
                    }
                    string WareHourses = this.ddlWareHourses.SelectedValue;
                    if (WareHourses == "-1" || WareHourses == "")
                    {
                        base.ShowMessage("请先选择发库仓库！");
                        return;
                    }
                    using (TransactionScope scope = new TransactionScope())
                    {
                        foreach (var item in Ids)
                        {
                            var ApplicationInfo = base.XMApplicationService.GetXMApplicationByID(item);
                            if (ApplicationInfo != null)
                            {
                                if (ApplicationInfo.ApplicationType == 6)//换货
                                {
                                    if (ApplicationInfo.SupervisorStatus == true && (ApplicationInfo.IsSingleRow == null || ApplicationInfo.IsSingleRow == false))//&& ApplicationInfo.FinancialStatus == true
                                    {
                                        int OrderInfoProductCount = 0;//有效的订单产品条数
                                        int DeliveryProductCount = 0;//能排单的订单产品条数
                                        int WarehouseID = 0;
                                        int ProvinceWarehouseID = 0;

                                        DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                                        XLMInventoryList = new List<XMXLMInventory>();
                                        InventoryList = new List<int>();

                                        List<XMApplicationExchange> OrderInfoProductUnSpare = new List<XMApplicationExchange>();//无备用地址产品
                                        List<XMApplicationExchange> OrderInfoProductSpare = new List<XMApplicationExchange>();//有备用地址产品
                                        List<XMApplicationExchange> LatexPillowUnSpare = new List<XMApplicationExchange>();//乳胶枕，U型枕，无备用地址产品
                                        List<XMApplicationExchange> LatexPillowSpare = new List<XMApplicationExchange>();//乳胶枕，U型枕，有备用地址产品

                                        var Info = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(ApplicationInfo.OrderCode);
                                        if (Info != null)
                                        {
                                            string Address = Info.Province + Info.City + Info.County + Info.DeliveryAddress;
                                            

                                            var list = base.XMApplicationExchangeService.GetXMApplicationExchangeListByApplicationIDType(ApplicationInfo.ID, 1);
                                            foreach (var info in list)
                                            {
                                                if (info.ProductName.IndexOf("床笠") != -1 || info.ProductName.IndexOf("运费") != -1 || info.ProductName.IndexOf("邮费") != -1 || info.ProductName.IndexOf("无产品") != -1)
                                                {
                                                    continue;
                                                }

                                                OrderInfoProductCount++;
                                                var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 710);
                                                if (info.ProductName.IndexOf("乳胶枕") != -1 || info.ProductName.IndexOf("U型枕") != -1)
                                                {
                                                    if (spareAddress != null)
                                                    {
                                                        Address = spareAddress.Province + spareAddress.City + spareAddress.County + spareAddress.DeliveryAddress;
                                                        
                                                        LatexPillowSpare.Add(info);
                                                    }
                                                    else
                                                    {
                                                        LatexPillowUnSpare.Add(info);
                                                    }
                                                }
                                                else
                                                {
                                                    if (spareAddress != null)
                                                    {
                                                        Address = spareAddress.Province + spareAddress.City + spareAddress.County + spareAddress.DeliveryAddress;
                                                       
                                                        OrderInfoProductSpare.Add(info);
                                                    }
                                                    else
                                                    {
                                                        OrderInfoProductUnSpare.Add(info);
                                                    }
                                                }
                                            }

                                            if (OrderInfoProductUnSpare.Count > 0)
                                            {
                                                msg = ToPlanBillApplication(OrderInfoProductUnSpare, Info, ApplicationInfo, int.Parse(WareHourses), ProvinceWarehouseID, 1, msg);//无备用地址产品
                                            }
                                            if (LatexPillowUnSpare.Count > 0)
                                            {
                                                msg = ToPlanBillApplication(LatexPillowUnSpare, Info, ApplicationInfo, int.Parse(WareHourses), ProvinceWarehouseID, 3, msg);//乳胶枕，U型枕，无备用地址产品
                                            }
                                            if (OrderInfoProductSpare.Count > 0)
                                            {
                                                msg = ToPlanBillApplication(OrderInfoProductSpare, Info, ApplicationInfo, int.Parse(WareHourses), ProvinceWarehouseID, 2, msg);//有备用地址产品
                                            }
                                            if (LatexPillowSpare.Count > 0)
                                            {
                                                msg = ToPlanBillApplication(LatexPillowSpare, Info, ApplicationInfo, int.Parse(WareHourses), ProvinceWarehouseID, 4, msg);//乳胶枕，U型枕，有备用地址产品
                                            }

                                            foreach (var delivery in DeliveryList)
                                            {
                                                if (delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
                                                {
                                                    DeliveryProductCount += delivery.XM_Delivery_Details.Count;
                                                }
                                            }

                                            if (OrderInfoProductCount > 0 && OrderInfoProductCount == DeliveryProductCount)
                                            {
                                                foreach (var delivery in DeliveryList)
                                                {
                                                    delivery.OrderRemarks = ApplicationInfo.Remarks;//备注
                                                    base.XMDeliveryService.InsertXMDelivery(delivery);
                                                }

                                                //换货-排单完成
                                                ApplicationInfo.IsSingleRow = true;
                                                ApplicationInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                                ApplicationInfo.UpdateDate = DateTime.Now;
                                                base.XMApplicationService.UpdateXMApplication(ApplicationInfo);

                                                //CreateSaleDelivery(DeliveryList[0].Id, Info.ID);//生成销售出库单

                                                //减喜临门当日库存
                                                for (int i = 0; i < XLMInventoryList.Count; i++)
                                                {
                                                    XLMInventoryList[i].Inventory = InventoryList[i];
                                                    base.XMXLMInventoryService.UpdateXMXLMInventory(XLMInventoryList[i]);
                                                }
                                                //操作记录
                                                XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                                record.PropertyName = "换货批量手动排单";
                                                record.OldValue = "";
                                                record.NewValue = "新增";
                                                record.OrderInfoId = Info.ID;
                                                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                                record.UpdateTime = DateTime.Now;
                                                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                            }
                                        }
                                        else
                                        {
                                            msg += "订单:" + ApplicationInfo.OrderCode + "不存在！<br/>";
                                        }
                                    }
                                    else
                                    {
                                        msg += "订单:" + ApplicationInfo.OrderCode + "未审核或已排单！<br/>";
                                    }
                                }
                                else
                                {
                                    msg += "订单:" + ApplicationInfo.OrderCode + "的申请类型错误！<br/>";
                                }
                            }
                        }
                        scope.Complete();
                    }
                    if (msg != "")
                    {
                        base.ShowMessage(msg);
                    }
                    else
                    {
                        Session.Remove("SaveApplicationIds");
                        base.ShowMessage("生成发货单成功！");
                    }
                }
                #endregion
            }
            catch(Exception ex)
            {
                base.ShowMessage("更新排单失败，请检查后重新排单！");
                return;
            }
        }

        /// <summary>
        /// 批量审单方法
        /// </summary>
        /// <returns>操作结果</returns>
        public string MethodAllIsAudit(int XMOrderInfoID, bool packageChecked)
        {
            try
            {
                string msg = "";
                var xmorderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
                if (xmorderInfo != null)
                {
                    int TMInsertCount = 0;
                    int TMUpdateCount = 0;

                    int JDInsertCount = 0;
                    int JDUpdateCount = 0;

                    int SNInsertCount = 0;
                    int SNUpdateCount = 0;

                    int YHDInsertCount = 0;
                    int YHDUpdateCount = 0;

                    int VPHInsertCount = 0;
                    int VPHUpdateCount = 0;

                    //同步各平台记录
                    var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppByPlatformTypeId(xmorderInfo.PlatformTypeId.Value).Where(p => p.NickId == xmorderInfo.NickID).FirstOrDefault();
                    if (XMOrderInfoAppList != null)
                    {
                        switch (xmorderInfo.PlatformTypeId)
                        {
                            #region 淘宝/天猫

                            case 250:
                                Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderInfo.OrderCode), XMOrderInfoAppList);
                                if (trade != null)
                                {
                                    base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, XMOrderInfoAppList);

                                    if (TMUpdateCount > 0)
                                    {
                                        var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                        //备注内容  用来判断是否已经提单
                                        string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;
                                        //备注内容
                                        string Remarksstr = "";
                                        Remarksstr = xMOrderInfoTMNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                        if (remmarksYTD.IndexOf("已提单") == -1)
                                        {
                                            //修改备注
                                            var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(xMOrderInfoTMNew.OrderCode), Remarksstr, XMOrderInfoAppList);
                                            if (tradeMemoUpdate != null)
                                            {
                                                xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                            }
                                        }
                                    }
                                }
                                break;
                            #endregion

                            #region 集市店

                            case 381:
                                Trade trade2 = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderInfo.OrderCode), XMOrderInfoAppList);
                                if (trade2 != null)
                                {
                                    base.XMOrderInfoAPIService.getTradeTM(trade2, ref  TMInsertCount, ref  TMUpdateCount, XMOrderInfoAppList);

                                    if (TMUpdateCount > 0)
                                    {
                                        var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                        //备注内容  用来判断是否已经提单
                                        string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;
                                        //备注内容
                                        string Remarksstr = "";
                                        Remarksstr = xMOrderInfoTMNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                        if (remmarksYTD.IndexOf("已提单") == -1)
                                        {
                                            //修改备注
                                            var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(xMOrderInfoTMNew.OrderCode), Remarksstr, XMOrderInfoAppList);

                                            if (tradeMemoUpdate != null)
                                            {
                                                xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                            }
                                        }
                                    }
                                }
                                break;
                            #endregion

                            #region 京东

                            case 251:
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderInfo.OrderCode, XMOrderInfoAppList.AppKey, XMOrderInfoAppList.AppSecret, XMOrderInfoAppList.ServerUrl, XMOrderInfoAppList.AccessToken);

                                if (orderInfo != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, XMOrderInfoAppList);

                                    if (JDUpdateCount > 0)
                                    {
                                        var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                        //备注内容  用来判断是否已经提单
                                        string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                                        //备注内容
                                        string Remarksstr = "";
                                        Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                        if (remmarksYTD.IndexOf("已提单") == -1)
                                        {
                                            //修改备注
                                            var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(xMOrderInfoNew.OrderCode, Remarksstr, "", XMOrderInfoAppList);

                                            if (orderVenderRemark != null)
                                            {
                                                if (orderVenderRemark.OUP != null)
                                                {
                                                    if (orderVenderRemark.OUP.Code.ToString() == "0")
                                                    {
                                                        xmorderInfo.CustomerServiceRemark = Remarksstr;
                                                        base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;

                            #endregion

                            #region 京东闪购

                            case 382:
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver2 = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo2 = webserver2.WebGetJDOrderInfo(xmorderInfo.OrderCode, XMOrderInfoAppList.AppKey, XMOrderInfoAppList.AppSecret, XMOrderInfoAppList.ServerUrl, XMOrderInfoAppList.AccessToken);
                                if (orderInfo2 != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo2, ref JDInsertCount, ref JDUpdateCount, XMOrderInfoAppList);

                                    if (JDUpdateCount > 0)
                                    {
                                        var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                        //备注内容  用来判断是否已经提单
                                        string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                                        //备注内容
                                        string Remarksstr = "";
                                        Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                        if (remmarksYTD.IndexOf("已提单") == -1)
                                        {
                                            //修改备注
                                            //var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(xMOrderInfoNew.OrderCode, Remarksstr, "", XMOrderInfoAppList);

                                            //if (orderVenderRemark != null)
                                            //{
                                            //    if (orderVenderRemark.OUP != null)
                                            //    {
                                            //        if (orderVenderRemark.OUP.Code.ToString() == "0")
                                            //        {
                                            xmorderInfo.CustomerServiceRemark = Remarksstr;
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                            //        }
                                            //    }
                                            //}

                                        }
                                    }
                                }
                                break;

                            #endregion

                            #region 苏宁易购
                            case 383:
                                //OrderInfo orderInfoSN = base.XMOrderInfoAPIService.getOrderSuning(xmorderInfo.OrderCode, XMOrderInfoAppList);
                                //if (orderInfoSN != null)
                                //{
                                base.XMOrderInfoAPIService.getOrderSuning(xmorderInfo.OrderCode, ref SNInsertCount, ref SNUpdateCount, XMOrderInfoAppList);

                                if (SNUpdateCount > 0)
                                {

                                    var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                    //备注内容  用来判断是否已经提单
                                    string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                                    //备注内容
                                    string Remarksstr = "";
                                    Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                    if (remmarksYTD.IndexOf("已提单") == -1)
                                    {
                                        //修改备注
                                        var result = base.XMOrderInfoAPIService.OrdernoteModifyUpdate(xMOrderInfoNew.OrderCode, Remarksstr, "4", XMOrderInfoAppList);

                                        if (result == "Y")//判断平台后台备注是否修改成功
                                        {
                                            xmorderInfo.CustomerServiceRemark = Remarksstr;
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                        }
                                    }
                                }
                                // }
                                break;
                            #endregion

                            #region 一号店
                            case 375:
                                base.XMOrderInfoAPIService.getOrderYHD(xmorderInfo.OrderCode, ref YHDInsertCount, ref YHDUpdateCount, XMOrderInfoAppList);

                                if (YHDUpdateCount > 0)
                                {
                                    var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));

                                    //备注内容  用来判断是否已经提单
                                    string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;
                                    //备注内容
                                    string Remarksstr = "";
                                    Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                                    if (remmarksYTD.IndexOf("已提单") == -1)
                                    {
                                        //修改备注 
                                        int OrderMerchantRemarkUpdateInt = base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(xMOrderInfoNew.OrderCode, Remarksstr, XMOrderInfoAppList);

                                        if (OrderMerchantRemarkUpdateInt == 1)
                                        {
                                            xmorderInfo.CustomerServiceRemark = Remarksstr;
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                                        }
                                    }
                                }
                                break;
                            #endregion

                            #region 唯品会
                            //case 259:
                            //    base.XMOrderInfoAPIService.getOrderVPH("", "", xmorderInfo.OrderCode, ref VPHInsertCount, ref VPHUpdateCount, XMOrderInfoAppList);
                            //    if (VPHUpdateCount > 0)
                            //    {
                            //        var xMOrderInfoNew = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(XMOrderInfoID));
                            //        //备注内容  用来判断是否已经提单
                            //        string remmarksYTD = xmorderInfo.Remark + xmorderInfo.CustomerServiceRemark;

                            //        //备注内容
                            //        string Remarksstr = "";
                            //        Remarksstr = xMOrderInfoNew.CustomerServiceRemark + "/已提单，" + HozestERPContext.Current.User.SCustomerInfo.FullName;

                            //        if (remmarksYTD.IndexOf("已提单") == -1)
                            //        {
                            //            //修改备注
                            //            int OrderMerchantRemarkUpdateInt = base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(xMOrderInfoNew.OrderCode, Remarksstr, XMOrderInfoAppList);

                            //            if (OrderMerchantRemarkUpdateInt == 1)
                            //            {
                            //                xmorderInfo.CustomerServiceRemark = Remarksstr;
                            //                base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);
                            //            }
                            //        }
                            //    }
                            //    break;
                            #endregion
                        }
                        //原功能只能是待发货状态的订单才能审核，现在取消这个判断
                        //if (!IsAllowAudit(xmorderInfo))
                        //{
                        //    msg += xmorderInfo.OrderCode + ",<br/>";
                        //}

                        //修改审核状态
                        bool IsAudit = false;
                        foreach (XMOrderInfoProductDetails xmpd in xmorderInfo.XM_OrderInfoProductDetails)
                        {
                            xmpd.IsAudit = true;
                            xmpd.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xmpd.UpdateDate = DateTime.Now;
                            if (xmpd.IsAudit == true)
                            {
                                IsAudit = true;
                            }
                        }
                        if(packageChecked)
                        {
                            List<XMOrderInfoProductDetails> list = xmorderInfo.XM_OrderInfoProductDetails.ToList();
                            if(list.Where(a=>a.IsSingleRow==false|| a.IsSingleRow==null).Count()>1&&list.Where(a=>a.Manufacturers== "10601139").Count()==1)
                            {
                                xmorderInfo.IsAudit = false;
                            }
                            else
                            {
                                xmorderInfo.IsAudit = true;
                            }
                        }
                        else
                        {
                            xmorderInfo.IsAudit = true;
                        }
                        xmorderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xmorderInfo.UpdateDate = DateTime.Now;
                        base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);//修改审核状态

                        //操作记录
                        XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                        record1.PropertyName = "IsAudit";
                        record1.OldValue = System.Convert.ToString(IsAudit);

                        record1.NewValue = System.Convert.ToString(true);
                        record1.OrderInfoId = XMOrderInfoID;
                        record1.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        record1.UpdateTime = DateTime.Now;
                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);
                    }
                    else
                    {
                        //if (xmorderInfo.PlatformTypeId.Value == 376)
                        //{
                        //原功能只能是待发货状态的订单才能审核，现在取消这个判断
                        //if (!IsAllowAudit(xmorderInfo))
                        //{
                        //    msg += xmorderInfo.OrderCode + ",<br/>";
                        //}

                        //修改审核状态
                        bool IsAudit = false;
                        foreach (XMOrderInfoProductDetails xmpd in xmorderInfo.XM_OrderInfoProductDetails)
                        {
                            xmpd.IsAudit = true;
                            xmpd.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xmpd.UpdateDate = DateTime.Now;
                            if (xmpd.IsAudit == true)
                            {
                                IsAudit = true;
                            }
                        }
                        if (packageChecked)
                        {
                            List<XMOrderInfoProductDetails> list = xmorderInfo.XM_OrderInfoProductDetails.ToList();
                            if (list.Where(a => a.IsSingleRow == false || a.IsSingleRow == null).Count()>1 && list.Where(a => a.Manufacturers == "10601139").Count() == 1)
                            {
                                xmorderInfo.IsAudit = true;
                            }
                            else
                            {
                                xmorderInfo.IsAudit = false;
                            }
                        }
                        else
                        {
                            xmorderInfo.IsAudit = true;
                        }
                        xmorderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xmorderInfo.UpdateDate = DateTime.Now;
                        base.XMOrderInfoService.UpdateXMOrderInfo(xmorderInfo);//修改 审核状态

                        //操作记录
                        XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                        record1.PropertyName = "IsAudit";
                        record1.OldValue = System.Convert.ToString(IsAudit);
                        record1.NewValue = System.Convert.ToString(true);
                        record1.OrderInfoId = XMOrderInfoID;
                        record1.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        record1.UpdateTime = DateTime.Now;
                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record1);

                        //}
                    }
                }
                if (msg == "")
                {
                    msg = "操作成功";
                }
                return msg;
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\r", "").Replace("\n", "");
                return msg;
            }
        }

        public bool IsAllowAudit(XMOrderInfo Info)
        {
            bool status = false;
            if (Info.PlatformTypeId == 250 || Info.PlatformTypeId == 381)
            {
                if (Info.OrderStatus == "WAIT_SELLER_SEND_GOODS")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 511)
            {
                if (Info.OrderStatus == "DS_WAIT_SELLER_DELIVERY")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 251 || Info.PlatformTypeId == 537 || Info.PlatformTypeId == 382 || Info.PlatformTypeId == 691)
            {
                if (Info.OrderStatus == "WAIT_SELLER_DELIVERY" || Info.OrderStatus == "WAIT_SELLER_STOCK_OUT")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 259)
            {
                if (Info.OrderStatus == "STATUS_10")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 375)
            {
                if (Info.OrderStatus == "ORDER_TRUNED_TO_DO")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 376)
            {
                if (Info.OrderStatus == "以接受")
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 383)
            {
                if (Info.OrderStatus == "10")
                {
                    status = true;
                }
            }

            if (Info.PlatformTypeId == 736)//以后通用订单在这里增加
            {
                if (Info.OrderStatus == "已付款")
                {
                    status = true;
                }
            }
            return status;
        }

        public string ToPlanBillApplication(List<XMApplicationExchange> list, XMOrderInfo Info, XMApplication ApplicationInfo, int WarehouseID, int ProvinceWarehouseID, int type, string msg)
        {
            if (type == 1 || type == 3)
            {
                if (string.IsNullOrEmpty(Info.FullName) || (string.IsNullOrEmpty(Info.Mobile) && string.IsNullOrEmpty(Info.Tel)) ||
                string.IsNullOrEmpty(Info.Province) || string.IsNullOrEmpty(Info.City) || string.IsNullOrEmpty(Info.County) ||
                string.IsNullOrEmpty(Info.DeliveryAddress))
                {
                    msg += "订单:" + Info.OrderCode + " 收货人信息不完整！";
                    return msg;
                }
                bool ProductExist = false;
                if (!GetPlanBillResultApplication(list, Info, null, WarehouseID, type))//排单不成功
                {
                    var MoveCargo = base.XMOrderInfoService.AgreeMoveCargo(null, ApplicationInfo);
                    if (MoveCargo)//允许调货
                    {
                        var SpareList = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByProvinceWarehouseID(WarehouseID);
                        if (SpareList != null && SpareList.Count > 0)
                        {
                            foreach (var item in SpareList)
                            {
                                if (GetPlanBillResultApplication(list, Info, null, (int)item.SpareWarehouseID, type))
                                {
                                    ProductExist = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    ProductExist = true;
                }

                if (!ProductExist)
                {
                    msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                }
            }
            else if (type == 2 || type == 4)
            {
                List<int?> Ids = new List<int?>();
                var IDs = list.Select(x => x.ID).ToList();
                var SpareAddressList = base.XMSpareAddressService.GetXMSpareAddressListByIDs(IDs, 710);
                foreach (var info in list)
                {
                    if (Ids.Contains(info.ID))
                    {
                        continue;
                    }
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 710);
                    if (spareAddress != null)
                    {
                        if (string.IsNullOrEmpty(spareAddress.FullName) || (string.IsNullOrEmpty(spareAddress.Mobile) && string.IsNullOrEmpty(spareAddress.Tel)) ||
                        string.IsNullOrEmpty(spareAddress.Province) || string.IsNullOrEmpty(spareAddress.City) || string.IsNullOrEmpty(spareAddress.County) ||
                        string.IsNullOrEmpty(spareAddress.DeliveryAddress))
                        {
                            msg += "订单:" + Info.OrderCode + " 收货人信息不完整！";
                            break;
                        }

                        //不同产品，相同地址
                        var SpareAddress = SpareAddressList.Where(x => x.FullName == spareAddress.FullName && x.Mobile == spareAddress.Mobile && x.DeliveryAddress == spareAddress.DeliveryAddress).ToList();
                            var OrderInfoProductIds = SpareAddress.Select(x => x.OtherID).ToList();
                            var List = list.Where(x => OrderInfoProductIds.Contains(x.ID)).ToList();
                            Ids.AddRange(OrderInfoProductIds);

                            bool ProductExist = false;
                            if (!GetPlanBillResultApplication(List, Info, spareAddress, WarehouseID, type))//排单不成功
                            {
                                var MoveCargo = base.XMOrderInfoService.AgreeMoveCargo(null, ApplicationInfo);
                                if (MoveCargo)//允许调货
                                {
                                    var SpareList = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByProvinceWarehouseID(WarehouseID);
                                    if (SpareList != null && SpareList.Count > 0)
                                    {
                                        foreach (var item in SpareList)
                                        {
                                            if (GetPlanBillResultApplication(List, Info, spareAddress, (int)item.SpareWarehouseID, type))
                                            {
                                                ProductExist = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ProductExist = true;
                            }

                            if (!ProductExist)
                            {
                                msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                            }
                    }
                }
            }
            return msg;
        }

        public bool GetPlanBillResultApplication(List<XMApplicationExchange> list, XMOrderInfo OrderInfo, XMSpareAddress SpareAddress, int WarehouseID, int type)
        {
            ManufacturersCodeRecord = "";
            bool complete = true;
            HozestERP.BusinessLogic.ManageProject.XMDelivery delivery = ToInsertDeliveryApplication(OrderInfo, SpareAddress, type);
            delivery.XM_Delivery_Details = new List<XMDeliveryDetails>();

            foreach (var info in list)
            {
                if (type == 1 || type == 2)
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseID, info.Manufacturers, "");//喜临门项目判断喜临门当日库存
                    int? CanOrderCount = 0;
                    if (exist.Count > 0)
                    {
                        CanOrderCount = exist[0].Inventory;
                    }
                    if (OrderInfo != null)
                    {
                        string paramProjectid = OrderInfo.ProjectId.ToString();
                        if (paramProjectid != "2")
                        {
                            var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByPorjectID(info.Manufacturers, "", WarehouseID.ToString(), paramProjectid, OrderInfo.ProjectId, -1);//其他项目判断库存管理里面的可订购数量
                            if (inventoryNotNickID2.Count > 0)
                            {
                                CanOrderCount = inventoryNotNickID2[0].CanOrderCount;
                            }
                        }
                    }
                    if (CanOrderCount >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.Manufacturers);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == OrderInfo.CustomerServiceRemark && !string.IsNullOrEmpty(OrderInfo.CustomerServiceRemark))
                        {
                            delivery.OrderRemarks = OrderInfo.CustomerServiceRemark;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetailsApplication(info, OrderInfo.OrderCode, WarehouseID, int.Parse(OrderInfo.PlatformTypeId.ToString())));
                        //减喜临门当日库存
                        if (info != null && OrderInfo.ProjectId == 2)
                        {
                            InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                            XLMInventoryList.Add(exist[0]);
                        }
                        else
                        {
                            var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByPorjectID(info.Manufacturers, "", WarehouseID.ToString(), OrderInfo.ProjectId.ToString(), OrderInfo.ProjectId, -1);//其他项目判断库存管理里面的可订购数量
                            //扣减可订购数量
                            if (inventoryNotNickID2.Count > 0)
                            {
                                inventoryNotNickID2[0].CanOrderCount -= info.ProductNum;
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(inventoryNotNickID2[0]);
                            }
                        }
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.Manufacturers + "，";
                    }
                }

                if (type == 3 || type == 4)//乳胶枕，U型枕，无备用地址
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(693, info.Manufacturers, "");//南方仓库
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.Manufacturers);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetailsApplication(info, OrderInfo.OrderCode, 693, OrderInfo.PlatformTypeId.Value));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.Manufacturers + "，";
                    }
                }
            }

            if (complete == true && delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
            {
                DeliveryList.Add(delivery);
            }

            return complete;
        }

        public HozestERP.BusinessLogic.ManageProject.XMDelivery ToInsertDeliveryApplication(XMOrderInfo Info, XMSpareAddress SpareAddress, int type)
        {
            HozestERP.BusinessLogic.ManageProject.XMDelivery info = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
            info.DeliveryTypeId = 708;//换货
            info.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号;
            info.OrderCode = Info.OrderCode;
            if (type == 1 || type == 3)
            {
                info.FullName = Info.FullName;
                info.Mobile = Info.Mobile;
                info.Tel = Info.Tel;
                info.Province = Info.Province;
                info.City = Info.City;
                info.County = Info.County;
                info.DeliveryAddress = Info.DeliveryAddress;
            }
            else if (type == 2 || type == 4)
            {
                info.FullName = SpareAddress.FullName;
                info.Mobile = SpareAddress.Mobile;
                info.Tel = SpareAddress.Tel;
                info.Province = SpareAddress.Province;
                info.City = SpareAddress.City;
                info.County = SpareAddress.County;
                info.DeliveryAddress = SpareAddress.DeliveryAddress;
            }

            info.OrderRemarks = Info.CustomerServiceRemark;
            info.Shipper = 0;
            info.Price = 0;
            info.PrintBatch = 0;
            info.PrintQuantity = 0;
            info.IsDelivery = false;
            info.IsEnabled = false;
            info.CreateDate = DateTime.Now;
            info.CreateId = HozestERPContext.Current.User.CustomerID;
            info.UpdateDate = DateTime.Now;
            info.UpdateId = HozestERPContext.Current.User.CustomerID;
            return info;
        }

        public XMDeliveryDetails GetDeliveryDetailsApplication(XMApplicationExchange ProductDetails, string OrderCode, int WarehouseID, int PlatformTypeId)
        {
            string PrdouctName = "";
            string Specifications = "";

            XMDeliveryDetails detail = new XMDeliveryDetails();
            //detail.DeliveryId = DeliveryIDType;
            detail.DetailsTypeId = (int)StatusEnum.ApplicationOrder;//换货订单
            detail.OrderNo = OrderCode;
            var ProductDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(ProductDetails.PlatformMerchantCode, PlatformTypeId);
            if (ProductDetail != null && ProductDetail.Count > 0)
            {
                detail.ProductlId = ProductDetail[0].ProductId;
                var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)detail.ProductlId);
                if (product != null)
                {
                    PrdouctName = product.ProductName;
                    Specifications = product.Specifications;
                }
            }
            detail.PlatformMerchantCode = ProductDetails.PlatformMerchantCode;
            detail.PrdouctName = PrdouctName;
            detail.Specifications = Specifications;
            detail.ProductNum = (int)ProductDetails.ProductNum;
            detail.WarehouseID = WarehouseID;
            detail.IsEnabled = false;
            detail.CreateDate = DateTime.Now;
            detail.CreateID = HozestERPContext.Current.User.CustomerID;
            detail.UpdateDate = DateTime.Now;
            detail.UpdateID = HozestERPContext.Current.User.CustomerID;
            //IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(detail);
            return detail;
        }

        public ProvinceWarehouse GetProvinceWarehouseApplication(string Address)
        {
            var WarehouseList = base.ProvinceWarehouseService.GetProvinceWarehouseList();
            foreach (var item in WarehouseList)
            {
                if (Address.StartsWith(item.ProvinceName))
                {
                    return item;
                }
            }
            return null;
        }

        public string XMOrderInfoGroup(XMOrderInfo Info, List<XMOrderInfo> orderInfoList, string msg, bool Multiple, int WarehouseID,bool packageChecked)
        {
            int OrderInfoProductCount = 0;//有效的订单产品条数
            int DeliveryProductCount = 0;//能排单的订单产品条数

            DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
            XLMInventoryList = new List<XMXLMInventory>();
            InventoryList = new List<int>();
            List<XMOrderInfoProductDetails> list_XMOrderInfoProductDetails = new List<XMOrderInfoProductDetails>();
            if(packageChecked)
            {
                list_XMOrderInfoProductDetails = Info.XM_OrderInfoProductDetails.Where(a => a.Manufacturers == "10601139").ToList();
            }
            else
            {
                list_XMOrderInfoProductDetails = Info.XM_OrderInfoProductDetails.ToList();
            }

            List<XMOrderInfoProductDetails> OrderInfoProductUnSpare = new List<XMOrderInfoProductDetails>();//无备用地址产品
            List<XMOrderInfoProductDetails> OrderInfoProductSpare = new List<XMOrderInfoProductDetails>();//有备用地址产品
            List<XMOrderInfoProductDetails> LatexPillowUnSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，无备用地址产品
            List<XMOrderInfoProductDetails> LatexPillowSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，有备用地址产品

            if(Info.FinancialAudit==null|| Info.FinancialAudit==false)
            {
                msg = "订单:" + Info.OrderCode + ",财务未审核";
                return msg;
            }

            if(list_XMOrderInfoProductDetails.Count<=0)
            {
                msg = "订单:" + Info.OrderCode + ",明细为空，不允许排单";
                return msg;
            }

            foreach (var info in list_XMOrderInfoProductDetails)
            {
                if (info.ProductName.IndexOf("床笠") != -1 || info.ProductName.IndexOf("运费") != -1 || info.ProductName.IndexOf("邮费") != -1 || info.ProductName.IndexOf("无产品") != -1)
                {
                    continue;
                }

                if ((bool)info.IsAudit && (info.IsSingleRow == null || !(bool)info.IsSingleRow))
                {
                    OrderInfoProductCount++;
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                    var product = XMProductService.getXMProductByManufacturersCode(info.ManufacturersCode);
                    if(product==null)
                    {
                        msg += "订单:" + Info.OrderCode + "，产品编码：" + info.TManufacturersCode + "的产品不存在！<br/>";
                        return msg;
                    }
                    if (info.ProductName.IndexOf("乳胶枕") != -1 || info.ProductName.IndexOf("U型枕") != -1 || info.ProductName.IndexOf("凝胶枕") != -1)
                    {
                        if (spareAddress != null)
                        {
                            LatexPillowSpare.Add(info);
                        }
                        else
                        {
                            LatexPillowUnSpare.Add(info);
                        }
                    }
                    else
                    {
                        if (spareAddress != null)
                        {
                            OrderInfoProductSpare.Add(info);
                        }
                        else
                        {
                            OrderInfoProductUnSpare.Add(info);
                        }
                    }
                }
                else
                {
                    msg += "订单:" + Info.OrderCode + "，产品编码：" + info.TManufacturersCode + "的产品未审核或已排单！<br/>";
                    return msg;
                }
            }

            if (OrderInfoProductUnSpare.Count > 0)
            {
                msg = ToPlanBill(OrderInfoProductUnSpare, Info, WarehouseID, 1, msg, orderInfoList);//无备用地址产品
            }
            if (LatexPillowUnSpare.Count > 0)
            {
                msg = ToPlanBill(LatexPillowUnSpare, Info, WarehouseID, 3, msg, orderInfoList);//乳胶枕，U型枕，无备用地址产品
            }
            if (OrderInfoProductSpare.Count > 0)
            {
                msg = ToPlanBill(OrderInfoProductSpare, Info, WarehouseID, 2, msg, orderInfoList);//有备用地址产品
            }
            if (LatexPillowSpare.Count > 0)
            {
                msg = ToPlanBill(LatexPillowSpare, Info, WarehouseID, 4, msg, orderInfoList);//乳胶枕，U型枕，有备用地址产品
            }

            foreach (var item in DeliveryList)
            {
                if (item.XM_Delivery_Details != null && item.XM_Delivery_Details.Count > 0)
                {
                    DeliveryProductCount += item.XM_Delivery_Details.Count;
                }
            }

            if (OrderInfoProductCount > 0 && OrderInfoProductCount == DeliveryProductCount)
            {
                foreach (var item in DeliveryList)
                {
                    if (!Multiple)
                    {
                        base.XMDeliveryService.InsertXMDelivery(item);
                    }
                    else
                    {
                        SpareDeliveryList.Add(item);
                    }
                }


                //订单产品排单状态变为true
                foreach (var info in list_XMOrderInfoProductDetails)
                {
                    if (!Multiple)
                    {
                        info.IsSingleRow = true;
                        info.UpdateDate = DateTime.Now;
                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(info);
                    }
                    else
                    {
                        SpareOrderInfoProductList.Add(info);
                    }
                }
                //减喜临门当日库存
                for (int i = 0; i < XLMInventoryList.Count; i++)
                {
                    if (Multiple)
                    {
                        XMXLMInventory a = new XMXLMInventory();
                        a.ID = XLMInventoryList[i].ID;
                        a.Inventory = XLMInventoryList[i].Inventory - InventoryList[i];
                        SpareXLMInventoryList.Add(a);
                    }
                    XLMInventoryList[i].Inventory = InventoryList[i];
                    base.XMXLMInventoryService.UpdateXMXLMInventory(XLMInventoryList[i]);
                }
                //操作记录
                XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                record.PropertyName = "批量手动排单";
                record.OldValue = "IsSingleRow - false";
                record.NewValue = "IsSingleRow - true";
                record.OrderInfoId = Info.ID;
                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                record.UpdateTime = DateTime.Now;
                if (!Multiple)
                {
                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                }
                else
                {
                    SpareRecordList.Add(record);
                }
            }
            return msg;
        }

        public string ToPlanBill(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, int WarehouseID, int type, string msg, List<XMOrderInfo> orderInfoList)
        {
            if (type == 1 || type == 3)
            {
                if (string.IsNullOrEmpty(Info.FullName) || (string.IsNullOrEmpty(Info.Mobile) && string.IsNullOrEmpty(Info.Tel)) ||
                        string.IsNullOrEmpty(Info.Province) || string.IsNullOrEmpty(Info.City) || string.IsNullOrEmpty(Info.County) ||
                        string.IsNullOrEmpty(Info.DeliveryAddress))
                {
                    msg += "订单:" + Info.OrderCode+" 收货人信息不完整！";
                    return msg;
                }
                if (GetPlanBillResult(list, Info, null, WarehouseID, type, orderInfoList))//排单成功
                {
                    if (orderInfoList.Where(x => x.Mobile == Info.Mobile).ToList().Count > 1 && msg.IndexOf("顾客: " + Info.FullName) == -1)
                    {
                        msg += "<—————————— 顾客: " + Info.FullName
                            + "，有多个订单参与排单，请注意！——————————> <br/>";
                    }
                }
                else
                {
                    MultipleUpdate = false;
                    msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                }
            }
            else if (type == 2 || type == 4)
            {
                List<int?> Ids = new List<int?>();
                var IDs = list.Select(x => x.ID).ToList();
                var SpareAddressList = base.XMSpareAddressService.GetXMSpareAddressListByIDs(IDs, 709);
                foreach (var info in list)
                {
                    if (Ids.Contains(info.ID))
                    {
                        continue;
                    }
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                    if (spareAddress != null)
                    {
                        if (string.IsNullOrEmpty(spareAddress.FullName) || (string.IsNullOrEmpty(spareAddress.Mobile) && string.IsNullOrEmpty(spareAddress.Tel)) ||
                        string.IsNullOrEmpty(spareAddress.Province) || string.IsNullOrEmpty(spareAddress.City) || string.IsNullOrEmpty(spareAddress.County) ||
                        string.IsNullOrEmpty(spareAddress.DeliveryAddress))
                        {
                            msg += "订单:" + Info.OrderCode + " 收货人信息不完整！";
                            break;
                        }
                        //不同产品，相同地址
                        var SpareAddress = SpareAddressList.Where(x => x.FullName == spareAddress.FullName && x.Mobile == spareAddress.Mobile && x.DeliveryAddress == spareAddress.DeliveryAddress).ToList();
                        var OrderInfoProductIds = SpareAddress.Select(x => x.OtherID).ToList();
                        var List = list.Where(x => OrderInfoProductIds.Contains(x.ID)).ToList();
                        Ids.AddRange(OrderInfoProductIds);

                        if (GetPlanBillResult(List, Info, spareAddress, WarehouseID, type, orderInfoList))//排单不成功
                        {
                            if (orderInfoList.Where(x => x.Mobile == Info.Mobile).ToList().Count > 1 && msg.IndexOf("顾客: " + Info.FullName) == -1)
                            {
                                msg += "<—————————— 顾客: " + Info.FullName
                                    + "，有多个订单参与排单，请注意！——————————> <br/>";
                            }
                        }
                        else
                        {
                            MultipleUpdate = false;
                            msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                        }
                    }
                }
            }
            return msg;
        }

        public bool GetPlanBillResult(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, XMSpareAddress SpareAddress, int WarehouseID, int type, List<XMOrderInfo> orderInfoList)
        {
                ManufacturersCodeRecord = "";
                bool complete = true;
                HozestERP.BusinessLogic.ManageProject.XMDelivery delivery = ToInsertDelivery(Info, SpareAddress, type, orderInfoList);
                delivery.XM_Delivery_Details = new List<XMDeliveryDetails>();

                foreach (var info in list)
                {
                    if (type == 1 || type == 2)
                    {
                        var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseID, info.TManufacturersCode, "");//喜临门项目判断喜临门当日库存
                        int? CanOrderCount = 0;
                        if (exist.Count > 0)
                        {
                            CanOrderCount = exist[0].Inventory;
                        }
                        if (orderInfoList.Count > 0)
                        {
                            string paramProjectid = orderInfoList[0].ProjectId.ToString();
                            if (paramProjectid != "2")
                            {
                                var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByPorjectID(info.TManufacturersCode, "", WarehouseID.ToString(), paramProjectid, orderInfoList[0].ProjectId, -1);//其他项目判断库存管理里面的可订购数量
                                if (inventoryNotNickID2.Count > 0)
                                {
                                    CanOrderCount = inventoryNotNickID2[0].CanOrderCount;
                                }
                            }
                            //喜临门临时使用
                            if (info.TManufacturersCode == "10105808" || info.TManufacturersCode == "10105807" || info.TManufacturersCode == "10105804")
                            {
                                var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByPorjectID(info.TManufacturersCode, "", WarehouseID.ToString(), paramProjectid, orderInfoList[0].ProjectId, -1);//其他项目判断库存管理里面的可订购数量
                                if (inventoryNotNickID2.Count > 0)
                                {
                                    CanOrderCount = inventoryNotNickID2[0].CanOrderCount;
                                }
                            }
                            //喜临门临时使用
                        }
                        if (CanOrderCount >= info.ProductNum)
                        {
                            if (delivery.Shipper == 0)
                            {
                                var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                                if (product != null && product.Count > 0)
                                {
                                    delivery.Shipper = product[0].Shipper;
                                }
                            }

                            if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                            {
                                delivery.OrderRemarks = info.SpareRemarks;
                            }

                            delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, WarehouseID));
                            //减喜临门当日库存                                             //下一行的这些判断是喜临门临时使用
                            if (orderInfoList.Count > 0 && orderInfoList[0].ProjectId == 2 && info.TManufacturersCode != "10105808" && info.TManufacturersCode != "10105807" && info.TManufacturersCode != "10105804")
                            {
                                InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                                XLMInventoryList.Add(exist[0]);
                            }
                            else
                            {
                                var inventoryNotNickID2 = base.XMInventoryInfoService.GetXMInventoryInfoByPorjectID(info.TManufacturersCode, "", WarehouseID.ToString(), orderInfoList[0].ProjectId.ToString(), orderInfoList[0].ProjectId, -1);//其他项目判断库存管理里面的可订购数量
                                //扣减可订购数量
                                if (inventoryNotNickID2.Count > 0)
                                {
                                    inventoryNotNickID2[0].CanOrderCount -= info.ProductNum;
                                    base.XMInventoryInfoService.UpdateXMInventoryInfo(inventoryNotNickID2[0]);
                                }
                            }
                        }
                        else
                        {
                            complete = false;
                            ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                        }
                    }

                    if (type == 3 || type == 4)//乳胶枕，U型枕，无备用地址
                    {
                        var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(693, info.TManufacturersCode, "");//南方仓库
                        if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                        {
                            if (delivery.Shipper == 0)
                            {
                                var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                                if (product != null && product.Count > 0)
                                {
                                    delivery.Shipper = product[0].Shipper;
                                }
                            }

                            if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                            {
                                delivery.OrderRemarks = info.SpareRemarks;
                            }
                            delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, 693));
                            //减喜临门当日库存
                            InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                            XLMInventoryList.Add(exist[0]);
                        }
                        else
                        {
                            complete = false;
                            ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                        }
                    }
                }

                if (complete == true && delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
                {
                    DeliveryList.Add(delivery);
                }
                return complete;
        }

        /// <summary>
        /// 创建出库单
        /// </summary>
        public void CreateSaleDelivery(int deliveryid,int orderid) 
        {
            string msg = "";
            bool isExist = false;
            string errMessage = "";
            List<int> Ids = new List<int>();
            string WareHourses = this.ddlWareHourses.SelectedValue;
            Ids.Add(orderid);
            var list = base.XMOrderInfoService.GetXMOrderInfoListByIds(Ids);
            //已下注释代码，原来是判断单唯一性，实际情况无法做到唯一
            //if (list != null && list.Count > 0)
            //{
            //    foreach (var info in list)
            //    {
            //        var saleDeliverys = base.XMSaleDeliveryService.GetXMSaleDeliveryListByOrderInfoID(info.ID);
            //        if (saleDeliverys != null && saleDeliverys.Count > 0)
            //        {
            //            isExist = true;
            //            errMessage = errMessage + " " + info.OrderCode;
            //            break;
            //        }
            //    }
            //}
            ////订单对应的出库单已经存在，无法再次生成出库单
            //if (isExist && Session["SaveApplicationIds"] == null)
            //{
            //    base.ShowMessage("订单号为：" + errMessage + "的订单出库单已经存在，操作失败！");
            //    return;
            //}


            if (list != null && list.Count > 0)
            {
                foreach (var info in list)
                {
                    bool OldValue = info.IsAudit == null ? false : (bool)info.IsAudit;
                    decimal Total = 0;
                    XMSaleDelivery Item = new XMSaleDelivery();
                    Item.XM_SaleDeliveryProductDetails = new List<XMSaleDeliveryProductDetails>();
                    List<XMDeliveryDetails> paramXMDeliveryDetails = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(deliveryid);
                    foreach (var detail in paramXMDeliveryDetails)
                    {
                        XMSaleDeliveryProductDetails details = new XMSaleDeliveryProductDetails();
                        var productDetail = base.XMProductService.GetXMProductListByPlatformMerchantCode(detail.PlatformMerchantCode, (int)info.PlatformTypeId);
                        details.SaleCount = detail.ProductNum;
                        if (productDetail != null && productDetail.Count > 0)
                        {
                            var product = base.XMProductService.GetXMProductById(productDetail[0].ProductId.Value);
                            if (product != null)
                            {
                                details.PlatformMerchantCode = product.ManufacturersCode;
                                details.ProductId = product.Id;
                            }
                            details.ProductPrice = productDetail[0].Saleprice;
                            details.ProductMoney = details.ProductPrice * details.SaleCount;
                        }
                        Total += details.ProductMoney == null ? 0 : (decimal)details.ProductMoney;
                        details.IsEnable = false;
                        details.UpdateDate = details.CreateDate = DateTime.Now;
                        details.UpdateID = details.CreateID = HozestERPContext.Current.User.CustomerID;
                        Item.XM_SaleDeliveryProductDetails.Add(details);
                    }

                    #region  自动生成销售出货单号
                    string SaleDeliveryCode = "";
                    int number = 1;
                    var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryList();
                    if (saleDelivery != null && saleDelivery.Count > 0)
                    {
                        number = saleDelivery[0].Id + 1;
                    }
                    SaleDeliveryCode = "SD" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
                    #endregion

                    Item.Ref = SaleDeliveryCode;
                    Item.SaleInfoId = 0;
                    Item.OrderInfoID = info.ID;
                    Item.WareHouseId = int.Parse(WareHourses);
                    Item.BillStatus = 0;
                    Item.SaleMoney = Total;
                    Item.ReceivingType = 701;//支付宝
                    Item.Remarks = info.CustomerServiceRemark;
                    Item.BizUserId = HozestERPContext.Current.User.CustomerID;
                    Item.BizDt = DateTime.Now;
                    Item.IsEnable = false;
                    Item.IsAudit = false;
                    Item.UpdateDate = Item.CreateDate = DateTime.Now;
                    Item.UpdateID = Item.CreateID = HozestERPContext.Current.User.CustomerID;
                    Item.DeliveryID = deliveryid;
                    base.XMSaleDeliveryService.InsertXMSaleDelivery(Item);
                }

                if (msg != "")
                {
                    base.ShowMessage(msg);
                    return;
                }
            }
        }

        public HozestERP.BusinessLogic.ManageProject.XMDelivery ToInsertDelivery(XMOrderInfo Info, XMSpareAddress SpareAddress, int type, List<XMOrderInfo> orderInfoList)
        {
            HozestERP.BusinessLogic.ManageProject.XMDelivery info = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
            info.DeliveryTypeId = 480;//正常
            info.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号;
            info.OrderCode = Info.OrderCode;

            if (type == 1 || type == 3)
            {
                info.FullName = Info.FullName;
                info.Mobile = Info.Mobile;
                info.Tel = Info.Tel;
                info.Province = Info.Province;
                info.City = Info.City;
                info.County = Info.County;
                info.DeliveryAddress = Info.DeliveryAddress;
            }
            else if (type == 2 || type == 4)
            {
                info.FullName = SpareAddress.FullName;
                info.Mobile = SpareAddress.Mobile;
                info.Tel = SpareAddress.Tel;
                info.Province = SpareAddress.Province;
                info.City = SpareAddress.City;
                info.County = SpareAddress.County;
                info.DeliveryAddress = SpareAddress.DeliveryAddress;
            }

            info.OrderRemarks = Info.CustomerServiceRemark;
            info.Shipper = 0;
            info.Price = 0;
            info.PrintBatch = 0;
            info.PrintQuantity = 0;
            info.IsDelivery = false;
            info.IsEnabled = false;
            info.CreateDate = DateTime.Now;
            info.CreateId = HozestERPContext.Current.User.CustomerID;
            info.UpdateDate = DateTime.Now;
            info.UpdateId = HozestERPContext.Current.User.CustomerID;
            //base.XMDeliveryService.InsertXMDelivery(info);
            return info;
        }

        public XMDeliveryDetails GetDeliveryDetails(XMOrderInfoProductDetails ProductDetails, string OrderCode, int WarehouseID)
        {
            string PrdouctName = "";
            string Specifications = "";

            XMDeliveryDetails detail = new XMDeliveryDetails();
            //detail.DeliveryId = DeliveryIDType;
            detail.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
            detail.OrderNo = OrderCode;

            var ProductDetail = IoC.Resolve<IXMProductDetailsService>().GetXMProductDetailsByPlatformMerchantCode(ProductDetails.PlatformMerchantCode, (int)ProductDetails.XM_OrderInfo.PlatformTypeId);
            if (ProductDetail != null && ProductDetail.Count > 0)
            {
                detail.ProductlId = ProductDetail[0].ProductId;
                var product = IoC.Resolve<IXMProductService>().GetXMProductById((int)detail.ProductlId);
                if (product != null)
                {
                    PrdouctName = product.ProductName;
                    Specifications = product.Specifications;
                }
            }

            detail.PlatformMerchantCode = ProductDetails.PlatformMerchantCode;
            detail.PrdouctName = PrdouctName;
            detail.Specifications = Specifications;
            detail.ProductNum = (int)ProductDetails.ProductNum;
            detail.WarehouseID = WarehouseID;
            detail.IsEnabled = false;
            detail.CreateDate = DateTime.Now;
            detail.CreateID = HozestERPContext.Current.User.CustomerID;
            detail.UpdateDate = DateTime.Now;
            detail.UpdateID = HozestERPContext.Current.User.CustomerID;
            //IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(detail);
            return detail;
        }

        #region
        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
        #endregion

        public string Type
        {
            get
            {
                return CommonHelper.QueryString("From");
            }
        }
    }
}