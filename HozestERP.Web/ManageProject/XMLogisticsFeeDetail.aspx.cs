using Ext.Net;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Codes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace HozestERP.Web.ManageProject
{
    public partial class XMLogisticsFeeDetail : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                string OrderID = CommonHelper.QueryString("ID");
                string[] status = new string[] { "TRADE_FINISHED", "TRADE_CLOSED", "TRADE_CLOSED_BY_TAOBAO",
                "FINISHED_L","TRADE_CANCELED","FINISHED_L","TRADE_CANCELED","STATUS_97","STATUS_25",
                "ORDER_FINISH","ORDER_CANCEL","已取消","30","40","DS_DEAL_END_NORMAL","已完成"};

                XMOrderInfo entityOrderInfo = XMOrderInfoService.GetXMOrderInfoByID(int.Parse(OrderID));
                if(status.Contains(entityOrderInfo.OrderStatus))
                {
                    btn_SaveClick.Enabled = false;
                    btn_ReCalculateClick.Enabled = false;
                }
            }
        }

        protected void btnSave_Click(object sender, DirectEventArgs e)
        {
            decimal fee = decimal.Parse(numPrice.Text);
            string note = taNote.Text;
            string OrderID = CommonHelper.QueryString("ID");

            BusinessLogic.ManageProject.XMLogisticsFeeDetail model = new BusinessLogic.ManageProject.XMLogisticsFeeDetail();
            model.OrderID = int.Parse(OrderID);
            model.Type = 3;
            model.Fee = fee;
            model.Note = note;
            model.CreateID = HozestERPContext.Current.User.CustomerID;
            model.CreateDate = DateTime.Now;

            XMLogisticsFeeDetailService.InsertXMLogisticsFeeDetail(model);
        }

        protected void btnEdit_Click(object sender, DirectEventArgs e)
        {
            int ID = int.Parse(selectID.Text);
            BusinessLogic.ManageProject.XMLogisticsFeeDetail entity = XMLogisticsFeeDetailService.GetXMLogisticsFeeDetailByID(ID);
            entity.Fee = decimal.Parse(numPrice.Text);
            entity.Note = taNote.Text;
            entity.UpdateID = HozestERPContext.Current.User.CustomerID;
            entity.UpdateDate = DateTime.Now;

            XMLogisticsFeeDetailService.UpdateXMLogisticsFeeDetail(entity);
        }

        protected void rowCommand(object sender, DirectEventArgs e)
        {
            int ID = int.Parse(e.ExtraParams["ID"]);
            BusinessLogic.ManageProject.XMLogisticsFeeDetail entity = XMLogisticsFeeDetailService.GetXMLogisticsFeeDetailByID(ID);
            if (entity == null)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "数据记录不存在").Show();
                return;
            }

            XMLogisticsFeeDetailService.DeleteXMLogisticsFeeDetail(ID);
        }

        protected void btnCalculate_Click(object sender, DirectEventArgs e)
        {
            string OrderID = CommonHelper.QueryString("ID");

            XMOrderInfo entity_Order = XMOrderInfoService.GetXMOrderInfoByID(int.Parse(OrderID));
            if (entity_Order == null)
            {
                ExtNet.Msg.Alert("提示", "订单信息不存在").Show();
                return;
            }

            XMProject entity_Project = XMProjectService.GetXMProjectById(entity_Order.ProjectId);
            if (entity_Project == null)
            {
                ExtNet.Msg.Alert("提示", "项目信息不存在").Show();
                return;
            }

            if (entity_Project.ProjectName == "曲美")
            {
                //干线费用
                decimal mainMoney = 0;
                //支线费用
                decimal branchMoney = 0;
                string province = entity_Order.Province;
                string city = entity_Order.City;
                string region = entity_Order.County;
                string[] mes = entity_Order.CustomerServiceRemark.Split(new string[] { "///" }, StringSplitOptions.RemoveEmptyEntries);
                if (mes.Count() <= 0)
                {
                    ExtNet.Msg.Alert("提示", "解析错误").Show();
                    return;
                }
                string[] mes1 = mes[0].Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
                if (mes1.Count() <= 0)
                {
                    ExtNet.Msg.Alert("提示", "解析错误").Show();
                    return;
                }
                //查询干线物流公司信息
                List<CodeList> codeList = CodeService.GetCodeListInfoByCodeTypeIDAndCodeName(243, mes1[0]);
                if (codeList.Count<=0)
                {
                    ExtNet.Msg.Alert("提示", "找不到干线物流公司信息").Show();
                    return;
                }

                int logisticsMainID = codeList[0].CodeID;
                //查询干线物流单价费率
                BusinessLogic.ManageProject.XMLogisticsFeeMain entityMain = XMLogisticsFeeMainService.
                getSingle(a => a.ProjectID == entity_Project.Id && a.WareHouseID == 758 && province.StartsWith(a.Province) && city.StartsWith(a.City) && region.StartsWith(a.Area) && a.LogisticsID == logisticsMainID);
                if (entityMain == null)
                {
                    ExtNet.Msg.Alert("提示", "找不到对应干线单价费率").Show();
                    return;
                }

                //只计算干线费用
                if (mes1.Count() == 1)
                {
                    //对应干线单价费率
                    decimal main = (decimal)entityMain.Fee;

                    List<XMOrderInfoProductDetails> list_OrderProductDetails = XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsList(entity_Order.ID);
                    foreach (var item in list_OrderProductDetails)
                    {
                        string ProductVolume = string.IsNullOrEmpty(item.ProductVolume) ? "0" : item.ProductVolume;
                        mainMoney = mainMoney + main * decimal.Parse(ProductVolume) * (int)item.ProductNum;
                    }
                }
                //计算干线和支线费用
                else if (mes1.Count() == 2)
                {
                    //对应干线单价费率
                    decimal main = (decimal)entityMain.Fee;
                    //查询支线物流公司信息
                    List<CodeList> codeList1 = CodeService.GetCodeListInfoByCodeTypeIDAndCodeName(244, mes1[1]);
                    if (codeList.Count<=0)
                    {
                        ExtNet.Msg.Alert("提示", "找不到支线物流公司信息").Show();
                        return;
                    }

                    List<XMOrderInfoProductDetails> list_OrderProductDetails = XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsList(entity_Order.ID);
                    foreach (var item in list_OrderProductDetails)
                    {
                        //对应支线单价费率
                        decimal Branch = 0;
                        XMProduct entityProduct = XMProductService.getXMProductByManufacturersCode(item.TManufacturersCode);
                        XMProductDetails entityProductDetails = XMProductDetailsService.GetXMProductDetailsListByProductId(entityProduct.Id)[0];
                        //查询支线物流单价费率
                        int logisticsBranchID = codeList1[0].CodeID;
                        BusinessLogic.ManageProject.XMLogisticsFeeBranch entityBranch = XMLogisticsFeeBranchService.
                            getSingle(a=>a.ProjectID== entity_Project.Id&&a.LogisticsID== logisticsBranchID && a.ProductCategoryID== entityProductDetails.ProductTypeId);
                        if (entityBranch == null)
                        {
                            ExtNet.Msg.Alert("提示", "找不到对应支线单价费率").Show();
                            return;
                        }

                        Branch = (decimal)entityBranch.Fee;
                        //商品体积
                        string ProductVolume = string.IsNullOrEmpty(entityProduct.ProductVolume) ? "0" : entityProduct.ProductVolume;
                        mainMoney = mainMoney + main * decimal.Parse(ProductVolume)*(int)item.ProductNum;
                        branchMoney = branchMoney + Branch*(int)item.ProductNum;
                    }
                }
                //事务
                using (TransactionScope scope = new TransactionScope())
                {
                    List<BusinessLogic.ManageProject.XMLogisticsFeeDetail> list = XMLogisticsFeeDetailService.getList(a => a.Type != 3);
                    foreach (var item in list)
                    {
                        XMLogisticsFeeDetailService.delete(item);
                    }

                    if(mainMoney>=0)
                    {
                        XMLogisticsFeeDetailService.InsertXMLogisticsFeeDetail(new BusinessLogic.ManageProject.XMLogisticsFeeDetail()
                        {
                            OrderID= entity_Order.ID,
                            Type=1,
                            Fee= mainMoney,
                            CreateID=HozestERPContext.Current.User.CustomerID,
                            CreateDate=DateTime.Now,
                        });
                    }
                    if(branchMoney>=0)
                    {
                        XMLogisticsFeeDetailService.InsertXMLogisticsFeeDetail(new BusinessLogic.ManageProject.XMLogisticsFeeDetail()
                        {
                            OrderID = entity_Order.ID,
                            Type=2,
                            Fee = branchMoney,
                            CreateID = HozestERPContext.Current.User.CustomerID,
                            CreateDate = DateTime.Now,
                        });
                    }

                    scope.Complete();
                }
            }
            else
            {
                ExtNet.Msg.Alert("提示", "不在计算范围内").Show();
                return;
            }

        }
    }
}