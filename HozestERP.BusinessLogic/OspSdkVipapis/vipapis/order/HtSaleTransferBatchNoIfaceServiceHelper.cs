using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.order{
	
	
	public class HtSaleTransferBatchNoIfaceServiceHelper {
		
		
		
		public class getSaleTransferBatchNoOrderList_args {
			
			///<summary>
			/// 仓库
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 国际运输发货批次[批次号唯一]
			///</summary>
			
			private string batchNo_;
			
			///<summary>
			/// 国际运输发货批次[批次号唯一]
			///</summary>
			
			private int? deliveryNum_;
			
			///<summary>
			/// 关口
			///</summary>
			
			private string customsCode_;
			
			///<summary>
			/// 国内贷代
			///</summary>
			
			private string chinaFreightForwarding_;
			
			///<summary>
			/// 国际货代
			///</summary>
			
			private string globalFreightForwarding_;
			
			///<summary>
			/// 通关模式[BC、BBC...]
			///</summary>
			
			private string customsClearanceMode_;
			
			///<summary>
			/// VOP默认当前服务器时间
			///</summary>
			
			private string creatTime_;
			
			///<summary>
			/// 订单列表
			///</summary>
			
			private List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> orders_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetBatchNo(){
				return this.batchNo_;
			}
			
			public void SetBatchNo(string value){
				this.batchNo_ = value;
			}
			public int? GetDeliveryNum(){
				return this.deliveryNum_;
			}
			
			public void SetDeliveryNum(int? value){
				this.deliveryNum_ = value;
			}
			public string GetCustomsCode(){
				return this.customsCode_;
			}
			
			public void SetCustomsCode(string value){
				this.customsCode_ = value;
			}
			public string GetChinaFreightForwarding(){
				return this.chinaFreightForwarding_;
			}
			
			public void SetChinaFreightForwarding(string value){
				this.chinaFreightForwarding_ = value;
			}
			public string GetGlobalFreightForwarding(){
				return this.globalFreightForwarding_;
			}
			
			public void SetGlobalFreightForwarding(string value){
				this.globalFreightForwarding_ = value;
			}
			public string GetCustomsClearanceMode(){
				return this.customsClearanceMode_;
			}
			
			public void SetCustomsClearanceMode(string value){
				this.customsClearanceMode_ = value;
			}
			public string GetCreatTime(){
				return this.creatTime_;
			}
			
			public void SetCreatTime(string value){
				this.creatTime_ = value;
			}
			public List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getSaleTransferBatchNoOrderList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult success_;
			
			public com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult value){
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
		
		
		
		
		
		public class getSaleTransferBatchNoOrderList_argsHelper : TBeanSerializer<getSaleTransferBatchNoOrderList_args>
		{
			
			public static getSaleTransferBatchNoOrderList_argsHelper OBJ = new getSaleTransferBatchNoOrderList_argsHelper();
			
			public static getSaleTransferBatchNoOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleTransferBatchNoOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBatchNo(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetDeliveryNum(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsCode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetChinaFreightForwarding(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetGlobalFreightForwarding(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsClearanceMode(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCreatTime(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> value;
					
					value = new List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder elem1;
							
							elem1 = new com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder();
							com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrderHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOrders(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleTransferBatchNoOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetBatchNo() != null) {
					
					oprot.WriteFieldBegin("batchNo");
					oprot.WriteString(structs.GetBatchNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetDeliveryNum() != null) {
					
					oprot.WriteFieldBegin("deliveryNum");
					oprot.WriteI32((int)structs.GetDeliveryNum()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCustomsCode() != null) {
					
					oprot.WriteFieldBegin("customsCode");
					oprot.WriteString(structs.GetCustomsCode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetChinaFreightForwarding() != null) {
					
					oprot.WriteFieldBegin("chinaFreightForwarding");
					oprot.WriteString(structs.GetChinaFreightForwarding());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetGlobalFreightForwarding() != null) {
					
					oprot.WriteFieldBegin("globalFreightForwarding");
					oprot.WriteString(structs.GetGlobalFreightForwarding());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCustomsClearanceMode() != null) {
					
					oprot.WriteFieldBegin("customsClearanceMode");
					oprot.WriteString(structs.GetCustomsClearanceMode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCreatTime() != null) {
					
					oprot.WriteFieldBegin("creatTime");
					oprot.WriteString(structs.GetCreatTime());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder _item0 in structs.GetOrders()){
						
						
						com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrderHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleTransferBatchNoOrderList_args bean){
				
				
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
		
		
		
		
		public class getSaleTransferBatchNoOrderList_resultHelper : TBeanSerializer<getSaleTransferBatchNoOrderList_result>
		{
			
			public static getSaleTransferBatchNoOrderList_resultHelper OBJ = new getSaleTransferBatchNoOrderList_resultHelper();
			
			public static getSaleTransferBatchNoOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleTransferBatchNoOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult value;
					
					value = new com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult();
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleTransferBatchNoOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleTransferBatchNoOrderList_result bean){
				
				
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
		
		
		
		
		public class HtSaleTransferBatchNoIfaceServiceClient : OspRestStub , HtSaleTransferBatchNoIfaceService  {
			
			
			public HtSaleTransferBatchNoIfaceServiceClient():base("vipapis.order.HtSaleTransferBatchNoIfaceService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult getSaleTransferBatchNoOrderList(string warehouse_,string batchNo_,int? deliveryNum_,string customsCode_,string chinaFreightForwarding_,string globalFreightForwarding_,string customsClearanceMode_,string creatTime_,List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> orders_) {
				
				send_getSaleTransferBatchNoOrderList(warehouse_,batchNo_,deliveryNum_,customsCode_,chinaFreightForwarding_,globalFreightForwarding_,customsClearanceMode_,creatTime_,orders_);
				return recv_getSaleTransferBatchNoOrderList(); 
				
			}
			
			
			private void send_getSaleTransferBatchNoOrderList(string warehouse_,string batchNo_,int? deliveryNum_,string customsCode_,string chinaFreightForwarding_,string globalFreightForwarding_,string customsClearanceMode_,string creatTime_,List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> orders_){
				
				InitInvocation("getSaleTransferBatchNoOrderList");
				
				getSaleTransferBatchNoOrderList_args args = new getSaleTransferBatchNoOrderList_args();
				args.SetWarehouse(warehouse_);
				args.SetBatchNo(batchNo_);
				args.SetDeliveryNum(deliveryNum_);
				args.SetCustomsCode(customsCode_);
				args.SetChinaFreightForwarding(chinaFreightForwarding_);
				args.SetGlobalFreightForwarding(globalFreightForwarding_);
				args.SetCustomsClearanceMode(customsClearanceMode_);
				args.SetCreatTime(creatTime_);
				args.SetOrders(orders_);
				
				SendBase(args, getSaleTransferBatchNoOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtSaleTransferBatchNoResult recv_getSaleTransferBatchNoOrderList(){
				
				getSaleTransferBatchNoOrderList_result result = new getSaleTransferBatchNoOrderList_result();
				ReceiveBase(result, getSaleTransferBatchNoOrderList_resultHelper.getInstance());
				
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