using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using Top.Api.Domain;


namespace HozestERP.Web.ManageProject
{
    public partial class dyYD : BaseAdministrationPage
    {
        const string strHostName = "strHostName";

        #region 定义变量
        public string OrderCode
        {
            get { return ViewState["OrderCode"].ToString(); }
            set { ViewState["OrderCode"] = value; }
        }

        public string ids
        {
            get { return ViewState["ids"].ToString(); }
            set { ViewState["ids"] = value; }
        }



        public string PrintTypeId
        {
            get { return ViewState["PrintTypeId"].ToString(); }
            set { ViewState["PrintTypeId"] = value; }
        }


        public string kdgs
        {
            get { return ViewState["kdgs"].ToString(); }
            set { ViewState["kdgs"] = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblMSG.Text = "";
                if (Request.QueryString["ids"] != null && Request.QueryString["ids"].ToString() != "")
                {
                    ids = Request.QueryString["ids"].ToString();
                }

                if (Request.QueryString["PrintTypeId"] != null && Request.QueryString["PrintTypeId"].ToString() != "")
                {
                    PrintTypeId = Request.QueryString["PrintTypeId"].ToString();
                }


                ViewState[strHostName] = System.Net.Dns.GetHostName();
                if (Session[ViewState[strHostName].ToString()] != null)
                {
                    hid_plyd.Value = Session[ViewState[strHostName].ToString()].ToString();
                    Session.Clear();
                }
            }
        }
        public static void ShowMessage(string strMsg)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');</script>");
        }

        public void binddata()
        {

            #region 加载快递单模板
            this.lblMSG.Text = "";
            string ydgs = "EMS";

            if (Rad_EMS.Checked)
            {
                ydgs = "EMS";
            }
            else if (Rad_ZTO.Checked)
            {
                ydgs = "ZTO";
            }
            else if (Rad_STO.Checked)
            {
                ydgs = "STO";
            }
            else if (this.Rad_YTO.Checked)
            {
                ydgs = "YTO";
            }
            Session["CompanyCode"] = ydgs;

            ///读取模板信息
            Encoding code = Encoding.GetEncoding("gb2312");
            StringBuilder divHtml = new StringBuilder();
            StringBuilder htmls = new StringBuilder();
            StreamReader sr = new StreamReader(new Page().Server.MapPath("/auth/" + ydgs.ToString() + ".html"), code);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                divHtml.Append(line);
            }
            sr.Close();

            #endregion

            //string[] status = new string[3];
            //status[0] = "FINISHED_L";
            //status[1] = "TRADE_FINISHED";
            //status[2] = "ORDERS_HAVE_AUDITED";
            string status = "FINISHED_L,TRADE_FINISHED,ORDERS_HAVE_AUDITED";

            //订单列表
            //List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
            //发货单列表
            List<HozestERP.BusinessLogic.ManageProject.XMDelivery> xMDeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
            //从发货单管理中取数据源
            if (PrintTypeId == "Delivery")
            {
                #region  新 从发货单管理中取数据源
                if (ids != "")
                {
                    int[] sts = new int[ids.Split(',').Length];
                    for (int i = 0; i < ids.Split(',').Length; i++)
                    {
                        string Id = ids.Split(',')[i];
                        sts[i] = Convert.ToInt32(Id);
                    }
                    xMDeliveryList = base.XMDeliveryService.GetXMDeliveryById(sts);
                    //List<string> OrderCodes = xMDeliveryList.Select(q => q.OrderCode).Distinct().ToList();  
                    //orderInfoList = base.XMOrderInfoService.GetXMOrderInfoByOrderCodeList(OrderCodes);//订单信息

                }
                //去掉重复的发货单
                List<HozestERP.BusinessLogic.ManageProject.XMDelivery> temp = xMDeliveryList.Distinct().ToList();

                this.lblcount.Text = temp.Count().ToString() + "个订单";
                this.lblcount.ForeColor = Color.Red;
                Int64 aa = 0;


                if (txtStartCode.Text != string.Empty && txtEndCode.Text != string.Empty)//面单号不允许为空
                {
                    if (Int64.TryParse(txtStartCode.Text, out aa) && Int64.TryParse(txtEndCode.Text, out aa))//判断输入的面单号是否数字
                    {
                        Int64 len = Int64.Parse(txtEndCode.Text) - Int64.Parse(txtStartCode.Text);
                        if (len >= 0)
                        {
                            if (temp.Count() == len + 1)
                            {

                            }
                            else
                            {
                                this.lblMSG.Text = "面单数量和发货单数量不符，请确认!";
                                this.lblMSG.ForeColor = Color.Red;
                                return;
                            }
                        }
                        else
                        {
                            this.lblMSG.Text = "请正确输入打印的面单号码！";
                            this.lblMSG.ForeColor = Color.Red;
                            return;
                        }
                    }
                    else
                    {
                        this.lblMSG.Text = "请正确输入打印的面单号码！";
                        this.lblMSG.ForeColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    this.lblMSG.Text = "请正确输入打印的面单号码！";
                    this.lblMSG.ForeColor = Color.Red;
                    return;
                }
                //List<XMOrderInfo> temp = orderInfoList.Distinct(new Comparer()).ToList<XMOrderInfo>();
                #region 相同地址订单合并
                //foreach (var o in temp)
                //{
                //    foreach (var p in orderInfoList)
                //    {
                //        string xaddress = (o.DeliveryAddressSpare == null || o.DeliveryAddressSpare == string.Empty) ? o.DeliveryAddress : o.DeliveryAddressSpare;
                //        string yaddress = (p.DeliveryAddressSpare == null || p.DeliveryAddressSpare == string.Empty) ? p.DeliveryAddress : p.DeliveryAddressSpare;
                //        if (xaddress == yaddress)
                //        {
                //            //if (p.Specifications.IndexOf(o.Specifications) == -1 && p.Specifications != "")//判断是否已包含
                //            //    o.Specifications += ",|," + p.Specifications;//尺寸合并
                //            if (p.CustomerServiceRemark.IndexOf(o.CustomerServiceRemark) == -1 && p.CustomerServiceRemark != "")//判断是否已包含
                //                o.CustomerServiceRemark += ",|," + p.CustomerServiceRemark;//客服备注合并
                //            if (p.Remark.IndexOf(o.Remark) == -1 && p.Remark != "")//判断是否已包含
                //                o.Remark += ",|," + p.Remark;//备注合并
                //        }
                //    }
                //}
                #endregion


                if (temp != null && temp.Count > 0)
                {
                    foreach (var item in temp)
                    {
                        //根据发货单 的订单号查询订单信息
                        XMOrderInfo xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(item.OrderCode);

                        //根据发货单 Id 查询明细信息 
                        List<XMDeliveryDetails> deliverDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(item.Id);

                        List<XMDeliveryDetails_Result> deliverDetailsListGroupy =
                            deliverDetailsList.GroupBy(g => new { g.PlatformMerchantCode, g.PrdouctName, g.Specifications }).
                            Select(group => new XMDeliveryDetails_Result()
                            {
                                PlatformMerchantCode = group.Key.PlatformMerchantCode,
                                PrdouctName = group.Key.PrdouctName,
                                Specifications = group.Key.Specifications,
                                ProductNum = group.Sum(l => l.ProductNum)
                            }).ToList();

                        //赠品信息
                        string displayRemark = "";
                        if (deliverDetailsListGroupy != null && deliverDetailsListGroupy.Count > 0)
                        {
                            foreach (var DetailsList in deliverDetailsListGroupy)
                            {
                                displayRemark += DetailsList.PrdouctName + "(" + DetailsList.Specifications + ")" + "*" + DetailsList.ProductNum + "+";
                            }
                            if (!string.IsNullOrEmpty(displayRemark))
                            {

                                displayRemark = displayRemark.Substring(0, displayRemark.Length - 1);
                            }
                        }

                        string fapiao = "";

                        if (xmorderinfo.CustomerServiceRemark.IndexOf("发票") > -1)
                        {
                            fapiao = "发票";
                        }

                        if (fapiao != "")
                        {
                            displayRemark = displayRemark + "  " + fapiao;
                        }
                        StringBuilder htmltext = new StringBuilder();
                        htmltext.Append(divHtml);

                        string strtel = "0574-55712472/0574-55712170";

                        #region 不存在收货地址修改(淘宝订单原始订单收货地址)
                        var customerInfo = HozestERPContext.Current.User.SCustomerInfo;
                        htmltext = htmltext.Replace("$fahuoren$", xmorderinfo.NickName);
                        htmltext = htmltext.Replace("$xingming$", xmorderinfo.FullName.ToString());

                        if (xmorderinfo.Mobile.ToString() != "")
                        {
                            htmltext = htmltext.Replace("$dianhua$", xmorderinfo.Mobile.ToString());
                        }
                        else
                        {
                            htmltext = htmltext.Replace("$dianhua$", xmorderinfo.Tel.ToString());
                        }
                        htmltext = htmltext.Replace("$danwei$", xmorderinfo.WantID.ToString() + "  " + xmorderinfo.OrderCode);

                        //CustomerServiceRemark
                        //赠品更地址
                        string Address = "";
                        string s = "";
                        if (xmorderinfo.CustomerServiceRemark != "")
                        {
                            if (xmorderinfo.CustomerServiceRemark.IndexOf("更改赠品地址") > -1)
                            {

                                s = xmorderinfo.CustomerServiceRemark.Substring(xmorderinfo.CustomerServiceRemark.IndexOf("更改赠品地址") + 6).Trim();

                            }
                            int f = s.IndexOf("/");
                            if (f > -1)
                            {
                                Address = s.Substring(0, f).Trim();
                            }
                        }


                        if (Address != "")
                        {
                            htmltext = htmltext.Replace("$dizhi$", Address);
                        }
                        else
                        {
                            if (xmorderinfo.DeliveryAddressSpare == "" || xmorderinfo.DeliveryAddressSpare == "NULL" || xmorderinfo.DeliveryAddressSpare == null)
                            {
                                htmltext = htmltext.Replace("$dizhi$", xmorderinfo.DeliveryAddress.ToString());
                            }
                            else
                            {
                                    htmltext = htmltext.Replace("$dizhi$", xmorderinfo.DeliveryAddressSpare.ToString());
                            }
                        }

                        if (Rad_EMS.Checked)
                        {
                            htmltext = htmltext.Replace("$youbian$", "315502");
                            htmltext = htmltext.Replace("$richuo$", DateTime.Now.ToString("yyyy.MM.dd.HH"));
                        }
                        #endregion

                        #region 提取备注
                        //string allRemark = item.Remark + "/" + item.CustomerServiceRemark;
                        //string[] remarklist = allRemark.Split('/');
                        //int remarkcount = remarklist.Count();
                        //string displayRemark = "";
                        //for (int i = 0; i < remarklist.Count(); i++)
                        //{
                        //    string contact = remarklist[i].ToString();
                        //    if (contact.IndexOf("赠品") >= 0 || contact.IndexOf("发票") >= 0)
                        //    {
                        //        string displayRemarkReplace = remarklist[i].Replace("赠品:", "");
                        //        displayRemarkReplace = displayRemarkReplace.Replace("赠品：", "");
                        //        displayRemarkReplace = displayRemarkReplace.Replace("赠品", "");
                        //        if (displayRemark.IndexOf(remarklist[i].ToString()) == -1)
                        //            displayRemark += displayRemarkReplace.ToString() + ",";
                        //    }
                        //}
                        #endregion

                        htmltext = htmltext.Replace("$fahuodianhua$", strtel);
                        htmltext = htmltext.Replace("$neijian$", displayRemark);
                        htmltext = htmltext.Replace("$shijian$", DateTime.Now.ToString("yyyy MM dd HH:mm"));
                        htmls.Append(htmltext);
                        div_dy.InnerHtml = htmls.ToString();
                    }
                }
                #endregion
            }
            else if (PrintTypeId == "Empty")
            {
                #region 刷单打印

                //订单列表
                List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();

                if (ids != "")
                {
                    int[] sts = new int[ids.Split(',').Length];
                    for (int i = 0; i < ids.Split(',').Length; i++)
                    {
                        string Id = ids.Split(',')[i];
                        sts[i] = Convert.ToInt32(Id);
                    }
                    orderInfoList = base.XMScalpingService.GetXMOrderinfoShudan(sts);
                }
                this.lblcount.Text = orderInfoList.Count().ToString() + "个订单";
                this.lblcount.ForeColor = Color.Red;
                #region 相同地址订单合并
                List<XMOrderInfo> temp = orderInfoList.Distinct(new Comparer()).ToList<XMOrderInfo>();
                foreach (var o in temp)
                {
                    foreach (var p in orderInfoList)
                    {
                        string xaddress = (o.DeliveryAddressSpare == null || o.DeliveryAddressSpare == string.Empty) ? o.DeliveryAddress : o.DeliveryAddressSpare;
                        string yaddress = (p.DeliveryAddressSpare == null || p.DeliveryAddressSpare == string.Empty) ? p.DeliveryAddress : p.DeliveryAddressSpare;
                        if (xaddress == yaddress)
                        {
                            //if (p.Specifications.IndexOf(o.Specifications) == -1 && p.Specifications != "")//判断是否已包含
                            //    o.Specifications += ",|," + p.Specifications;//尺寸合并
                            if (p.CustomerServiceRemark.IndexOf(o.CustomerServiceRemark) == -1 && p.CustomerServiceRemark != "")//判断是否已包含
                                o.CustomerServiceRemark += ",|," + p.CustomerServiceRemark;//客服备注合并
                        }
                    }
                }
                #endregion
                if (temp != null && temp.Count > 0)
                {
                    foreach (var item in temp)
                    {
                        StringBuilder htmltext = new StringBuilder();
                        htmltext.Append(divHtml);


                        string strtel = "0574-55712472";

                        #region 不存在收货地址修改(淘宝订单原始订单收货地址)
                        var customerInfo = HozestERPContext.Current.User.SCustomerInfo;
                        htmltext = htmltext.Replace("$fahuoren$", item.NickName);
                        htmltext = htmltext.Replace("$xingming$", item.FullName.ToString());

                        if (item.Mobile.ToString() != "")
                        {
                            htmltext = htmltext.Replace("$dianhua$", item.Mobile.ToString());
                        }
                        else
                        {
                            htmltext = htmltext.Replace("$dianhua$", item.Tel.ToString());
                        }
                        htmltext = htmltext.Replace("$danwei$", item.WantID.ToString() + "  " + item.OrderCode);
                        //赠品更地址
                        string Address = "";
                        string s = "";
                        if (item.CustomerServiceRemark != "")
                        {
                            if (item.CustomerServiceRemark.IndexOf("更改赠品地址") > -1)
                            {

                                s = item.CustomerServiceRemark.Substring(item.CustomerServiceRemark.IndexOf("更改赠品地址") + 6).Trim();

                            }
                            int f = s.IndexOf("/");
                            if (f > -1)
                            {
                                Address = s.Substring(0, f).Trim();
                            }
                        }

                        if (Address != "")
                        {
                            htmltext = htmltext.Replace("$dizhi$", Address);
                        }
                        else
                        {
                            if (item.DeliveryAddressSpare == "" || item.DeliveryAddressSpare == null)
                            {
                                htmltext = htmltext.Replace("$dizhi$", item.DeliveryAddress.ToString());
                            }
                            else
                            {
                                htmltext = htmltext.Replace("$dizhi$", item.DeliveryAddressSpare.ToString());
                            }
                        }

                        if (Rad_EMS.Checked)
                        {
                            htmltext = htmltext.Replace("$youbian$", "315502");
                            htmltext = htmltext.Replace("$richuo$", DateTime.Now.ToString("yyyy.MM.dd.HH"));
                        }
                        #endregion

                        #region 提取备注
                        string allRemark = item.CustomerServiceRemark;
                        string[] remarklist = allRemark.Split('/');
                        int remarkcount = remarklist.Count();
                        string displayRemark = "";
                        for (int i = 0; i < remarklist.Count(); i++)
                        {
                            string contact = remarklist[i].ToString();
                            if (contact.IndexOf("赠品") >= 0 || contact.IndexOf("发票") >= 0)
                            {
                                string displayRemarkReplace = remarklist[i].Replace("赠品:", "");
                                displayRemarkReplace = displayRemarkReplace.Replace("赠品：", "");
                                displayRemarkReplace = displayRemarkReplace.Replace("赠品", "");
                                if (displayRemark.IndexOf(remarklist[i].ToString()) == -1)
                                    displayRemark += displayRemarkReplace.ToString() + ",";
                            }
                        }
                        #endregion

                        htmltext = htmltext.Replace("$fahuodianhua$", strtel);
                        htmltext = htmltext.Replace("$neijian$", displayRemark);
                        htmltext = htmltext.Replace("$shijian$", DateTime.Now.ToString("yyyy MM dd HH:mm"));
                        htmls.Append(htmltext);
                        div_dy.InnerHtml = htmls.ToString();
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// 打印快递单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_qrdy_Click(object sender, EventArgs e)
        {
            #region 加载快递单模板
            string StartCode = "";
            string ydgs = "EMS";

            if (Rad_EMS.Checked)
            {
                ydgs = "EMS";
            }
            else if (Rad_ZTO.Checked)
            {
                ydgs = "ZTO";
            }
            else if (Rad_STO.Checked)
            {
                ydgs = "STO";
            }

            Session["CompanyCode"] = ydgs;

            ///读取模板信息
            Encoding code = Encoding.GetEncoding("gb2312");
            StringBuilder divHtml = new StringBuilder();
            StringBuilder htmls = new StringBuilder();
            StreamReader sr = new StreamReader(new Page().Server.MapPath("/auth/" + ydgs.ToString() + ".html"), code);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                divHtml.Append(line);
            }
            sr.Close();

            #endregion

            //string[] status = new string[3];
            //status[0] = "FINISHED_L";
            //status[1] = "TRADE_FINISHED";
            //status[2] = "ORDERS_HAVE_AUDITED";
            string status = "FINISHED_L,TRADE_FINISHED,ORDERS_HAVE_AUDITED";
            if (PrintTypeId == "Delivery")
            {
                #region

                //打印批次
                int PrintBatch = 0;
                //取发货单表中 打印批次倒序最后条
                var xMDeliveryListByPrintBatch = base.XMDeliveryService.GetXMDeliveryList().OrderByDescending(p => p.PrintBatch).FirstOrDefault();
                if (xMDeliveryListByPrintBatch != null)
                {
                    if (xMDeliveryListByPrintBatch.PrintBatch != null)
                    {
                        PrintBatch = xMDeliveryListByPrintBatch.PrintBatch.Value;
                    }
                }

                //发货单列表
                List<HozestERP.BusinessLogic.ManageProject.XMDelivery> xMDeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();

                if (ids != "")
                {
                    int[] sts = new int[ids.Split(',').Length];
                    for (int i = 0; i < ids.Split(',').Length; i++)
                    {
                        string Id = ids.Split(',')[i];
                        sts[i] = Convert.ToInt32(Id);
                    }
                    xMDeliveryList = base.XMDeliveryService.GetXMDeliveryById(sts);
                }

                this.lblcount.Text = xMDeliveryList.Count().ToString() + "个订单";
                this.lblcount.ForeColor = Color.Red;
                Int64 aa = 0;
                if (txtStartCode.Text != string.Empty && txtEndCode.Text != string.Empty)//面单号不允许为空
                {
                    if (Int64.TryParse(txtStartCode.Text, out aa) && Int64.TryParse(txtEndCode.Text, out aa))//判断输入的面单号是否数字
                    {
                        Int64 len = Int64.Parse(txtEndCode.Text) - Int64.Parse(txtStartCode.Text);
                        if (len >= 0)
                        {
                            if (xMDeliveryList.Count() == len + 1)
                            {
                                StartCode = txtStartCode.Text;
                            }
                            else
                            {
                                this.lblMSG.Text = "面单数量和发货单数量不符，请确认!";
                                this.lblMSG.ForeColor = Color.Red;
                                return;
                            }
                        }
                        else
                        {
                            this.lblMSG.Text = "请正确输入打印的面单号码";
                            this.lblMSG.ForeColor = Color.Red;
                            return;
                        }
                    }
                    else
                    {
                        this.lblMSG.Text = "请正确输入打印的面单号码";
                        this.lblMSG.ForeColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    this.lblMSG.Text = "请正确输入打印的面单号码";
                    this.lblMSG.ForeColor = Color.Red;
                    return;
                }

                Int64 cc = 0;//目前第几个订单
                if (xMDeliveryList != null && xMDeliveryList.Count > 0)
                {
                    foreach (var item in xMDeliveryList)
                    {

                        //根据发货单 的订单号查询订单信息
                        XMOrderInfo xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(item.OrderCode);

                        //根据发货单 Id 查询明细信息 
                        List<XMDeliveryDetails> deliverDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(item.Id);

                        List<XMDeliveryDetails_Result> deliverDetailsListGroupy =
                            deliverDetailsList.GroupBy(g => new { g.PlatformMerchantCode, g.PrdouctName, g.Specifications }).
                            Select(group => new XMDeliveryDetails_Result()
                            {
                                PlatformMerchantCode = group.Key.PlatformMerchantCode,
                                PrdouctName = group.Key.PrdouctName,
                                Specifications = group.Key.Specifications,
                                ProductNum = group.Sum(l => l.ProductNum)
                            }).ToList();

                        //赠品信息
                        string displayRemark = "";
                        if (deliverDetailsListGroupy != null && deliverDetailsListGroupy.Count > 0)
                        {
                            foreach (var DetailsList in deliverDetailsListGroupy)
                            {
                                displayRemark += DetailsList.PrdouctName + "(" + DetailsList.Specifications + ")" + "*" + DetailsList.ProductNum + "+";
                            }
                            if (!string.IsNullOrEmpty(displayRemark))
                            {
                                displayRemark = displayRemark.Substring(0, displayRemark.Length - 1);
                            }
                        }

                        string fapiao = "";

                        if (xmorderinfo.CustomerServiceRemark.IndexOf("发票") > -1)
                        {
                            fapiao = "发票";
                        }

                        if (fapiao != "")
                        {
                            displayRemark = displayRemark + "  " + fapiao;
                        }
                        StringBuilder htmltext = new StringBuilder();
                        htmltext.Append(divHtml);


                        string strtel = "0574-55712472/0574-55712170";

                        #region 不存在收货地址修改(淘宝订单原始订单收货地址)
                        var customerInfo = HozestERPContext.Current.User.SCustomerInfo;
                        htmltext = htmltext.Replace("$fahuoren$", xmorderinfo.NickName);
                        htmltext = htmltext.Replace("$xingming$", xmorderinfo.FullName.ToString());

                        if (xmorderinfo.Mobile.ToString() != "")
                        {
                            htmltext = htmltext.Replace("$dianhua$", xmorderinfo.Mobile.ToString());
                        }
                        else
                        {
                            htmltext = htmltext.Replace("$dianhua$", xmorderinfo.Tel.ToString());
                        }
                        htmltext = htmltext.Replace("$danwei$", xmorderinfo.WantID.ToString() + "  " + xmorderinfo.OrderCode);
                        if (xmorderinfo.DeliveryAddressSpare == "" || xmorderinfo.DeliveryAddressSpare == "NULL" || xmorderinfo.DeliveryAddressSpare == null)
                        {
                            htmltext = htmltext.Replace("$dizhi$", xmorderinfo.DeliveryAddress.ToString());
                        }
                        else
                        {
                                htmltext = htmltext.Replace("$dizhi$", xmorderinfo.DeliveryAddressSpare.ToString());
                        }

                        if (Rad_EMS.Checked)
                        {
                            htmltext = htmltext.Replace("$youbian$", "315502");
                            htmltext = htmltext.Replace("$richuo$", DateTime.Now.ToString("yyyy.MM.dd.HH"));
                        }
                        #endregion

                        htmltext = htmltext.Replace("$fahuodianhua$", strtel);
                        htmltext = htmltext.Replace("$neijian$", displayRemark);
                        htmltext = htmltext.Replace("$shijian$", DateTime.Now.ToString("yyyy MM dd HH:mm"));
                        htmls.Append(htmltext);

                        //var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(xmorderinfo.ID);
                        //xMOrderInfo.IsSentGifts = true;
                        //base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);

                        //根据Id查询发货单
                        var xmDelivery = base.XMDeliveryService.GetXMDeliveryById(item.Id);

                        xmDelivery.LogisticsId = 482;//默认申通快递单号
                        xmDelivery.LogisticsNumber = (Int64.Parse(StartCode) + cc).ToString();
                        int PrintQuantity = 0;
                        if (xmDelivery.PrintQuantity != null)
                        {
                            PrintQuantity = xmDelivery.PrintQuantity.Value;
                        }
                        xmDelivery.PrintQuantity = PrintQuantity + 1;//打印次数
                        if (xmDelivery.PrintBatch == 0)
                        {
                            xmDelivery.PrintBatch = PrintBatch + 1;//打印批次
                        }
                        xmDelivery.PrintDateTime = DateTime.Now;//打印时间
                        xmDelivery.IsDelivery = true;
                        base.XMDeliveryService.UpdateXMDelivery(xmDelivery);
                        cc++;
                    }

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "dyscript_yd", "window.print();", true);
                }

                #endregion
            }
            else if (PrintTypeId == "Empty")
            {
                #region
                List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
                if (ids != "")
                {
                    int[] sts = new int[ids.Split(',').Length];
                    for (int i = 0; i < ids.Split(',').Length; i++)
                    {
                        string Id = ids.Split(',')[i];
                        sts[i] = Convert.ToInt32(Id);
                    }
                    orderInfoList = base.XMScalpingService.GetXMOrderinfoShudan(sts);
                }
                this.lblcount.Text = orderInfoList.Count().ToString() + "个订单";
                this.lblcount.ForeColor = Color.Red;

                #region 相同地址订单合并
                List<XMOrderInfo> temp = orderInfoList.Distinct(new Comparer()).ToList<XMOrderInfo>();
                foreach (var o in temp)
                {
                    foreach (var p in orderInfoList)
                    {
                        string xaddress = (o.DeliveryAddressSpare == null || o.DeliveryAddressSpare == string.Empty) ? o.DeliveryAddress : o.DeliveryAddressSpare;
                        string yaddress = (p.DeliveryAddressSpare == null || p.DeliveryAddressSpare == string.Empty) ? p.DeliveryAddress : p.DeliveryAddressSpare;
                        if (xaddress == yaddress)
                        {
                            //if (p.Specifications.IndexOf(o.Specifications) == -1 && p.Specifications != "")//判断是否已包含
                            //    o.Specifications += ",|," + p.Specifications;//尺寸合并
                            if (p.CustomerServiceRemark.IndexOf(o.CustomerServiceRemark) == -1 && p.CustomerServiceRemark != "")//判断是否已包含
                                o.CustomerServiceRemark += ",|," + p.CustomerServiceRemark;//客服备注合并
                        }
                    }
                }
                #endregion

                if (orderInfoList != null && orderInfoList.Count > 0)
                {
                    foreach (var item in orderInfoList)
                    {
                        StringBuilder htmltext = new StringBuilder();
                        htmltext.Append(divHtml);


                        string strtel = "0574-55712472";

                        #region 不存在收货地址修改(淘宝订单原始订单收货地址)
                        var customerInfo = HozestERPContext.Current.User.SCustomerInfo;
                        htmltext = htmltext.Replace("$fahuoren$", item.NickName);
                        htmltext = htmltext.Replace("$xingming$", item.FullName.ToString());

                        if (item.Mobile.ToString() != "")
                        {
                            htmltext = htmltext.Replace("$dianhua$", item.Mobile.ToString());
                        }
                        else
                        {
                            htmltext = htmltext.Replace("$dianhua$", item.Tel.ToString());
                        }
                        htmltext = htmltext.Replace("$danwei$", item.WantID.ToString() + "  " + item.OrderCode);
                        if (item.DeliveryAddressSpare == "" || item.DeliveryAddressSpare == null)
                        {
                            htmltext = htmltext.Replace("$dizhi$", item.DeliveryAddress.ToString());
                        }
                        else
                        {
                            htmltext = htmltext.Replace("$dizhi$", item.DeliveryAddressSpare.ToString());
                        }

                        if (Rad_EMS.Checked)
                        {
                            htmltext = htmltext.Replace("$youbian$", "315502");
                            htmltext = htmltext.Replace("$richuo$", DateTime.Now.ToString("yyyy.MM.dd.HH"));
                        }
                        #endregion

                        htmltext = htmltext.Replace("$fahuodianhua$", strtel);
                        #region 提取备注
                        string allRemark = item.CustomerServiceRemark;
                        string[] remarklist = allRemark.Split('/');
                        int remarkcount = remarklist.Count();
                        string displayRemark = "";
                        for (int i = 0; i < remarklist.Count(); i++)
                        {
                            if (remarklist[i].IndexOf("赠品") >= 0 || remarklist[i].IndexOf("发票") >= 0)
                            {
                                string displayRemarkReplace = remarklist[i].Replace("赠品:", "");
                                displayRemarkReplace = displayRemarkReplace.Replace("赠品：", "");
                                displayRemarkReplace = displayRemarkReplace.Replace("赠品", "");
                                if (displayRemark.IndexOf(remarklist[i].ToString()) == -1)
                                    displayRemark += displayRemarkReplace.ToString() + ",";
                            }
                        }
                        #endregion
                        htmltext = htmltext.Replace("$neijian$", displayRemark);
                        htmltext = htmltext.Replace("$shijian$", DateTime.Now.ToString("yyyy MM dd HH:mm"));
                        htmls.Append(htmltext);

                        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(item.ID);
                        xMOrderInfo.IsSentGifts = true;
                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                    }

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "dyscript_yd", "window.print();", true);
                }
                #endregion
            }

        }

        public class Comparer : IEqualityComparer<XMOrderInfo>
        {
            #region IEqualityComparer<XMOrderInfo> Members

            public bool Equals(XMOrderInfo x, XMOrderInfo y)
            {
                if (x == null || y == null)
                    return false;
                string xaddress = (x.DeliveryAddressSpare == null || x.DeliveryAddressSpare == string.Empty) ? x.DeliveryAddress : x.DeliveryAddressSpare;
                string yaddress = (y.DeliveryAddressSpare == null || y.DeliveryAddressSpare == string.Empty) ? y.DeliveryAddress : y.DeliveryAddressSpare;
                return xaddress == yaddress;
            }

            public int GetHashCode(XMOrderInfo obj)
            {
                return obj.ToString().GetHashCode();
            }

            #endregion
        }

        protected void but_dy_Click(object sender, EventArgs e)
        {
            this.binddata();
        }
    }
}