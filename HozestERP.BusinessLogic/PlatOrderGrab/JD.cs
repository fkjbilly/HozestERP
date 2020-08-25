using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.ManageProject;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ErrorLog;
using Jd.Api.Request;
using Jd.Api;
using Jd.Api.Domain;
using Jd.Api.Response;

namespace HozestERP.BusinessLogic.PlatOrderGrab
{
    public partial class JD : IJD
    {
        #region 京东同步订单
        /// <summary>
        ///  京东订单检索（360buy.order.search）
        ///  定时同步时使用
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="orderState"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public string GetOrderList(string startDate, string endDate, string orderState, string page, string pageSize, out Int32 totalCount, bool recursive)
        {
            try
            {
                int count = 0;

                string AppKey = "0901C6C9E495BDB7FEEAE8EEA47D13F2";//xMorderInfoApp.AppKey;
                string AppSecret = "1916857c7087437095775f29763f527b";//xMorderInfoApp.AppSecret;
                string CallbackUrl = "http://www.hozest.com";//  xMorderInfoApp.CallbackUrl;
                string AccessToken = "032ecc44-7ac6-46c3-a4b7-7e844f7ea1b4";// xMorderInfoApp.AccessToken;
                Jd.Api.IJdClient Client = new DefaultJdClient("http://gw.api.360buy.com/routerjson", AppKey, AppSecret, AccessToken);
                OrderSearchRequest request = new OrderSearchRequest();
                //
                request.startDate = startDate.ToString();//开始时间
                request.endDate = endDate.ToString();//结束时间
                request.orderState = orderState;
                request.page = page.ToString();
                request.pageSize = pageSize.ToString();
                request.optionalFields = "order_id,vender_id,pay_type,order_total_price,order_payment,order_seller_price,freight_price,seller_discount,order_state,delivery_type,invoice_info,order_remark,order_start_time,order_end_time,modified,payment_confirm_time,pin,consignee_info,coupon_detail_list,item_info_list,logistics_id,waybill,vender_remark";
                OrderSearchResponse response = Client.Execute(request);

                string s = "\"consignee_info\":\"\",";
                string ns = "\"consignee_info\":null,";
                string str = response.Body.Replace(s, ns);
                OrderSearchResponse m = JsonConvert.DeserializeObject<OrderSearchResponse>(str);

                if (m.orderSearch == null)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        Client = new DefaultJdClient("http://gw.api.360buy.com/routerjson", AppKey, AppSecret, AccessToken);

                        OrderSearchRequest requestfor = new OrderSearchRequest();
                        requestfor.startDate = startDate;//付款开始时间
                        requestfor.endDate = endDate;//付款结束时间
                        requestfor.orderState = orderState;
                        requestfor.page = page;
                        requestfor.pageSize = pageSize;
                        requestfor.optionalFields = "order_id,vender_id,pay_type,order_total_price,order_payment,order_seller_price,freight_price,seller_discount,order_state,delivery_type,invoice_info,order_remark,order_start_time,order_end_time,modified,payment_confirm_time,pin,consignee_info,coupon_detail_list,item_info_list,logistics_id,waybill,vender_remark";
                        OrderSearchResponse responsefor = Client.Execute(requestfor);
                        string sfor = "\"consignee_info\":\"\",";
                        string nsfor = "\"consignee_info\":null,";
                        string strfor = responsefor.Body.Replace(sfor, nsfor);
                        OrderSearchResponse mfor = JsonConvert.DeserializeObject<OrderSearchResponse>(strfor);

                        if (mfor.orderSearch != null)
                        {
                            if (!responsefor.IsError)
                            {
                                count = mfor.orderSearch.Count();
                                totalCount = count;
                                return "";
;
                            }
                            else
                            {
                                throw new Exception("错误代码：" + responsefor.ErrCode + "错误信息：" + responsefor.ErrMsg);
                            }
                        }
                    }
                }
                else
                {
                    if (!response.IsError)
                    {
                        //count = m.Child.OrderSearch.OrderTotal;
                        totalCount = count;
                        //return m.Child.OrderSearch.OrderInfoList;
                        return "";
                    }
                    else
                    {
                        throw new Exception("错误代码：" + response.ErrCode + "错误信息：" + response.ErrMsg);
                    }
                }
                totalCount = count;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message); 
                //BusinessLogic.ErrorLog.RecordErrorLogs.WriteError(ex.Message.ToString(), CRMContext.Current.User.CustomerID.ToString());
                totalCount = 0;
                IoC.Resolve<IRecordErrorLogs>().WriteErrorLog("负责人:" + HozestERPContext.Current.User.CustomerID.ToString() + ";   方法名:GetOrderList;  异常提示：" + ex.Message.ToString() + ";   InnerException:" + ex.InnerException);
            }

            return null;
        }
        #endregion
    }
}
