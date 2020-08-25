using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.order{
	
	
	public class OrderServiceHelper {
		
		
		
		public class getChannelOrderList_args {
			
			///<summary>
			/// 订单渠道
			/// @sampleValue channel_id 10
			///</summary>
			
			private string channel_id_;
			
			///<summary>
			/// 订单号列表
			/// @sampleValue order_sn [15013055143441,15013055143442]
			///</summary>
			
			private List<long?> order_sn_;
			
			public string GetChannel_id(){
				return this.channel_id_;
			}
			
			public void SetChannel_id(string value){
				this.channel_id_ = value;
			}
			public List<long?> GetOrder_sn(){
				return this.order_sn_;
			}
			
			public void SetOrder_sn(List<long?> value){
				this.order_sn_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInfo_args {
			
			///<summary>
			/// 唯品会订单sn
			/// @sampleValue order_sn order_sn=12345678
			///</summary>
			
			private long? order_sn_;
			
			///<summary>
			/// 唯品会登陆账号
			/// @sampleValue login_account username=ma@163.com
			///</summary>
			
			private string login_account_;
			
			public long? GetOrder_sn(){
				return this.order_sn_;
			}
			
			public void SetOrder_sn(long? value){
				this.order_sn_ = value;
			}
			public string GetLogin_account(){
				return this.login_account_;
			}
			
			public void SetLogin_account(string value){
				this.login_account_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTrackInfo_args {
			
			///<summary>
			/// 订单SN与运单SN必填一个
			/// @sampleValue order_sn order_sn=[12345678]
			///</summary>
			
			private List<long?> order_sn_;
			
			///<summary>
			/// 订单SN与运单SN必填一个
			/// @sampleValue transport_sn transport_sn=12345678
			///</summary>
			
			private string transport_sn_;
			
			public List<long?> GetOrder_sn(){
				return this.order_sn_;
			}
			
			public void SetOrder_sn(List<long?> value){
				this.order_sn_ = value;
			}
			public string GetTransport_sn(){
				return this.transport_sn_;
			}
			
			public void SetTransport_sn(string value){
				this.transport_sn_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_args {
			
			///<summary>
			/// 查询开始时间戳
			/// @sampleValue start_date 2013-06-01 10:00:00
			///</summary>
			
			private string start_date_;
			
			///<summary>
			/// 查询结束时间戳
			/// @sampleValue end_date 2013-06-01 10:00:00
			///</summary>
			
			private string end_date_;
			
			///<summary>
			/// 时间区间类型
			/// @sampleValue date_type OrderDateType.ORDER_DATETIME
			///</summary>
			
			private vipapis.order.OrderDateType? date_type_;
			
			///<summary>
			/// 订单状态
			/// @sampleValue order_status OrderStatus.STATUS_0
			///</summary>
			
			private vipapis.common.OrderStatus? order_status_;
			
			///<summary>
			/// 页数
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue limit limit=100
			///</summary>
			
			private int? limit_;
			
			public string GetStart_date(){
				return this.start_date_;
			}
			
			public void SetStart_date(string value){
				this.start_date_ = value;
			}
			public string GetEnd_date(){
				return this.end_date_;
			}
			
			public void SetEnd_date(string value){
				this.end_date_ = value;
			}
			public vipapis.order.OrderDateType? GetDate_type(){
				return this.date_type_;
			}
			
			public void SetDate_type(vipapis.order.OrderDateType? value){
				this.date_type_ = value;
			}
			public vipapis.common.OrderStatus? GetOrder_status(){
				return this.order_status_;
			}
			
			public void SetOrder_status(vipapis.common.OrderStatus? value){
				this.order_status_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getChannelOrderList_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.order.ChannelOrderResult> success_;
			
			public List<vipapis.order.ChannelOrderResult> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.order.ChannelOrderResult> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.OrderInfo success_;
			
			public vipapis.order.OrderInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.OrderInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderTrackInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.order.OrderTrack success_;
			
			public vipapis.order.OrderTrack GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.order.OrderTrack value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.order.Order> success_;
			
			public List<vipapis.order.Order> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.order.Order> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getChannelOrderList_argsHelper : BeanSerializer<getChannelOrderList_args>
		{
			
			public static getChannelOrderList_argsHelper OBJ = new getChannelOrderList_argsHelper();
			
			public static getChannelOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getChannelOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetChannel_id(value);
				}
				
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem1;
							elem1 = iprot.ReadI64(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrder_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getChannelOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetChannel_id() != null) {
					
					oprot.WriteFieldBegin("channel_id");
					oprot.WriteString(structs.GetChannel_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("channel_id can not be null!");
				}
				
				
				if(structs.GetOrder_sn() != null) {
					
					oprot.WriteFieldBegin("order_sn");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetOrder_sn()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_sn can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getChannelOrderList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInfo_argsHelper : BeanSerializer<getOrderInfo_args>
		{
			
			public static getOrderInfo_argsHelper OBJ = new getOrderInfo_argsHelper();
			
			public static getOrderInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetOrder_sn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetLogin_account(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOrder_sn() != null) {
					
					oprot.WriteFieldBegin("order_sn");
					oprot.WriteI64((long)structs.GetOrder_sn()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_sn can not be null!");
				}
				
				
				if(structs.GetLogin_account() != null) {
					
					oprot.WriteFieldBegin("login_account");
					oprot.WriteString(structs.GetLogin_account());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("login_account can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTrackInfo_argsHelper : BeanSerializer<getOrderTrackInfo_args>
		{
			
			public static getOrderTrackInfo_argsHelper OBJ = new getOrderTrackInfo_argsHelper();
			
			public static getOrderTrackInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTrackInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem0;
							elem0 = iprot.ReadI64(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrder_sn(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetTransport_sn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTrackInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOrder_sn() != null) {
					
					oprot.WriteFieldBegin("order_sn");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetOrder_sn()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_sn can not be null!");
				}
				
				
				if(structs.GetTransport_sn() != null) {
					
					oprot.WriteFieldBegin("transport_sn");
					oprot.WriteString(structs.GetTransport_sn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("transport_sn can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTrackInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrders_argsHelper : BeanSerializer<getOrders_args>
		{
			
			public static getOrders_argsHelper OBJ = new getOrders_argsHelper();
			
			public static getOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStart_date(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEnd_date(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.order.OrderDateType? value;
					
					value = vipapis.order.OrderDateTypeUtil.FindByName(iprot.ReadString());
					
					structs.SetDate_type(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.common.OrderStatus? value;
					
					value = vipapis.common.OrderStatusUtil.FindByName(iprot.ReadString());
					
					structs.SetOrder_status(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetStart_date() != null) {
					
					oprot.WriteFieldBegin("start_date");
					oprot.WriteString(structs.GetStart_date());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("start_date can not be null!");
				}
				
				
				if(structs.GetEnd_date() != null) {
					
					oprot.WriteFieldBegin("end_date");
					oprot.WriteString(structs.GetEnd_date());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("end_date can not be null!");
				}
				
				
				if(structs.GetDate_type() != null) {
					
					oprot.WriteFieldBegin("date_type");
					oprot.WriteString(structs.GetDate_type().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("date_type can not be null!");
				}
				
				
				if(structs.GetOrder_status() != null) {
					
					oprot.WriteFieldBegin("order_status");
					oprot.WriteString(structs.GetOrder_status().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : BeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getChannelOrderList_resultHelper : BeanSerializer<getChannelOrderList_result>
		{
			
			public static getChannelOrderList_resultHelper OBJ = new getChannelOrderList_resultHelper();
			
			public static getChannelOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getChannelOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.order.ChannelOrderResult> value;
					
					value = new List<vipapis.order.ChannelOrderResult>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.ChannelOrderResult elem0;
							
							elem0 = new vipapis.order.ChannelOrderResult();
							vipapis.order.ChannelOrderResultHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getChannelOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.ChannelOrderResult _item0 in structs.GetSuccess()){
						
						
						vipapis.order.ChannelOrderResultHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getChannelOrderList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderInfo_resultHelper : BeanSerializer<getOrderInfo_result>
		{
			
			public static getOrderInfo_resultHelper OBJ = new getOrderInfo_resultHelper();
			
			public static getOrderInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.OrderInfo value;
					
					value = new vipapis.order.OrderInfo();
					vipapis.order.OrderInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.OrderInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderTrackInfo_resultHelper : BeanSerializer<getOrderTrackInfo_result>
		{
			
			public static getOrderTrackInfo_resultHelper OBJ = new getOrderTrackInfo_resultHelper();
			
			public static getOrderTrackInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderTrackInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.order.OrderTrack value;
					
					value = new vipapis.order.OrderTrack();
					vipapis.order.OrderTrackHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderTrackInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.order.OrderTrackHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderTrackInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrders_resultHelper : BeanSerializer<getOrders_result>
		{
			
			public static getOrders_resultHelper OBJ = new getOrders_resultHelper();
			
			public static getOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.order.Order> value;
					
					value = new List<vipapis.order.Order>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.order.Order elem0;
							
							elem0 = new vipapis.order.Order();
							vipapis.order.OrderHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.order.Order _item0 in structs.GetSuccess()){
						
						
						vipapis.order.OrderHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : BeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OrderServiceClient : OspRestStub , OrderService  {
			
			
			public OrderServiceClient():base("vipapis.order.OrderService","1.0.0") {
				
				
			}
			
			
			
			public List<vipapis.order.ChannelOrderResult> getChannelOrderList(string channel_id_,List<long?> order_sn_) {
				
				send_getChannelOrderList(channel_id_,order_sn_);
				return recv_getChannelOrderList(); 
				
			}
			
			
			private void send_getChannelOrderList(string channel_id_,List<long?> order_sn_){
				
				InitInvocation("getChannelOrderList");
				
				getChannelOrderList_args args = new getChannelOrderList_args();
				args.SetChannel_id(channel_id_);
				args.SetOrder_sn(order_sn_);
				
				SendBase(args, getChannelOrderList_argsHelper.getInstance());
			}
			
			
			private List<vipapis.order.ChannelOrderResult> recv_getChannelOrderList(){
				
				getChannelOrderList_result result = new getChannelOrderList_result();
				ReceiveBase(result, getChannelOrderList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.OrderInfo getOrderInfo(long order_sn_,string login_account_) {
				
				send_getOrderInfo(order_sn_,login_account_);
				return recv_getOrderInfo(); 
				
			}
			
			
			private void send_getOrderInfo(long order_sn_,string login_account_){
				
				InitInvocation("getOrderInfo");
				
				getOrderInfo_args args = new getOrderInfo_args();
				args.SetOrder_sn(order_sn_);
				args.SetLogin_account(login_account_);
				
				SendBase(args, getOrderInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.order.OrderInfo recv_getOrderInfo(){
				
				getOrderInfo_result result = new getOrderInfo_result();
				ReceiveBase(result, getOrderInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.order.OrderTrack getOrderTrackInfo(List<long?> order_sn_,string transport_sn_) {
				
				send_getOrderTrackInfo(order_sn_,transport_sn_);
				return recv_getOrderTrackInfo(); 
				
			}
			
			
			private void send_getOrderTrackInfo(List<long?> order_sn_,string transport_sn_){
				
				InitInvocation("getOrderTrackInfo");
				
				getOrderTrackInfo_args args = new getOrderTrackInfo_args();
				args.SetOrder_sn(order_sn_);
				args.SetTransport_sn(transport_sn_);
				
				SendBase(args, getOrderTrackInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.order.OrderTrack recv_getOrderTrackInfo(){
				
				getOrderTrackInfo_result result = new getOrderTrackInfo_result();
				ReceiveBase(result, getOrderTrackInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.order.Order> getOrders(string start_date_,string end_date_,vipapis.order.OrderDateType? date_type_,vipapis.common.OrderStatus? order_status_,int? page_,int? limit_) {
				
				send_getOrders(start_date_,end_date_,date_type_,order_status_,page_,limit_);
				return recv_getOrders(); 
				
			}
			
			
			private void send_getOrders(string start_date_,string end_date_,vipapis.order.OrderDateType? date_type_,vipapis.common.OrderStatus? order_status_,int? page_,int? limit_){
				
				InitInvocation("getOrders");
				
				getOrders_args args = new getOrders_args();
				args.SetStart_date(start_date_);
				args.SetEnd_date(end_date_);
				args.SetDate_type(date_type_);
				args.SetOrder_status(order_status_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getOrders_argsHelper.getInstance());
			}
			
			
			private List<vipapis.order.Order> recv_getOrders(){
				
				getOrders_result result = new getOrders_result();
				ReceiveBase(result, getOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}