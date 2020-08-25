using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.order{
	
	
	public class HtSaleTransferLadingBillIServiceHelper {
		
		
		
		public class getLadingBillInfo_args {
			
			///<summary>
			/// 用户id
			///</summary>
			
			private string userId_;
			
			///<summary>
			/// 提单号
			///</summary>
			
			private string ladingBillNumber_;
			
			public string GetUserId(){
				return this.userId_;
			}
			
			public void SetUserId(string value){
				this.userId_ = value;
			}
			public string GetLadingBillNumber(){
				return this.ladingBillNumber_;
			}
			
			public void SetLadingBillNumber(string value){
				this.ladingBillNumber_ = value;
			}
			
		}
		
		
		
		
		public class getSaleTransferLadingBillIBatchNoOrderList_args {
			
			///<summary>
			/// 仓库
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 提单号
			///</summary>
			
			private string ladingBillNumber_;
			
			///<summary>
			/// 起运国
			///</summary>
			
			private string shipmentCountry_;
			
			///<summary>
			/// 抵达国
			///</summary>
			
			private string arriveCountry_;
			
			///<summary>
			/// 通关模式[BC、BBC...]
			///</summary>
			
			private string customsClearanceMode_;
			
			///<summary>
			/// 重量(默认单位Kg)
			///</summary>
			
			private double? totalWeight_;
			
			///<summary>
			/// 子提单号列表
			///</summary>
			
			private List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> subBillNumerList_;
			
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public string GetLadingBillNumber(){
				return this.ladingBillNumber_;
			}
			
			public void SetLadingBillNumber(string value){
				this.ladingBillNumber_ = value;
			}
			public string GetShipmentCountry(){
				return this.shipmentCountry_;
			}
			
			public void SetShipmentCountry(string value){
				this.shipmentCountry_ = value;
			}
			public string GetArriveCountry(){
				return this.arriveCountry_;
			}
			
			public void SetArriveCountry(string value){
				this.arriveCountry_ = value;
			}
			public string GetCustomsClearanceMode(){
				return this.customsClearanceMode_;
			}
			
			public void SetCustomsClearanceMode(string value){
				this.customsClearanceMode_ = value;
			}
			public double? GetTotalWeight(){
				return this.totalWeight_;
			}
			
			public void SetTotalWeight(double? value){
				this.totalWeight_ = value;
			}
			public List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> GetSubBillNumerList(){
				return this.subBillNumerList_;
			}
			
			public void SetSubBillNumerList(List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> value){
				this.subBillNumerList_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class matchLaddingNum_args {
			
			///<summary>
			/// 待匹配订单号
			///</summary>
			
			private List<string> orders_;
			
			public List<string> GetOrders(){
				return this.orders_;
			}
			
			public void SetOrders(List<string> value){
				this.orders_ = value;
			}
			
		}
		
		
		
		
		public class getLadingBillInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult success_;
			
			public com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleTransferLadingBillIBatchNoOrderList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult success_;
			
			public com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult value){
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
		
		
		
		
		public class matchLaddingNum_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getLadingBillInfo_argsHelper : TBeanSerializer<getLadingBillInfo_args>
		{
			
			public static getLadingBillInfo_argsHelper OBJ = new getLadingBillInfo_argsHelper();
			
			public static getLadingBillInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLadingBillInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetUserId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetLadingBillNumber(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLadingBillInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUserId() != null) {
					
					oprot.WriteFieldBegin("userId");
					oprot.WriteString(structs.GetUserId());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("userId can not be null!");
				}
				
				
				if(structs.GetLadingBillNumber() != null) {
					
					oprot.WriteFieldBegin("ladingBillNumber");
					oprot.WriteString(structs.GetLadingBillNumber());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("ladingBillNumber can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLadingBillInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleTransferLadingBillIBatchNoOrderList_argsHelper : TBeanSerializer<getSaleTransferLadingBillIBatchNoOrderList_args>
		{
			
			public static getSaleTransferLadingBillIBatchNoOrderList_argsHelper OBJ = new getSaleTransferLadingBillIBatchNoOrderList_argsHelper();
			
			public static getSaleTransferLadingBillIBatchNoOrderList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleTransferLadingBillIBatchNoOrderList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetLadingBillNumber(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShipmentCountry(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetArriveCountry(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCustomsClearanceMode(value);
				}
				
				
				
				
				
				if(true){
					
					double? value;
					value = iprot.ReadDouble();
					
					structs.SetTotalWeight(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> value;
					
					value = new List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.haitao.orderservice.service.SubLadingBillNumberVo elem0;
							
							elem0 = new com.vip.haitao.orderservice.service.SubLadingBillNumberVo();
							com.vip.haitao.orderservice.service.SubLadingBillNumberVoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSubBillNumerList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleTransferLadingBillIBatchNoOrderList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLadingBillNumber() != null) {
					
					oprot.WriteFieldBegin("ladingBillNumber");
					oprot.WriteString(structs.GetLadingBillNumber());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetShipmentCountry() != null) {
					
					oprot.WriteFieldBegin("shipmentCountry");
					oprot.WriteString(structs.GetShipmentCountry());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetArriveCountry() != null) {
					
					oprot.WriteFieldBegin("arriveCountry");
					oprot.WriteString(structs.GetArriveCountry());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCustomsClearanceMode() != null) {
					
					oprot.WriteFieldBegin("customsClearanceMode");
					oprot.WriteString(structs.GetCustomsClearanceMode());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetTotalWeight() != null) {
					
					oprot.WriteFieldBegin("totalWeight");
					oprot.WriteDouble((double)structs.GetTotalWeight());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSubBillNumerList() != null) {
					
					oprot.WriteFieldBegin("subBillNumerList");
					
					oprot.WriteListBegin();
					foreach(com.vip.haitao.orderservice.service.SubLadingBillNumberVo _item0 in structs.GetSubBillNumerList()){
						
						
						com.vip.haitao.orderservice.service.SubLadingBillNumberVoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleTransferLadingBillIBatchNoOrderList_args bean){
				
				
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
		
		
		
		
		public class matchLaddingNum_argsHelper : TBeanSerializer<matchLaddingNum_args>
		{
			
			public static matchLaddingNum_argsHelper OBJ = new matchLaddingNum_argsHelper();
			
			public static matchLaddingNum_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(matchLaddingNum_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
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
			
			
			public void Write(matchLaddingNum_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOrders() != null) {
					
					oprot.WriteFieldBegin("orders");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrders()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(matchLaddingNum_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getLadingBillInfo_resultHelper : TBeanSerializer<getLadingBillInfo_result>
		{
			
			public static getLadingBillInfo_resultHelper OBJ = new getLadingBillInfo_resultHelper();
			
			public static getLadingBillInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLadingBillInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult value;
					
					value = new com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult();
					com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLadingBillInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLadingBillInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleTransferLadingBillIBatchNoOrderList_resultHelper : TBeanSerializer<getSaleTransferLadingBillIBatchNoOrderList_result>
		{
			
			public static getSaleTransferLadingBillIBatchNoOrderList_resultHelper OBJ = new getSaleTransferLadingBillIBatchNoOrderList_resultHelper();
			
			public static getSaleTransferLadingBillIBatchNoOrderList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleTransferLadingBillIBatchNoOrderList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult value;
					
					value = new com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult();
					com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleTransferLadingBillIBatchNoOrderList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleTransferLadingBillIBatchNoOrderList_result bean){
				
				
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
		
		
		
		
		public class matchLaddingNum_resultHelper : TBeanSerializer<matchLaddingNum_result>
		{
			
			public static matchLaddingNum_resultHelper OBJ = new matchLaddingNum_resultHelper();
			
			public static matchLaddingNum_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(matchLaddingNum_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
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
			
			
			public void Write(matchLaddingNum_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(matchLaddingNum_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class HtSaleTransferLadingBillIServiceClient : OspRestStub , HtSaleTransferLadingBillIService  {
			
			
			public HtSaleTransferLadingBillIServiceClient():base("vipapis.order.HtSaleTransferLadingBillIService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult getLadingBillInfo(string userId_,string ladingBillNumber_) {
				
				send_getLadingBillInfo(userId_,ladingBillNumber_);
				return recv_getLadingBillInfo(); 
				
			}
			
			
			private void send_getLadingBillInfo(string userId_,string ladingBillNumber_){
				
				InitInvocation("getLadingBillInfo");
				
				getLadingBillInfo_args args = new getLadingBillInfo_args();
				args.SetUserId(userId_);
				args.SetLadingBillNumber(ladingBillNumber_);
				
				SendBase(args, getLadingBillInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtLadingBillNumberInfoResult recv_getLadingBillInfo(){
				
				getLadingBillInfo_result result = new getLadingBillInfo_result();
				ReceiveBase(result, getLadingBillInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult getSaleTransferLadingBillIBatchNoOrderList(string warehouse_,string ladingBillNumber_,string shipmentCountry_,string arriveCountry_,string customsClearanceMode_,double? totalWeight_,List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> subBillNumerList_) {
				
				send_getSaleTransferLadingBillIBatchNoOrderList(warehouse_,ladingBillNumber_,shipmentCountry_,arriveCountry_,customsClearanceMode_,totalWeight_,subBillNumerList_);
				return recv_getSaleTransferLadingBillIBatchNoOrderList(); 
				
			}
			
			
			private void send_getSaleTransferLadingBillIBatchNoOrderList(string warehouse_,string ladingBillNumber_,string shipmentCountry_,string arriveCountry_,string customsClearanceMode_,double? totalWeight_,List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> subBillNumerList_){
				
				InitInvocation("getSaleTransferLadingBillIBatchNoOrderList");
				
				getSaleTransferLadingBillIBatchNoOrderList_args args = new getSaleTransferLadingBillIBatchNoOrderList_args();
				args.SetWarehouse(warehouse_);
				args.SetLadingBillNumber(ladingBillNumber_);
				args.SetShipmentCountry(shipmentCountry_);
				args.SetArriveCountry(arriveCountry_);
				args.SetCustomsClearanceMode(customsClearanceMode_);
				args.SetTotalWeight(totalWeight_);
				args.SetSubBillNumerList(subBillNumerList_);
				
				SendBase(args, getSaleTransferLadingBillIBatchNoOrderList_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.orderservice.service.HtSaleTransferLadingBillResult recv_getSaleTransferLadingBillIBatchNoOrderList(){
				
				getSaleTransferLadingBillIBatchNoOrderList_result result = new getSaleTransferLadingBillIBatchNoOrderList_result();
				ReceiveBase(result, getSaleTransferLadingBillIBatchNoOrderList_resultHelper.getInstance());
				
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
			
			
			public List<string> matchLaddingNum(List<string> orders_) {
				
				send_matchLaddingNum(orders_);
				return recv_matchLaddingNum(); 
				
			}
			
			
			private void send_matchLaddingNum(List<string> orders_){
				
				InitInvocation("matchLaddingNum");
				
				matchLaddingNum_args args = new matchLaddingNum_args();
				args.SetOrders(orders_);
				
				SendBase(args, matchLaddingNum_argsHelper.getInstance());
			}
			
			
			private List<string> recv_matchLaddingNum(){
				
				matchLaddingNum_result result = new matchLaddingNum_result();
				ReceiveBase(result, matchLaddingNum_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}