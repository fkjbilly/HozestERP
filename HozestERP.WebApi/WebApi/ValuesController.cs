using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Text;
using HozestERP.WebApi.App_Start;
using HozestERP.WebApi.Message;
using System.Transactions;
using System.Net;
using System.IO;
using HozestERP.WebApi.Entities;
using HozestERP.WebApi.Manager;
using Newtonsoft.Json;

namespace HozestERP.WebApi.WebApi
{
    
    //[HozestERP.WebApi.App_Start.Throttle]
    [ThrottleAttribute]
    public class ValuesController : ApiController
    {
        private OrderInsertManager _orderInsertManager;

        private SearchInventoryManager _searchInventoryManager;

        private SearchProductManager _searchProductManager;

        private SearchOrderStatusManager _searchOrderStatusManager;

        public UtilManager _utilManager;
     
        public ValuesController()
        {
            if (_orderInsertManager == null)
                _orderInsertManager = new OrderInsertManager();
            if (_searchInventoryManager == null)
                _searchInventoryManager = new SearchInventoryManager();
            if (_searchProductManager == null)
                _searchProductManager = new SearchProductManager();
            if (_searchOrderStatusManager == null)
                _searchOrderStatusManager = new SearchOrderStatusManager();
            if (_utilManager == null)
                _utilManager = new UtilManager();
        }
        [HttpGet]
        public string GetMessage()
        {
            return "OK";
        }
        /// <summary>
        /// 导入订单数据
        /// </summary>
        /// <param name="orderInfoListClient"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ImportOrder([FromBody] OrderInfoListClient orderInfoListClient)
        {
            InsertLog.Insert("订单导入数据获得的订单数据", orderInfoListClient.xmOrderInfoClientList.Count.ToString());
            _utilManager.Write(JsonConvert.SerializeObject(orderInfoListClient));
            var apiMessage = new ApiMassage();
            apiMessage.Header = new Header();
            var str = string.Empty;
            if (orderInfoListClient.xmOrderInfoClientList.Count == 0)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "请求的参数为空";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            var nostatus = new List<string>() { "待付款", "待使用","已完成", "已发货" };
            var clientOrderList = orderInfoListClient.xmOrderInfoClientList.Where(m=> !nostatus.Contains(m.OrderStatus)).ToList();
            if (clientOrderList.Count > 500 || clientOrderList.Count == 0)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "传入的订单条数不能超过500!或者少于0";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            _orderInsertManager.InsertXMOrderInfo(clientOrderList,apiMessage.Header);
            if (string.IsNullOrWhiteSpace(apiMessage.Header.Message))
            {
                apiMessage.Header.IsSuccess = true;
                apiMessage.Header.Message = "接口接收订单数量:" + clientOrderList.Count.ToString() + "处理成功！";
            }
            else
                apiMessage.Header.IsSuccess = false;
            //apiMessage.Header.Message += errorStr;
            str = JsonConvert.SerializeObject(apiMessage);
            InsertLog.Insert("订单导入数据返回值", str);
            return _utilManager.HttpMessage(str);
            //return JsonConvert.SerializeObject(apiMessage);
        }

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="requestInventoryApi">请求库存信息的参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetInventoryInfo([FromBody] RequestInventoryApi requestInventoryApi)
        {
            var apiMessage = new ErpInventoryInfo();
            apiMessage.Header = new TotalHeader();
            var str = string.Empty;
            if (requestInventoryApi == null)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "请求的参数为空";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            if (_searchInventoryManager.ValidationSecretKey(requestInventoryApi))
            {
                if (requestInventoryApi.PlatformMerchantCode != null)//如果传入的商品编码有值，则回传这些商品编码对应的库存信息
                {
                    apiMessage.Header.IsSuccess = true;
                    var XMInventoryList =_searchInventoryManager.GetXLMInventory(requestInventoryApi.PlatformMerchantCode, apiMessage.Header);
                    if (apiMessage.Header.IsSuccess)
                        apiMessage.InventoryList = XMInventoryList;
                }
                else
                {
                    if ((requestInventoryApi.PageNum > 0) && (requestInventoryApi.PageSize > 0))//判断页码和每页条数是否有
                    {
                        apiMessage.Header.IsSuccess = true;
                        var totalcount = 0;
                        apiMessage.InventoryList = _searchInventoryManager.GetXLMInventory(requestInventoryApi.PageSize, requestInventoryApi.PageNum,ref totalcount);
                        apiMessage.Header.TotalCount = totalcount;
                    }
                    else
                    {
                        apiMessage.Header.IsSuccess = false;
                        apiMessage.Header.Message = "页码和每页请求条数必填且大于0";
                        str = JsonConvert.SerializeObject(apiMessage);
                        return _utilManager.HttpMessage(str);
                    }
                }
            }else
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "秘钥出错";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            str = JsonConvert.SerializeObject(apiMessage);
            return _utilManager.HttpMessage(str);
        }


        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="requestProductApi">请求产品信息的参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetProductInfo([FromBody] RequestProductApi requestProductApi)
        //public string GetProductInfo([FromBody] string message)
        {
            //var requestProductApi = JsonConvert.DeserializeObject<RequestProductApi>(message);
            var apiMessage = new ErpProduct();
            apiMessage.Header = new TotalHeader();
            var str = string.Empty;
            if (requestProductApi == null)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "请求的参数为空";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            if (_searchProductManager.ValidationSecretKey(requestProductApi))
            {
                if (requestProductApi.PlatformMerchantCode != null)//如果传入的商品编码有值，则回传这些商品编码对应的库存信息
                {
                    apiMessage.Header.IsSuccess = true;
                    var ProductList = _searchProductManager.GetXMProduct(requestProductApi.PlatformMerchantCode, apiMessage.Header);
                    if (apiMessage.Header.IsSuccess)
                        apiMessage.ProductList = ProductList;
                }
                else
                {
                    if ((requestProductApi.PageNum > 0) && (requestProductApi.PageSize > 0))//判断页码和每页条数是否有
                    {
                        apiMessage.Header.IsSuccess = true;
                        var toatlcount = 0;
                        //apiMessage.Header.TotalCount = _searchProductManager.GetProductTotalCount();
                        apiMessage.ProductList = _searchProductManager.GetXMProduct(requestProductApi.PageSize, requestProductApi.PageNum, ref toatlcount);
                        apiMessage.Header.TotalCount = toatlcount;
                    }
                    else
                    {
                        apiMessage.Header.IsSuccess = false;
                        apiMessage.Header.Message = "页码和每页请求条数必填且大于0";
                        str = JsonConvert.SerializeObject(apiMessage);
                        return _utilManager.HttpMessage(str);
                    }
                }
            }
            str = JsonConvert.SerializeObject(apiMessage);
            return _utilManager.HttpMessage(str);
        }

        /// <summary>
        /// 获取订单状态信息
        /// </summary>
        /// <param name="requestOrderStatusApi">获取订单状态的请求参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetOrderStatus([FromBody] RequestOrderStatusApi requestOrderStatusApi)
        {
            var apiMessage = new ErpOrderStatus();
            apiMessage.Header = new Header();
            var str = string.Empty;
            if (requestOrderStatusApi == null)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "请求的参数为空";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            if (requestOrderStatusApi.OrderStatusList.Count > 500)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "请求的订单号超过了500条";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            else
            {
                apiMessage.Header.IsSuccess = true;
                 var OrderStatusList =_searchOrderStatusManager.GetXMOrderStatus(requestOrderStatusApi.OrderStatusList, apiMessage.Header);
                if (apiMessage.Header.IsSuccess)
                    apiMessage.OrderStatusList = OrderStatusList;
            }
            str = JsonConvert.SerializeObject(apiMessage);
            return _utilManager.HttpMessage(str);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="requestOrderStatusApi">获取订单状态的请求参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CancelOrder([FromBody] RequestCancelOrder requestCancelOrder)
        {
            var apiMessage = new ApiMassage();
            apiMessage.Header = new Header();
            var str = string.Empty;
            if (requestCancelOrder == null)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "请求的参数为空";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            if (requestCancelOrder.OrderCodeList.Count > 500)
            {
                apiMessage.Header.IsSuccess = false;
                apiMessage.Header.Message = "请求取消的订单号超过了500条";
                str = JsonConvert.SerializeObject(apiMessage);
                return _utilManager.HttpMessage(str);
            }
            else
            {
                apiMessage.Header.Message = _searchOrderStatusManager.CancelOrder(requestCancelOrder.OrderCodeList);
                apiMessage.Header.IsSuccess = string.IsNullOrEmpty(apiMessage.Header.Message) ? true : false;
            }
            str = JsonConvert.SerializeObject(apiMessage);
            return _utilManager.HttpMessage(str);
        }

        [HttpGet]
        public string Get()
        {
            string url = "http://localhost:16566/WebApi/Values/ImportOrder";
            string json = "";
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.Headers.Add("userName", "wudaoshangcheng");
            request.Headers.Add("passWord", "wd123456");
            request.Headers.Add("accessToken", "Hhum0fYEXMUKSb2QWUi0");
            request.KeepAlive = true;

            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json;charset=utf-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
            var orderInfoList = new OrderInfoListClient();
            orderInfoList.xmOrderInfoClientList = new List<XMOrderInfoClient>();

            //for (var i = 0; i < 1; i++)
            //{
            //    var entity = new XMOrderInfoClient();
            //    entity.XM_OrderInfoProductDetails = new List<XMOrderInfoProductDetailsClient>();
            //    entity.PlatformTypeId = 508;
            //    entity.OrderCode = "SH201904124521771121111" + i;
            //    entity.NickID = 77;
            //    entity.OrderStatus = "已付款";
            //    entity.RealName = "王瑜";
            //    entity.PaymentNo = "41697455477425";
            //    entity.OrderSeqNo = "74485411212121";
            //    entity.Source = "02";
            //    entity.IdentityCard = "666554558855";
            //    entity.CreateDate = DateTime.Now;
            //    entity.OrderInfoCreateDate = Convert.ToDateTime("2019-04-12T18:24:48+08:00");
            //    entity.PayDate = Convert.ToDateTime("2019-04-12T18:24:48+08:00");
            //    entity.WantID = "王瑜";
            //    entity.ProductPrice = (decimal)379.9;
            //    entity.DistributePrice = (decimal)20.00;
            //    entity.ProductPromotion = 0;
            //    entity.OrderPromotion = 0;
            //    entity.OrderPrice = (decimal)399.9;
            //    entity.PayPrice = (decimal)379.9;
            //    entity.ReceivablePrice = (decimal)379.9;
            //    entity.DistributeMethod = "仓库配送";
            //    entity.FullName = "wangyu";
            //    entity.Mobile = "13567424734";
            //    entity.Province = "浙江省";
            //    entity.City = "嘉兴市";
            //    entity.County = "海盐县";
            //    entity.DeliveryAddress = "西塘桥街道外塘路666号万通安达";
            //    entity.SourceType = "接口导入";
            //    entity.FinancialAudit = false;
            //    entity.IsScalping = false;
            //    entity.IsAudit = false;
            //    entity.IsEnable = false;//是否删除
            //    entity.IsCashBack = false;//是否返现
            //    entity.IsSentGifts = false;//是否已发赠品 
            //    entity.IsEvaluate = false;//是否赔付
            //    entity.IsOurOrder = true;
            //    entity.CreateID = 7;
            //    entity.UpdateID = 7;
            //    entity.CreateDate = DateTime.Now;
            //    entity.UpdateDate = DateTime.Now;

            //    //for (var j = 0; j < 1; j++)
            //    //{
            //    var entityDetails = new XMOrderInfoProductDetailsClient();
            //    entityDetails.PlatformMerchantCode = "1002010001";
            //    entityDetails.ProductName = "资生堂洗颜专科洗面奶120g*2 ";
            //    //entityDetails.TManufacturersCode = dic[j];
            //    entityDetails.SalesPrice = decimal.Parse("379.9");
            //    entityDetails.ProductNum = 2;
            //    entity.XM_OrderInfoProductDetails.Add(entityDetails);
            //    //}

            //    orderInfoList.xmOrderInfoClientList.Add(entity);
            //}
            //var clientOrderList = orderInfoList.xmOrderInfoClientList;
            //var jsonParas = JsonConvert.SerializeObject(orderInfoList);
            var jsonParas = _utilManager.ReadTxtContent();
            byte[] buffer = encoding.GetBytes(jsonParas);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }

        [HttpGet]
        public string GetIntenctroy()
        {
            var entity = new RequestInventoryApi();
            string url = "http://www.hozest.com.cn:30003/WebApi/Values/GetInventoryInfo";
            //string url = "http://localhost:16566/WebApi/Values/GetInventoryInfo";
            string json = "";
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.Headers.Add("userName", "wudaoshangcheng");
            request.Headers.Add("passWord", "wd123456");
            request.Headers.Add("accessToken", "Hhum0fYEXMUKSb2QWUi0");
            //request.KeepAlive = true;
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json;charset=utf-8";
            //entity.PlatformMerchantCode = new List<string>() { "4897086340269", "4903367304032", "1006010001" };
            entity.PageNum = 1;
            entity.PageSize = 200;
            var signstr = string.Format("{0}Hozest88582", JsonConvert.SerializeObject(entity));

            var rsignstrMd5 = _utilManager.MD5Encrypt(signstr);
            entity.SecretKey = rsignstrMd5;

            byte[] buffer = encoding.GetBytes(JsonConvert.SerializeObject(entity));
            request.ContentLength = buffer.Length;

            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }

        [HttpGet]
        public string GetProduct()
        {
            var entity = new RequestProductApi();
            //string url = "http://localhost:16566/WebApi/Values/GetProductInfo";
            string url = "http://www.hozest.com.cn:30003/WebApi/Values/GetProductInfo1";
            string json = "";
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("userName", "wudaoshangcheng");
            request.Headers.Add("passWord", "wd123456");
            request.Headers.Add("accessToken", "Hhum0fYEXMUKSb2QWUi0");
            //request.KeepAlive = true;
            //request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json;charset=utf-8";
            //entity.PlatformMerchantCode = new List<string>() { "9003020001", "9005010001", "7003010001"};
            entity.PageNum = 1;
            entity.PageSize = 200;
            var signstr = string.Format("{0}Hozest88582", JsonConvert.SerializeObject(entity));

            var rsignstrMd5 = _utilManager.MD5Encrypt(signstr);
            entity.SecretKey = rsignstrMd5;

            byte[] buffer = encoding.GetBytes(JsonConvert.SerializeObject(entity));
            request.ContentLength = buffer.Length;

            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }

        [HttpGet]
        public string GetOrderStatus()
        {
            var entity = new RequestOrderStatusApi();
            //string url = "http://localhost:16566/WebApi/Values/GetOrderStatus";
            string url = "http://www.hozest.com.cn:30003/WebApi/Values/GetOrderStatus";
            string json = "";
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.Headers.Add("userName", "wudaoshangcheng");
            request.Headers.Add("passWord", "wd123456");
            request.Headers.Add("accessToken", "Hhum0fYEXMUKSb2QWUi0");
            //request.KeepAlive = true;
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json;charset=utf-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
            // entity.OrderCode
            entity.OrderStatusList = new List<RequestOrderStatusList>();
            entity.OrderStatusList.Add(new RequestOrderStatusList()
            {
                PlatformMerchantCode = "9005010001",
                OrderCode = "SH20190201145740844163"
            });
            entity.OrderStatusList.Add(new RequestOrderStatusList()
            {
                PlatformMerchantCode = "6971793120074",
                OrderCode = "SH20190213003636121967"
            });
            byte[] buffer = encoding.GetBytes(JsonConvert.SerializeObject(entity));
            request.ContentLength = buffer.Length;

            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }

    }
}