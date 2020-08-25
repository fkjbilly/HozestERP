
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2014-12-24 16:05:07
** 修改人:
** 修改日期:
** 描 述: 接口实现类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;
using JdSdk;
using JdSdk.Request;
using JdSdk.Response;
using Newtonsoft.Json;
using JdSdk.Domains;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.CustomerManagement;
using System.Configuration;
using HozestERP.BusinessLogic.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class KFChatLogService: IKFChatLogService
    {
        #region Fields
    	/// <summary>
    	/// Object context
    	/// </summary>
    	private readonly HozestERPObjectContext _context;
    	/// <summary>
    	/// Cache manager
    	/// </summary>
    	private readonly ICacheManager _cacheManager;

        private object obj = new object();
        #endregion
    	
        #region Ctor
    	
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
    	public KFChatLogService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IKFChatLogService成员
        /// <summary>
        /// Insert into KFChatLog
        /// </summary>
        /// <param name="kfchatlog">KFChatLog</param>
    	public void InsertKFChatLog(KFChatLog kfchatlog)
    	{	
            if (kfchatlog == null)
                return;
    
            if (!this._context.IsAttached(kfchatlog))
    			
                this._context.KFChatLogs.AddObject(kfchatlog);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into KFChatLog
        /// </summary>
        /// <param name="kfchatlog">KFChatLog</param>
        public void UpdateKFChatLog(KFChatLog kfchatlog)
        {
            if (kfchatlog == null)
                return;
    
            if (this._context.IsAttached(kfchatlog))
                this._context.KFChatLogs.Attach(kfchatlog);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to KFChatLog list
        /// </summary>
        public List<KFChatLog> GetKFChatLogList()
        {		
            var query = from p in this._context.KFChatLogs
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to KFChatLog list
        /// </summary>
        public List<KFChatLog> GetKFChatLogList(string customer,string waiter)
        {
            var query = from p in this._context.KFChatLogs
                        where (customer == "" || p.Customer.Contains(customer))
                        && (waiter == "" || p.Waiter.Contains(waiter))
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to KFChatLog Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>KFChatLog Page List</returns>
        public PagedList<KFChatLog> SearchKFChatLog(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.KFChatLogs
                        orderby p.Id
                        select p;
            return new PagedList<KFChatLog>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a KFChatLog by Id
        /// </summary>
        /// <param name="id">KFChatLog Id</param>
        /// <returns>KFChatLog</returns>   
        public KFChatLog GetKFChatLogById(long id)
        {
            var query = from p in this._context.KFChatLogs
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete KFChatLog by Id
        /// </summary>
        /// <param name="Id">KFChatLog Id</param>
        public void DeleteKFChatLog(long id)
        {
            var kfchatlog = this.GetKFChatLogById(id);
            if (kfchatlog == null)
                return;
    
            if (!this._context.IsAttached(kfchatlog))
                this._context.KFChatLogs.Attach(kfchatlog);
    
            this._context.DeleteObject(kfchatlog);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete KFChatLog by Id
        /// </summary>
        /// <param name="Ids">KFChatLog Id</param>
        public void BatchDeleteKFChatLog(List<long> ids)
        {
    	   var query = from q in _context.KFChatLogs
                    where ids.Contains(q.Id)
                    select q;
            var kfchatlogs = query.ToList();
            foreach (var item in kfchatlogs)
            {
                if (!_context.IsAttached(item))
                    _context.KFChatLogs.Attach(item);  
    
                _context.KFChatLogs.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion

        #region 聊天记录
        /// <summary>
        /// 360buy.order.get 根据订单id获取单个订单(京东)
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
       

        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d">double 型数字</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddMilliseconds(d);
            return time;
        }

        public void doJob()
        {
            var FinDate = DateTime.Now;
            DateTime startdate = FinDate.AddDays(-1);
            DateTime enddate = FinDate;
            lock (obj)
            {
                //var task = new TaskFactory();
                //task.StartNew(() =>
                //{
                    JDdoJob(startdate, enddate);
                //});
                //task.StartNew(() =>
                //{
                //    TBdoJob(startdate, enddate);
                //});
            }
        } 

        /// <summary>
        /// 定时抓取京东聊天记录
        /// </summary>
        public void JDdoJob(DateTime startdate, DateTime enddate)
        {
            //获取要查询聊天记录的店铺
            var XMOrderInfoAppList = getAppList("京东");
            //获取聊天记录并插入数据库
            getSessionList(startdate, enddate, XMOrderInfoAppList);


        }
        public void getSessionList(DateTime start_date, DateTime end_date, List<XMOrderInfoApp> XMOrderInfoAppList)
        {
            try
            {
                var XMConsultationList = new List<XMConsultation>();
                foreach (var elem in XMOrderInfoAppList)
                {
                    JdSdk.DefaultJdClient client = new DefaultJdClient("http://gw.api.360buy.com/routerjson",elem.AppKey, elem.AppSecret);
                    JdSdk.Request.JingdongImPopSessionlistGetRequest request = new JdSdk.Request.JingdongImPopSessionlistGetRequest();
                    request.StartTime = start_date;
                    request.EndTime = end_date;
                    request.AddedParam.Add("page", 1);
                    request.AddedParam.Add("pageSize", 50);
                    JdSdk.Response.JingdongImPopSessionlistGetResponse response = client.Execute(request, elem.AccessToken);

                    var body = JsonConvert.DeserializeObject<JingdongImPopSessionlistGetResponse>(response.Body);//首次默认返回50条

                    var totalrow = body.jingdong_im_pop_sessionlist_get_responce.ChatSessionPage.totalRecord;//总行数

                    if(totalrow > 50)
                    {
                        JdSdk.Request.JingdongImPopSessionlistGetRequest request1 = new JdSdk.Request.JingdongImPopSessionlistGetRequest();
                        request1.StartTime = start_date;
                        request1.EndTime = end_date;
                        request1.AddedParam.Add("page", 2);
                        request1.AddedParam.Add("pageSize", 50);
                        JdSdk.Response.JingdongImPopSessionlistGetResponse response1 = client.Execute(request, elem.AccessToken);

                        var body1 = JsonConvert.DeserializeObject<JingdongImPopSessionlistGetResponse>(response1.Body);//首次默认返回50条

                    }

                    foreach (var ele in body.jingdong_im_pop_sessionlist_get_responce.ChatSessionPage.chatSessionList)
                    {
                        var XMConsultationEntity = new XMConsultation();
                        XMConsultationEntity.CustomerID = ele.customer;
                        XMConsultationEntity.NickId = elem.NickId;
                        XMConsultationEntity.PlatformTypeId = elem.PlatformTypeId;
                        XMConsultationEntity.ReceptionDate = Convert.ToDateTime(ele.replyTime);
                        XMConsultationEntity.ManufacturersCode = ele.skuId.ToString();//暂时存储为商品ID
                        XMConsultationList.Add(XMConsultationEntity);
                    }//获取客户旺旺信息
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 根据商品id获取厂家编码
        /// </summary>
        /// <param name="skuid">商品ID</param>
        /// <returns></returns>
        protected IQueryable<dynamic> GetManufacturersCode(List<string> skuidList)
        {
            var ManufacturersCodelsit = from p in this._context.XMProductDetails
                             join q in this._context.XMProducts on p.ProductId equals q.Id
                             where skuidList.Contains(p.PlatformMerchantCode)
                             select new {
                                 p.PlatformMerchantCode,
                                 q.ManufacturersCode
                             };
             return ManufacturersCodelsit;
        }
        /// <summary>
        /// 定时抓取淘宝聊天记录
        /// </summary>
        public void TBdoJob(DateTime startdate, DateTime enddate)
        {
            //获取要查询聊天记录的店铺
            var XMOrderInfoAppList =  getAppList("天猫");
            //获取聊天记录并插入数据库
            getTBChatPeersList(startdate, enddate, XMOrderInfoAppList);
        }


        public void  getTBChatPeersList(DateTime start_date, DateTime end_date, List<XMOrderInfoApp> XMOrderInfoAppList)
        {
            try
            {
                foreach (var elem in XMOrderInfoAppList)//循环所有的账号
                {
                    Top.Api.ITopClient client = new Top.Api.DefaultTopClient("http://gw.api.tbsandbox.com/router/rest", elem.AppKey, elem.AppSecret);
                    //Top.Api.Request.WangwangEserviceChatpeersGetRequest request = new Top.Api.Request.WangwangEserviceGroupmemberGetRequest();
                    //Top.Api.Response.WangwangEserviceChatpeersGetResponse response = client.Execute(request, sessionKey);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private object applistobj = new object();
        /// <summary>
        /// 对应平台下的所有账号信息
        /// </summary>
        /// <param name="codename">平台名称</param>
        /// <returns></returns>
        protected List<XMOrderInfoApp> getAppList(string codename)
        {
            lock (applistobj)
            {
                var tbshoplsit = from p in this._context.XMOrderInfoApps
                                 join q in this._context.CodeLists on p.PlatformTypeId equals q.CodeID
                                 where q.CodeName == codename
                                 select p;
                return tbshoplsit.Distinct().ToList();
            }
        }
 
        /// <summary>
        /// 查询最后聊天时间
        /// </summary> 
        public DateTime GetFinTime()
        {
            var query = (from p in this._context.KFChatLogs
                         select p.Time).Max();
            return query.Value;
        }

        //public void getSessionList(DateTime start_date, DateTime end_date, XMOrderInfoApp orderInfoApp)
        //{
        //    try
        //    {
        //        string AppKey = orderInfoApp.AppKey;//"C3BDD1943916998096181AFFE213DFB5";
        //        string AppSecret = orderInfoApp.AppSecret;//"7ac900a3cbba49568a884098fb4a8a7f";
        //        string CallbackUrl = orderInfoApp.CallbackUrl;// "http://www.hozest.com";
        //        string AccessToken = orderInfoApp.AccessToken;// "8367ab51-9345-4a43-8893-9ded184ced2d";

        //        IJdClient client = new DefaultJdClient("http://gw.api.360buy.com/routerjson", AppKey, AppSecret, AccessToken);

        //        //获取客服组信息
        //        JingdongImPopGroupinfoGetRequest requestgroupinfo = new JingdongImPopGroupinfoGetRequest();
        //        JingdongImPopGroupinfoGetResponse responsegroupinfo = client.Execute(requestgroupinfo);
        //        JingdongImPopGroupinfoGetResponse psgroupinfo = JsonConvert.DeserializeObject<JingdongImPopGroupinfoGetResponse>(responsegroupinfo.Body);

        //        foreach (var pg in psgroupinfo.PG.PopGroup.WaiterList)
        //        {
        //            string waiter = pg.WaiterId;//客服账号
        //            JingdongImPopSessionlistGetRequest request = new JingdongImPopSessionlistGetRequest();
        //            request.Waiter = waiter;//"jd-喜临门城市爱情6号"
        //            request.StartTime = start_date;//start_date;//
        //            request.EndTime = end_date;//end_date;//
        //            JingdongImPopSessionlistGetResponse response = client.Execute(request);

        //            JingdongImPopSessionlistGetResponse ps = JsonConvert.DeserializeObject<JingdongImPopSessionlistGetResponse>(response.Body);
        //            //去除重复客服信息
        //            var DistinctList = ps.CS.ChatSession.ChatSessionList.GroupBy(x => x.Customer).Select(x => x.First()).ToList();

        //            foreach (ChatSessionList cs in DistinctList)
        //            {
        //                DateTime sdt = ConvertIntDateTime(cs.BeginTime);
        //                DateTime edt = ConvertIntDateTime(cs.EndTime);
        //                JingdongImPopChatlogGetRequest requestcl = new JingdongImPopChatlogGetRequest();
        //                requestcl.Waiter = waiter;
        //                requestcl.StartTime = start_date;
        //                requestcl.EndTime = end_date;
        //                requestcl.Customer = cs.Customer;
        //                JingdongImPopChatlogGetResponse responsecl = client.Execute(requestcl);

        //                JingdongImPopChatlogGetResponse cl = JsonConvert.DeserializeObject<JingdongImPopChatlogGetResponse>(responsecl.Body);

        //                foreach (ChatLogList chatl in cl.CL.ChatLog.ChatLogList)
        //                {
        //                    KFChatLog kfcl = new KFChatLog();
        //                    kfcl.Customer = chatl.Customer;
        //                    kfcl.Waiter = chatl.Waiter;
        //                    kfcl.Content = chatl.Content;
        //                    kfcl.SId = chatl.Sid;
        //                    kfcl.SkuId = chatl.SkuId;
        //                    kfcl.Time = ConvertIntDateTime(chatl.Time);
        //                    kfcl.Channel = int.Parse(chatl.Channel.ToString());
        //                    kfcl.WaiterSend = chatl.WaiterSend;
        //                    kfcl.Remark = "";
        //                    kfcl.IsDelete = false;

        //                    this.InsertKFChatLog(kfcl);
        //                }

        //                if (responsecl.IsError)
        //                {
        //                    throw new Exception("错误代码：" + responsecl.ErrCode + "错误信息：" + responsecl.ErrMsg);
        //                }
        //            }

        //            if (response.IsError)
        //            {
        //                throw new Exception("错误代码：" + response.ErrCode + "错误信息：" + response.ErrMsg);
        //            }
        //        }

        //        if (!responsegroupinfo.IsError)
        //        {
        //            throw new Exception("错误代码：" + responsegroupinfo.ErrCode + "错误信息：" + responsegroupinfo.ErrMsg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        #endregion
    }
}
