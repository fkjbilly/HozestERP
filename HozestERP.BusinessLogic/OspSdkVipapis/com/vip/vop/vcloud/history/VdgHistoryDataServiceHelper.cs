using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vcloud.history{
	
	
	public class VdgHistoryDataServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class pullHistoryOrders_args {
			
			///<summary>
			/// 渠道id
			///</summary>
			
			private long? channelId_;
			
			///<summary>
			/// 合作伙伴id
			///</summary>
			
			private long? partnerId_;
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string orderSn_;
			
			///<summary>
			/// 开始时间
			///</summary>
			
			private System.DateTime? beginTime_;
			
			///<summary>
			/// 最大的entityId(一定要填对)
			///</summary>
			
			private long? maxId_;
			
			public long? GetChannelId(){
				return this.channelId_;
			}
			
			public void SetChannelId(long? value){
				this.channelId_ = value;
			}
			public long? GetPartnerId(){
				return this.partnerId_;
			}
			
			public void SetPartnerId(long? value){
				this.partnerId_ = value;
			}
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			public System.DateTime? GetBeginTime(){
				return this.beginTime_;
			}
			
			public void SetBeginTime(System.DateTime? value){
				this.beginTime_ = value;
			}
			public long? GetMaxId(){
				return this.maxId_;
			}
			
			public void SetMaxId(long? value){
				this.maxId_ = value;
			}
			
		}
		
		
		
		
		public class synHistoricProductAndPrice_args {
			
			///<summary>
			/// 文件存储bucket
			///</summary>
			
			private string bucket_;
			
			///<summary>
			/// 文件存储key
			///</summary>
			
			private string key_;
			
			public string GetBucket(){
				return this.bucket_;
			}
			
			public void SetBucket(string value){
				this.bucket_ = value;
			}
			public string GetKey(){
				return this.key_;
			}
			
			public void SetKey(string value){
				this.key_ = value;
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
		
		
		
		
		public class pullHistoryOrders_result {
			
			
		}
		
		
		
		
		public class synHistoricProductAndPrice_result {
			
			
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
		
		
		
		
		public class pullHistoryOrders_argsHelper : TBeanSerializer<pullHistoryOrders_args>
		{
			
			public static pullHistoryOrders_argsHelper OBJ = new pullHistoryOrders_argsHelper();
			
			public static pullHistoryOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pullHistoryOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetChannelId(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetPartnerId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				
				if(true){
					
					System.DateTime? value;
					value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
					
					structs.SetBeginTime(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetMaxId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pullHistoryOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetChannelId() != null) {
					
					oprot.WriteFieldBegin("channelId");
					oprot.WriteI64((long)structs.GetChannelId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("channelId can not be null!");
				}
				
				
				if(structs.GetPartnerId() != null) {
					
					oprot.WriteFieldBegin("partnerId");
					oprot.WriteI64((long)structs.GetPartnerId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("partnerId can not be null!");
				}
				
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBeginTime() != null) {
					
					oprot.WriteFieldBegin("beginTime");
					oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetBeginTime())); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetMaxId() != null) {
					
					oprot.WriteFieldBegin("maxId");
					oprot.WriteI64((long)structs.GetMaxId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("maxId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pullHistoryOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class synHistoricProductAndPrice_argsHelper : TBeanSerializer<synHistoricProductAndPrice_args>
		{
			
			public static synHistoricProductAndPrice_argsHelper OBJ = new synHistoricProductAndPrice_argsHelper();
			
			public static synHistoricProductAndPrice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(synHistoricProductAndPrice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBucket(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetKey(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(synHistoricProductAndPrice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBucket() != null) {
					
					oprot.WriteFieldBegin("bucket");
					oprot.WriteString(structs.GetBucket());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("bucket can not be null!");
				}
				
				
				if(structs.GetKey() != null) {
					
					oprot.WriteFieldBegin("key");
					oprot.WriteString(structs.GetKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("key can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(synHistoricProductAndPrice_args bean){
				
				
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
		
		
		
		
		public class pullHistoryOrders_resultHelper : TBeanSerializer<pullHistoryOrders_result>
		{
			
			public static pullHistoryOrders_resultHelper OBJ = new pullHistoryOrders_resultHelper();
			
			public static pullHistoryOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pullHistoryOrders_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pullHistoryOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pullHistoryOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class synHistoricProductAndPrice_resultHelper : TBeanSerializer<synHistoricProductAndPrice_result>
		{
			
			public static synHistoricProductAndPrice_resultHelper OBJ = new synHistoricProductAndPrice_resultHelper();
			
			public static synHistoricProductAndPrice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(synHistoricProductAndPrice_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(synHistoricProductAndPrice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(synHistoricProductAndPrice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VdgHistoryDataServiceClient : OspRestStub , VdgHistoryDataService  {
			
			
			public VdgHistoryDataServiceClient():base("com.vip.vop.vcloud.history.VdgHistoryDataService","1.0.0") {
				
				
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
			
			
			public void pullHistoryOrders(long channelId_,long partnerId_,string orderSn_,System.DateTime? beginTime_,long maxId_) {
				
				send_pullHistoryOrders(channelId_,partnerId_,orderSn_,beginTime_,maxId_);
				recv_pullHistoryOrders();
				
			}
			
			
			private void send_pullHistoryOrders(long channelId_,long partnerId_,string orderSn_,System.DateTime? beginTime_,long maxId_){
				
				InitInvocation("pullHistoryOrders");
				
				pullHistoryOrders_args args = new pullHistoryOrders_args();
				args.SetChannelId(channelId_);
				args.SetPartnerId(partnerId_);
				args.SetOrderSn(orderSn_);
				args.SetBeginTime(beginTime_);
				args.SetMaxId(maxId_);
				
				SendBase(args, pullHistoryOrders_argsHelper.getInstance());
			}
			
			
			private void recv_pullHistoryOrders(){
				
				pullHistoryOrders_result result = new pullHistoryOrders_result();
				ReceiveBase(result, pullHistoryOrders_resultHelper.getInstance());
				
				
			}
			
			
			public void synHistoricProductAndPrice(string bucket_,string key_) {
				
				send_synHistoricProductAndPrice(bucket_,key_);
				recv_synHistoricProductAndPrice();
				
			}
			
			
			private void send_synHistoricProductAndPrice(string bucket_,string key_){
				
				InitInvocation("synHistoricProductAndPrice");
				
				synHistoricProductAndPrice_args args = new synHistoricProductAndPrice_args();
				args.SetBucket(bucket_);
				args.SetKey(key_);
				
				SendBase(args, synHistoricProductAndPrice_argsHelper.getInstance());
			}
			
			
			private void recv_synHistoricProductAndPrice(){
				
				synHistoricProductAndPrice_result result = new synHistoricProductAndPrice_result();
				ReceiveBase(result, synHistoricProductAndPrice_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}