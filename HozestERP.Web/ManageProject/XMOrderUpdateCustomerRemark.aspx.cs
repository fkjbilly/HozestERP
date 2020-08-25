using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderUpdateCustomerRemark : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //提示信息
                    string paramMessage = "";
                    //卖家备注
                    string CustomerServiceRemarkNew = this.txtCustomerRemark.Text.Trim();
                    //买家备注 
                    string Remark = this.txtRemark.Text.Trim();

                    var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(OrderCode);
                    if (xMOrderInfo != null)
                    {
                        string CustomerServiceRemarkOld = "";
                        //修改之前的客服备注信息
                        if (xMOrderInfo.CustomerServiceRemark != null)
                            CustomerServiceRemarkOld = xMOrderInfo.CustomerServiceRemark.Trim();

                        if (xMOrderInfo.CustomerServiceRemark != CustomerServiceRemarkNew)
                        {
                            XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                            record.PropertyName = "客服备注";
                            record.OldValue = CustomerServiceRemarkOld;
                            record.NewValue = CustomerServiceRemarkNew;
                            record.OrderInfoId = xMOrderInfo.ID;
                            record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            record.UpdateTime = DateTime.Now;
                            base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                        }
                        xMOrderInfo.Remark = Remark;
                        xMOrderInfo.CustomerServiceRemark = CustomerServiceRemarkNew;
                        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMOrderInfo.UpdateDate = DateTime.Now;
                        //base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);

                        #region  判断是否刷单
                        bool IsScalping = false;
                        //刷单关键词
                        var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(191, false);
                        if (codeList.Count > 0)
                        {
                            for (int cl = 0; cl < codeList.Count; cl++)
                            {
                                string CodeName = "";
                                CodeName = codeList[cl].CodeName.Trim();
                                if (CustomerServiceRemarkNew.IndexOf(CodeName) > -1)
                                {
                                    IsScalping = true;
                                }
                                if (Remark.IndexOf(CodeName) > -1)
                                {
                                    IsScalping = true;
                                }
                            }
                            #region 有返回刷单关键字

                            if (IsScalping == true)
                            {
                                //根据订单号查询刷单记录 
                                List<XMScalping> xmScalpingList = base.XMScalpingService.GetXMScalpingByOrderCode(OrderCode);

                                if (xmScalpingList.Count == 0)
                                {
                                    string ProductName = "";
                                    var xMOrderInfoProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderCode(OrderCode);
                                    if (xMOrderInfoProductDetails.Count > 0)
                                    {
                                        ProductName = xMOrderInfoProductDetails[0].ProductName;
                                    }

                                    #region 根据店铺Id查询项目  再根据项目Id、平台类型Id查询扣点

                                    int ProjectId = 0;
                                    //根据店铺Id查询  取项目Id
                                    var XMNick = base.XMNickService.GetXMNickByID((int)xMOrderInfo.NickID);
                                    if (XMNick != null)
                                    {
                                        if (XMNick.ProjectId != null)
                                        {
                                            ProjectId = XMNick.ProjectId.Value;
                                        }
                                    }
                                    //根据项目Id 平台类型查询 扣点 
                                    var xMDeductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(ProjectId, 475, (int)xMOrderInfo.PlatformTypeId);


                                    #endregion

                                    XMScalping xmScalping = new XMScalping();

                                    xmScalping.PlatformTypeId = (int)xMOrderInfo.PlatformTypeId;
                                    xmScalping.NickId = (int)xMOrderInfo.NickID;
                                    xmScalping.OrderCode = OrderCode;
                                    xmScalping.WantID = xMOrderInfo.WantID;
                                    xmScalping.ProductName = ProductName;
                                    xmScalping.SalePrice = Convert.ToDecimal(xMOrderInfo.PayPrice == null ? 0 : xMOrderInfo.PayPrice);
                                    xmScalping.Fee = 0;
                                    if (xMDeductionSetUp != null)
                                    {
                                        //计算扣点
                                        if (xMDeductionSetUp.Deduction != null)
                                        {
                                            decimal DeductionD = xMDeductionSetUp.Deduction.Value / 100;

                                            xmScalping.Deduction = Convert.ToDecimal(xMOrderInfo.PayPrice == null ? 0 : xMOrderInfo.PayPrice) * DeductionD;//扣点
                                        }
                                    }
                                    else
                                    {
                                        xmScalping.Deduction = 0;//扣点
                                    }
                                    xmScalping.IsAbnormal = false;
                                    xmScalping.IsEnable = false;
                                    xmScalping.CreateID = HozestERPContext.Current.User.CustomerID;
                                    xmScalping.CreateDate = DateTime.Now;
                                    xmScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    xmScalping.UpdateDate = DateTime.Now;
                                    base.XMScalpingService.InsertXMScalping(xmScalping);
                                }
                                xMOrderInfo.IsScalping = IsScalping;
                            }
                            #endregion
                        }

                        #endregion

                        #region 赠品新增、修改;返现新增、修改 ;订单信息修改

                        //原赠品信息
                        string PremiumsOld = "";
                        //新赠品信息
                        string PremiumsNew = "";
                        //原返现信息 
                        string CashBackOld = "";
                        //新返现信息
                        string CashBackNew = "";
                        //返回赠品条数
                        int PremiumsInst = 0;
                        //返回返现条数
                        int CashBackInst = 0;

                        //判断备注信息中 赠品、返现信息是否修改过
                        if (CustomerServiceRemarkOld != CustomerServiceRemarkNew)
                        {
                            #region 原赠品信息
                            string strOld = "";
                            if (CustomerServiceRemarkOld.IndexOf("/赠品") > -1)
                            {
                                strOld = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/赠品") + 3).Trim();
                            }
                            int fOld = strOld.IndexOf("/");
                            if (fOld > -1)
                            {
                                PremiumsOld = strOld.Substring(0, fOld).Trim();
                            }
                            #endregion

                            #region 新赠品信息
                            string strNew = "";
                            if (CustomerServiceRemarkNew.IndexOf("/赠品") > -1)
                            {
                                strNew = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/赠品") + 3).Trim();
                            }
                            int fNew = strNew.IndexOf("/");
                            if (fNew > -1)
                            {
                                PremiumsNew = strNew.Substring(0, fNew).Trim();
                            }
                            #endregion

                            #region 赠品信息新增、修改

                            //根据订单号、赠品类型：赠品  查询 赠品申请表
                            List<XMPremiums> PremiumsList = base.XMPremiumsService.GetXMPremiumsListByOrderCode(OrderCode, (int)StatusEnum.ChildPremiums);

                            if (PremiumsOld != PremiumsNew)
                            {
                                //赠品表中已经存在赠品信息
                                if (PremiumsList.Count > 0)
                                {
                                    var AlreadyCheckList = PremiumsList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();
                                    //赠品信息项目已审核 （不允许修改）
                                    if (AlreadyCheckList.Count > 0)
                                    {
                                        paramMessage = "订单号：" + OrderCode + "赠品信息已审核,不允许修改赠品内容.";

                                        base.ShowMessage(paramMessage);
                                        return;
                                    }
                                    //修改赠品信息
                                    else
                                    {
                                        //返回赠品条数
                                        PremiumsInst = base.XMOrderInfoAPIService.XMPremiumsInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, (int)StatusEnum.ChildPremiums, ref paramMessage, (int)xMOrderInfo.PlatformTypeId, (int)xMOrderInfo.NickID);
                                    }
                                }
                                else
                                {
                                    //赠品表中不存在 （订单信息） 
                                    //返回赠品条数
                                    PremiumsInst = base.XMOrderInfoAPIService.XMPremiumsInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, (int)StatusEnum.ChildPremiums, ref paramMessage, (int)xMOrderInfo.PlatformTypeId, (int)xMOrderInfo.NickID);
                                }
                            }
                            //最新的返现信息 为空
                            if (PremiumsNew == "")
                            {
                                if (PremiumsList.Count > 0)
                                {
                                    if (PremiumsList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                    {
                                        //删除原返现信息
                                        base.XMPremiumsService.DeleteXMPremiums(PremiumsList[0].Id);
                                    }
                                }
                            }
                            #endregion

                            if (xMOrderInfo.PlatformTypeId.Value == 250)
                            {
                                #region 原返现信息
                                string strCBOld = "";
                                if (CustomerServiceRemarkOld.IndexOf("/退差价") > -1)
                                {
                                    strCBOld = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/退差价")).Trim();
                                }
                                string BuyerAlipayNoOld = "";//账号信息
                                string BuyerNameOld = "";// 收款人账号

                                if ((CustomerServiceRemarkOld.IndexOf("/支付宝") > -1 || CustomerServiceRemarkOld.IndexOf("/卡号") > -1))
                                {
                                    if (CustomerServiceRemarkOld.IndexOf("/支付宝") > -1)
                                    {
                                        string a = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/支付宝") + 1).Trim();
                                        if (a.IndexOf("/") > 0)
                                        {
                                            int I2 = a.IndexOf("/");
                                            BuyerAlipayNoOld = a.Substring(0, I2);
                                        }
                                    }
                                    else if (CustomerServiceRemarkOld.IndexOf("/卡号") > -1)
                                    {
                                        string b = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/卡号") + 1).Trim();
                                        if (b.IndexOf("/") > 0)
                                        {
                                            int I = b.IndexOf("/");
                                            BuyerAlipayNoOld = b.Substring(0, I);
                                        }

                                    }
                                    if (BuyerAlipayNoOld != "")
                                    {
                                        int length = BuyerAlipayNoOld.Length + 1;
                                        string c = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf(BuyerAlipayNoOld) + length);
                                        //订单备注信息中 收货人后面有/
                                        int I3 = c.IndexOf("/");
                                        if (I3 > -1)
                                        {
                                            BuyerNameOld = c.Substring(0, I3);
                                        }
                                    }
                                }
                                //账号信息、收款人账号 都不为空
                                if ((BuyerAlipayNoOld != "" && BuyerNameOld != "") || (BuyerAlipayNoOld == "" && BuyerNameOld != ""))
                                {
                                    int f = strCBOld.IndexOf(BuyerNameOld);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackOld = strCBOld.Substring(0, f + BuyerNameOld.Length);
                                    }
                                }
                                else if (BuyerAlipayNoOld != "" && BuyerNameOld == "")
                                {
                                    int f = strCBOld.IndexOf(BuyerAlipayNoOld);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackOld = strCBOld.Substring(0, f + BuyerAlipayNoOld.Length);
                                    }
                                }
                                else
                                {
                                    int f = strCBOld.IndexOf("元/");

                                    if (f > -1)
                                    {
                                        CashBackOld = strCBOld.Substring(0, f + 2);//OrderRemark.Substring(OrderRemark.IndexOf("返现") + 2, OrderRemark.IndexOf("元/") - 2); 
                                    }
                                }
                                #endregion

                                #region 新返现信息 (并有原返现信息对比   记录返现申请)

                                string strCBNew = "";
                                if (CustomerServiceRemarkNew.IndexOf("/退差价") > -1)
                                {
                                    strCBNew = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/退差价")).Trim();
                                }
                                string BuyerAlipayNoNew = "";//账号信息
                                string BuyerNameNew = "";// 收款人账号

                                if ((CustomerServiceRemarkNew.IndexOf("/支付宝") > -1 || CustomerServiceRemarkNew.IndexOf("/卡号") > -1))
                                {
                                    if (CustomerServiceRemarkNew.IndexOf("/支付宝") > -1)
                                    {
                                        string a = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/支付宝") + 1).Trim();
                                        if (a.IndexOf("/") > 0)
                                        {
                                            int I2 = a.IndexOf("/");
                                            BuyerAlipayNoNew = a.Substring(0, I2);
                                        }
                                    }
                                    else if (CustomerServiceRemarkNew.IndexOf("/卡号") > -1)
                                    {
                                        string b = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/卡号") + 1).Trim();
                                        if (b.IndexOf("/") > 0)
                                        {
                                            int I = b.IndexOf("/");
                                            BuyerAlipayNoNew = b.Substring(0, I);
                                        }

                                    }
                                    if (BuyerAlipayNoNew != "")
                                    {
                                        int length = BuyerAlipayNoNew.Length + 1;
                                        string c = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf(BuyerAlipayNoNew) + length);
                                        //订单备注信息中 收货人后面有/
                                        int I3 = c.IndexOf("/");
                                        if (I3 > -1)
                                        {
                                            BuyerNameNew = c.Substring(0, I3);
                                        }
                                    }
                                }
                                //账号信息、收款人账号 都不为空
                                if ((BuyerAlipayNoNew != "" && BuyerNameNew != "") || (BuyerAlipayNoNew == "" && BuyerNameNew != ""))
                                {
                                    int f = strCBNew.IndexOf(BuyerNameNew);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackNew = strCBNew.Substring(0, f + BuyerNameNew.Length);
                                    }


                                    #region 返现信息新增、修改 （有收款人账号、收款人姓名）

                                    //根据订单号、返现类型：返现 查询返现申请
                                    List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(OrderCode, (int)StatusEnum.ChildCashBack);

                                    if (CashBackOld != CashBackNew)
                                    {

                                        if (XMCashBackApplicationList.Count > 0)
                                        {

                                            var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                            //返现信息项目已审核 （不允许修改）
                                            if (AlreadyCheckList.Count > 0)
                                            {
                                                paramMessage = "订单号：" + OrderCode + "返现信息已审核,不允许修改返现内容.";

                                                base.ShowMessage(paramMessage);
                                                return;
                                            }
                                            //修改返现信息
                                            else
                                            {
                                                //返回返现条数
                                                CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                            }
                                        }
                                        else
                                        {
                                            //返回返现条数
                                            CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                        }
                                    }

                                    //最新的返现信息 为空
                                    if (CashBackNew == "")
                                    {
                                        if (XMCashBackApplicationList.Count > 0)
                                        {
                                            if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                            {
                                                //删除原返现信息
                                                //base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                            }

                                        }
                                    }
                                    #endregion
                                }
                                else if (BuyerAlipayNoNew != "" && BuyerNameNew == "")
                                {
                                    int f = strCBNew.IndexOf(BuyerAlipayNoNew);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackNew = strCBNew.Substring(0, f + BuyerAlipayNoNew.Length);
                                    }


                                    #region 返现信息新增、修改 （有收款人账号、收款人姓名）

                                    //根据订单号、返现类型：返现 查询返现申请
                                    List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(OrderCode, (int)StatusEnum.ChildCashBack);

                                    if (CashBackOld != CashBackNew)
                                    {

                                        if (XMCashBackApplicationList.Count > 0)
                                        {

                                            var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                            //返现信息项目已审核 （不允许修改）
                                            if (AlreadyCheckList.Count > 0)
                                            {
                                                paramMessage = "订单号：" + OrderCode + "返现信息已审核,不允许修改返现内容.";

                                                base.ShowMessage(paramMessage);
                                                return;
                                            }
                                            //修改返现信息
                                            else
                                            {
                                                //返回返现条数
                                                CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                            }
                                        }
                                        else
                                        {
                                            //返回返现条数
                                            CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                        }
                                    }

                                    //最新的返现信息 为空
                                    if (CashBackNew == "")
                                    {
                                        if (XMCashBackApplicationList.Count > 0)
                                        {
                                            if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                            {
                                                //删除原返现信息
                                                //base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    int f = strCBNew.IndexOf("元/");

                                    if (f > -1)
                                    {
                                        CashBackNew = strCBNew.Substring(0, f + 2);//OrderRemark.Substring(OrderRemark.IndexOf("返现") + 2, OrderRemark.IndexOf("元/") - 2); 
                                    }

                                    #region 返现信息新增、修改  （无收款人账号、收款人姓名）

                                    //根据订单号、返现类型：返现 查询返现申请
                                    List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(OrderCode, (int)StatusEnum.ChildCashBack);

                                    if (CashBackOld != CashBackNew)
                                    {

                                        if (XMCashBackApplicationList.Count > 0)
                                        {

                                            var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                            //返现信息项目已审核 （不允许修改）
                                            if (AlreadyCheckList.Count > 0)
                                            {
                                                paramMessage = "订单号：" + OrderCode + "返现信息已审核,不允许修改返现内容.";

                                                base.ShowMessage(paramMessage);
                                                return;
                                            }
                                            //修改返现信息
                                            else
                                            {
                                                //返回返现条数
                                                CashBackInst = base.XMOrderInfoAPIService.TMCashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                            }
                                        }
                                        else
                                        {
                                            //返回返现条数
                                            CashBackInst = base.XMOrderInfoAPIService.TMCashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                        }
                                    }

                                    //最新的返现信息 为空
                                    if (CashBackNew == "")
                                    {
                                        if (XMCashBackApplicationList.Count > 0)
                                        {
                                            if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                            {
                                                //删除原返现信息
                                                //base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                #region 原返现信息
                                string strCBOld = "";
                                if (CustomerServiceRemarkOld.IndexOf("/退差价") > -1)
                                {
                                    strCBOld = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/退差价")).Trim();
                                }
                                string BuyerAlipayNoOld = "";//账号信息
                                string BuyerNameOld = "";// 收款人账号

                                if ((CustomerServiceRemarkOld.IndexOf("/支付宝") > -1 || CustomerServiceRemarkOld.IndexOf("/卡号") > -1))
                                {
                                    if (CustomerServiceRemarkOld.IndexOf("/支付宝") > -1)
                                    {
                                        string a = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/支付宝") + 1).Trim();
                                        if (a.IndexOf("/") > 0)
                                        {
                                            int I2 = a.IndexOf("/");
                                            BuyerAlipayNoOld = a.Substring(0, I2);
                                        }
                                    }
                                    else if (CustomerServiceRemarkOld.IndexOf("/卡号") > -1)
                                    {
                                        string b = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/卡号") + 1).Trim();
                                        if (b.IndexOf("/") > 0)
                                        {
                                            int I = b.IndexOf("/");
                                            BuyerAlipayNoOld = b.Substring(0, I);
                                        }
                                    }
                                    if (BuyerAlipayNoOld != "")
                                    {
                                        int length = BuyerAlipayNoOld.Length + 1;
                                        string c = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf(BuyerAlipayNoOld) + length);
                                        //订单备注信息中 收货人后面有/
                                        int I3 = c.IndexOf("/");
                                        if (I3 > -1)
                                        {
                                            BuyerNameOld = c.Substring(0, I3);
                                        }
                                    }
                                }
                                //账号信息、收款人账号 都不为空
                                if ((BuyerAlipayNoOld != "" && BuyerNameOld != "") || (BuyerAlipayNoOld == "" && BuyerNameOld != ""))
                                {
                                    int f = strCBOld.IndexOf(BuyerNameOld);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackOld = strCBOld.Substring(0, f + BuyerNameOld.Length);
                                    }
                                }
                                else if (BuyerAlipayNoOld != "" && BuyerNameOld == "")
                                {
                                    int f = strCBOld.IndexOf(BuyerAlipayNoOld);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackOld = strCBOld.Substring(0, f + BuyerAlipayNoOld.Length);
                                    }
                                }
                                #endregion

                                #region 新返现信息

                                string strCBNew = "";
                                if (CustomerServiceRemarkNew.IndexOf("/退差价") > -1)
                                {
                                    strCBNew = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/退差价")).Trim();
                                }
                                string BuyerAlipayNoNew = "";//账号信息
                                string BuyerNameNew = "";// 收款人账号

                                if ((CustomerServiceRemarkNew.IndexOf("/支付宝") > -1 || CustomerServiceRemarkNew.IndexOf("/卡号") > -1))
                                {
                                    if (CustomerServiceRemarkNew.IndexOf("/支付宝") > -1)
                                    {
                                        string a = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/支付宝") + 1).Trim();
                                        if (a.IndexOf("/") > 0)
                                        {
                                            int I2 = a.IndexOf("/");
                                            BuyerAlipayNoNew = a.Substring(0, I2);
                                        }
                                    }
                                    else if (CustomerServiceRemarkNew.IndexOf("/卡号") > -1)
                                    {
                                        string b = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/卡号") + 1).Trim();
                                        if (b.IndexOf("/") > 0)
                                        {
                                            int I = b.IndexOf("/");
                                            BuyerAlipayNoNew = b.Substring(0, I);
                                        }

                                    }
                                    if (BuyerAlipayNoNew != "")
                                    {
                                        int length = BuyerAlipayNoNew.Length + 1;
                                        string c = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf(BuyerAlipayNoNew) + length);
                                        //订单备注信息中 收货人后面有/
                                        int I3 = c.IndexOf("/");
                                        if (I3 > -1)
                                        {
                                            BuyerNameNew = c.Substring(0, I3);
                                        }
                                    }
                                }
                                //账号信息、收款人账号 都不为空
                                if ((BuyerAlipayNoNew != "" && BuyerNameNew != "") || (BuyerAlipayNoNew == "" && BuyerNameNew != ""))
                                {
                                    int f = strCBNew.IndexOf(BuyerNameNew);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackNew = strCBNew.Substring(0, f + BuyerNameNew.Length);
                                    }
                                }
                                else if (BuyerAlipayNoNew != "" && BuyerNameNew == "")
                                {
                                    int f = strCBNew.IndexOf(BuyerAlipayNoNew);
                                    if (f > -1)
                                    {
                                        //原返现信息
                                        CashBackNew = strCBNew.Substring(0, f + BuyerAlipayNoNew.Length);
                                    }
                                }

                                #endregion

                                #region 返现信息新增、修改

                                //根据订单号、返现类型：返现 查询返现申请
                                List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(OrderCode, (int)StatusEnum.ChildCashBack);

                                if (CashBackOld != CashBackNew)
                                {
                                    if (XMCashBackApplicationList.Count > 0)
                                    {
                                        var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                        //返现信息项目已审核 （不允许修改）
                                        if (AlreadyCheckList.Count > 0)
                                        {
                                            paramMessage = "订单号：" + OrderCode + "返现信息已审核,不允许修改返现内容.";

                                            base.ShowMessage(paramMessage);
                                            return;
                                        }
                                        //修改返现信息
                                        else
                                        {
                                            //返回返现条数
                                            CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                        }
                                    }
                                    else
                                    {
                                        //返回返现条数
                                        CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, xMOrderInfo.WantID, OrderCode, xMOrderInfo.FullName, (int)StatusEnum.ChildCashBack, ref paramMessage);
                                    }
                                }

                                //最新的返现信息 为空
                                if (CashBackNew == "")
                                {
                                    if (XMCashBackApplicationList.Count > 0)
                                    {
                                        if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                        {
                                            //删除原返现信息
                                            //base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                        }
                                    }
                                }
                                #endregion
                            }

                            if (xMOrderInfo.SourceType == "同步")
                            {
                                #region 修改平台后台备注信息

                                if (xMOrderInfo != null)
                                {
                                    //订单号
                                    //string OrderCode = this.lblOrderCode.Text.Trim();

                                    var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();

                                    List<XMOrderInfoApp> xMorderInfoAppNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == xMOrderInfo.PlatformTypeId && q.NickId == xMOrderInfo.NickID).ToList();
                                    if (xMorderInfoAppNew.Count > 0)
                                    {
                                        for (int k = 0; k < xMorderInfoAppNew.Count; k++)
                                        {
                                            #region  京东、京东闪购
                                            if (xMorderInfoAppNew[k].PlatformTypeId == 251 || xMorderInfoAppNew[k].PlatformTypeId == 382 || xMorderInfoAppNew[k].PlatformTypeId == 823)
                                            {
                                                #region 平台后台修改备注
                                                //修改备注
                                                var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(OrderCode, this.txtCustomerRemark.Text.Trim(), "", xMorderInfoAppNew[k]);
                                                if (orderVenderRemark != null)
                                                {

                                                    if (orderVenderRemark.OUP != null)
                                                    {

                                                        if (orderVenderRemark.OUP.Code.ToString() == "0")
                                                        {
                                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                            paramMessage = "操作成功.";
                                                            //return;
                                                        }
                                                        else
                                                        {
                                                            paramMessage = "操作失败,请联系管理员.";
                                                            //return;
                                                        }
                                                    }
                                                }

                                                #endregion
                                            }
                                            #endregion

                                            #region  淘宝、淘宝集市店
                                            else if (xMorderInfoAppNew[k].PlatformTypeId == 250 || xMorderInfoAppNew[k].PlatformTypeId == 381)
                                            {
                                                #region 平台后台修改备注
                                                //修改备注
                                                var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(OrderCode), this.txtCustomerRemark.Text.Trim(), xMorderInfoAppNew[k]);

                                                if (tradeMemoUpdate != null)
                                                {

                                                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                    paramMessage = "操作成功.";
                                                    //return;
                                                }
                                                else
                                                {
                                                    paramMessage = "操作失败,请联系管理员.";
                                                    //return; 
                                                }

                                                #endregion
                                            }
                                            #endregion

                                            #region 一号店
                                            else if (xMorderInfoAppNew[k].PlatformTypeId == 375)
                                            {
                                                #region 平台后台修改备注
                                                //修改备注 
                                                int OrderMerchantRemarkUpdateInt = base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(OrderCode, this.txtCustomerRemark.Text.Trim(), xMorderInfoAppNew[k]);

                                                if (OrderMerchantRemarkUpdateInt == 1)
                                                {
                                                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                    paramMessage = "操作成功.";
                                                    // return; 
                                                }
                                                else
                                                {

                                                    paramMessage = "操作失败,请联系管理员.";
                                                    //return; 
                                                }

                                                #endregion
                                            }
                                            #endregion

                                            #region  苏宁易购
                                            else if (xMorderInfoAppNew[k].PlatformTypeId == 383)
                                            {
                                                #region 平台后台修改备注

                                                string colorMarkFlag = "";
                                                if (this.txtCustomerRemark.Text.Trim().IndexOf("已提单") > -1)
                                                {
                                                    colorMarkFlag = "2";//交易备注旗帜, 空表示灰色， 1表示红色， 2表示黄色， 3表示绿色， 4表示蓝色， 5表示紫色
                                                }
                                                else
                                                {
                                                    colorMarkFlag = "1";
                                                }
                                                //修改备注
                                                var tradeMemoUpdate = base.XMOrderInfoAPIService.OrdernoteModifyUpdate(xMOrderInfo.OrderCode, this.txtCustomerRemark.Text.Trim(), colorMarkFlag, xMorderInfoAppNew[k]);

                                                if (tradeMemoUpdate != null && tradeMemoUpdate != "")
                                                {
                                                    if (tradeMemoUpdate == "Y")
                                                    {
                                                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                        paramMessage = "苏宁易购平台操作成功.";
                                                        // return;
                                                    }
                                                    else
                                                    {
                                                        paramMessage = "苏宁易购平台操作失败,请联系管理员.";
                                                        //return;
                                                    }
                                                }

                                                #endregion
                                            }
                                            #endregion

                                            //其它平台信息修改
                                            else
                                            {
                                                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                paramMessage = "操作成功.";
                                            }

                                            //唯品会
                                            //else if (xMorderInfoAppNew[0].PlatformTypeId == 259)
                                            //{
                                            //    return;
                                            //}
                                        }
                                    }
                                    else
                                    {
                                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                        paramMessage = "操作成功.";
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                paramMessage = "操作成功.";
                            }
                        }
                        // 修改其他信息
                        else
                        {
                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                            paramMessage = "操作成功！";
                        }

                        #endregion
                    }
                    scope.Complete();
                    base.ShowMessage(paramMessage);
                }
                catch (Exception err)
                {
                    this.ProcessException(err);
                }
            }
        }

        /// <summary>
        /// 订单OrderCode
        /// </summary>
        public string OrderCode
        {
            get
            {
                return CommonHelper.QueryString("OrderCode");
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            var OrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(OrderCode);
            if (OrderInfo != null)
            {
                this.txtCustomerRemark.Text = OrderInfo.CustomerServiceRemark.Trim();
                this.txtRemark.Text = OrderInfo.Remark == null ? "" : OrderInfo.Remark.Trim();
            }
            if (type == 0)
            {
                this.txtCustomerRemark.Visible = false;
                this.lblCustomerRemark.Text = "该订单已排单，客服备注不可修改！";
            }
            else
            {
                this.lblCustomerRemark.Visible = false;
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        public int type
        {
            get
            {

                return CommonHelper.QueryStringInt("type");
            }
        }

        #endregion
    }
}