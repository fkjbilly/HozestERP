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
		
		
		
		
		
		public class getChannelOrderList_argsHelper : TBeanSerializer<getChannelOrderList_args>
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
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
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
		
		
		
		
		public class getChannelOrderList_resultHelper : TBeanSerializer<getChannelOrderList_result>
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
							
							vipapis.order.ChannelOrderResult elem1;
							
							elem1 = new vipapis.order.ChannelOrderResult();
							vipapis.order.ChannelOrderResultHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
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