using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public class JingdongImPopSessionlistGetResponse
    {
        //[JsonProperty("jingdong_im_pop_sessionlist_get_responce")]
        //[XmlElement("jingdong_im_pop_sessionlist_get_responce")]
        public Jingdong_im_pop_sessionlist_get_responce jingdong_im_pop_sessionlist_get_responce { get; set; }
    }
   
    public class Jingdong_im_pop_sessionlist_get_responce
    {
        public string code { get; set; }
        public ChatSessionPage ChatSessionPage { get; set; }
    }
    public class ChatSessionPage
    {
        public ChatSession[] chatSessionList { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int totalRecord { get; set; }
    }

    public class ChatSession
    {
        /// <summary>
        /// 咨询的顾客
        /// </summary>
        public string customer { get; set; }
        /// <summary>
        /// 客服账号  
        /// </summary>
        public string waiter { get; set; }
        /// <summary>
        /// 咨询开始时间 
        /// </summary>
        public long beginTime { get; set; }
        /// <summary>
        /// 客服回复时间，如果未回复此时间为空  
        /// </summary>
        public long replyTime { get; set; }
        /// <summary>
        /// 会话结束时间，会话结束即会话断开连接时间。
        /// </summary>
        public long endTime { get; set; }
        /// <summary>
        /// 会话类型 1：在线会话 2：留言 
        /// </summary>
        public int sessionType { get; set; }
        /// <summary>
        /// 是否转接 true: 转接 false：未转接  
        /// </summary>
        public string transfer { get; set; }
        /// <summary>
        /// 会话ID。保留，暂不支持。  
        /// </summary>
        public string sid { get; set; }
        /// <summary>
        /// 顾客咨询的商品编号，为0表示无商品咨询。
        /// </summary>
        public string skuId { get; set; }
    }
}
