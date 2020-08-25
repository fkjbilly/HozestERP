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
using System.Transactions;

namespace HozestERP.Web.ManageProject
{
    public partial class dyFHD : BaseAdministrationPage
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

            #region 加载发货单模板
            this.lblMSG.Text = "";
            string ydgs = "DeliveryBill";


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

            string status = "FINISHED_L,TRADE_FINISHED,ORDERS_HAVE_AUDITED";

            ////订单列表
            //List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
            //发货单列表
            List<HozestERP.BusinessLogic.ManageProject.XMDelivery> Deliveryinfolist = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
            
            //从订单管理中取数据源
            #region  新 从发货单管理中取数据源
            if (ids != "")
            {
                int[] sts = new int[ids.Split(',').Length];
                for (int i = 0; i < ids.Split(',').Length; i++)
                {
                    string Id = ids.Split(',')[i];
                    sts[i] = int.Parse(Id);
                }

                //orderInfoList = base.XMOrderInfoService.GetXMOrderInfoList(sts);//订单信息
                Deliveryinfolist = base.XMDeliveryService.GetXMDeliveryById(sts);//发货单信息

            }

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


            if (Deliveryinfolist != null && Deliveryinfolist.Count > 0)
            {
                foreach (HozestERP.BusinessLogic.ManageProject.XMDelivery Deliveryinfo in Deliveryinfolist)
                {
                    //根据订单号查询订单信息

                    StringBuilder htmltext = new StringBuilder();
                    StringBuilder tb = new StringBuilder();
                    htmltext.Append(divHtml);

                    #region 不存在收货地址修改(淘宝订单原始订单收货地址)
                    var customerInfo = HozestERPContext.Current.User.SCustomerInfo;
                    htmltext = htmltext.Replace("$riqidata$", DateTime.Now.ToString());
                    htmltext = htmltext.Replace("$NickName$", Deliveryinfo.NickName);
                    htmltext = htmltext.Replace("$Ordercode$", Deliveryinfo.OrderCode.ToString());
                    htmltext = htmltext.Replace("$Mobile$", Deliveryinfo.Mobile.ToString());
                    if (Deliveryinfo.Tel != null)
                    {
                        htmltext = htmltext.Replace("$Tel$", Deliveryinfo.Tel.ToString());
                    }
                    else 
                    {
                        htmltext = htmltext.Replace("$Tel$", "");
                    }
                    htmltext = htmltext.Replace("$WantID$", Deliveryinfo.WantID.ToString());
                    htmltext = htmltext.Replace("$FullName$", Deliveryinfo.FullName.ToString());
                    htmltext = htmltext.Replace("$DeliveryAddress$", Deliveryinfo.DeliveryAddress.ToString());
                    if (Deliveryinfo.OrderRemarks != null)
                    {
                        htmltext = htmltext.Replace("$CustomerServiceRemarkData$", Deliveryinfo.OrderRemarks.ToString());
                    }
                    else 
                    {
                        htmltext = htmltext.Replace("$CustomerServiceRemarkData$", "");
                    }
                    #endregion
                    htmls.Append(htmltext);

                    //创建明细表页面table
                    //订单明细列表
                    List<XMDeliveryDetails> XMDeliveryProductDetails = new List<XMDeliveryDetails>();
                    XMDeliveryProductDetails = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Deliveryinfo.Id);//订单信息
                    if (XMDeliveryProductDetails.Count > 0)
                    {
                        tb.Append("<div class='tb'>"); //
                        tb.Append("<table style='font-family: verdana,arial,sans-serif;font-size:13px;color:#333333;border: 1px solid #000;width: 240mm;'>"); //
                        int nRowCount = XMDeliveryProductDetails.Count;//所有条数 
                        int colNum = 6;//列数
                        //增加列头
                        tb.Append("<tr><td style='border: 1px solid #000;width: 15%;font-weight: 700;'>商品编码</td><td style='border: 1px solid #000;width: 25%;font-weight: 700;'>商品名称</td><td style='border: 1px solid #000;width: 15%;font-weight: 700;'>规格尺寸</td><td style='border: 1px solid #000;width: 5%;font-weight: 700;'>数量</td><td style='border: 1px solid #000;width: 13%;font-weight: 700;'>出库出库</td><td style='border: 1px solid #000;width: 26%;font-weight: 700;'>订单号</td></tr>");
                        for (int m = 0; m < nRowCount; m++)
                        {
                            tb.Append("<tr>"); //加行数
                            for (int n = 0; n < colNum; n++)
                            {
                                switch (n)
                                {
                                    case 0:
                                        tb.Append("<td style='border: 1px solid #000;width: 15%;'>");
                                        tb.Append(XMDeliveryProductDetails[m].PlatformMerchantCode);
                                        break;
                                    case 1:
                                        tb.Append("<td style='border: 1px solid #000;width: 25%;'>");
                                        tb.Append(XMDeliveryProductDetails[m].PrdouctName);
                                        break;
                                    case 2:
                                        tb.Append("<td style='border: 1px solid #000;width: 15%;'>");
                                        tb.Append(XMDeliveryProductDetails[m].Specifications);
                                        break;
                                    case 3:
                                        tb.Append("<td style='border: 1px solid #000;width: 5%;'>");
                                        tb.Append(XMDeliveryProductDetails[m].ProductNum);
                                        break;
                                    case 4:
                                        tb.Append("<td style='border: 1px solid #000;width: 13%;'>");
                                        tb.Append(XMDeliveryProductDetails[m].WarehouseName);
                                        break;
                                    case 5:
                                        tb.Append("<td style='border: 1px solid #000;width: 26%;'>");
                                        tb.Append(XMDeliveryProductDetails[m].OrderNo);
                                        break;
                                }
                                tb.Append("</td>");
                            }
                            tb.Append("</tr>");
                        }
                        tb.Append("</table>"); //
                        tb.Append("</div>"); //
                    }
                    int zindex = htmls.Length - 20;
                    htmls.Insert(zindex, tb);
                    div_dy.InnerHtml = htmls.ToString();
                }
            }
            #endregion
        }

        /// <summary>
        /// 打印发货单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_qrdy_Click(object sender, EventArgs e)
        {
            #region 加载发货单打印模板
            string ydgs = "DeliveryBill";
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

            //订单列表
            //发货单列表
            List<HozestERP.BusinessLogic.ManageProject.XMDelivery> Deliveryinfolist = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
            //List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();

            if (ids != "")
            {
                int[] sts = new int[ids.Split(',').Length];
                for (int i = 0; i < ids.Split(',').Length; i++)
                {
                    string Id = ids.Split(',')[i];
                    sts[i] = int.Parse(Id);
                }

                //orderInfoList = base.XMOrderInfoService.GetXMOrderInfoList(sts);//订单信息
                Deliveryinfolist = base.XMDeliveryService.GetXMDeliveryById(sts);//发货单信息
            }

            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                if (Deliveryinfolist != null && Deliveryinfolist.Count > 0)
                {
                    foreach (HozestERP.BusinessLogic.ManageProject.XMDelivery Deliveryinfo in Deliveryinfolist)
                    {
                        if (Deliveryinfo != null)
                        {
                            StringBuilder htmltext = new StringBuilder();
                            StringBuilder tb = new StringBuilder();
                            htmltext.Append(divHtml);

                            #region 不存在收货地址修改(淘宝订单原始订单收货地址)
                            var customerInfo = HozestERPContext.Current.User.SCustomerInfo;
                            htmltext = htmltext.Replace("$riqidata$", DateTime.Now.ToUniversalTime().ToString());
                            htmltext = htmltext.Replace("$NickName$", Deliveryinfo.NickName);
                            htmltext = htmltext.Replace("$Ordercode$", Deliveryinfo.OrderCode.ToString());
                            htmltext = htmltext.Replace("$Mobile$", Deliveryinfo.Mobile.ToString());
                            if (Deliveryinfo.Tel != null)
                            {
                                htmltext = htmltext.Replace("$Tel$", Deliveryinfo.Tel.ToString());
                            }
                            else
                            {
                                htmltext = htmltext.Replace("$Tel$", "");
                            }
                            htmltext = htmltext.Replace("$WantID$", Deliveryinfo.WantID.ToString());
                            htmltext = htmltext.Replace("$FullName$", Deliveryinfo.FullName.ToString());
                            htmltext = htmltext.Replace("$DeliveryAddress$", Deliveryinfo.DeliveryAddress.ToString());
                            if (Deliveryinfo.OrderRemarks != null)
                            {
                                htmltext = htmltext.Replace("$CustomerServiceRemarkData$", Deliveryinfo.OrderRemarks.ToString());
                            }
                            else
                            {
                                htmltext = htmltext.Replace("$CustomerServiceRemarkData$", "");
                            }
                            #endregion
                            //if (orderinfo.Remark != null)
                            //{
                            //    htmltext = htmltext.Replace("$Remark$", orderinfo.Remark.ToString());
                            //}
                            //else 
                            //{
                            //    htmltext = htmltext.Replace("$Remark$", "");
                            //}
                            //htmltext = htmltext.Replace("$CustomerServiceRemark$", orderinfo.CustomerServiceRemark.ToString());

                            //创建明细表页面table
                            //订单明细列表
                            List<XMDeliveryDetails> XMDeliveryProductDetails = new List<XMDeliveryDetails>();
                            XMDeliveryProductDetails = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(Deliveryinfo.Id);//订单信息
                            if (XMDeliveryProductDetails.Count > 0)
                            {
                                tb.Append("<div class='tb'>"); //
                                tb.Append("<table style='font-family: verdana,arial,sans-serif;font-size:13px;color:#333333;border: 1px solid #000;width: 230mm;'>"); //
                                int nRowCount = XMDeliveryProductDetails.Count;//所有条数
                                int row = (int)Math.Ceiling(nRowCount / 6.0);//6.0表示每行有多少条数据
                                int colNum = 6;//列数
                                               //增加列头
                                tb.Append("<tr><td style='border: 1px solid #000;width: 15%;font-weight: 700;'>商品编码</td><td style='border: 1px solid #000;width: 25%;font-weight: 700;'>商品名称</td><td style='border: 1px solid #000;width: 15%;font-weight: 700;'>规格尺寸</td><td style='border: 1px solid #000;width: 5%;font-weight: 700;'>数量</td><td style='border: 1px solid #000;width: 13%;font-weight: 700;'>出库出库</td><td style='border: 1px solid #000;width: 26%;font-weight: 700;'>订单号</td></tr>");
                                for (int m = 0; m < row; m++)
                                {
                                    tb.Append("<tr>"); //加行数
                                    for (int n = 0; n < colNum; n++)
                                    {
                                        switch (n)
                                        {
                                            case 0:
                                                tb.Append("<td style='border: 1px solid #000;width: 15%;'>");
                                                tb.Append(XMDeliveryProductDetails[m].PlatformMerchantCode);
                                                break;
                                            case 1:
                                                tb.Append("<td style='border: 1px solid #000;width: 25%;'>");
                                                tb.Append(XMDeliveryProductDetails[m].PrdouctName);
                                                break;
                                            case 2:
                                                tb.Append("<td style='border: 1px solid #000;width: 20%;'>");
                                                tb.Append(XMDeliveryProductDetails[m].Specifications);
                                                break;
                                            case 3:
                                                tb.Append("<td style='border: 1px solid #000;width: 5%;'>");
                                                tb.Append(XMDeliveryProductDetails[m].ProductNum);
                                                break;
                                            case 4:
                                                tb.Append("<td style='border: 1px solid #000;width: 13%;'>");
                                                tb.Append(XMDeliveryProductDetails[m].WarehouseName);
                                                break;
                                            case 5:
                                                tb.Append("<td style='border: 1px solid #000;width: 26%;'>");
                                                tb.Append(XMDeliveryProductDetails[m].OrderNo);
                                                break;
                                        }
                                        tb.Append("</td>");
                                    }
                                    tb.Append("</tr>");
                                }
                                tb.Append("</table>"); //
                                tb.Append("</div>"); //
                            }

                            htmls.Append(htmltext);
                            int zindex = htmls.Length - 20;
                            htmls.Insert(zindex, tb);

                            Deliveryinfo.IsPrint = true;
                            base.XMDeliveryService.UpdateXMDelivery(Deliveryinfo);
                        }
                    }
                }
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "dyscript_yd", "window.print();", true);

                scope.Complete();
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